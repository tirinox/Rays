using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rays._3D
{
    [Serializable]
    public class Vector2
    {
        public double x;
        public double y;

        public double phi;
        public int Tag;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Vector2(double u, double v)
        {
            x = u;
            y = v;
            phi = 0;
        }

        public Vector2(double u, double v, int _Tag)
        {
            x = u;
            y = v;
            phi = 0;
            Tag = _Tag;
        }

        public Vector2()
        {
            x = 0;
            y = 0;
            phi = 0;
            Tag = -1;
        }

        public Vector2(Vector2 rp)
        {
            x = rp.x;
            y = rp.y;
            phi = 0;
        }

        public void Dump(string name, CW cw)
        {
            if (cw != null)
                cw("Point <" + name + "> ( " + x + " ; " + y + " )");
        }

        public static Vector2 Middle(Vector2 p1, Vector2 p2)
        {
            return new Vector2(0.5 * (p1.x + p2.x), 0.5 * (p1.y + p2.y));
        }

        public static Vector2 Interpolate(Vector2 p1, Vector2 p2, double Control)
        {
            return new Vector2(Control * p1.x + (1 - Control) * p2.x, Control * p1.y + (1 - Control) * p2.y);
        }

        public static Vector2 operator +(Vector2 t, double add)
        {
            return new Vector2(t.x + add, t.y + add);
        }

        public static Vector2 operator -(Vector2 t, double add)
        {
            return new Vector2(t.x - add, t.y - add);
        }

        public static Vector2 operator +(Vector2 t, Vector2 add)
        {
            return new Vector2(t.x + add.x, t.y + add.y);
        }

        public static Vector2 operator -(Vector2 t, Vector2 add)
        {
            return new Vector2(t.x - add.x, t.y - add.y);
        }
    };

    public class RealPointComparer : IEqualityComparer<Vector2>
    {
        public bool Equals(Vector2 x, Vector2 y)
        {

            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return Math.Abs(x.x - y.x) + Math.Abs(x.y - y.y) < Tracer3D.GeometryEpsilon;
        }


        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Vector2 x)
        {
            return 0;// x.x.GetHashCode() ^ x.y.GetHashCode();
        }
    }

    public class Utils2D
    {

        public static double I2Diap(int i, int Details, double Min, double Max)
        {
            double zero2one = ((double)i) / Details;
            return Min + (Max - Min) * zero2one;
        }

        #region LINE_INTERSECT
        //**************************************************************
        //  CrossType
        //  типы пересечения прямых
        //**************************************************************
        public enum EnumCrossType
        {
            ctParallel,    // отрезки лежат на параллельных прямых
            ctSameLine,    // отрезки лежат на одной прямой
            ctOnBounds,    // прямые пересекаются в конечных точках отрезков
            ctInBounds,    // прямые пересекаются в   пределах отрезков
            ctOutBounds,    // прямые пересекаются вне пределов отрезков
            ctOnLine
        };

        //**************************************************************
        //  CrossResultRec
        //  результат проверки пересечения прямых
        //**************************************************************
        public struct CrossResultRec
        {
            public EnumCrossType type;  // тип пересечения
            public Vector2 pt;    // точка пересечения
        };

        //**************************************************************
        //  Crossing()
        //  проверка пересечения двух отрезков
        //**************************************************************
        public static CrossResultRec Crossing(
            Vector2 p11, Vector2 p12,   // координаты первого отрезка
            Vector2 p21, Vector2 p22)  // координаты второго отрезка
        {
            CrossResultRec result = new CrossResultRec();

            // знаменатель
            double Z = (p12.y - p11.y) * (p21.x - p22.x) - (p21.y - p22.y) * (p12.x - p11.x);
            // числитель 1
            double Ca = (p12.y - p11.y) * (p21.x - p11.x) - (p21.y - p11.y) * (p12.x - p11.x);
            // числитель 2
            double Cb = (p21.y - p11.y) * (p21.x - p22.x) - (p21.y - p22.y) * (p21.x - p11.x);

            // если числители и знаменатель = 0, прямые совпадают
            if ((Math.Abs(Z) < Tracer3D.GeometryEpsilon) && (Ca == 0) && (Cb == 0))
            {
                result.type = EnumCrossType.ctSameLine;
                return result;
            }


            // если знаменатель = 0, прямые параллельны
            if (Math.Abs(Z) < Tracer3D.GeometryEpsilon)
            {
                if (ThreePointOnTheLine(p11, p12, p21))
                    result.type = EnumCrossType.ctOnLine;
                else
                    result.type = EnumCrossType.ctParallel;
                return result;
            }


            double Ua = Ca / Z;
            double Ub = Cb / Z;

            result.pt = new Vector2();

            result.pt.x = p11.x + (p12.x - p11.x) * Ub;
            result.pt.y = p11.y + (p12.y - p11.y) * Ub;

            // если 0<=Ua<=1 и 0<=Ub<=1, точка пересечения в пределах отрезков
            if ((0 <= Ua) && (Ua <= 1) && (0 <= Ub) && (Ub <= 1))
            {
                if ((Ua == 0) || (Ua == 1) || (Ub == 0) || (Ub == 1))
                    result.type = EnumCrossType.ctOnBounds;
                else
                    result.type = EnumCrossType.ctInBounds;
            }
            // иначе точка пересечения за пределами отрезков
            else
            {
                result.type = EnumCrossType.ctOutBounds;
            }

            return result;
        }

        public static double GetParameterLinesPoint(Vector2 Bgn, Vector2 End, Vector2 Pts)
        {
            double Res = double.NaN;

            if (End.x != Bgn.x)
                Res = (Pts.x - Bgn.x) / (End.x - Bgn.x);
            else if (End.y != Bgn.y)
                Res = (Pts.y - Bgn.y) / (End.y - Bgn.y);

            return Res;
        }

        public static bool ThreePointOnTheLine(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            double v1 = p1.x * (p2.y - p3.y);
            double v2 = p2.x * (p3.y - p1.y);
            double v3 = p3.x * (p1.y - p2.y);

            return (Math.Abs(v1 + v2 + v3) < Tracer3D.GeometryEpsilon);
        }
        #endregion

        public static void AngularSort(Vector2[] Vs)
        {
            double uc = 0, vc = 0;
            for (int i = 0; i < Vs.Length; ++i)
            {
                uc += Vs[i].x;
                vc += Vs[i].y;
            }
            uc /= Vs.Length;
            vc /= Vs.Length;
            for (int i = 0; i < Vs.Length; ++i)
                Vs[i].phi = Math.Atan2(Vs[i].y - vc, Vs[i].x - uc);

            Array.Sort<Vector2>(Vs,
                delegate(Vector2 x, Vector2 y)
                {
                    if (x.phi > y.phi) return 1;
                    else if (x.phi < y.phi) return -1;
                    else return 0;
                });


        }

        public static List<Triangle> RoundTrianglulation(List<Vector2> Vs)
        {
            List<Triangle> Res = new List<Triangle>();

            Vector2 Center = Vs[0];


            Vs.RemoveAt(0);
            foreach (Vector2 v in Vs)
                v.phi = Math.Atan2(v.y - Center.y, v.x - Center.x);

            Vs.Sort(delegate(Vector2 x, Vector2 y)
            {
                if (x.phi > y.phi) return 1;
                else if (x.phi < y.phi) return -1;
                else return 0;
            });


            for (int i = 0; i < Vs.Count - 1; i++)
                Res.Add(new Triangle(0, i + 1, i + 2));
            Res.Add(new Triangle(0, 1, Vs.Count));

            Vs.Insert(0, Center);

            return Res;
        }

        public static List<Triangle> RoundTrianglulationWOCenter(List<Vector2> Vs)
        {
            List<Triangle> Res = new List<Triangle>();

            Vector2 Center = CenterOfMass(Vs);

            foreach (Vector2 v in Vs)
                v.phi = Math.Atan2(v.y - Center.y, v.x - Center.x);

            Vs.Sort(delegate(Vector2 x, Vector2 y)
            {
                if (x.phi > y.phi) return 1;
                else if (x.phi < y.phi) return -1;
                else return 0;
            });


            for (int i = 1; i < Vs.Count - 1; i++)
                Res.Add(new Triangle(0, i, i + 1, true));

            return Res;
        }

        private static int IrComparasion(IntersectRecord x, IntersectRecord y)
        {
            if (x.planeEdge1 > y.planeEdge1) return 1;
            if (x.planeEdge1 < y.planeEdge1) return -1;
            return 0;
        }

        public static bool InMe(double u, double v)
        {
            return u > 0 && v > 0 && u + v < 1;
        }

        public static Vector2 CenterOfMass(List<Vector2> Pts)
        {
            Vector2 Res = new Vector2(0, 0);

            Pts.ForEach(delegate(Vector2 P) { Res.x += P.x; Res.y += P.y; });

            Res.x /= Pts.Count;
            Res.y /= Pts.Count;
            return Res;
        }

        public static Vector2 CenterOfMass(List<Vector2> Pts, Triangle Tr)
        {
            return new Vector2(
                0.3333 * (Pts[Tr.p1].x + Pts[Tr.p2].x + Pts[Tr.p3].x),
                0.3333 * (Pts[Tr.p1].y + Pts[Tr.p2].y + Pts[Tr.p3].y));
        }

        public static double Classify(
            double ua, double va,
            double ub, double vb,
            double ut, double vt)
        {
            return ut * (vb - va) + vt * (ua - ub) + va * ub - ua * vb;
        }


    }
}
