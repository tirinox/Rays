using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using System.Text;
using System.Windows.Forms;
using CSScriptLibrary;
using Tao.OpenGl;

namespace Rays._3D
{
    [Serializable]
    public class Scene3D : IDisposable
    {
        public string FileName = "";



        [XmlArray] // Было без всего...
        public List<Figure3D> Figs = new List<Figure3D>();
        [XmlArray] // Было без всего...
        public List<Tube3D> InitialRays = new List<Tube3D>();

        [XmlArray] // Было без всего...
        public List<Tube3D> AllRays = new List<Tube3D>();

        [XmlElement]
        public int PercentVisible = 100;

        [XmlIgnore]
        public Vector4 fColor = new Vector4(1, 1, 1, 1);
        [XmlIgnore]
        public PlaneType PlaneType = PlaneType.Normal;
        [XmlIgnore]
        public double InnerN = 1;
        [XmlIgnore]
        public double InnerDelta = 0.0;

        [XmlIgnore]
        public int Tag = -1;

        [XmlIgnore]
        public int RayCnt = 0;
        [XmlIgnore]
        public int ProgressPercent = 0;
        [XmlIgnore]
        public int ProgressPercentOld = 0;
        [XmlIgnore]
        public bool Ready = false;
        [XmlIgnore]
        public bool ShouldTerminate = false;

        [XmlIgnore]
        public Octree MyOctree = new Octree();

        [XmlIgnore]
        public Figure3D Selected = null;

        [XmlIgnore]
        public bool RaysVisible = false;

        [XmlIgnore]
        private int DisplayListScene = -1;
      //  [XmlIgnore]
      //  private int DisplayListRays = -1; 
        // 1. Вызывать BuildLists при изменении на сцене
        [XmlIgnore]
        private VBO RaysVBO = new VBO();

        [XmlIgnore]
        public Project3D Parrent = null;
        [XmlIgnore]
        public bool LoadedFromScript = false;
        [XmlIgnore]
        public bool Opened = false;
        [XmlIgnore]
        public AsmHelper Asm = null;
        [XmlIgnore]
        public static CW Cw = null;

        [XmlIgnore]
        public FontGL FontLarge = null;
        [XmlIgnore]
        public FontGL FontSmall = null;

        [XmlIgnore]
        private bool HasFonts = false;

        public void Dispose()
        {
            if (Asm != null)
                Asm.Dispose();
        }

        public static void Log(string s)
        {
            if (Cw != null)
                Cw(s);
        }

        public void DeleteList(ref int List)
        {
            if (List != -1)
            {
                Gl.glDeleteLists(List, 1);
                List = -1;
            }
        }

        public int GenerateFreeID()
        {
            int Res;
            Random Rnd = new Random((int)(DateTime.Now - new DateTime(1999, 12, 31)).TotalSeconds);
            do
                Res = Rnd.Next();
            while (Figs.FindIndex(f => f.ID == Res) >= 0);
            return Res;
        }

        public void DisableRays()
        {
            RaysVisible = false;
            AllRays.Clear();
            RaysVBO.Free();
        }

        public void CreateInitialRays(Vector3 Pos, int Details = 10)
        {
            InitialRays.Clear();

            for (int i = 0; i < Details; ++i)
                for (int j = 0; j < Details; ++j)
                {
                    double Phi1 = Utils2D.I2Diap(i, Details, 0, Math.PI * 2);
                    double Phi2 = Utils2D.I2Diap(i + 1, Details, 0, Math.PI * 2);

                    double The1 = Utils2D.I2Diap(j, Details, -Math.PI, Math.PI);
                    double The2 = Utils2D.I2Diap(j + 1, Details, -Math.PI, Math.PI);

                    double x1, x2, x3, x4;
                    double y1, y2, y3, y4;
                    double z1, z2, z3, z4;

                    double r = 50;
                    Utils3D.SphToXYZ(r, Phi1, The1, out x1, out y1, out z1);
                    Utils3D.SphToXYZ(r, Phi2, The1, out x2, out y2, out z2);
                    Utils3D.SphToXYZ(r, Phi1, The2, out x3, out y3, out z3);
                    Utils3D.SphToXYZ(r, Phi2, The2, out x4, out y4, out z4);

                    Tube3D t = new Tube3D();

                    t.Rays[0].Begin = Pos + Vector3.xAxis * 0.005;
                    t.Rays[1].Begin = Pos + Vector3.yAxis * 0.005;
                    t.Rays[2].Begin = Pos;

                    t.Rays[0].End = new Vector3(x1 + Pos.X, y1 + Pos.Y, z1 + Pos.Z);
                    t.Rays[1].End = new Vector3(x2 + Pos.X, y2 + Pos.Y, z2 + Pos.Z);
                    t.Rays[2].End = new Vector3(x3 + Pos.X, y3 + Pos.Y, z3 + Pos.Z);

                    InitialRays.Add(t);
                    /*
                     *  Gl.glNormal3d(nx, ny, nz);
                    Gl.glVertex3d(x1, y1, z1);
                    Gl.glVertex3d(x2, y2, z2);
                    Gl.glVertex3d(x3, y3, z3);
                    
                    NormalToVector(x2, y2, z2, x3, y3, z3, x4, y4, z4, out nx, out ny, out nz);

                    Gl.glNormal3d(nx, ny, nz);
                    Gl.glVertex3d(x2, y2, z2);
                    Gl.glVertex3d(x3, y3, z3);
       
                    Gl.glVertex3d(x4, y4, z4);*/
                }
        }

        public void Open(string fName = "")
        {
            try
            {
                if (Asm != null)
                {
                    Asm.Dispose();
                    Asm = null;
                }
                Selected = null;
                RaysVisible = false;
                AllRays.Clear();
                InitialRays.Clear();
                Figs.Clear();

                if (fName == "")
                    fName = FileName;
                else
                    FileName = fName;

                DateTime Begin = DateTime.Now;

                Log("[i] Начинается загрузка файла \"" + fName + "\".");

                Assembly aS = CSScript.Load(fName, null, true);
                Asm = new AsmHelper(aS);


                Log("[i] Загрузка файла завершена \"" + fName + "\".");
                Log("[i] Выполнение скрипта вызовом Script.Load(this).");

                Asm.Invoke("Script.Load", this);
                LoadedFromScript = true;

                Log("[i] Вызов метода Script.Load(this) завершен.");

                TransformFiguresAndMergeFaces();

                Log("[i] Загрузка выполнена за " + (DateTime.Now - Begin).TotalSeconds + " сек.");
            }
            catch (csscript.CompilerException ce)
            {
                CompilerErrorCollection errors = (CompilerErrorCollection)ce.Data["Errors"];

                foreach (CompilerError err in errors)
                {
                    Log(@"/!\ Loader ERROR (C#) " + string.Format("{0}({1},{2}): {3} {4}: {5}",
                                        err.FileName,
                                        err.Line,
                                        err.Column,
                                        err.IsWarning ? "warning" : "error",
                                        err.ErrorNumber,
                                        err.ErrorText));
                }

            }
            catch (ArgumentException ce)
            {
                Log(@"/!\ Loader ERROR (ArgumentExpection) " + ce.Message);
            }
            catch (ApplicationException ce)
            {
                Log(@"/!\ Loader ERROR (ApplicationExpection) " + ce.Message);
            }
            catch (Exception ce)
            {
                Log(@"/!\ Loader ERROR (Expection) " + ce.Message);
            }
        }

        public void RemoveFigure(Figure3D Fig)
        {
            int Ind = Figs.IndexOf(Fig);
            if (Ind >= 0)
            {
                if (Selected == Fig)
                    Selected = null;
                int Id = Fig.ID;
                Figs.RemoveAt(Ind);
                Figs.ForEach(delegate(Figure3D F)
                {
                    if (F.ParrentID == Id)
                    {
                        
                        F.ParrentID = -1;
                        F.ApplyTransform(this);
                        F.BuildVBO(false);
                    }
                });
                if(Parrent != null)
                    Parrent.ChangesUnsaved = true;
            }
            else
                throw new Exception("The scene does not contains the figure you want to remove from it.");
        }

        public void CoordSystemRender()
        {
            Gl.glDisable(Gl.GL_LIGHTING);

            bool aCap = Rays.Properties.Settings.Default.AxisCaptions;
            double msz = Math.Abs(Rays.Properties.Settings.Default.AxisMax);
            double step = Rays.Properties.Settings.Default.AxisStep;
            if (step < 0.001)
                step = 1;

            Gl.glLineWidth(0.2f);
            Gl.glColor4d(0.5, 0.5, 0.5, 1);

            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(-msz, 0, 0);
            Gl.glVertex3d(msz, 0, 0);
            Gl.glVertex3d(0, -msz, 0);
            Gl.glVertex3d(0, msz, 0);
            Gl.glVertex3d(0, 0, -msz);
            Gl.glVertex3d(0, 0, msz);

            for (double i = -msz; i <= msz; i += step)
            {
                if (i > 0)
                    Gl.glColor4d(0.99, 0.5, 0.5, 1);
                else
                    Gl.glColor4d(0.5, 0.5, 0.99, 1);
                Gl.glVertex3d(i, 0, 0);
                Gl.glVertex3d(i, 1, 0);
                Gl.glVertex3d(0, i, 0);
                Gl.glVertex3d(1, i, 0);
                Gl.glVertex3d(0, 0, i);
                Gl.glVertex3d(1, 0, i);
            }

            Gl.glEnd();

            if (aCap)
            {
                Utils.GColor(Color.Gray);
                for (double i = -msz; i <= msz; i += step)
                {
                    FontSmall.Print(i, 0, 0, i.ToString());
                    FontSmall.Print(0, i, 0, i.ToString());
                    FontSmall.Print(0, 0, i, i.ToString());
                }
            }
            Utils.GColor(Color.Red);
            FontLarge.Print(msz + step, 0, 0, "+X");
            FontLarge.Print(-msz - step, 0, 0, "-X");
            Utils.GColor(Color.Green);
            FontLarge.Print(0, msz + step, 0, "+Y");
            FontLarge.Print(0, -msz - step, 0, "-Y");
            Utils.GColor(Color.Blue);
            FontLarge.Print(0, 0, msz + step, "+Z");
            FontLarge.Print(0, 0, -msz - step, "-Z");
        }

        private static int[] selectBuffer = new int[128 * 4];
        public void PickFigure(int x, int y)
        {
            int selectedId = -1;

            Gl.glSelectBuffer(128 * 4, selectBuffer);
            Gl.glRenderMode(Gl.GL_SELECT);
            Gl.glInitNames();
            Gl.glPushName(0);
       
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();

            int[] viewport = new int[4];
            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);

            double[] doubleArray = new double[16];
            Gl.glGetDoublev(Gl.GL_PROJECTION_MATRIX, doubleArray);

            Gl.glLoadIdentity();
            Glu.gluPickMatrix(x, y, 0.001f, 0.001f, viewport);
            Gl.glMultMatrixd(doubleArray);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            Render(true);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();

            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            Gl.glFlush();

            int hits = Gl.glRenderMode(Gl.GL_RENDER);
            uint closest = uint.MaxValue;

            for (int i = 0; i < hits; i++)
            {

                uint distance = (uint)selectBuffer[i * 4 + 1];

                if (closest >= distance)
                {
                    closest = distance;
                    selectedId = (int)selectBuffer[i * 4 + 3];
                }
            }

            SelectFigure(Figs.Find(f => f.ID == selectedId));
        }

        public void TransformFiguresAndMergeFaces()
        {
            foreach (Figure3D Fig in Figs)
            {
                Fig.ApplyTransform(this);
                Fig.BuildVBO(Fig == Selected);
            }

            if (Rays.Properties.Settings.Default.OctreeEnable)
            {
                MyOctree.MinFaceCountInNode = Rays.Properties.Settings.Default.OctreeMinFaces;
                MyOctree.MaxDeep = Rays.Properties.Settings.Default.OctreeDeepness;
                MyOctree.BuildTree(this);
            }
            BuildVBO(false);
        }

        public void SelectFigure(Figure3D Fig)
        {
            if (Selected != null)
                Selected.BuildVBO(false);
            Selected = Figs.Contains(Fig) ? Fig : null;
            if (Selected != null)
                Selected.BuildVBO(true);
        }

        public void BuildVBO(bool RaysList)
        {
            if (!HasFonts)
            {
                FontSmall = new FontGL("Verdana", 10);
                FontLarge = new FontGL("Verdana", 16);
                HasFonts = true;
            }

            if (!RaysList)
            {
                DeleteList(ref DisplayListScene);
                DisplayListScene = Gl.glGenLists(1);
                Gl.glNewList(DisplayListScene, Gl.GL_COMPILE);
                Render1(false);
                Gl.glEndList();
            }
            else
            {
                RaysVBO.Build(AllRays, Parrent.LineWidth, Parrent.TubeRenderStyle, PercentVisible);
                RaysVisible = true;
            }
        }

        public void Render(bool Pick)
        {
            if (!Pick && DisplayListScene != -1)
                Gl.glCallList(DisplayListScene);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            foreach (Figure3D F in Figs)
                F.Render(Pick, Selected == F);

            if (!Pick && RaysVisible)
                RaysVBO.Render();
        }

        public void Render1(bool Pick = false)
        {
            if (!Pick && Rays.Properties.Settings.Default.DrawAxis)
                CoordSystemRender();
        }

        public Figure3D CurrentFigure = null;

        public void BeginFigure()
        {
            if (CurrentFigure != null)
                throw new Exception("Call EndFigure first!");
            CurrentFigure = new Figure3D(this);
        }

        public void EndFigure()
        {
            if (CurrentFigure == null)
                throw new Exception("Call BeginFigure first!");
            Figs.Add(CurrentFigure);
            CurrentFigure = null;
        }

        public void Add(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double x3, double y3, double z3)
        {
            Plane3D Face = new Plane3D();
            Face.Color = new Vector4(fColor);
            Face.InnerDelta = InnerDelta;
            Face.InnerN = InnerN;
            Face.Tp = PlaneType;
            Face.Vertex[0] = new Vector3(x1, y1, z1);
            Face.Vertex[1] = new Vector3(x2, y2, z2);
            Face.Vertex[2] = new Vector3(x3, y3, z3);
            try
            {
                Face.CalcNormal();
                CurrentFigure.Faces.Add(Face);
            }
            catch (Exception e)
            {
                Log(e.Message);
            }

        }

        public void ModelAdd(
            Vector3[] Vert, Vector3[] Norm)
        {
            Plane3D Face = new Plane3D();
            Face.Color = new Vector4(fColor);
            Face.InnerDelta = InnerDelta;
            Face.InnerN = InnerN;
            Face.Tp = PlaneType;
            for (int i = 0; i < 3; ++i)
            {
                Face.Vertex[i] = new Vector3(Vert[i]);
                Face.Normals[i] = new Vector3(Norm[i]);
                Face.PerVertexLightning = true;
            }

            try
            {
                Face.CalcNormal();
                //     Log(Face.Tp.ToString());
                CurrentFigure.Faces.Add(Face);
            }
            catch (Exception e)
            {
                Log(e.Message);
            }

        }

    

   /*     static public void GPrint(Vector2 P, Color C, string Text, bool Big = false)
        {
            GColor(C);
            Utils.glPrint(new Vector3(P.x, P.y, 0), Text, Big ? 1 : 0);
        }

        static public void GPrint(double x, double y, double z, string Text, bool Big = false)
        {
            Utils.glPrint(new Vector3(x, y, z), Text, Big ? 1 : 0);
        }*/
        /*
        public TubeProcessingData t = null;
        public void TEST_Trace()
        {
           AllRays.Clear();
            InitialRays[0].Rayize();
            t = Figs[0].Faces[0].ProcessTubeStageOne(InitialRays[0]);

            if (t.cs != TTCase.CaseNo)
            {
                // Список вершин для триангуляции
                List<RealPoint> VertsForDelauney1 = new List<RealPoint>();

                // Важно, что сначала я добавляю PinTs
                for (int i = 0; i < t.PinTs.Count; ++i)
                    VertsForDelauney1.Add(t.Vert[t.PinTs[i]]);



                // Затем пересечения
                int Ic = t.Intersections.Count;
                for (int i = 0; i < Ic; ++i)
                    VertsForDelauney1.Add(new RealPoint(t.Intersections[i].u, t.Intersections[i].v));



                List<Triangle> Triangles = new List<Triangle>();

                int cnt1 = VertsForDelauney1.Count;
                // удаляем всех дублеров
                VertsForDelauney1 = VertsForDelauney1.Distinct(new RealPointComparer()).ToList();
                // сколько убавилось?
                Log("Delta -> cnt : VertsForDelauney1 = " + (VertsForDelauney1.Count - cnt1));

                if (t.cs == TTCase.CaseA)
                {
                    for (int i = 0; i < 3; ++i)
                        VertsForDelauney1.Add(t.UVs[i]);
                    Triangles.Add(new Triangle(0, 1, 2, true));
                }
                else
                {
                    // ядро триангулируем
                    Triangles = Utils2D.RoundTrianglulationWOCenter(VertsForDelauney1);

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
                            List<RealPoint> Region = new List<RealPoint>();
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
                // ТЕСТ - сохраним данные о треугольниках
                t.Pts = VertsForDelauney1;
                t.Traingles = Triangles;

            }

        }

        public void TEST_Render()
        {
            if (t == null)
                return;

            for (int i = 0; i < 3; ++i)
            {
                int j = i == 2 ? 0 : i + 1;

                GLine(t.UVs[i], t.UVs[j], Color.Red, 3.5);
                GSmallSquare(t.UVs[i], Color.PaleVioletRed);
                GPrint(t.UVs[i], Color.DeepPink, "T" + i, true);


                GLine(t.Vert[i], t.Vert[j], Color.Blue, 3.5);
                GSmallSquare(t.Vert[i], Color.LightBlue);
                GPrint(t.Vert[i], Color.MidnightBlue, "P" + i, true);
            }


            for (int i = 0; i < t.Intersections.Count; ++i)
            {
                GSmallSquare(new RealPoint(t.Intersections[i].u, t.Intersections[i].v), Color.LawnGreen);
                GPrint(new RealPoint(t.Intersections[i].u + 0.015, t.Intersections[i].v + 0.015), Color.Green, "I" + i, false);
            }

            int n = 0;
            foreach (Triangle tr in t.Traingles)
            {

                GLine(t.Pts[tr.p1], t.Pts[tr.p2], Color.Peru, 1);
                GLine(t.Pts[tr.p2], t.Pts[tr.p3], Color.Peru, 1);
                GLine(t.Pts[tr.p3], t.Pts[tr.p1], Color.Peru, 1);
                GPrint(Utils2D.CenterOfMass(t.Pts, tr), Color.OrangeRed, "(" + n + ")");
                ++n;
            }

            n = 0;
            foreach (RealPoint rp in t.Pts)
            {

                GPrint(rp - 0.02, Color.DarkSlateGray, "[" + n + "]");
                ++n;
            }

            /*  if (t.Pts.Count > 2) 
                  GLine(t.Pts[0], t.Pts[1], Color.Black, 4);

        }*/


    }
}
