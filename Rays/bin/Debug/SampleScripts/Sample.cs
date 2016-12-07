using System;
using System.Collections.Generic;
using Rays;
using Rays._3D;
using System.IO;
using System.Text;

public class Script
{
	private static Random r = new Random();
	static public void AddPapiped(Rays._3D.Scene3D s, Vector3 v1, Vector3 v2)
	{
		
	}
	
	static public void AddQuad(Rays._3D.Scene3D s, Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4)
	{
		s.Add(v1.X, v1.Y, v1.Z, v2.X, v2.Y, v2.Z, v3.X, v3.Y, v3.Z);
		//s.Add(v3.X, v3.Y, v3.Z, v2.X, v2.Y, v2.Z, v4.X, v4.Y, v4.Z);
	}
	
	static private double RD(double Min, double Max)
	{
		return Min + r.NextDouble() * (Max - Min);
	}

    static public void Load(Rays._3D.Scene3D s)
    {
		s.BeginFigure();
		s.PlaneType = PlaneType.Normal;
		s.InnerDelta = 0;

		
		Tube3D tube = new Tube3D();
		
		tube.Rays[0].Begin = new Vector3(-10, -100, 20);
		tube.Rays[1].Begin = new Vector3(20, -100, -40);
		tube.Rays[2].Begin = new Vector3(20, -100, 20);
		
		tube.Rays[0].End = new Vector3(-10, -10, 20);
		tube.Rays[1].End = new Vector3(20, -10, -40);
		tube.Rays[2].End = new Vector3(20, -10, 20);
		
		tube.Rayize();
		
		
		
		s.InitialRays.Add(tube);
		
		//s.Add(-50, 0, -50, 50, 10, -50, 50, 20, 50);
		//s.Add(-45, 0, -45, 55, 20, 55, -45, 10, 55);
		s.InnerN = 3.5;
		/*AddQuad(s, 
			new Vector3(-10, -50, -10),
			new Vector3(-10, -50, 10),
			new Vector3(10, -50, -10),
			new Vector3(10, -50, 10));*/
		
		double mn = -100, mx = 100;
	//	s.Add( RD(mn, mx), 0, RD(mn, mx), RD(mn, mx), 0, RD(mn, mx), RD(mn, mx), 0, RD(mn, mx));
		s.Add(-10, 0, 20, 20, 0, -40, 30, 0, 30);
		
		s.EndFigure();
	//	s.Figs[0].Rotate1(-10, 'x');
		s.Figs[0].Transpose1(0, -40, 0);
    }
}
	
	