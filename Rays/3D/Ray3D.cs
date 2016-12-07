using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace Rays._3D
{
    [Serializable]
    public class Ray3D
    {
        public Vector3 Begin = new Vector3();
        public Vector3 End = new Vector3();
        
  
        public double Path = 0;

        public static CW cw = null;
        public static void Log(string s)
        {
            if (cw != null)
                cw("Ray3D: " + s);
        }

        public Ray3D(Vector3 begin, Vector3 end, Ray3D parrent = null)
        {
            Begin = new Vector3(begin);
            End = new Vector3(end);
            if (parrent != null)
            {
                Path = parrent.Path;
            }
        }

        public Ray3D(Vector3 begin, Vector3 end)
        {
            Begin = new Vector3(begin);
            End = new Vector3(end);
        }

        public Ray3D(Ray3D old)
        {
            Begin = new Vector3(old.Begin);
            End = new Vector3(old.End);
            Path = old.Path;
        }

        public Ray3D()
        {
        }

        public Ray3D(double xb, double yb, double zb, double xe, double ye, double ze)
        {
            Begin = new Vector3(xb, yb, zb);
            End = new Vector3(xe, ye, ze);
        }

        public void AddPath(Ray3D parrent, double MediumN)
        {
            Path += (parrent.End - parrent.Begin).Magnitude * MediumN;
        }

        public void Rayize()
        {
            SetLenght(Tracer3D.InfinityM);
        }

        public void AntiRayize()
        {
            Vector3 p = Begin - End;
            p.Normalize();
            p *= Tracer3D.InfinityM * 2;
            Begin = End + p;
        }

        public void Render()
        {
            Gl.glBegin(Gl.GL_LINE_STRIP);

            
            Gl.glVertex3dv(Begin.Array);
            Gl.glVertex3dv(End.Array);


            Gl.glEnd();
        }

        public static double FresnelFormulaR(double n1, double n2, double thetaI, double thetaT, bool IsSPolarization = true)
        {
            double Numerator, Denominator;
            if (IsSPolarization)
            {
                Numerator = n1 * Math.Cos(thetaI) - n2 * Math.Cos(thetaT);
                Denominator = n1 * Math.Cos(thetaI) + n2 * Math.Cos(thetaT);
            }
            else
            {
                Numerator = n1 * Math.Cos(thetaT) - n2 * Math.Cos(thetaI);
                Denominator = n1 * Math.Cos(thetaT) + n2 * Math.Cos(thetaI);
            }
            return Numerator * Numerator / (Denominator * Denominator);
        }

        public void Dump()
        {
            if(cw != null)
                cw(" Begin = " + Begin.ToString() + " end = " + End.ToString());
        }

        public void SetLenght(double Len)
        {
            Vector3 p = End - Begin;
            p.Normalize();
            p *= Len;
            End = Begin + p;         
        }

        public double GetT(Vector3 Pt)
        {
            double N, D;
            if (Math.Abs(Begin.X - End.X) > Tracer3D.GeometryEpsilon)
            {
                N = Pt.X - Begin.X;
                D = End.X - Begin.X;
            }
            else if (Math.Abs(Begin.Y - End.Y) > Tracer3D.GeometryEpsilon)
            {
                N = Pt.Y - Begin.Y;
                D = End.Y - Begin.Y;
            }
            else
            {
                N = Pt.Z - Begin.Z;
                D = End.Z - Begin.Z;
            }


            return N / D;
        }
    }
}
