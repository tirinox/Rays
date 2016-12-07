using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Rays._3D
{
    public delegate void ProgressUpdateDelegate(int Percent, bool Complete);
    public class Tracer3D
    {
        public double MinimumPower = 1e-5;
        public double MaxTraceSteps = 3;
        public double MinAreaTop = 1e-8;
        public static double InfinityM = 1e5;
        public static double GeometryEpsilon = 1e-6;
        public const uint MaxThrN = 255;
        public double InfinityMVisible = 200;

        public static CW cw = null;
        public ProgressUpdateDelegate ProgressUpdateD = null;

        private Scene3D[] Scene_List = null;
        private Thread[] Thr_List = null;
        private Scene3D CurrentScene = null;

        //  public Octree MyOctree = new Octree();

        public bool InWork = false;

        public static void Log(string s)
        {
            if (cw != null)
                cw("Tracer3D: " + s);
        }

        public void AbortCalculation()
        {
            InWork = false;
            if (Scene_List != null && Thr_List != null)
            {
                int CurrentThreadNum = Thr_List.Length;
                for (int i = 0; i < CurrentThreadNum; ++i)
                    if (Thr_List[i] != null)
                    {
                        Scene_List[i].ShouldTerminate = true;
                    }
            }
        }

        public void UpdateProgress(int Tag, bool Completed)
        {
            if (Tag < 0 || Tag >= MaxThrN || Scene_List == null || Scene_List[Tag] == null) return;
            Object thisLock = new Object();
            lock (thisLock)
            {
                int CurrentThreadNum = Scene_List.Length;
                int Accum = 0;

                for (int i = 0; i < CurrentThreadNum; ++i)
                    if (Scene_List[i] != null)
                        Accum += Scene_List[i].ProgressPercent;
                if (CurrentThreadNum != 0)
                    Accum /= CurrentThreadNum;

                bool AllCompleted = false;
                // завершено!
                if (Completed)
                {
                    Scene_List[Tag].Ready = true;
                    AllCompleted = true;

                    for (int i = 0; i < CurrentThreadNum; ++i)
                        if (!Scene_List[i].Ready)
                        {
                            AllCompleted = false;
                            break;
                        }
                }

                if (AllCompleted)
                {
                    InWork = false;
                    Scene_List = null;
                    Thr_List = null;
                    GC.Collect();
                }
                if (ProgressUpdateD != null)
                    ProgressUpdateD(Accum, AllCompleted);
            }
        }

        public List<Tube3D> RecursiveTracing(Scene3D MyScene, List<Tube3D> Rays, uint Call = 0, uint AddCnt = 0)
        {
            // Список лучей
            List<Tube3D> Result = new List<Tube3D>();

            if (MyScene.ShouldTerminate)
            {
                MyScene.Ready = true;
                return Result;
            }

            // Если достигли максимального шага вернем пустой список
            if (Call >= MaxTraceSteps || AddCnt >= 5)
            {
                if (AddCnt >= 5)
                    Log("Stack overflow???");
                Rays.ForEach(R => R.SetLenght(InfinityMVisible));
                return Rays;
            }

            // Для каждого луча из предложенных на данный шаг
            foreach (Tube3D Ray in Rays)
            {
                // Заморочки многопоточности
                if (MyScene.ShouldTerminate)
                {
                    MyScene.Ready = true;
                    return Result;
                }
                if (Call == 0 && AddCnt == 0)
                {
                    MyScene.RayCnt++;

                    MyScene.ProgressPercent = 100 * MyScene.RayCnt / MyScene.InitialRays.Count;

                    if (MyScene.ProgressPercent != MyScene.ProgressPercentOld)
                    {
                        UpdateProgress(MyScene.Tag, false);
                        MyScene.ProgressPercentOld = MyScene.ProgressPercent;
                    }
                }

                Log("Call = " + Call + " comment = {{" + Ray.Comment + "}}" + " Area = " + Ray.AreaTop().ToString());

                if (Call == 1)
                    Log("stop call 1");

                // Если мощность трубки исчезающе мала, проигнорируем ее, чтобы не плодить лишних
                // или если площадь нулевая
                if (Ray.Power < MinimumPower || Ray.AreaTopC < MinAreaTop)
                    continue;

                // Устремим концы лучей в бесконечность
                Ray.Rayize();

                // Данные о ближайшем пересечении
                TubeProcessingData MinTpd = null;
                double MinDistance = 1e10;
                Plane3D MinPlane = null;

                // Для всех граней в сцене
                int fc = -1;
                foreach (Figure3D Fig in MyScene.Figs)
                    foreach (Plane3D Plane in Fig.TransformedFaces)
                    {
                        fc++;
                        // Нам запрещено взаимодействовать с этим треугольником, пропускаем его
                        if (Ray.Prohibit == Plane)
                            continue;

                        // Данные о столковении
                        TubeProcessingData Tpd = Plane.ProcessTubeStageOne(Ray);

                        // Если оно имело место и оказалось ближе предыдущего, сохраним эти данные
                        if (Tpd.cs != TTCase.CaseNo && MinDistance > Tpd.Distance)
                        {
                            MinDistance = Tpd.Distance;
                            MinTpd = Tpd;
                            MinPlane = Plane;
                        }

                    }

                // Список трубок, которые отправят на следующий этап алгоритма
                List<Tube3D> ToNextCall = new List<Tube3D>();
                // Список трубок, которые получены из падающей трубки путем ее разбиения 
                List<Tube3D> SplitTubes = new List<Tube3D>();
                // Список трубок, отсчеченных
                List<Tube3D> ToThisCall = new List<Tube3D>();

                // Если нет никаких пересечений пересечение
                if (MinPlane == null)
                {
                    // Просто сохраним эту трубку с результатах
                    Ray.SetLenght(InfinityMVisible);
                    Result.Add(Ray);
                }
                else
                {
                    Log("Stage 2: " + MinTpd.cs);
                    if (MinTpd.cs == TTCase.CaseUnknown)
                    {
                        Log("Stage 2: Unknown case details: ");
                        Log("   Ic = " + MinTpd.Intersections.Count);
                        Log("   PinT = " + MinTpd.PinT);
                        Log("   TinP = " + MinTpd.TinP);
                    }

                    // Второй этап обработки трубки и треугольника дает нам уже все производные трубки
                    TubeProcessResult Tpr = MinPlane.ProcessTubeStageTwo(MinTpd, Ray, ToNextCall, SplitTubes, ToThisCall);

                    // Добавим трубки составляющее все, что осталось от исходной при отсечке
                    Result.AddRange(SplitTubes);

                    // Добавим результат рекурсивного вызова трассировки для следующего шага (это прел./отр. трубки)
                    Result.AddRange(RecursiveTracing(MyScene, ToNextCall, Call + 2));

                    // Добавим результат рекурсивного вызова трассировки для текущего шага (отсечка)
                    Result.AddRange(RecursiveTracing(MyScene, ToThisCall, Call, AddCnt + 1));
                }
            }

            return Result;
        }

        public void RayTracing(Scene3D MyScene)
        {
            try
            {
                MyScene.ProgressPercent = 0;
                MyScene.RayCnt = 0;
                InWork = true;
                MyScene.AllRays = RecursiveTracing(MyScene, MyScene.InitialRays, 0);
                InWork = false;
            }
            catch (Exception Ex)
            {
                Log("Exception! " + Ex.Message + "\n\r" + Ex.StackTrace);
            }
        }

        public void RayTracingThreaded(Scene3D MyScene, uint ThrNum = 4)
        {
            if (ThrNum < 1) ThrNum = 1;
            if (ThrNum > MaxThrN) ThrNum = MaxThrN;

            uint IR_C = (uint)MyScene.InitialRays.Count;
            if (IR_C < ThrNum)
                ThrNum = (uint)IR_C;


            MyScene.AllRays = new List<Tube3D>();
            CurrentScene = MyScene;
            InWork = true;
            Scene_List = new Scene3D[ThrNum];
            Thr_List = new Thread[ThrNum];

            double d = (double)(IR_C) / ThrNum;
            d = Math.Floor(d);
            int RangeSz = (int)d;
            for (int i = 0; i < ThrNum; ++i)
            {
                Scene_List[i] = new Scene3D();
                Scene_List[i].Figs = MyScene.Figs;
                Scene_List[i].Tag = i;
                Scene_List[i].RayCnt = 0;
                Scene_List[i].Ready = false;
                Scene_List[i].ShouldTerminate = false;
                Scene_List[i].InitialRays = MyScene.InitialRays.GetRange(i * RangeSz, i != ((int)ThrNum) - 1 ? RangeSz : (int)IR_C - i * RangeSz);

                Log("Thread " + i + " RaysNum = " + Scene_List[i].InitialRays.Count);

                Thr_List[i] = new Thread(RT_Thread);
                Thr_List[i].Start(Scene_List[i]);
            }
        }

        private void RT_Thread(object par)
        {
            Scene3D MyScene = (Scene3D)par;

            try
            {
                Log("Thread created " + MyScene.Tag);
                MyScene.AllRays = RecursiveTracing(MyScene, MyScene.InitialRays, 0);
                object O = new object();
                lock (O)
                {
                    if (CurrentScene != null)
                        CurrentScene.AllRays.AddRange(MyScene.AllRays);
                }
                Log("Thread completed " + MyScene.Tag);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Exception! " + Ex.Message + "\n\r" + Ex.StackTrace);
                Log("Exception! " + Ex.Message + "\n\r" + Ex.StackTrace);
            }
            finally
            {
                UpdateProgress(MyScene.Tag, true);
            }
        }

    }
}
