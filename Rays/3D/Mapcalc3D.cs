using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MatrixLibrary;
using Tao.OpenGl;

namespace Rays._3D
{
    public enum MapType3D
    {
        Linear = 0,
        Plane = 1,
        Sphere = 2
    }

    [Serializable]
    public class MapcalcRecord3D
    {
        [XmlAttribute]
        public MapType3D Type = MapType3D.Linear;

        public Vector3 Begin = new Vector3(0, 0, 0);
        public Vector3 End = new Vector3(1, 0, 0);
        public double Dorr = 1.0;
        public int Details = 100;

        public MapcalcRecord3D(MapcalcRecord3D P)
        {
            Type = P.Type;
            Begin = new Vector3(P.Begin);
            End = new Vector3(P.End);
            Dorr = P.Dorr;
            Details = P.Details;
        }

        public MapcalcRecord3D()
        { }
    }

    public class MapcalcPoint3D
    {
        public Vector3 P = new Vector3();
        public double A = 0;
        public double Phi = 0;
        public int Waves = 0;
    }

    public class Mapcalc3D
    {
        public MapcalcRecord3D Params = new MapcalcRecord3D();

        public List<MapcalcPoint3D> CalcPts = new List<MapcalcPoint3D>();

        public Mapcalc3D(MapcalcRecord3D P)
        {
            Params = new MapcalcRecord3D(P);
        }

        public void GenerateCalculationPoints()
        {
            if (Params.Details < 1 || Params.Details > 10000)
                throw new Exception("Mapcalc3D: invalid detail number = " + Params.Details);
            CalcPts.Clear();

            if (Params.Type == MapType3D.Linear)
            {
                double Fac = 1.0 / Params.Details;
                for (int i = 0; i < Params.Details; ++i)
                {
                    double control = Fac * i;
                    MapcalcPoint3D P = new MapcalcPoint3D();
                    P.P = Vector3.Interpolate(Params.Begin, Params.End, control);
                    CalcPts.Add(P);
                }
            }
        }
    }
}
