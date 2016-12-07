using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using MatrixLibrary;
using System.Xml.Serialization;

namespace Rays._3D
{
    [Serializable]
    public class Figure3D
    {
        public string Name = "";

        public List<Plane3D> Faces = new List<Plane3D>();

        [XmlIgnore]
        public List<Plane3D> TransformedFaces = new List<Plane3D>();

        // New trasnform
        [XmlElement]
        public Vector3 Position = new Vector3(0, 0, 0);
        [XmlElement]
        public Vector3 EulerRotation = new Vector3(0, 0, 0);
        [XmlElement]
        public Vector3 Scale = new Vector3(1, 1, 1);

        [XmlAttribute]
        public int ID = 0;

        [XmlElement]
        public int ParrentID = -1;

        [XmlIgnore]
        public AABB MyAABB = new AABB();

        [XmlElement]
        public bool Enabled = true;

        [XmlIgnore]
        public static CW Cw = null;

        [XmlIgnore]
        public VBO Vbo = new VBO();

        public static void Log(string s)
        {
            if (Cw != null)
                Cw("Figure3D: " + s);
        }

        public string GetName()
        {
            return Name == string.Empty ? "Фигура ID" + ID.ToString() : Name;
        }

        public void BuildVBO(bool Selected)
        {
            if (Selected)
                Vbo.Colorizer(true, new Vector4(1, 0, 1, 1));
            else
                Vbo.Colorizer(false);
            Vbo.Build(this.TransformedFaces);
        }

        public AABB GetClearAABB()
        {
            AABB aabb = new AABB();
            foreach (Plane3D F in Faces)
                for (int i = 0; i < 3; ++i)
                    aabb.Extend(F.Vertex[i]);
            return aabb;
        }

        public void Render1(bool Pick, bool Selected, bool Transformed)
        {
            List<Plane3D> WhatISee = Transformed ? TransformedFaces : Faces; //OctreeEnabled ? MyOctree.WalkTree(Frustum) : MergedFaces;

            if (Pick)
                Gl.glDisable(Gl.GL_LIGHTING);
            else
                Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            int CurID = WhatISee.Count > 0 ? WhatISee[0].ID : 0;
            Gl.glLoadName(CurID);

            Gl.glBegin(Gl.GL_TRIANGLES);

            foreach (Plane3D P in WhatISee)
            {
                if (!Pick)
                {
                    if (Selected)
                        Gl.glColor4dv(new double[] { 1, 0, 1, 1 });
                    else
                        Gl.glColor4dv(P.Color.Array);
                }

                if (!P.PerVertexLightning)
                {
                    Gl.glNormal3dv(P.Normal.Array);

                    Gl.glVertex3dv(P.Vertex[0].Array);
                    Gl.glVertex3dv(P.Vertex[1].Array);
                    Gl.glVertex3dv(P.Vertex[2].Array);
                }
                else
                {
                    Gl.glNormal3dv(P.Normals[0].Array);
                    Gl.glVertex3dv(P.Vertex[0].Array);
                    Gl.glNormal3dv(P.Normals[1].Array);
                    Gl.glVertex3dv(P.Vertex[1].Array);
                    Gl.glNormal3dv(P.Normals[2].Array);
                    Gl.glVertex3dv(P.Vertex[2].Array);
                }
            }
            Gl.glEnd();

            Gl.glDisable(Gl.GL_LIGHTING);

            if (!Pick && Rays.Properties.Settings.Default.FaceHighlight)
            {
                Gl.glLineWidth(0.2f);
                Gl.glBegin(Gl.GL_LINE_STRIP);

                Utils.GColor(Rays.Properties.Settings.Default.FaceHighlightColor);

                foreach (Plane3D P in Faces)
                {
                    Gl.glVertex3dv(P.Vertex[0].Array);
                    Gl.glVertex3dv(P.Vertex[1].Array);
                    Gl.glVertex3dv(P.Vertex[2].Array);
                    Gl.glVertex3dv(P.Vertex[0].Array);
                }
                Gl.glEnd();
            }

            if (!Pick && Selected)
            {
                Utils.GColor(System.Drawing.Color.DeepPink);
                Gl.glLineWidth(3);
                MyAABB.Render();
            }

        //    Vector3 c = FindCenter(true);
          //  Log("Center = " + c.X + " ; " + c.Y + " ; " + c.Z);
        }

        public void Render(bool Pick, bool Selected)
        {
            if (!Pick)
            {
                Vbo.Render();
                if (Selected)
                {
                    Utils.GColor(System.Drawing.Color.DeepPink);
                    Gl.glLineWidth(3);
                    MyAABB.Render();
                }
            }
            else
                Render1(true, false, true);
        }

        public Figure3D(Scene3D s)
        {
            if (ID == 0)
                ID = s.GenerateFreeID();
        }

        public Figure3D()
        {
            if (ID == 0)
                ID = (new Random(DateTime.Now.Millisecond)).Next();
        }

        public Matrix GetTrasnformRecursive(Scene3D s, int Call = 0)
        {
            if (Call > 10)
                return new Matrix(Matrix.Identity(4));

            Figure3D ParrentF = s.Figs.Find(f => f.ID == this.ParrentID);

            if (ParrentF == null)
                return TransformToMatrix();
            else
                return TransformToMatrix() * ParrentF.GetTrasnformRecursive(s, Call + 1);

        }

        public Matrix TransformToMatrix()
        {
            Vector4 Quat = Vector4.QuatEuler(EulerRotation * 0.00555555 * Math.PI);
            Quat.QuatNormalize();
            Matrix Rotation = Quat.QuatToMatrix44();
            Matrix Translation = Matrix.Translate44(
                new Vector3(Position.X / Scale.X, Position.Y / Scale.Y, Position.Z / Scale.Z));
            
            Matrix Scalation = Matrix.Scale44(Scale);
            return Scalation * Translation * Rotation; // full matrix?
        }

        public void ApplyTransform(Scene3D s)
        {
            TransformedFaces.Clear();
            MyAABB = new AABB();

            Matrix TrfM = TransformToMatrix();

            Figure3D ParrentF = s.Figs.Find(f => f.ID == this.ParrentID);
            Matrix ParrentM = ParrentF != null ? ParrentF.GetTrasnformRecursive(s, 0) : null;

            foreach (Plane3D F in Faces)
            {
                Plane3D newF = new Plane3D(F);
                for (int i = 0; i < 3; ++i)
                {
                    if (ParrentF != null)
                        newF.Vertex[i] = newF.Vertex[i].MultMatrix(ParrentM);
                    newF.Vertex[i] = newF.Vertex[i].MultMatrix(TrfM);
                    MyAABB.Extend(newF.Vertex[i]);
                }
                newF.ID = ID;
                newF.CalcNormal();
                TransformedFaces.Add(newF);
            }
        }

        public void Sample(string Case, int Num)
        {
            Faces.Clear();
            if (Case == "a")
                Faces.Add(
                new Plane3D(
                    new Vector3(-100, 0, 50),
                    new Vector3(100, 10, 50),
                    new Vector3(0, 20, -35)
                    ));
            if (Case == "b")
                Faces.Add(
                new Plane3D(
                    new Vector3(-50, 0, 10),
                    new Vector3(50, 10, 10),
                    new Vector3(0, 20, -35)
                    ));

            if (Case == "v")
                Faces.Add(
                new Plane3D(
                    new Vector3(-50, 0, -35),
                    new Vector3(50, 10, -35),
                    new Vector3(0, 20, 10)
                    ));
            if (Case == "g")
                Faces.Add(
                new Plane3D(
                    new Vector3(-50, 0, -35),
                    new Vector3(50, 10, -35),
                    new Vector3(0, 20, 60)
                    ));
            if (Case == "d")
                Faces.Add(
                new Plane3D(
                    new Vector3(-50, 0, -5),
                    new Vector3(50, 10, -5),
                    new Vector3(0, 20, 75)
                    ));
            if (Case == "e")
                Faces.Add(
                new Plane3D(
                    new Vector3(-80, 0, -5),
                    new Vector3(80, 10, -5),
                    new Vector3(0, 20, 90)
                    ));
            if (Case == "zh")
                Faces.Add(
                new Plane3D(
                    new Vector3(-80, 0, -5),
                    new Vector3(80, 10, -5),
                    new Vector3(80, 20, 15)
                    ));
            if (Case == "z")
                Faces.Add(
                new Plane3D(
                    new Vector3(-8, 0, -2),
                    new Vector3(8, 10, -2),
                    new Vector3(8, 20, 14)
                    ));

            if (Case == "i")
                Faces.Add(
                new Plane3D(
                    new Vector3(-20, 0, 50),
                    new Vector3(20, 10, 50),
                    new Vector3(0, 20, -5)
                    ));
            if (Case == "k")
                Faces.Add(
                new Plane3D(
                    new Vector3(-100, 0, 50),
                    new Vector3(100, 10, 50),
                    new Vector3(0, 20, -5)
                    ));
            if (Case == "l")
                Faces.Add(
                new Plane3D(
                    new Vector3(-50, 0, 10),
                    new Vector3(50, 10, 10),
                    new Vector3(0, 20, -5)
                    ));
            if (Case == "m")
                Faces.Add(
                new Plane3D(
                    new Vector3(-15, 0, 15),
                    new Vector3(15, 10, 15),
                    new Vector3(0, 20, 75)
                    ));
        }



        public void Transpose1(double x, double y, double z)
        {
            Transpose1(new Vector3(x, y, z));
        }

        public void Transpose1(Vector3 Place)
        {
            foreach (Plane3D Face in Faces)
                for (int i = 0; i < 3; ++i)
                    Face.Vertex[i] += Place;
        }

        public Vector3 Center;

        public Vector3 FindCenter(bool Transformed)
        {
            Center = new Vector3(0, 0, 0);
            int Num = 0;
            var FaceList = Transformed ? TransformedFaces : Faces;
            foreach (Plane3D Face in FaceList)
            {
                for (int i = 0; i < 3; ++i)
                    Center += Face.Vertex[i];
                Num += 3;
            }
            Center = Num > 0 ? Center / Num : Center;
            return Center;
        }

        public void Rotate1(double Ang, char Axis)
        {
            Ang = Ang / 180 * Math.PI;
            double cos = Math.Cos(Ang);
            double sin = Math.Sin(Ang);

            switch (Axis)
            {
                case 'z':
                case 'Z':
                    foreach (Plane3D Face in Faces)
                        for (int i = 0; i < 3; ++i)
                        {
                            Face.Vertex[i] = new Vector3(
                                Face.Vertex[i].X * cos - Face.Vertex[i].Y * sin,
                                Face.Vertex[i].X * sin + Face.Vertex[i].Y * cos,
                                Face.Vertex[i].Z
                                );
                            Face.CalcNormal();
                        }
                    break;
                case 'x':
                case 'X':
                    foreach (Plane3D Face in Faces)
                        for (int i = 0; i < 3; ++i)
                        {
                            Face.Vertex[i] = new Vector3(
                                Face.Vertex[i].X,
                                Face.Vertex[i].Y * cos - Face.Vertex[i].Z * sin,
                                Face.Vertex[i].Y * sin + Face.Vertex[i].Z * cos
                                );
                            Face.CalcNormal();
                        }
                    break;
                case 'y':
                case 'Y':
                    foreach (Plane3D Face in Faces)
                        for (int i = 0; i < 3; ++i)
                        {
                            Face.Vertex[i] = new Vector3(
                                Face.Vertex[i].Z * sin - Face.Vertex[i].X * cos,
                                Face.Vertex[i].Y,
                                Face.Vertex[i].Z * cos + Face.Vertex[i].X * sin
                                );
                            Face.CalcNormal();
                        }
                    break;
            }
        }

        public void Scale1(Vector3 ScaleXYZ)
        {
            foreach (Plane3D Face in Faces)
                for (int i = 0; i < 3; ++i)
                    Face.Vertex[i] = new Vector3(
                        Face.Vertex[i].X * ScaleXYZ.X,
                        Face.Vertex[i].Y * ScaleXYZ.Y,
                        Face.Vertex[i].Z * ScaleXYZ.Z);

        }

        public void Scale1(double x, double y, double z)
        {
            Scale1(new Vector3(x, y, z));
        }



    }
}
