using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Tao.OpenGl;

namespace Rays._3D
{
 
    [Serializable]
    public class Tube3D
    {
        public enum RenderStyle
        {
            FullPolyhedron,
            CenterDirectionOnly
        }

        public Ray3D[] Rays = new Ray3D[3];

        [XmlAttribute]
        public double Power = 1;

        // на заметку, если антенна в среде, MyN надо менять! хотя такое будет врядли...
        [XmlAttribute]
        public double MyN = 1;
        [XmlAttribute]
        public double MyDelta = 0;
        [XmlAttribute]
        public bool IsSPolarization = true;

        public string Comment = "";

        [XmlIgnore]
        public bool Mark = false;
        [XmlAttribute]
        public double AreaTopC = 1;

        [XmlIgnore]
        public Plane3D Prohibit = null;

        [XmlIgnore]
        public static CW cw = null;

        [XmlIgnore]
        public static bool RayAlphaPower = false;

        [XmlElement]
        public Vector4 Color = new Vector4(1, 0, 0, 1);


        public static void Log(string s)
        {
            if (cw != null)
                cw("Tracer3D: " + s);
        }

        public Tube3D(Tube3D old)
        {
            MyN = old.MyN;
            MyDelta = old.MyDelta;
            IsSPolarization = old.IsSPolarization;
            for (int i = 0; i < 3; ++i)
                Rays[i] = new Ray3D(old.Rays[i]);
        }

        public Tube3D()
        {
            for (int i = 0; i < 3; ++i)
                Rays[i] = new Ray3D();
        }

        public void Render(RenderStyle Style)
        {

            Gl.glColor4d(Color.X, Color.Y, Color.Z, RayAlphaPower ? Power : 1);

            if (Style == RenderStyle.CenterDirectionOnly)
            {
                Gl.glVertex3dv((0.333 * (Rays[0].Begin + Rays[1].Begin + Rays[2].Begin)).Array);
                Gl.glVertex3dv((0.333 * (Rays[0].End + Rays[1].End + Rays[2].End)).Array);
            }
            else if (Style == RenderStyle.FullPolyhedron)
            {
                for (int i = 0; i < 3; ++i)
                {
                    int j = i == 2 ? 0 : i + 1;
                    Gl.glVertex3dv(Rays[i].Begin.Array);
                    Gl.glVertex3dv(Rays[j].Begin.Array);
                    Gl.glVertex3dv(Rays[i].End.Array);
                    Gl.glVertex3dv(Rays[j].End.Array);
                    Gl.glVertex3dv(Rays[i].Begin.Array);
                    Gl.glVertex3dv(Rays[i].End.Array);
                }
            }

          
        }

        public void Rayize()
        {
            for (int i = 0; i < 3; ++i)
                Rays[i].Rayize();
        }

        public void AntiRayize()
        {
            for (int i = 0; i < 3; ++i)
                Rays[i].AntiRayize();
        }

        public void SetLenght(double Len)
        {
            for (int i = 0; i < 3; ++i)
                Rays[i].SetLenght(Len);
        }

        public void Sample()
        {
            Rays[0] = new Ray3D(
                new Vector3(-30, -80, 30), new Vector3(-35, -30, 30));
            Rays[1] = new Ray3D(
                new Vector3(30, -80, 30), new Vector3(35, -30, 30));
            Rays[2] = new Ray3D(
                new Vector3(0, -80, -20), new Vector3(0, -30, -20));
            Rayize();
        }

        public void Dump()
        {
            Log("Tube: power = " + Power);
            for (int i = 0; i < 3; ++i)
                Rays[i].Dump();
        }

        public Tube3D Split(int SaveVertex, int FirstEdgeIndex, Vector3 One, Vector3 Two)
        {
            Tube3D t = new Tube3D(this);
            t.Rays[SaveVertex] = new Ray3D(Rays[SaveVertex]);

            int LastIndex = 3 - SaveVertex - FirstEdgeIndex;


            double FirstEdgeSplitFactor = Rays[SaveVertex].End.Distance(One) / Rays[FirstEdgeIndex].End.Distance(Rays[SaveVertex].End);
            double SecondEdgeSplitFactor = Rays[SaveVertex].End.Distance(Two) / Rays[LastIndex].End.Distance(Rays[SaveVertex].End);

            Vector3 BottomOne = Rays[SaveVertex].Begin.Interpolate(Rays[FirstEdgeIndex].Begin, FirstEdgeSplitFactor);
            Vector3 BottomTwo = Rays[SaveVertex].Begin.Interpolate(Rays[LastIndex].Begin, SecondEdgeSplitFactor);

            t.Rays[FirstEdgeIndex] = new Ray3D(BottomOne, One, Rays[FirstEdgeIndex]);
            t.Rays[LastIndex] = new Ray3D(BottomTwo, Two, Rays[LastIndex]);

            return t;
        }

        public Tube3D Split2(int SaveVertex, int FirstEdgeIndex, Vector3 One, Vector3 Two)
        {
            Tube3D t = new Tube3D(this);
            t.Rays[SaveVertex] = new Ray3D(Rays[SaveVertex]);

            int LastIndex = 3 - SaveVertex - FirstEdgeIndex;


            double FirstEdgeSplitFactor = Rays[SaveVertex].End.Distance(One) / Rays[FirstEdgeIndex].End.Distance(Rays[SaveVertex].End);
            double SecondEdgeSplitFactor = Rays[FirstEdgeIndex].End.Distance(Two) / Rays[LastIndex].End.Distance(Rays[FirstEdgeIndex].End);

            Vector3 BottomOne = Rays[SaveVertex].Begin.Interpolate(Rays[FirstEdgeIndex].Begin, FirstEdgeSplitFactor);
            Vector3 BottomTwo = Rays[FirstEdgeIndex].Begin.Interpolate(Rays[LastIndex].Begin, SecondEdgeSplitFactor);

            t.Rays[FirstEdgeIndex] = new Ray3D(BottomOne, One, Rays[FirstEdgeIndex]);
            t.Rays[LastIndex] = new Ray3D(BottomTwo, Two, Rays[LastIndex]);

            return t;
        }

        public Tube3D UniversalSplit(Vector3[] Points)
        {
            Tube3D t = new Tube3D(this);


            
            Plane3D UpperPlane = new Plane3D(Rays[0].End, Rays[1].End, Rays[2].End, false);

            try
            {
                UpperPlane.CalcNormal();
            }
            catch
            {
                return null;
            }

            Plane3D LowerPlane = new Plane3D(Rays[0].Begin, Rays[1].Begin, Rays[2].Begin, false);

            for (int i = 0; i < 3; ++i)
            {
                double u, v, n;
                UpperPlane.GetUV(Points[i], out u, out v, out n);
                t.Rays[i] = new Ray3D(LowerPlane.UVToXYZ(u, v), Points[i], t.Rays[i]);
            }
            return t;
        }

        public void SetColor(Vector4 Color)
        {
            this.Color = new Vector4(Color);
        }

        public double AreaTop()
        {
            AreaTopC = 0.5 * (Rays[2].End - Rays[0].End).CrossProduct(Rays[1].End - Rays[0].End).Magnitude;
            return AreaTopC;
        }

        public Vector3 CenterDirection()
        {
            return ((this.Rays[0].End + this.Rays[1].End + this.Rays[2].End) - (this.Rays[0].Begin + this.Rays[1].Begin + this.Rays[2].Begin)) * 0.333333;
        }

        public bool UnderLowerPlane(Vector3 Pt)
        {
            return (Rays[0].End - Rays[0].Begin).DotProduct(Pt - Rays[0].Begin) < 0;
        }

        public bool WrongTubeTest()
        {
            for (int i = 0; i < 3; ++i)
                if (Math.Sqrt(Rays[i].End.Z * Rays[i].End.Z + Rays[i].End.Y * Rays[i].End.Y) > 300)
                    return true;

            return false;
        }

        public bool PointIntersection(Vector3 P)
        {
            return false;
        }
    }
}
