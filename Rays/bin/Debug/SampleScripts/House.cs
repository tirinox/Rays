using System;
using System.Collections.Generic;
using Rays;
using Rays._3D;
using System.IO;
using System.Text;

//css_include 3DSLoader.cs

public class Script
{
	static private Rays._3D.Scene3D ss;
	static public void AddPapiped(Rays._3D.Scene3D s, Vector3 v1, Vector3 v2)
	{
		
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
				ss.InitialRays.Add(tube);
			}
	}

    static public void Load(Rays._3D.Scene3D s)
    {
		ss = s;
		s.BeginFigure();
		
		
		Model model = new ThreeDSFile( @"SampleScripts\fachwerk40T.3ds" ).ThreeDSModel;
		
		foreach(Entity e in model.Entities)
			foreach(Triangle t in e.indices)
				s.ModelAdd(
					new Vector3[3] { 
						new Vector3(e.vertices[t.vertex1].X, e.vertices[t.vertex1].Y, e.vertices[t.vertex1].Z),
						new Vector3(e.vertices[t.vertex2].X, e.vertices[t.vertex2].Y, e.vertices[t.vertex2].Z),
						new Vector3(e.vertices[t.vertex3].X, e.vertices[t.vertex3].Y, e.vertices[t.vertex3].Z) },
					new Vector3[3] { 
						new Vector3(e.normals[t.vertex1].X, e.normals[t.vertex1].Y, e.normals[t.vertex1].Z),
						new Vector3(e.normals[t.vertex2].X, e.normals[t.vertex2].Y, e.normals[t.vertex2].Z),
						new Vector3(e.normals[t.vertex3].X, e.normals[t.vertex3].Y, e.normals[t.vertex3].Z) } );
		s.EndFigure();			
		s.Figs[0].Scale1(new Vector3(10, 10, 10));
		
		InitRays(new Vector3(-100, 0, 0), 10, 50);
		
		/*s.Add(-50, 0, -50, 50, 10, -50, 50, 20, 50);
		s.Add(-50, 0, -50, 50, 20, 50, -50, 10, 50);
		*/
		
    }
}
	
	