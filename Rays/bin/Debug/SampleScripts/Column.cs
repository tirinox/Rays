using System;
using System.Collections.Generic;
using Rays;
using Rays._3D;
using System.IO;
using System.Text;

//css_include 3DSLoader.cs

public class Script
{
	static public void AddPapiped(Rays._3D.Scene3D s, Vector3 v1, Vector3 v2)
	{
		
	}

    static public void Load(Rays._3D.Scene3D s)
    {
		s.BeginFigure();
		
		
		Model model = new ThreeDSFile( @"SampleScripts\12column-model-3d.3DS" ).ThreeDSModel;
		
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
		s.Figs[0].Rotate1(Math.PI / 2, 'x');
		s.Figs[0].Transpose1(new Vector3(0, 0, 0));
		
		Tube3D tube = new Tube3D();

		tube.Rays[0].Begin = new Vector3(3, -100, 2);
		tube.Rays[1].Begin = new Vector3(20, -100, 2);
		tube.Rays[2].Begin = new Vector3(1, -100, 20);
		
		tube.Rays[0].End = new Vector3(3, -11, 2);
		tube.Rays[1].End = new Vector3(20, -11, 2);
		tube.Rays[2].End = new Vector3(1, -11, 20);
		
		tube.Rayize();
		
		s.InnerN = 1.5;
		
		s.InitialRays.Add(tube);
		
		/*s.Add(-50, 0, -50, 50, 10, -50, 50, 20, 50);
		s.Add(-50, 0, -50, 50, 20, 50, -50, 10, 50);
		*/
		
    }
}
	
	