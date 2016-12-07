using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using Tao.Platform.Windows;
using Rays._3D;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace Rays
{
    public delegate void CW(string s);

    public class FontGL : IDisposable
    {
        private int fontbase = -1;

        public void Load(string FontFamily, int Size)
        {
            
            IntPtr font;
            IntPtr oldfont;
            fontbase = Gl.glGenLists(257);

            font = Gdi.CreateFont(
                   -Size,
                    0,
                    0,
                    0,
                    Gdi.FW_BOLD,
                    false,
                    false,
                    false,
                    Gdi.ANSI_CHARSET,
                    Gdi.OUT_TT_PRECIS,
                    Gdi.CLIP_DEFAULT_PRECIS,
                    Gdi.ANTIALIASED_QUALITY,
                    Gdi.FF_DONTCARE | Gdi.DEFAULT_PITCH,
                    FontFamily
                );
            IntPtr hDC = Wgl.wglGetCurrentDC();
            oldfont = Gdi.SelectObject(hDC, font);
            Wgl.wglUseFontBitmapsA(hDC, 0, 256, fontbase);
            Gdi.SelectObject(hDC, oldfont);
            Gdi.DeleteObject(font);
            
        }

        public FontGL(string FontFamily, int Size)
        {
            Load(FontFamily, Size);
        }

        public void Print(double x, double y, double z, string text)
        {
            Gl.glRasterPos3d(x, y, z);
            if (text == null || text.Length == 0)
            {
                return;
            }
            Gl.glPushAttrib(Gl.GL_LIST_BIT);
            Gl.glListBase(fontbase);
            byte[] textbytes = new byte[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                textbytes[i] = (byte)text[i];

                if (text[i] > 1039 && text[i] < 1104)
                {
                    textbytes[i] = (byte)(text[i] + 176);
                }
                else
                {
                    textbytes[i] = (byte)text[i];
                }
            }
            Gl.glCallLists(text.Length, Gl.GL_UNSIGNED_BYTE, textbytes);
            Gl.glPopAttrib();
        }

        public void Print(Vector3 Pos, string text)
        {
            Print(Pos.X, Pos.Y, Pos.Z, text);
        }

        public void Print(Vector2 Pos, string text)
        {
            Print(Pos.X, Pos.Y, 0, text);
        }

        public void Print(double x, double y, string text)
        {
            Print(x, y, 0, text);
        }

        private bool Disposed = false;
        public void Dispose()
        {
            if (!Disposed && fontbase > -1)
            {
                Gl.glDeleteLists(fontbase, 257);
                Disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }

    public class Utils
    {
        private static int[] fontbase = new int[2] { 0, 0 };

        public static bool VBO = false;

        public static void AssertGLError(string Where)
        {
            int err = Gl.glGetError();
            if (err != Gl.GL_NO_ERROR)
                throw new Exception("OpenGL error: " + Where + " Err # " + err + ".");
        }

        public static void SetupGL()
        {
            if (!Gl.IsExtensionSupported("GL_ARB_vertex_buffer_object"))
            {
                MessageBox.Show("Extension GL_ARB_vertex_buffer_object is not supported!");
                VBO = false;
            }
            else VBO = true;

            Gl.ReloadFunctions(); 

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glDisable(Gl.GL_DEPTH_TEST);
            Gl.glShadeModel(Gl.GL_SMOOTH);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
            Gl.glLineWidth(0.5f);
            Gl.glClearColor(1, 1, 1, 1);

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LEQUAL);

            Gl.glColorMaterial(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT_AND_DIFFUSE);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

         /*   CreateSymbols(0, 10, "Verdana");
            CreateSymbols(1, 16, "Verdana");*/
        }

        public static string GetProgramName()
        {
            var Name = Assembly.GetEntryAssembly().GetName();
            return Name.Name + " v." + Name.Version.Major + "." + Name.Version.MajorRevision + "." + Name.Version.Build;
        }

        public static Color ConvertColorFromVector4(Vector4 vc)
        {
            int r = (int)(vc.X * 255); if (r > 255) r = 255; else if (r < 0) r = 0;
            int g = (int)(vc.Y * 255); if (g > 255) g = 255; else if (g < 0) g = 0;
            int b = (int)(vc.Z * 255); if (b > 255) b = 255; else if (b < 0) b = 0;
            int a = (int)(vc.A * 255); if (a > 255) a = 255; else if (a < 0) a = 0;
            return Color.FromArgb(a, r, g, b);
        }

        public static Vector4 ConvertVector4FromColor(Color c)
        {
            return new Vector4(c.R / 255.0, c.G / 255.0, c.B / 255.0, c.A / 255.0);
        }

        public static string StringLimited(string in_s, int len)
        {
            if (in_s.Length <= len) return in_s;
            else return in_s.Substring(len);
        }

        private static byte[] polystipple = new byte[128]
            {0xaa, 0xaa, 0xaa, 0xaa, 0x44, 0x44, 0x44, 0x44, 0xaa, 0xaa, 0xaa, 0xaa, 0x00, 0x00, 0x00, 0x00,
            0xaa, 0xaa, 0xaa, 0xaa, 0x44, 0x44, 0x44, 0x44, 0xaa, 0xaa, 0xaa, 0xaa, 0x00, 0x00, 0x00, 0x00,
            0xaa, 0xaa, 0xaa, 0xaa, 0x44, 0x44, 0x44, 0x44, 0xaa, 0xaa, 0xaa, 0xaa, 0x00, 0x00, 0x00, 0x00,
            0xaa, 0xaa, 0xaa, 0xaa, 0x44, 0x44, 0x44, 0x44, 0xaa, 0xaa, 0xaa, 0xaa, 0x00, 0x00, 0x00, 0x00,
            0xaa, 0xaa, 0xaa, 0xaa, 0x44, 0x44, 0x44, 0x44, 0xaa, 0xaa, 0xaa, 0xaa, 0x00, 0x00, 0x00, 0x00,
            0xaa, 0xaa, 0xaa, 0xaa, 0x44, 0x44, 0x44, 0x44, 0xaa, 0xaa, 0xaa, 0xaa, 0x00, 0x00, 0x00, 0x00,
            0xaa, 0xaa, 0xaa, 0xaa, 0x44, 0x44, 0x44, 0x44, 0xaa, 0xaa, 0xaa, 0xaa, 0x00, 0x00, 0x00, 0x00,
            0xaa, 0xaa, 0xaa, 0xaa, 0x44, 0x44, 0x44, 0x44, 0xaa, 0xaa, 0xaa, 0xaa, 0x00, 0x00, 0x00, 0x00};

        public static void GPolyStipple(bool Enable = false)
        {
            if (Enable)
            {
                Gl.glEnable(Gl.GL_POLYGON_STIPPLE);
                Gl.glPolygonStipple(polystipple);
            }
            else
                Gl.glDisable(Gl.GL_POLYGON_STIPPLE);
            
        }

        public static double DegreeToRad(double Rad)
        {
            return Rad * Math.PI * 0.00555555555555;
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Отмена";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        static public void GLine(double x1, double y1, double x2, double y2, Color C, double Width = 1.0)
        {
            GColor(C);
            Gl.glLineWidth((float)Width);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(x1, y1);
            Gl.glVertex2d(x2, y2);
            Gl.glEnd();
        }

        static public void GLine(Vector2 R1, Vector2 R2, Color C, double Width = 1.0)
        {
            GLine(R1.x, R1.y, R2.x, R2.y, C, Width);
        }

        static public void GFillRect(Vector2 R1, Vector2 R2, Color C)
        {
            GColor(C);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2d(R1.x, R1.y);
            Gl.glVertex2d(R2.x, R1.y);
            Gl.glVertex2d(R2.x, R2.y);
            Gl.glVertex2d(R1.x, R2.y);
            Gl.glEnd();
        }

        static public void GSmallSquare(Vector2 P, Color C)
        {
            GFillRect(new Vector2(P.x - 0.012, P.y - 0.012), new Vector2(P.x + 0.012, P.y + 0.012), C);
        }

        static public void GColor(Color C)
        {
            Gl.glColor4d(C.R / 256.0, C.G / 256.0, C.B / 256.0, C.A / 256.0);
        }

        public const long KByte = 1024;
        public const long MByte = KByte * KByte;
        public const long GByte = MByte * KByte;
        public const long TByte = GByte * KByte;

        public static string MemoryToStr(long Memory)
        {
            if (Memory < KByte)
                return Memory.ToString() + " b";
            else if (Memory < MByte)
            {
                double Kb = (double)Memory / KByte;
                return Kb.ToString("0.##") + " Kb";
            }
            else if (Memory < GByte)
            {
                double Mb = (double)Memory / MByte;
                return Mb.ToString("0.##") + " Mb";
            }
            else
            {
                double Kb = (double)Memory / GByte;
                return Kb.ToString("0.##") + " Gb";
            }
        }
    }
}
