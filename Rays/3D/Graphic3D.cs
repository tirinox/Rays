using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tao.OpenGl;

namespace Rays._3D
{
    public class Graphic3D
    {
        public static double Epsilon = 1e-4;

        public enum Styles
        {
            Graphic2D,
            Colormap3D,
            Heightmap3D,
            HeightColormap3D,
            Spherical3D,
            SphericalColorMap3D
        }

        public Styles Style = Styles.Graphic2D;
        public Color LineColor = Color.Blue;

        public int Segments = 100;

        public List<Vector3> Data = new List<Vector3>();  // X = X-param, Y = Y-param if 3D, Z = Value, always!

       
        // аналогично как и дата, X Y - переменные, Z - значение функции
        public AABB MinMax = new AABB();

        private AABB PlotZone = new AABB();
        public AABB FuncZone = new AABB();

        public Vector3 EulerRotation = new Vector3();
        public double Scale3D = 1.0;
        public Vector3 LightPosition = new Vector3(0, 100, 0);

        public double Padding = 50;

        public Graphic3D()
        { }

        public Graphic3D(Styles GraphicStyle, int Segments = 100)
        {
            this.Segments = Segments;
            this.Style = GraphicStyle;
        }

        public static CW cw = null;

        public static void Log(string s)
        {
            if (cw != null)
                cw("Graphic3D: " + s);
        }

        public void Minimax()
        {
            MinMax = new AABB();
            foreach (Vector3 P in Data)
                MinMax.Extend(P);
        }

        public void Sample()
        {
            Style = Styles.Graphic2D;
            for(int i = 0; i < 20; ++i)
            {
                double X = i / 20.0 * Math.PI;
                double Fx = Math.Sin(X);
                Data.Add(new Vector3(X, 0, Fx));
            }
        }

        public void Prepare()
        {
            Data.Sort(delegate(Vector3 One, Vector3 Two)
            {
                if (One.X > Two.X) return -1;
                else if (One.X < Two.X) return 1;
                else
                {
                    if (One.Y > Two.Y) return -1;
                    else if (One.Y < Two.Y) return 1;
                    else return 0;
                }
            });
        }

        public bool AreSizesValid(double vpw, double wph)
        {
            if (
                vpw < 1 || wph < 1 ||
                vpw > 4000 || wph > 3000 ||
                MinMax.Min.X > MinMax.Max.X - Epsilon ||
                MinMax.Min.Y > MinMax.Max.Y - Epsilon ||
                MinMax.Min.Z > MinMax.Max.Z - Epsilon)
                return false;

            if (Style == Styles.Graphic2D || Style == Styles.Colormap3D)
            {
                if (
                    PlotZone.Min.X > PlotZone.Max.X - Epsilon ||
                    PlotZone.Min.Y > PlotZone.Max.Y - Epsilon ||
                    PlotZone.Min.Z > PlotZone.Max.Z - Epsilon ||
                    FuncZone.Min.X > FuncZone.Max.X - Epsilon ||
                    FuncZone.Min.Y > FuncZone.Max.Y - Epsilon ||
                    FuncZone.Min.Z > FuncZone.Max.Z - Epsilon)
                    return false;
            }

            return true;
        }

        public void Reset()
        {
            Scale3D = 1.0;
            EulerRotation = new Vector3();
            FuncZone.Min.X = MinMax.Min.X;
            FuncZone.Max.X = MinMax.Max.X;

            if (Style == Styles.Graphic2D)
            {
                FuncZone.Min.Y = MinMax.Min.Y;
                FuncZone.Max.Y = MinMax.Max.Y;
            }
            else if (Style == Styles.Colormap3D)
            {
                FuncZone.Min.Y = MinMax.Min.Z;
                FuncZone.Max.Y = MinMax.Max.Z;
            }
        }

        // Перед использованием - обратить Y
        public Vector2 ScreenToGraphic(double X, double Y)
        {
            double NormX = (X - PlotZone.Min.X) / (PlotZone.Max.X - PlotZone.Min.X);
            double NormY = (Y - PlotZone.Min.Y) / (PlotZone.Max.Y - PlotZone.Min.Y);
            return new Vector2(
                NormX * (FuncZone.Max.X - FuncZone.Min.X) + FuncZone.Min.X,
                NormY * (FuncZone.Max.Y - FuncZone.Min.Y) + FuncZone.Min.Y
                );
        }
        // После использования - обратить Y
        public Vector2 GraphicToScreen(double X, double Y)
        {
            double NormX = (X - FuncZone.Min.X) / (FuncZone.Max.X - FuncZone.Min.X);
            double NormY = (Y - FuncZone.Min.Y) / (FuncZone.Max.Y - FuncZone.Min.Y);
            return new Vector2(
                NormX * (PlotZone.Max.X - PlotZone.Min.X) + PlotZone.Min.X,
                NormY * (PlotZone.Max.Y - PlotZone.Min.Y) + PlotZone.Min.Y
                );
        }

        public void Render(double VPWidth, double VPHeight)
        {
            // Настройка Огл
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            // сюда добавть настройку для 3д режима
            Glu.gluOrtho2D(0, VPWidth, 0, VPHeight);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_DEPTH_TEST);

            // Вычислим рабочую область
            PlotZone.Min = new Vector3(Padding, Padding, 0);
            PlotZone.Max = new Vector3(VPWidth - Padding, VPWidth - Padding, 0);

            if (!AreSizesValid(VPWidth, VPWidth))
            {
                // вывести плохое сообщение
            }
            // ЮЗАЙ СПЛАЙНЫ!!
        }


    }
}
