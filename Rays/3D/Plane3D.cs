using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Tao.OpenGl;
using MatrixLibrary;

namespace Rays._3D
{
    public enum PlaneType
    {
        Normal,
        Metal,
        Antireflection
    }

    public enum TTCase
    {
        CaseA = 0, CaseB, CaseV,
        CaseG, CaseD, CaseE,
        CaseZh, CaseZ, CaseI,
        CaseK, CaseL,
        CaseM, CaseN,
        CaseUnknown,
        CaseNo,
        Count
    }

    [Serializable]
    public class IntersectRecord
    {
        public double u = 0;
        public double v = 0;
        public int tubeEdge1 = -1, tubeEdge2 = -1;
        public int planeEdge1 = -1, planeEdge2 = -1;

        public void Dump(string name, CW cw)
        {
            if (cw == null)
                return;
            cw(" --- IntersectionRecord <" + name + ">--- ");
            cw(" u = " + u + " ; v = " + v);
            cw(" TubeVerts (" + tubeEdge1 + " ; " + tubeEdge2 + ") and PlaneVerts (" + planeEdge1 + " ; " + planeEdge2 + ")");
        }

        public IntersectRecord(Vector2 UV, int te1, int te2, int pe1, int pe2)
        {
            tubeEdge1 = te1;
            tubeEdge2 = te2;
            planeEdge1 = pe1;
            planeEdge2 = pe2;
            u = UV.x;
            v = UV.y;
        }

        public IntersectRecord()
        {
        }
    };

    [Serializable]
    public class TubeProcessResult
    {
        public TTCase Cs = TTCase.CaseNo;
        public int NumOfTriangles = 0;
        public int TotalNewTubes = 0;
    }


    // Класс содержит информацию о характере пересечения лучевой трубки и треугольника
    [Serializable]
    public class TubeProcessingData
    {
        public TTCase cs = TTCase.CaseNo;
        public Vector3[] IPoints = new Vector3[3];
        public Vector2[] UVs = new Vector2[3];
        public int[] IFact = new int[3];
        public List<int> PinTs = new List<int>();
        public List<int> TinPs = new List<int>();
        public int TinP = 0;
        public int PinT = 0;
        public int LastIndexTinP = -1;
        public int LastIndexPinT = -1;
        public List<IntersectRecord> Intersections = new List<IntersectRecord>();
        // public List<IntersectRecord> OutIntersections = new List<IntersectRecord>();
        public bool[] DoNotAddPP = new bool[3] { false, false, false };
        public double Distance = 1e10;
        public Vector3 WaveDirection = new Vector3();

        public bool ExclusiveCaseUnderDno = false;
        public bool[] ExclusiveCaseIV = new bool[3] { false, false, false };

        public TubeProcessingData()
        {
            for (int i = 0; i < 3; ++i) UVs[i] = new Vector2();
        }
        public Vector2[] Vert = new Vector2[3] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
        public Vector3[] OldDno = new Vector3[3];

        public bool UnderPlane(Vector3 v)
        {
            return v.DotProduct(WaveDirection) < 0;
        }

        public bool[] HasNoIc = new bool[3] { true, true, true };

        // ТЕСТ ТЕСТ ТЕСТ
        /*    public List<Triangle> Traingles = new List<Triangle>();
            public List<RealPoint> Pts = new List<RealPoint>();
            public int[] LeftToEdge = new int[2];
            public int LeftToEdgeCnt = 0;*/
    }

    [Serializable]
    public class Plane3D
    {
        public Vector3[] Vertex = new Vector3[3] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 0, 1) };
        public Vector2[] TextureUV = new Vector2[3] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
        public bool PerVertexLightning = false;
        public Vector3[] Normals = new Vector3[3]; // для графики
        public Vector3 Normal = new Vector3(0, 1, 0);

        [XmlAttribute]
        public bool GotNormal = false;

        [XmlAttribute]
        public double InnerN = 1.5; // 1 !!!
        [XmlAttribute]
        public double InnerDelta = 0;

        public Vector4 Color = new Vector4(1, 1, 1, 1);
        [XmlAttribute]
        public PlaneType Tp = PlaneType.Normal;

        [XmlIgnore]
        public static CW cw = null;

        [XmlIgnore]
        public bool Added = false;
        [XmlIgnore]
        public int ID = 0;

        public static void Log(string s)
        {
            if (cw != null)
                cw("Plane3D: " + s);
        }

        public void CalcNormal()
        {
            Normal = (Vertex[1] - Vertex[0]).CrossProduct(Vertex[2] - Vertex[1]);
            Normal.Normalize();
            if (!PerVertexLightning)
                for (int i = 0; i < 3; ++i)
                    Normals[i] = new Vector3(Normal);
            GotNormal = true;
        }

        public Plane3D(Vector3 v1, Vector3 v2, Vector3 v3, bool NeedNormal = true)
        {
            Vertex[0] = v1;
            Vertex[1] = v2;
            Vertex[2] = v3;
            if (NeedNormal)
                CalcNormal();
        }

        public Plane3D()
        {
        }

        public Plane3D(Plane3D Template)
        {
            PerVertexLightning = Template.PerVertexLightning;
            for (int i = 0; i < 3; ++i)
            {
                Vertex[i] = new Vector3(Template.Vertex[i]);
                Normals[i] = new Vector3(Template.Normals[i]);
                TextureUV[i] = new Vector2(Template.TextureUV[i]);
            }
            if (Template.Normal != null)
                Normal = new Vector3(Template.Normal);
            GotNormal = Template.GotNormal;
            InnerDelta = Template.InnerDelta;
            InnerN = Template.InnerN;
            Color = new Vector4(Template.Color);
            Tp = Template.Tp;
            ID = Template.ID;
            Added = false;
        }

        public Ray3D Reflected(Ray3D indic)
        {
            Vector3 dir = indic.End - indic.Begin;
            Vector3 refl_end = indic.End + dir - 2 * Normal * dir.DotProduct(Normal);
            return new Ray3D(indic.End, refl_end, indic);
        }

        public Ray3D Refracted(Ray3D indic, double n1, double n2)
        {
            Vector3 dir = indic.End - indic.Begin;
            dir.Normalize();
            double n = n1 / n2;
            double dot = dir.DotProduct(Normal);
            if (dot < 0)
                Normal = -Normal;
            double st2 = n * n * (1 - dot * dot);

            if (st2 > 1)
                return null;

            Vector3 v2 = n * dir - (n - Math.Sqrt(1 - st2)) * Normal;

            var nr = new Ray3D(indic.End, indic.End + v2, indic);
            nr.Rayize();
            return nr;
        }

        public Vector3 UVToXYZ(double u, double v)
        {
            return (1 - u - v) * Vertex[0] + u * Vertex[1] + v * Vertex[2];
        }

        public void GetUV(Vector3 MyPoint, out double u, out double v, out double n)
        {
            Vector3 Side1 = Vertex[1] - Vertex[0];
            Vector3 Side2 = Vertex[2] - Vertex[0];

            Matrix m = new Matrix(3, 3);
            m[0, 0] = Side1.X; m[0, 1] = Side2.X; m[0, 2] = Normal.X;// -Vertex[0].X;
            m[1, 0] = Side1.Y; m[1, 1] = Side2.Y; m[1, 2] = Normal.Y;// -Vertex[0].Y;
            m[2, 0] = Side1.Z; m[2, 1] = Side2.Z; m[2, 2] = Normal.Z;// -Vertex[0].Z;
            m = Matrix.Inverse(m);
            Matrix myVec = new Matrix(3, 1);
            myVec[0, 0] = MyPoint.X - Vertex[0].X;
            myVec[1, 0] = MyPoint.Y - Vertex[0].Y;
            myVec[2, 0] = MyPoint.Z - Vertex[0].Z;

            myVec = m * myVec;
            u = myVec[0, 0];
            v = myVec[1, 0];
            n = myVec[2, 0];
        }


        public int RayIntersect(Ray3D ray, out double u, out double v)
        {

            u = 0;
            v = 0;
            if (!GotNormal)
                return -1;

            Vector3 e1 = Vertex[1] - Vertex[0];
            Vector3 e2 = Vertex[2] - Vertex[0];

            Vector3 Dir = (ray.End - ray.Begin);
            Dir.Normalize();

            Vector3 p = Dir.CrossProduct(e2);
            double a = e1.DotProduct(p);

            if (a < Tracer3D.GeometryEpsilon && a > -Tracer3D.GeometryEpsilon)
                return -2;

            double f = 1 / a;
            Vector3 s = ray.Begin - Vertex[0];
            u = f * s.DotProduct(p);
            Vector3 q = s.CrossProduct(e1);
            v = f * Dir.DotProduct(q);
            /*
            if (Math.Abs(u) > 70 || Math.Abs(v) > 70)
                Log("STOP");
            */
            if (u <= 0 || u >= 1)
                return -3;


            if (v <= 0 || u + v >= 1)
                return -3;

            return 1;
        }



        // 0 - REFLECT
        // 1 - REFRACT
        public Tube3D[] ReflectAndRefractTube(Tube3D itube)
        {
            Tube3D[] rtube = new Tube3D[2] { null, null };

            // центральное направление падающей трубки
            Vector3 Dir = itube.CenterDirection();
            // косинус угла падения
            double CosThetaI = Dir.DotProduct(Normal) / Dir.Magnitude;
            CosThetaI = Math.Abs(CosThetaI);

            // просветвляющее покрытие - нет отраженной трубки
            if (Tp != PlaneType.Antireflection)
            {
                rtube[0] = new Tube3D(); // всегда есть отражение
                rtube[0].MyN = itube.MyN;
                rtube[0].MyDelta = itube.MyDelta;
            }

            // показатель преломления в среде 2
            double n2;
            double n1 = itube.MyN;
            // флаг того, что лучи идут из среды в вакуум (true) или наоборот (fasle)
            bool FromMediumToVacuum;
            if (itube.MyN == InnerN) // это значит луч распространялся в толще вещества и теперь выходит наружу
            {
                n2 = 1; // вакуум
                FromMediumToVacuum = true;
            }
            else // перешли из вакуума в среду
            {
                n2 = InnerN;
                FromMediumToVacuum = false;
            }

            // косинус угла преломления
            double CosThetaTSqr = 1 - (n1 * n1) / (n2 * n2) * (1 - CosThetaI * CosThetaI);

            // коэффициент отражения по формулам Френеля
            double ReCoeff = 1.0;


            // если этот косинус не в [-1,1], значит и нет преломления; так же, если поверхность - металл его тоже нет
            if (Tp != PlaneType.Metal && Math.Abs(CosThetaTSqr) <= 1)
            {
                // это - не полное внутреннее отражение, значит есть (возможно) преломленный
                rtube[1] = new Tube3D();
                rtube[1].MyN = n2;
                rtube[1].MyDelta = FromMediumToVacuum ? 0.0 : InnerDelta;

                double CosThetaT = Math.Sqrt(CosThetaTSqr);

                if (n1 != n2)
                {
                    if (itube.IsSPolarization)
                        ReCoeff = (n1 * CosThetaI - n2 * CosThetaT) / (n1 * CosThetaI + n2 * CosThetaT);
                    else
                        ReCoeff = (n1 * CosThetaT - n2 * CosThetaI) / (n1 * CosThetaT + n2 * CosThetaI);

                    ReCoeff *= ReCoeff;
                }
                else
                {
                    ReCoeff = 0;
                    rtube[0] = null;
                }
            }

            // в каждой трубке - три луча
            for (int i = 0; i < 3; ++i)
            {
                if (rtube[0] != null)
                {
                    // отраженные лучи
                    rtube[0].Rays[i] = Reflected(itube.Rays[i]);
                    rtube[0].Color = new Vector4(0, 0, 1, 1);

                    // добавим к лучу пройденную дистанцию от соответствующего луча падающей трубки

                    rtube[0].Rays[i].AddPath(itube.Rays[i], itube.MyN); // !!! добавить фазу на отражение


                }
                if (rtube[1] != null)
                {
                    // преломленный луч
                    rtube[1].Rays[i] = Refracted(itube.Rays[i], itube.MyN, rtube[1].MyN);
                    if (rtube[1].Rays[i] == null) // если хоть один из лучей испытывает полное внутрненнее отражение - нафиг всю трубку
                    {
                        rtube[1] = null;
                        continue;
                    }
                    rtube[1].Color = new Vector4(0, 0.5, 0, 1);

                    rtube[1].Rays[i].AddPath(itube.Rays[i], itube.MyN);


                }
            }
            if (rtube[0] != null) { rtube[0].Power = itube.Power * ReCoeff; rtube[0].Color.A = rtube[0].Power; }
            if (rtube[1] != null) { rtube[1].Power = itube.Power * (1 - ReCoeff); rtube[1].Color.A = rtube[1].Power; }

            return rtube;
        }

        public TTCase WhichCase(int TinP, int PinT, int Ic)
        {
            if (TinP == 3 && PinT == 0 && Ic == 0)
                return TTCase.CaseA;
            /* Б) Случай, трубка одной вершиной залезла через край грани */
            else if (TinP == 1 && PinT == 0 && Ic == 2)
                return TTCase.CaseB;
            /* В) Случай */
            else if (TinP == 1 && PinT == 1 && Ic == 2)
                return TTCase.CaseV;
            /* Г) Случай */
            else if (TinP == 1 && PinT == 0 && Ic == 4)
                return TTCase.CaseG;
            /* Д) Случай */
            else if (TinP == 0 && PinT == 0 && Ic == 6)
                return TTCase.CaseD;
            /* E) Случай */
            else if (TinP == 2 && PinT == 0 && Ic == 2)
                return TTCase.CaseE;
            /* Ж) Случай */
            else if (TinP == 0 && PinT == 0 && Ic == 4)
                return TTCase.CaseZh;
            /* З) Случай */
            else if (TinP == 0 && PinT == 3 && Ic == 0)
                return TTCase.CaseZ;
            /* Случай И) */
            else if (TinP == 0 && PinT == 1 && Ic == 2)
                return TTCase.CaseI;
            /* Случай К) */
            else if (TinP == 2 && PinT == 1 && Ic == 2)
                return TTCase.CaseK;
            /* Случай Л) */
            else if (TinP == 0 && PinT == 1 && Ic == 4)
                return TTCase.CaseL;
            /* Случай М) */
            else if (TinP == 0 && PinT == 2 && Ic == 2)
                return TTCase.CaseM;
            /* Случай Н) */
            else if (TinP == 1 && PinT == 1 && Ic == 4)
            {
                return TTCase.CaseN;
            }
            /* Случай Х) Нет пересечения */
            else if (TinP == 0 && PinT == 0 && Ic == 0)
                return TTCase.CaseNo;
            else
                return TTCase.CaseUnknown;
        }

        public TubeProcessingData ProcessTubeStageOne(Tube3D tube)
        {
            TubeProcessingData tpd = new TubeProcessingData();
            Vector2[] Vert = new Vector2[3] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };

            /* 1. Сохраним дно трубки */
            /*    for (int i = 0; i < 3; ++i)
                    tpd.OldDno[i] = new Vector3(tube.Rays[i].Begin);
                tube.AntiRayize();*/

            /* 2. Найдем точки пересечения каждого из лучей с плоскостью треугольника */


            int Fails = 0;
            int UnderFails = 0;
            for (int i = 0; i < 3; ++i)
            {
                tpd.IFact[i] = RayIntersect(tube.Rays[i], out tpd.UVs[i].x, out tpd.UVs[i].y);

                /* Плоские координаты u, v в 3D x, y, z */
                tpd.IPoints[i] = UVToXYZ(tpd.UVs[i].x, tpd.UVs[i].y);

                double t = tube.Rays[i].GetT(tpd.IPoints[i]);
                /* Если вдруг луч параллелен грани или вообще в другую сторону*/
                if (tpd.IFact[i] == -1 || tpd.IFact[i] == -2 /*|| t <= GeometryEpsilon*/ || t > 1 + Tracer3D.GeometryEpsilon)
                {
                    tpd.cs = TTCase.CaseNo;
                    //    Log("Stage1 : reject because tpd.IFact[" + i + "] = " + tpd.IFact[i] + " and t = " + t);
                    return tpd;
                }
                else if (t <= Tracer3D.GeometryEpsilon)
                {
                    Fails++;
                    tpd.ExclusiveCaseUnderDno = true;
                    tpd.ExclusiveCaseIV[i] = true;
                    //   Log("tpd.ExclusiveCaseUnderDno = true;");
                }
                // Log(" i = " + i + " ; t = " + t);

                /* трубка внутри треугольника */
                if (tpd.IFact[i] == 1)
                {
                    ++tpd.TinP;
                    tpd.TinPs.Add(i);
                    tpd.LastIndexTinP = i;
                }

                // Log("Stage 1: UnderPlane test: IPoints[i] = {" + tpd.IPoints[i].X + " , " + tpd.IPoints[i].Y + " , " + tpd.IPoints[i].Z + "}");
                //   Log("Stage 1: UnderPlane test: tube.Rays[0].Begin = {" + tube.Rays[0].Begin.X + " , " + tube.Rays[0].Begin.Y + " , " + tube.Rays[0].Begin.Z + "}");
                if (tpd.UnderPlane(UVToXYZ(tpd.Vert[i].x, tpd.Vert[i].y) - tube.Rays[0].Begin))
                {
                    UnderFails++;
                    tpd.DoNotAddPP[i] = true;
                    Log("Stage1 : underfail on i = " + i);

                    if (UnderFails == 3)
                    {
                        tpd.cs = TTCase.CaseNo;
                        Log("Stage1 : reject because UnderFails = 3");
                        return tpd;
                    }
                }

                //if (cw != null) cw("IPoints[" + i + "] = " + IPoints[i].ToString() + " >>>>> u = " + UVs[i].x + " ; v = " + UVs[i].y);

            }

            if (Fails > 2)
            {
                tpd.cs = TTCase.CaseNo;
                return tpd;
            }


            /* 3. ищем и пересчитываем все пересечения граней треугольника с гранями трубки */
            for (int i = 0; i < 3; ++i)
            {
                /* точки треугольника в трубке ? */

                double q1 = Utils2D.Classify(tpd.UVs[0].x, tpd.UVs[0].y, tpd.UVs[1].x, tpd.UVs[1].y, Vert[i].x, Vert[i].y);
                double q2 = Utils2D.Classify(tpd.UVs[1].x, tpd.UVs[1].y, tpd.UVs[2].x, tpd.UVs[2].y, Vert[i].x, Vert[i].y);
                double q3 = Utils2D.Classify(tpd.UVs[2].x, tpd.UVs[2].y, tpd.UVs[0].x, tpd.UVs[0].y, Vert[i].x, Vert[i].y);

                if ((q1 > 0 && q2 > 0 && q3 > 0) || (q1 < 0 && q2 < 0 && q3 < 0))
                {
                    ++tpd.PinT;
                    tpd.PinTs.Add(i);
                    tpd.LastIndexPinT = i;
                }

                int nexti = i == 2 ? 0 : i + 1;
                for (int j = 0; j < 3; ++j)
                {
                    int nextj = j == 2 ? 0 : j + 1;
                    Utils2D.CrossResultRec crr = Utils2D.Crossing(Vert[j], Vert[nextj], tpd.UVs[i], tpd.UVs[nexti]);
                    if (crr.type == Utils2D.EnumCrossType.ctOnLine)
                    {
                        //   double t1 = Utils2D.GetParameterLinesPoint(tpd.Vert[j], tpd.Vert[nextj], tpd.UVs[i]);
                        //   double t2 = Utils2D.GetParameterLinesPoint(tpd.Vert[j], tpd.Vert[nextj], tpd.UVs[nexti]);
                        tpd.Intersections.Add(new IntersectRecord(tpd.UVs[i], i, nexti, j, nextj));
                        tpd.Intersections.Add(new IntersectRecord(tpd.UVs[nexti], i, nexti, j, nextj));
                        //  tpd.DoNotAddPT[i] = true;
                        //  tpd.DoNotAddPT[nexti] = true;
                        tpd.HasNoIc[i] = false;

                    }
                    else if (crr.type == Utils2D.EnumCrossType.ctInBounds || crr.type == Utils2D.EnumCrossType.ctOnBounds)
                    {
                        tpd.Intersections.Add(new IntersectRecord(crr.pt, i, nexti, j, nextj));
                        tpd.HasNoIc[i] = false;
                    }
                    /* else if (crr.type == Utils2D.EnumCrossType.ctOutBounds)
                     {
                         tpd.OutIntersections.Add(new IntersectRecord(crr.pt, i, nexti, j, nextj));
                     }*/
                }
            }

            int Ic = tpd.Intersections.Count;

            if (tpd.PinT == 0 && tpd.TinP == 0 && Ic < 4)
            {
                tpd.cs = TTCase.CaseNo;
                return tpd;
            }

            /* 4. теперь зная TinP, PinT, Intersections.Count можно рассмотреть все 8 случаев */
            tpd.cs = WhichCase(tpd.TinP, tpd.PinT, Ic); // определим случай

            /* 5. если пересечение есть, смотрим минимальную дистанцию до каждого луча */
            if (tpd.cs != TTCase.CaseNo)
            {
                tpd.Distance = Math.Min(Math.Min(
                    (tube.Rays[0].Begin - tpd.IPoints[0]).SumComponentSqrs(),
                    (tube.Rays[1].Begin - tpd.IPoints[1]).SumComponentSqrs()),
                    (tube.Rays[2].Begin - tpd.IPoints[2]).SumComponentSqrs());
                tpd.WaveDirection = tube.CenterDirection();
                tpd.WaveDirection.Normalize();
            }

            /*  for (int i = 0; i < 3; ++i)
                  tube.Rays[i].Begin = tpd.OldDno[i];*/

            return tpd;
        }



        public TubeProcessResult ProcessTubeStageTwo(TubeProcessingData t, Tube3D tube, List<Tube3D> ReflRefrTubes, List<Tube3D> SplitTubes, List<Tube3D> AddTubes)
        {
            TubeProcessResult Tpr = new TubeProcessResult();
            /* Попробуем иначе!!!
             * 
             * */

            /*
             ВОТ СЮДА ВСТАВЛЯЮ ТЕСТОВЫЙ КОД!!!
             */
            // Список вершин для триангуляции
            List<Vector2> VertsForDelauney1 = new List<Vector2>();

            // Важно, что сначала я добавляю PinTs
            for (int i = 0; i < t.PinTs.Count; ++i)
                VertsForDelauney1.Add(t.Vert[t.PinTs[i]]);

            // Затем пересечения
            int Ic = t.Intersections.Count;
            for (int i = 0; i < Ic; ++i)
                VertsForDelauney1.Add(new Vector2(t.Intersections[i].u, t.Intersections[i].v));


            // Случай такой: часть грани оказалась под нижней плоскостью трубки 
            bool PlaneIntersectsBottomTubePlane = t.DoNotAddPP[0] || t.DoNotAddPP[1] || t.DoNotAddPP[2];
            Log("Stage 2: BEGIN - Addional actions need? " + PlaneIntersectsBottomTubePlane.ToString());
            if (PlaneIntersectsBottomTubePlane)
            {
                // удалим из массива для триангуляции все точки, лежажие ниже нижней плоскости трубки
                int Dt = VertsForDelauney1.Count;
                VertsForDelauney1.RemoveAll(xx =>
                    (xx != t.UVs[0] && xx != t.UVs[1] && xx != t.UVs[2]) &&
                    ((t.DoNotAddPP[0] && xx == t.Vert[0]) ||
                    (t.DoNotAddPP[1] && xx == t.Vert[1]) ||
                    (t.DoNotAddPP[2] && xx == t.Vert[2]) ||
                    t.UnderPlane(UVToXYZ(xx.x, xx.y) - tube.Rays[0].Begin))
                    );

                Log("Excl case Delta -> VertsForDelauney1.Count = " + (Dt - VertsForDelauney1.Count));

                // Созданим треугольник из нижней плоскости трубки
                Plane3D Bp = new Plane3D(tube.Rays[0].Begin, tube.Rays[1].Begin, tube.Rays[2].Begin, true);

                // Теперь выясним какие именно стороны грани пересекают эту плосокость

                // Индексы i<номер стороны>_<вершина>
                int i1_1, i1_2, i2_1, i2_2;

                // Число вершин под плосотью Bp
                int UnderVertNum = (t.DoNotAddPP[0] ? 1 : 0) + (t.DoNotAddPP[1] ? 1 : 0) + (t.DoNotAddPP[2] ? 1 : 0);
                int iUnderOrAbove;
                // одна снизу
                if (UnderVertNum == 1)
                    // Определили какая снизу
                    iUnderOrAbove = (t.DoNotAddPP[0] ? 0 : (t.DoNotAddPP[1] ? 1 : 2));
                // две снизу
                else
                    // Какая сверху оказалась?
                    iUnderOrAbove = (!t.DoNotAddPP[0] ? 0 : (!t.DoNotAddPP[1] ? 1 : 2));
                // Значит две стороны от нее исходят к остальным двум вершинам
                i1_1 = iUnderOrAbove;
                i2_1 = iUnderOrAbove;
                switch (iUnderOrAbove)
                {
                    case 0: i1_2 = 1; i2_2 = 2; break;
                    case 1: i1_2 = 0; i2_2 = 2; break;
                    default: i1_2 = 0; i2_2 = 1; break;
                }
                //Log("Indices i1_1 = " + i1_1 + " i1_2 = " + i1_2 + " i2_1 = " + i2_1 + " i2_2 = " + i2_2);

                // сюда занесем точки пересечения сторон грани с плосокотью Bp
                Vector2 PIB1 = new Vector2();
                Vector2 PIB2 = new Vector2();

                // собственно поиск пересечений сторон грани с плосоктью Bp
                int res1 = Bp.RayIntersect(new Ray3D(Vertex[i1_1], Vertex[i1_2]), out PIB1.x, out PIB1.y);
                int res2 = Bp.RayIntersect(new Ray3D(Vertex[i2_1], Vertex[i2_2]), out PIB2.x, out PIB2.y);
                Log("res1 = " + res1 + " res2 = " + res2);

                // проверим пересечия уже в плосокти Bp
                Vector2[] Rps = new Vector2[3] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1) };
                if (res1 < 0 || res2 < 0)
                    for (int i = 0; i < 3; ++i)
                    {
                        int nexti = i == 2 ? 0 : i + 1;
                        var cr = Utils2D.Crossing(Rps[i], Rps[nexti], PIB1, PIB2);
                        if (cr.type == Utils2D.EnumCrossType.ctInBounds || cr.type == Utils2D.EnumCrossType.ctOnBounds)
                        {
                            double u, v, n;
                            GetUV(Bp.UVToXYZ(cr.pt.x, cr.pt.y), out u, out v, out n);
                            VertsForDelauney1.Add(new Vector2(u, v));
                        }
                    }

                // добавим в массив для триангуляции точки отрезка, если они внутри треуголньика
                if (res1 > 0)
                {
                    double u, v, n;
                    GetUV(Bp.UVToXYZ(PIB1.x, PIB1.y), out u, out v, out n);
                    VertsForDelauney1.Add(new Vector2(u, v));
                }
                if (res2 > 0)
                {
                    double u, v, n;
                    GetUV(Bp.UVToXYZ(PIB2.x, PIB2.y), out u, out v, out n);
                    VertsForDelauney1.Add(new Vector2(u, v));
                }

                if (VertsForDelauney1.Count < 3)
                {
                    AddTubes.Add(tube);
                    Log("!!!1");

                    return Tpr;
                }
            }


            List<Triangle> Triangles = new List<Triangle>();

            int cnt1 = VertsForDelauney1.Count;
            // удаляем всех дублеров
            VertsForDelauney1 = VertsForDelauney1.Distinct(new RealPointComparer()).ToList();
            // сколько убавилось?
            Log("Delta -> cnt : VertsForDelauney1 = " + (VertsForDelauney1.Count - cnt1));

            // Индекс с которого ядро в списке кончилось
            int CoreEndIndex = 0;

            if (t.cs == TTCase.CaseA)
            {
                for (int i = 0; i < 3; ++i)
                    VertsForDelauney1.Add(t.UVs[i]);
                Triangles.Add(new Triangle(0, 1, 2, true));
                CoreEndIndex = 1;
            }
            else
            {
                // ядро триангулируем
                Triangles = Utils2D.RoundTrianglulationWOCenter(VertsForDelauney1);
                CoreEndIndex = Triangles.Count;

                int TubePStartIndex = VertsForDelauney1.Count;
                // Потом точки трубки добавим туда же после триангуляции ядра
                for (int i = 0; i < 3; ++i)
                    VertsForDelauney1.Add(t.UVs[i]);

                // Что теперь? Берем произвольное ребро выпулклого многоугольника ядра и рассекаем им пространоство
                for (int iE = 0; iE < TubePStartIndex; ++iE)
                {
                    int F1 = iE;
                    int F2 = iE == TubePStartIndex - 1 ? 0 : iE + 1;

                    // Сперва, нам нужно найти все точки трубки, лежащие левее от этого ребра
                    List<int> LeftToEdge = new List<int>();
                    for (int i = 0; i < VertsForDelauney1.Count; ++i)
                    {
                        if (
                            F1 == i || F2 == i ||
                            Utils2D.Classify(VertsForDelauney1[F1].x, VertsForDelauney1[F1].y, VertsForDelauney1[F2].x, VertsForDelauney1[F2].y, VertsForDelauney1[i].x, VertsForDelauney1[i].y) > Tracer3D.GeometryEpsilon)
                        {
                            LeftToEdge.Add(i);
                        }
                    }

                    // есть, о чем говорить
                    if (LeftToEdge.Count == 3)
                    {
                        Triangles.Add(new Triangle(LeftToEdge[0], LeftToEdge[1], LeftToEdge[2]));
                        Triangles[Triangles.Count - 1].Dump("Single T[" + (Triangles.Count - 1) + "] on core-edge F1 = " + F1 + " F2 = " + F2, VertsForDelauney1);
                    }
                    else if (LeftToEdge.Count > 3)
                    {
                        List<Vector2> Region = new List<Vector2>();
                        LeftToEdge.ForEach(delegate(int p)
                        {
                            VertsForDelauney1[p].Tag = p;
                            Region.Add(VertsForDelauney1[p]);
                        });

                        List<Triangle> RegionTriangles = Utils2D.RoundTrianglulationWOCenter(Region);

                        RegionTriangles.ForEach(delegate(Triangle tr)
                        {
                            Triangles.Add(new Triangle(
                                Region[tr.p1].Tag,
                                Region[tr.p2].Tag,
                                Region[tr.p3].Tag
                                ));
                            Triangles[Triangles.Count - 1].Dump("Multi  T[" + (Triangles.Count - 1) + "] on core-edge F1 = " + F1 + " F2 = " + F2, VertsForDelauney1);
                        });
                    }
                }

                // Все таки костыль!
                // Ищем ребро, на котором нет пересечений, оно подозрительно
                for (int i = 0; i < 3; ++i)
                {
                    // их нет!
                    if (t.HasNoIc[i])
                    {
                        int j = i == 2 ? 0 : i + 1;
                        j += TubePStartIndex;
                        int ii = i + TubePStartIndex;

                        // Есть ли треугольник, содержащий его?
                        int itr = Triangles.FindIndex(x =>
                            x.HasVertex(ii) && x.HasVertex(j)
                            );
                        Log("KOST! ");
                        if (itr == -1)
                        {
                            // АГА! Нет такого треугольника! Создадим его
                            // Для этого нам нужно найти точку ядра наиболее близкую к ребру i
                            int iWTF = 0;

                            Vector3 P2P1 = new Vector3(VertsForDelauney1[ii].x - VertsForDelauney1[j].x, VertsForDelauney1[ii].y - VertsForDelauney1[j].y, 0);
                            double MinDistance = 10e5;
                            for (int k = 0; k < TubePStartIndex; ++k)
                            {

                                double distanceFromPtoP2P1 = P2P1.CrossProduct(new Vector3(VertsForDelauney1[j].x - VertsForDelauney1[k].x, VertsForDelauney1[j].y - VertsForDelauney1[k].y, 0)).Magnitude;
                                if (MinDistance > distanceFromPtoP2P1)
                                {
                                    MinDistance = distanceFromPtoP2P1;
                                    iWTF = k;
                                }
                            }

                            Triangles.Add(new Triangle(ii, j, iWTF));
                            Triangles[Triangles.Count - 1].Dump("KOST!  T[" + (Triangles.Count - 1) + "]", VertsForDelauney1);
                        }
                    }
                }
            }

            /* DEBUG */
            /*  // Определим количество внутренних треугольников
              int Num = Triangles.Count(x => x.IsInner(VertsForDelauney1));

              // если их нет, значит попали мимо, значит на зачем дробить исходный
              if (Num == 0)
              {

                  Log("Miss!");
                  Tpr.Cs = TTCase.CaseNo;
                  return Tpr;

              }*/
            /* DEBUG */



            Tube3D tube2 = new Tube3D(tube); // КОСТЫЛЬ №2
            // Отрубим хвосты лучей до плоскости грани!
            for (int i = 0; i < 3; ++i)
                tube2.Rays[i].End = t.IPoints[i];
            // площадь трубки
            double Area = tube2.AreaTop();

            int Cnt = -1;
            foreach (Triangle tr in Triangles)
            {
                ++Cnt;
                // разбиваем трубку, вычленяем нужную
                Tube3D TubeToTrace1 = tube2.UniversalSplit(new Vector3[3]{ 
                            UVToXYZ(VertsForDelauney1[tr.p1].x, VertsForDelauney1[tr.p1].y),  
                            UVToXYZ(VertsForDelauney1[tr.p2].x, VertsForDelauney1[tr.p2].y),
                            UVToXYZ(VertsForDelauney1[tr.p3].x, VertsForDelauney1[tr.p3].y)
                        });

                if (TubeToTrace1 == null)
                    continue;

                /*   if (TubeToTrace1.WrongTubeTest())
                       Log("Stop");*/

                // DEBUG
                /*     TubeToTrace1.Tags[0] = "(" + tr.p1 + ")";
                     TubeToTrace1.Tags[1] = "(" + tr.p2 + ")";
                     TubeToTrace1.Tags[2] = "(" + tr.p3 + ")";
     */

                // вдруг смотрит вниз? исправить, должна смотреть вверх
                for (int i = 0; i < 3; ++i)
                {
                    TubeToTrace1.Rays[i].Begin += t.WaveDirection * Tracer3D.GeometryEpsilon; // КОСТЫЛЬ №3
                    TubeToTrace1.Rays[i].End += t.WaveDirection * Tracer3D.GeometryEpsilon * 2;
                    if (t.UnderPlane(TubeToTrace1.Rays[i].End - TubeToTrace1.Rays[i].Begin))
                        TubeToTrace1.Rays[i].End = 2 * TubeToTrace1.Rays[i].Begin - TubeToTrace1.Rays[i].End;
                }
                // наши потомки не должны воспринимать эту грань, чтобы повтроно ее не трассировать на след. шаге
                TubeToTrace1.Prohibit = this;

                // площаь потомка
                double AddArea = TubeToTrace1.AreaTop(); // ЭТО НЕ ПРАВИЛЬНО, КОГДА ГРАНЬ ПОД УКЛОНОМ!!!!

                // отгрызем кусок мощности
                TubeToTrace1.Power = tube.Power * AddArea / Area;
                //TubeToTrace1.

                // "внутренняя" трубка - та, что попала на грань, должна претерпеть отражение и преломление
                tr.Dump("", VertsForDelauney1);
                if (tr.IsInner(VertsForDelauney1))//Cnt < CoreEndIndex)//)//tr.Inner) // ?????????????????????????
                {
                    Log(" $$$ This triange is being traced! $$$");

                    // [0] - отраженная, [1] - преломленная
                    Tube3D[] RRT = ReflectAndRefractTube(TubeToTrace1);
                    if (RRT[0] != null)
                    {
                        // DEBUG
                        RRT[0].Comment = tube.Comment + " ; refl ";

                        // добавим ее в отраженные
                        RRT[0].Prohibit = this;
                        ReflRefrTubes.Add(RRT[0]);
                    }

                    if (RRT[1] != null)
                    {
                        // DEBUG
                        RRT[1].Comment = tube.Comment + " ; refr ";

                        // добавим ее в преломленные
                        RRT[1].Prohibit = this;
                        ReflRefrTubes.Add(RRT[1]);
                    }

                    // DEBUG
                    TubeToTrace1.Comment = tube.Comment + " ; me split ";

                    // а исходную - в дополнительные
                    SplitTubes.Add(TubeToTrace1);

                }
                else
                {
                    // DEBUG
                    TubeToTrace1.Comment = tube.Comment + " ; me add ";

                    // мимо грани - сразу в дополнительные
                    AddTubes.Add(TubeToTrace1);
                }
            }
            /* for (int i = 0; i < 3; ++i)
                 if (t.UnderPlane(tube.Rays[i].End - tube.Rays[i].Begin))
                 {
                     Log("WWTF?");
                     tube.Rays[i].End = 2 * tube.Rays[i].Begin - tube.Rays[i].End;
                 }*/

            Tpr.Cs = t.cs;
            Tpr.NumOfTriangles = Triangles.Count;
            Tpr.TotalNewTubes = SplitTubes.Count + AddTubes.Count + ReflRefrTubes.Count;
            return Tpr;
        }

        public AABB GetAABB()
        {
            return new AABB(
                new Vector3(
                    (Vertex[0].X > Vertex[1].X && Vertex[0].X > Vertex[2].X) ? Vertex[0].X : (Vertex[1].X > Vertex[0].X && Vertex[1].X > Vertex[2].X ? Vertex[1].X : Vertex[2].X),
                    (Vertex[0].Y > Vertex[1].Y && Vertex[0].Y > Vertex[2].Y) ? Vertex[0].Y : (Vertex[1].Y > Vertex[0].Y && Vertex[1].Y > Vertex[2].Y ? Vertex[1].Y : Vertex[2].Y),
                    (Vertex[0].Z > Vertex[1].Z && Vertex[0].Z > Vertex[2].Z) ? Vertex[0].Z : (Vertex[1].Z > Vertex[0].Z && Vertex[1].Z > Vertex[2].Z ? Vertex[1].Z : Vertex[2].Z)
                    ),
                new Vector3(
                    (Vertex[0].X < Vertex[1].X && Vertex[0].X < Vertex[2].X) ? Vertex[0].X : (Vertex[1].X < Vertex[0].X && Vertex[1].X < Vertex[2].X ? Vertex[1].X : Vertex[2].X),
                    (Vertex[0].Y < Vertex[1].Y && Vertex[0].Y < Vertex[2].Y) ? Vertex[0].Y : (Vertex[1].Y < Vertex[0].Y && Vertex[1].Y < Vertex[2].Y ? Vertex[1].Y : Vertex[2].Y),
                    (Vertex[0].Z < Vertex[1].Z && Vertex[0].Z < Vertex[2].Z) ? Vertex[0].Z : (Vertex[1].Z < Vertex[0].Z && Vertex[1].Z < Vertex[2].Z ? Vertex[1].Z : Vertex[2].Z)
                    ));

        }
    }
}
