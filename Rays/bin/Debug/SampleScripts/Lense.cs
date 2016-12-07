using System;
using System.Collections.Generic;
using Rays;
using Rays._3D;
using System.IO;
using System.Text;

public class Script
{
	static private Rays._3D.Scene3D ss;
	
	static public bool Debug = false;
	
	static int Cnt = 0;
	
	static public void AddQuad(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4)
	{
		ss.Add(v1.X, v1.Y, v1.Z, v2.X, v2.Y, v2.Z, v3.X, v3.Y, v3.Z);
		ss.Add(v3.X, v3.Y, v3.Z, v2.X, v2.Y, v2.Z, v4.X, v4.Y, v4.Z);
	}
	static public Tube3D NewTube(Vector3 Pos)
	{
		Tube3D tube = new Tube3D();
		
		for(int i = 0; i < 3; ++i)
		{
			tube.Rays[i].Begin = Pos;
			tube.Rays[i].End = Pos;
			tube.Rays[i].End.X += 1;
		}
		tube.Rayize();
		
		return tube;
	}

	static public void InitRays(Vector3 Pos, int NumSec, double A)
	{
		for(int i = 0; i < NumSec; ++i)
			for(int j = 0; j < NumSec; ++j)
			{
				if(Debug)
				if( i != 0 || j != 7) continue;
				double z1 =  (2.0 * i - NumSec) / NumSec * A;
				double y1 =  (2.0 * j - NumSec) / NumSec * A;
				double z2 =  (2.0 * (i + 1) - NumSec) / NumSec * A;
				double y2 =  (2.0 * (j + 1) - NumSec) / NumSec * A;
				
				Tube3D tube = NewTube(Pos);
				tube.Rays[0].Begin.Z += z1;
				tube.Rays[1].Begin.Z += z2;
				tube.Rays[2].Begin.Z += z1;
				tube.Rays[0].Begin.Y += y1;
				tube.Rays[1].Begin.Y += y1;
				tube.Rays[2].Begin.Y += y2;
				tube.Rays[0].End.Z += z1;
				tube.Rays[1].End.Z += z2;
				tube.Rays[2].End.Z += z1;
				tube.Rays[0].End.Y += y1;
				tube.Rays[1].End.Y += y1;
				tube.Rays[2].End.Y += y2;
				ss.InitialRays.Add(tube);
				
				/*Tube3D */tube = NewTube(Pos);
				tube.Rays[0].Begin.Z += z2;
				tube.Rays[1].Begin.Z += z1;
				tube.Rays[2].Begin.Z += z2;
				tube.Rays[0].Begin.Y += y1;
				tube.Rays[1].Begin.Y += y2;
				tube.Rays[2].Begin.Y += y2;
				tube.Rays[0].End.Z += z2;
				tube.Rays[1].End.Z += z1;
				tube.Rays[2].End.Z += z2;
				tube.Rays[0].End.Y += y1;
				tube.Rays[1].End.Y += y2;
				tube.Rays[2].End.Y += y2;
				if(!Debug)
				ss.InitialRays.Add(tube);
			}
	}
	
	static public Vector3 AngCoord(Vector3 Pos, double Ang, double Rad)
	{
		return new Vector3
			(
				Pos.X,
				Pos.Y + Rad * Math.Sin(Ang),
				Pos.Z + Rad * Math.Cos(Ang)
			);
	}
	
	static public void DrawFan(Vector3 Pos, int Num, double Rad, double Dx = 0)
	{
		++Cnt;
		if(Cnt == Num)
			Cnt = 0;
		for(int i = 0; i < Num; ++i)
		{
			//if(Debug)
			//if(i != 7 && i != 6/* && i != 5*/) continue;
			
			
		
			double Ang1 = ((double)i) / Num * Math.PI * 2;
			double Ang2 = ((double)(i + 1)) / Num * Math.PI * 2;
			
			Vector3 v1 = AngCoord(Pos, Ang1, Rad);
			Vector3 v2 = AngCoord(Pos, Ang2, Rad);
			
			ss.Add(Pos.X, Pos.Y, Pos.Z, v1.X + Dx, v1.Y, v1.Z, v2.X + Dx, v2.Y, v2.Z);
		}
	}

    static public void Load(Rays._3D.Scene3D s)
    {
		ss = s;
		s.BeginFigure();
		s.PlaneType = PlaneType.Antireflection;
		s.InnerDelta = 0;
		s.InnerN = 2;
		
		
		/*AddQuad(s, 
			new Vector3(-50, 0, -50),
			new Vector3(-50, 0, 50),
			new Vector3(50, 0, -50),
			new Vector3(50, 0, 50));
		*/
		DrawFan(new Vector3(0, 0, 0), 10, 100);
		s.EndFigure();
	//	if(!Debug) 
	
		s.BeginFigure();
		DrawFan(new Vector3(10, 0, 0), 10, 100, -10);
		s.EndFigure();
		
		
		//s.Figs[0].Rotate(-1, 'x');
		
		
		InitRays(new Vector3(-100, 0, 0), 10, 50);
	}
}
