using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using Rays._3D;

namespace Rays
{
    public class VBO
    {
        private bool Created = false;

        public const int VertexIndex = 0;
        public const int NormalIndex = 1;
        public const int ColorIndex = 2;
        public const int TextureIndex = 3;
        public const int PrimitiveIndex = 4;
        public const int MaxIndex = 5;

        private int NumOfPrim = 0;
        private int Mode = Gl.GL_TRIANGLES;
        private float LineWidth = 1.0f;
        private bool Colorized = false;
        private Vector4 MyColor = new Vector4();

        private int[] bufs = new int[MaxIndex];

        public static CW Cw = null;

        public static void Log(string s)
        {
            if (Cw != null)
                Cw("VBO: " + s);
        }

        public void Colorizer(bool Enable, Vector4 MyColor)
        {
            Colorized = Enable;
            this.MyColor = MyColor;
        }

        public void Colorizer(bool Enable)
        {
            Colorized = Enable;
        }

        public void Render()
        {
            if (!Created)
                return;

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[VertexIndex]);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, IntPtr.Zero);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[ColorIndex]);
            Gl.glColorPointer(4, Gl.GL_FLOAT, 0, IntPtr.Zero);
            if (Mode != Gl.GL_LINES)
            {
                Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[NormalIndex]);
                Gl.glNormalPointer(Gl.GL_FLOAT, 0, IntPtr.Zero);
                Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[TextureIndex]);
                Gl.glTexCoordPointer(2, Gl.GL_FLOAT, 0, IntPtr.Zero);
            }
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, bufs[PrimitiveIndex]);
            Utils.AssertGLError("bind VBO-s");

            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);

            int Multip;
            if (Mode != Gl.GL_LINES)
            {
                Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
                Gl.glEnableClientState(Gl.GL_TEXTURE_COORD_ARRAY);
                Multip = 3;
            }
            else
            {
                Gl.glLineWidth(LineWidth);
                Multip = 2;
            }
            Utils.AssertGLError("enable VBO-s");

            Gl.glDrawElements(Mode, Multip * NumOfPrim, Gl.GL_UNSIGNED_INT, IntPtr.Zero);
            Utils.AssertGLError("draw VBO-s");

            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
            if (Mode != Gl.GL_LINES)
            {
                Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);
                Gl.glDisableClientState(Gl.GL_TEXTURE_COORD_ARRAY);
            }
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, 0);
        }

        public void Generate()
        {
            if (Created)
            {
                Free();
            }
            bufs = new int[MaxIndex] { 0, 0, 0, 0, 0 };
            Gl.glGenBuffers(MaxIndex, bufs);
            Utils.AssertGLError("genearate VBO-s");

            Created = true;
        }

        public void Free()
        {
            Gl.glDeleteBuffers(MaxIndex, bufs);
            Created = false;
        }
        /*
        public void Build(List<Tube3D> Rays, double LineWidth, Tube3D.RenderStyle Rs, int PercentVisible)
        {
            Generate();
            this.LineWidth = (float)LineWidth;
            Mode = Gl.GL_LINES;

            NumOfPrim = Rs == Tube3D.RenderStyle.CenterDirectionOnly ? Rays.Count : Rays.Count * 9;

            int Skiper;
            switch (PercentVisible)
            {
                case 50: Skiper = 2; break;
                case 25: Skiper = 4; break;
                case 10: Skiper = 10; break;
                case 5: Skiper = 20; break;
                case 1: Skiper = 100; break;
                case 100:
                default:
                    Skiper = 1;
                    break;
            }

            Log("Total prim num = " + NumOfPrim);
            NumOfPrim /= Skiper;
            Log("After decimation prim num = " + NumOfPrim);
            

            int[] Elements = new int[NumOfPrim * 2];
            float[] Vertex = new float[NumOfPrim * 6];
            float[] Colors = new float[NumOfPrim * 8];

            for (int j = 0, i = -1; j < Rays.Count; ++j)
            {
                if (j % Skiper == 0)
                    ++i;
                else
                    continue;
                int j2 = i * 2;
                Elements[j2 + 0] = j2;
                Elements[j2 + 1] = j2 + 1;

                if (Rs == Tube3D.RenderStyle.CenterDirectionOnly)
                {
                    int j6 = i * 6;
                    Vector3 Begin = 0.333 * (Rays[j].Rays[0].Begin + Rays[j].Rays[1].Begin + Rays[j].Rays[2].Begin);
                    Vector3 End = 0.333 * (Rays[j].Rays[0].End + Rays[j].Rays[1].End + Rays[j].Rays[2].End);
                    Vertex[j6 + 0] = (float)Begin.X;
                    Vertex[j6 + 1] = (float)Begin.Y;
                    Vertex[j6 + 2] = (float)Begin.Z;
                    Vertex[j6 + 3] = (float)End.X;
                    Vertex[j6 + 4] = (float)End.Y;
                    Vertex[j6 + 5] = (float)End.Z;

                    int j8 = i * 8;

                    Colors[j8 + 0] = (float)Rays[j].Color.X;
                    Colors[j8 + 1] = (float)Rays[j].Color.Y;
                    Colors[j8 + 2] = (float)Rays[j].Color.Z;
                    Colors[j8 + 3] = (float)Rays[j].Color.A;

                    Colors[j8 + 4] = (float)Rays[j].Color.X;
                    Colors[j8 + 5] = (float)Rays[j].Color.Y;
                    Colors[j8 + 6] = (float)Rays[j].Color.Z;
                    Colors[j8 + 7] = (float)Rays[j].Color.A;
                }
                else
                {
                    int j54 = i * 54;
                    Vertex[j54 + 0] = (float)Rays[j].Rays[0].Begin.X;
                    Vertex[j54 + 1] = (float)Rays[j].Rays[0].Begin.Y;
                    Vertex[j54 + 2] = (float)Rays[j].Rays[0].Begin.Z;
                    Vertex[j54 + 3] = (float)Rays[j].Rays[0].End.X;
                    Vertex[j54 + 4] = (float)Rays[j].Rays[0].End.Y;
                    Vertex[j54 + 5] = (float)Rays[j].Rays[0].End.Z;
                    Vertex[j54 + 6] = (float)Rays[j].Rays[1].Begin.X;
                    Vertex[j54 + 7] = (float)Rays[j].Rays[1].Begin.Y;
                    Vertex[j54 + 8] = (float)Rays[j].Rays[1].Begin.Z;
                    Vertex[j54 + 9] = (float)Rays[j].Rays[1].End.X;
                    Vertex[j54 + 10] = (float)Rays[j].Rays[1].End.Y;
                    Vertex[j54 + 11] = (float)Rays[j].Rays[1].End.Z;
                    Vertex[j54 + 12] = (float)Rays[j].Rays[2].Begin.X;
                    Vertex[j54 + 13] = (float)Rays[j].Rays[2].Begin.Y;
                    Vertex[j54 + 14] = (float)Rays[j].Rays[2].Begin.Z;
                    Vertex[j54 + 15] = (float)Rays[j].Rays[2].End.X;
                    Vertex[j54 + 16] = (float)Rays[j].Rays[2].End.Y;
                    Vertex[j54 + 17] = (float)Rays[j].Rays[2].End.Z;

                    Vertex[j54 + 18] = (float)Rays[j].Rays[0].End.X;
                    Vertex[j54 + 19] = (float)Rays[j].Rays[0].End.Y;
                    Vertex[j54 + 20] = (float)Rays[j].Rays[0].End.Z;
                    Vertex[j54 + 21] = (float)Rays[j].Rays[2].End.X;
                    Vertex[j54 + 22] = (float)Rays[j].Rays[2].End.Y;
                    Vertex[j54 + 23] = (float)Rays[j].Rays[2].End.Z;

                    Vertex[j54 + 24] = (float)Rays[j].Rays[1].End.X;
                    Vertex[j54 + 25] = (float)Rays[j].Rays[1].End.Y;
                    Vertex[j54 + 26] = (float)Rays[j].Rays[1].End.Z;
                    Vertex[j54 + 27] = (float)Rays[j].Rays[2].End.X;
                    Vertex[j54 + 28] = (float)Rays[j].Rays[2].End.Y;
                    Vertex[j54 + 29] = (float)Rays[j].Rays[2].End.Z;

                    Vertex[j54 + 30] = (float)Rays[j].Rays[0].End.X;
                    Vertex[j54 + 31] = (float)Rays[j].Rays[0].End.Y;
                    Vertex[j54 + 32] = (float)Rays[j].Rays[0].End.Z;
                    Vertex[j54 + 33] = (float)Rays[j].Rays[1].End.X;
                    Vertex[j54 + 34] = (float)Rays[j].Rays[1].End.Y;
                    Vertex[j54 + 35] = (float)Rays[j].Rays[1].End.Z;

                    Vertex[j54 + 36] = (float)Rays[j].Rays[0].Begin.X;
                    Vertex[j54 + 37] = (float)Rays[j].Rays[0].Begin.Y;
                    Vertex[j54 + 38] = (float)Rays[j].Rays[0].Begin.Z;
                    Vertex[j54 + 39] = (float)Rays[j].Rays[2].Begin.X;
                    Vertex[j54 + 40] = (float)Rays[j].Rays[2].Begin.Y;
                    Vertex[j54 + 41] = (float)Rays[j].Rays[2].Begin.Z;

                    Vertex[j54 + 42] = (float)Rays[j].Rays[1].Begin.X;
                    Vertex[j54 + 43] = (float)Rays[j].Rays[1].Begin.Y;
                    Vertex[j54 + 44] = (float)Rays[j].Rays[1].Begin.Z;
                    Vertex[j54 + 45] = (float)Rays[j].Rays[2].Begin.X;
                    Vertex[j54 + 46] = (float)Rays[j].Rays[2].Begin.Y;
                    Vertex[j54 + 47] = (float)Rays[j].Rays[2].Begin.Z;

                    Vertex[j54 + 48] = (float)Rays[j].Rays[0].Begin.X;
                    Vertex[j54 + 49] = (float)Rays[j].Rays[0].Begin.Y;
                    Vertex[j54 + 50] = (float)Rays[j].Rays[0].Begin.Z;
                    Vertex[j54 + 51] = (float)Rays[j].Rays[1].Begin.X;
                    Vertex[j54 + 52] = (float)Rays[j].Rays[1].Begin.Y;
                    Vertex[j54 + 53] = (float)Rays[j].Rays[1].Begin.Z;

                    int j72 = i * 72;

                    Colors[j72 + 0] = (float)Rays[j].Color.X;
                    Colors[j72 + 1] = (float)Rays[j].Color.Y;
                    Colors[j72 + 2] = (float)Rays[j].Color.Z;
                    Colors[j72 + 3] = (float)Rays[j].Color.A;

                    Colors[j72 + 4] = (float)Rays[j].Color.X;
                    Colors[j72 + 5] = (float)Rays[j].Color.Y;
                    Colors[j72 + 6] = (float)Rays[j].Color.Z;
                    Colors[j72 + 7] = (float)Rays[j].Color.A;


                    Colors[j72 + 8] = (float)Rays[j].Color.X;
                    Colors[j72 + 9] = (float)Rays[j].Color.Y;
                    Colors[j72 + 10] = (float)Rays[j].Color.Z;
                    Colors[j72 + 11] = (float)Rays[j].Color.A;

                    Colors[j72 + 12] = (float)Rays[j].Color.X;
                    Colors[j72 + 13] = (float)Rays[j].Color.Y;
                    Colors[j72 + 14] = (float)Rays[j].Color.Z;
                    Colors[j72 + 15] = (float)Rays[j].Color.A;


                    Colors[j72 + 16] = (float)Rays[j].Color.X;
                    Colors[j72 + 17] = (float)Rays[j].Color.Y;
                    Colors[j72 + 18] = (float)Rays[j].Color.Z;
                    Colors[j72 + 19] = (float)Rays[j].Color.A;

                    Colors[j72 + 20] = (float)Rays[j].Color.X;
                    Colors[j72 + 21] = (float)Rays[j].Color.Y;
                    Colors[j72 + 22] = (float)Rays[j].Color.Z;
                    Colors[j72 + 23] = (float)Rays[j].Color.A;


                    Colors[j72 + 24] = (float)Rays[j].Color.X;
                    Colors[j72 + 25] = (float)Rays[j].Color.Y;
                    Colors[j72 + 26] = (float)Rays[j].Color.Z;
                    Colors[j72 + 27] = (float)Rays[j].Color.A;

                    Colors[j72 + 28] = (float)Rays[j].Color.X;
                    Colors[j72 + 29] = (float)Rays[j].Color.Y;
                    Colors[j72 + 30] = (float)Rays[j].Color.Z;
                    Colors[j72 + 31] = (float)Rays[j].Color.A;

                    Colors[j72 + 32] = (float)Rays[j].Color.X;
                    Colors[j72 + 33] = (float)Rays[j].Color.Y;
                    Colors[j72 + 34] = (float)Rays[j].Color.Z;
                    Colors[j72 + 35] = (float)Rays[j].Color.A;

                    Colors[j72 + 36] = (float)Rays[j].Color.X;
                    Colors[j72 + 37] = (float)Rays[j].Color.Y;
                    Colors[j72 + 38] = (float)Rays[j].Color.Z;
                    Colors[j72 + 39] = (float)Rays[j].Color.A;

                    Colors[j72 + 40] = (float)Rays[j].Color.X;
                    Colors[j72 + 41] = (float)Rays[j].Color.Y;
                    Colors[j72 + 42] = (float)Rays[j].Color.Z;
                    Colors[j72 + 43] = (float)Rays[j].Color.A;

                    Colors[j72 + 44] = (float)Rays[j].Color.X;
                    Colors[j72 + 45] = (float)Rays[j].Color.Y;
                    Colors[j72 + 46] = (float)Rays[j].Color.Z;
                    Colors[j72 + 47] = (float)Rays[j].Color.A;

                    Colors[j72 + 48] = (float)Rays[j].Color.X;
                    Colors[j72 + 49] = (float)Rays[j].Color.Y;
                    Colors[j72 + 50] = (float)Rays[j].Color.Z;
                    Colors[j72 + 51] = (float)Rays[j].Color.A;

                    Colors[j72 + 52] = (float)Rays[j].Color.X;
                    Colors[j72 + 53] = (float)Rays[j].Color.Y;
                    Colors[j72 + 54] = (float)Rays[j].Color.Z;
                    Colors[j72 + 55] = (float)Rays[j].Color.A;

                    Colors[j72 + 56] = (float)Rays[j].Color.X;
                    Colors[j72 + 57] = (float)Rays[j].Color.Y;
                    Colors[j72 + 58] = (float)Rays[j].Color.Z;
                    Colors[j72 + 59] = (float)Rays[j].Color.A;

                    Colors[j72 + 60] = (float)Rays[j].Color.X;
                    Colors[j72 + 61] = (float)Rays[j].Color.Y;
                    Colors[j72 + 62] = (float)Rays[j].Color.Z;
                    Colors[j72 + 63] = (float)Rays[j].Color.A;

                    Colors[j72 + 64] = (float)Rays[j].Color.X;
                    Colors[j72 + 65] = (float)Rays[j].Color.Y;
                    Colors[j72 + 66] = (float)Rays[j].Color.Z;
                    Colors[j72 + 67] = (float)Rays[j].Color.A;

                    Colors[j72 + 68] = (float)Rays[j].Color.X;
                    Colors[j72 + 69] = (float)Rays[j].Color.Y;
                    Colors[j72 + 70] = (float)Rays[j].Color.Z;
                    Colors[j72 + 71] = (float)Rays[j].Color.A;
                }
            }

            int DynCap = Gl.GL_STREAM_DRAW;
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[VertexIndex]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(Vertex.Length * sizeof(float)), Vertex, DynCap);

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[ColorIndex]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(Colors.Length * sizeof(float)), Colors, DynCap);

            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, bufs[PrimitiveIndex]);
            Gl.glBufferData(Gl.GL_ELEMENT_ARRAY_BUFFER, (IntPtr)(Elements.Length * sizeof(int)), Elements, DynCap);
            Utils.AssertGLError("build - bind VBO-s");

            Colors = null;
            Vertex = null;
            Elements = null;
        }*/

        public void Build(List<Tube3D> Rays, double LineWidth, Tube3D.RenderStyle Rs, int PercentVisible)
        {
            Generate();
            this.LineWidth = (float)LineWidth;
            Mode = Gl.GL_LINES;

            NumOfPrim = Rs == Tube3D.RenderStyle.CenterDirectionOnly ? Rays.Count : Rays.Count * 9;

            int Skiper;
            switch (PercentVisible)
            {
                case 50: Skiper = 2; break;
                case 25: Skiper = 4; break;
                case 10: Skiper = 10; break;
                case 5: Skiper = 20; break;
                case 1: Skiper = 100; break;
                case 100:
                default:
                    Skiper = 1;
                    break;
            }

            Log("Total prim num = " + NumOfPrim);
            NumOfPrim /= Skiper;
            Log("After decimation prim num = " + NumOfPrim);

            List<int> Elems = new List<int>();
            List<float> Verts = new List<float>();
            List<float> Colrs = new List<float>();
           

            for (int j = 0, i = -1; j < Rays.Count; ++j)
            {
                if (j % Skiper != 0)
                    continue;

                ++i;

                if (Rs == Tube3D.RenderStyle.CenterDirectionOnly)
                {
                    Elems.Add(i);
                    Elems.Add(i + 1);

                    int j6 = i * 6;
                    Vector3 Begin = 0.333 * (Rays[j].Rays[0].Begin + Rays[j].Rays[1].Begin + Rays[j].Rays[2].Begin);
                    Vector3 End = 0.333 * (Rays[j].Rays[0].End + Rays[j].Rays[1].End + Rays[j].Rays[2].End);
                    Verts.Add((float)Begin.X);
                    Verts.Add((float)Begin.Y);
                    Verts.Add((float)Begin.Z);
                    Verts.Add((float)End.X);
                    Verts.Add((float)End.Y);
                    Verts.Add((float)End.Z);

                    for (int k = 0; k < 2; ++k)
                    {
                        Colrs.Add((float)Rays[j].Color.X);
                        Colrs.Add((float)Rays[j].Color.Y);
                        Colrs.Add((float)Rays[j].Color.Z);
                        Colrs.Add((float)Rays[j].Color.A);
                    }
                }
                else
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        int n = k == 2 ? 0 : k + 1;
                        Verts.Add((float)Rays[j].Rays[k].Begin.X);
                        Verts.Add((float)Rays[j].Rays[k].Begin.Y);
                        Verts.Add((float)Rays[j].Rays[k].Begin.Z);
                        Verts.Add((float)Rays[j].Rays[k].End.X);
                        Verts.Add((float)Rays[j].Rays[k].End.Y);
                        Verts.Add((float)Rays[j].Rays[k].End.Z);

                        Verts.Add((float)Rays[j].Rays[k].Begin.X);
                        Verts.Add((float)Rays[j].Rays[k].Begin.Y);
                        Verts.Add((float)Rays[j].Rays[k].Begin.Z);
                        Verts.Add((float)Rays[j].Rays[n].Begin.X);
                        Verts.Add((float)Rays[j].Rays[n].Begin.Y);
                        Verts.Add((float)Rays[j].Rays[n].Begin.Z);

                        Verts.Add((float)Rays[j].Rays[k].End.X);
                        Verts.Add((float)Rays[j].Rays[k].End.Y);
                        Verts.Add((float)Rays[j].Rays[k].End.Z);
                        Verts.Add((float)Rays[j].Rays[n].End.X);
                        Verts.Add((float)Rays[j].Rays[n].End.Y);
                        Verts.Add((float)Rays[j].Rays[n].End.Z);
                    }

                    for (int k = 0; k < 18; ++k)
                    {
                        Colrs.Add((float)Rays[j].Color.X);
                        Colrs.Add((float)Rays[j].Color.Y);
                        Colrs.Add((float)Rays[j].Color.Z);
                        Colrs.Add((float)Rays[j].Color.A);
                    }                    
                }
            }

            float[] Vertex = Verts.ToArray();
            float[] Colors = Colrs.ToArray();
            int[] Elements = Elems.ToArray();

            int DynCap = Gl.GL_STREAM_DRAW;
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[VertexIndex]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(Vertex.Length * sizeof(float)), Vertex, DynCap);

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[ColorIndex]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(Colors.Length * sizeof(float)), Colors, DynCap);

            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, bufs[PrimitiveIndex]);
            Gl.glBufferData(Gl.GL_ELEMENT_ARRAY_BUFFER, (IntPtr)(Elements.Length * sizeof(int)), Elements, DynCap);
            Utils.AssertGLError("build - bind VBO-s");

     /*       Colors = null;
            Vertex = null;
            Elements = null;*/
        }

        public void Build(List<Plane3D> Faces)
        {
            Generate();

            Mode = Gl.GL_TRIANGLES;
            NumOfPrim = Faces.Count;

            int[] Elements = new int[NumOfPrim * 3];
            float[] Vertex = new float[NumOfPrim * 9];
            float[] Normals = new float[NumOfPrim * 9];
            float[] Colors = new float[NumOfPrim * 12];
            float[] TexCoords = new float[NumOfPrim * 6];

            for (int j = 0; j < NumOfPrim; ++j)
            {
                int j3 = j * 3;
                int j9 = j * 9;
                int j6 = j * 6;
                int j12 = j * 12;
                Elements[j3 + 0] = j3;
                Elements[j3 + 1] = j3 + 1;
                Elements[j3 + 2] = j3 + 2;

                Vertex[j9 + 0] = (float)Faces[j].Vertex[0].X;
                Vertex[j9 + 1] = (float)Faces[j].Vertex[0].Y;
                Vertex[j9 + 2] = (float)Faces[j].Vertex[0].Z;
                Vertex[j9 + 3] = (float)Faces[j].Vertex[1].X;
                Vertex[j9 + 4] = (float)Faces[j].Vertex[1].Y;
                Vertex[j9 + 5] = (float)Faces[j].Vertex[1].Z;
                Vertex[j9 + 6] = (float)Faces[j].Vertex[2].X;
                Vertex[j9 + 7] = (float)Faces[j].Vertex[2].Y;
                Vertex[j9 + 8] = (float)Faces[j].Vertex[2].Z;

                Normals[j9 + 0] = (float)Faces[j].Normals[0].X;
                Normals[j9 + 1] = (float)Faces[j].Normals[0].Y;
                Normals[j9 + 2] = (float)Faces[j].Normals[0].Z;
                Normals[j9 + 3] = (float)Faces[j].Normals[1].X;
                Normals[j9 + 4] = (float)Faces[j].Normals[1].Y;
                Normals[j9 + 5] = (float)Faces[j].Normals[1].Z;
                Normals[j9 + 6] = (float)Faces[j].Normals[2].X;
                Normals[j9 + 7] = (float)Faces[j].Normals[2].Y;
                Normals[j9 + 8] = (float)Faces[j].Normals[2].Z;

                TexCoords[j6 + 0] = (float)Faces[j].TextureUV[0].X;
                TexCoords[j6 + 1] = (float)Faces[j].TextureUV[0].Y;
                TexCoords[j6 + 2] = (float)Faces[j].TextureUV[1].X;
                TexCoords[j6 + 3] = (float)Faces[j].TextureUV[1].Y;
                TexCoords[j6 + 4] = (float)Faces[j].TextureUV[2].X;
                TexCoords[j6 + 5] = (float)Faces[j].TextureUV[2].Y;

                Vector4 Col = Colorized ? Vector4.PerComponentProduct(Faces[j].Color, MyColor) : Faces[j].Color;

                Colors[j12 + 0] = (float)Col.X;
                Colors[j12 + 1] = (float)Col.Y;
                Colors[j12 + 2] = (float)Col.Z;
                Colors[j12 + 3] = (float)Col.A;
                Colors[j12 + 4] = (float)Col.X;
                Colors[j12 + 5] = (float)Col.Y;
                Colors[j12 + 6] = (float)Col.Z;
                Colors[j12 + 7] = (float)Col.A;
                Colors[j12 + 8] = (float)Col.X;
                Colors[j12 + 9] = (float)Col.Y;
                Colors[j12 + 10] = (float)Col.Z;
                Colors[j12 + 11] = (float)Col.A;

            }

            int DynCap = Gl.GL_STATIC_DRAW;
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[VertexIndex]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(Vertex.Length * sizeof(float)), Vertex, DynCap);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[NormalIndex]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(Normals.Length * sizeof(float)), Normals, DynCap);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[ColorIndex]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(Colors.Length * sizeof(float)), Colors, DynCap);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufs[TextureIndex]);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(TexCoords.Length * sizeof(float)), TexCoords, DynCap);
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, bufs[PrimitiveIndex]);
            Gl.glBufferData(Gl.GL_ELEMENT_ARRAY_BUFFER, (IntPtr)(Elements.Length * sizeof(int)), Elements, DynCap);
            Utils.AssertGLError("build - bind VBO-s");

       /*     Colors = null;
            Vertex = null;
            Normals = null;
            Elements = null;
            TexCoords = null;*/
        }
    }
}
