using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rays._3D;
using Rays.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Rays
{
    public partial class TransformEditor : Form
    {
        public Project3D Proj = null;
        public Figure3D Fig = null;
        public MainForm ParrentForm = null;
        private AABB PreviewAABB = new AABB();
        private double Rot = 0;
        private VBO Vbo = new VBO();

        private DateTime LastRedraw = DateTime.Now;

        private Vector3 SavedPos = new Vector3();
        private Vector3 SavedRot = new Vector3();
        private Vector3 SavedScl = new Vector3();

        private bool RestoreSaved = true;

        private bool DisableEvents = false;

        public TransformEditor(Project3D Project)
        {
            InitializeComponent();

            Proj = Project;
            Fig = Proj.Scene.Selected;
        }

        private void Preview_Resize(object sender, EventArgs e)
        {
            Gl.glViewport(0, 0, Preview.Width - 1, Preview.Height - 1);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(PreviewAABB.Min.X, PreviewAABB.Max.X, PreviewAABB.Min.Y, PreviewAABB.Max.Y, PreviewAABB.Min.Z, PreviewAABB.Max.Z);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        private void TransformEditor_Load(object sender, EventArgs e)
        {
            if (Proj == null || Fig == null)
            {
                Close();
                return;
            }

            AABB FigAABB = Fig.GetClearAABB();
            Vector3 Sizes = FigAABB.Max - FigAABB.Min;

            double Xsz = FigAABB.Max.X - FigAABB.Min.X;
            double Zsz = FigAABB.Max.Z - FigAABB.Max.Z;

            bool XbZ = Xsz > Zsz;
            double MaxSz = XbZ ? Xsz : Zsz;

            double Rat = (FigAABB.Max.Y - FigAABB.Min.Y) / MaxSz;

            PreviewAABB = new AABB(
                Rat * (XbZ ? FigAABB.Min.X : FigAABB.Min.Z), FigAABB.Min.Y, -1000,
                Rat * (XbZ ? FigAABB.Max.X : FigAABB.Max.Z), FigAABB.Max.Y, 1000
                );
            Preview.InitializeContexts();
            Preview_Resize(null, null);

            Utils.SetupGL();
            Proj.SetupLight();

            tbFigureName.Text = Fig.Name;
            chBoxFigureEnabled.Checked = Fig.Enabled;
            tbTranslateX.Text = Fig.Position.X.ToString();
            tbTranslateY.Text = Fig.Position.Y.ToString();
            tbTranslateZ.Text = Fig.Position.Z.ToString();
            tbRotateX.Text = Fig.EulerRotation.X.ToString();
            tbRotateY.Text = Fig.EulerRotation.Y.ToString();
            tbRotateZ.Text = Fig.EulerRotation.Z.ToString();
            tbScaleX.Text = Fig.Scale.X.ToString();
            tbScaleY.Text = Fig.Scale.Y.ToString();
            tbScaleZ.Text = Fig.Scale.Z.ToString();
            chBoxScaleToghether.Checked = tbScaleX.Text == tbScaleY.Text && tbScaleY.Text == tbScaleZ.Text;

            SavedPos = new Vector3(Fig.Position);
            SavedRot = new Vector3(Fig.EulerRotation);
            SavedScl = new Vector3(Fig.Scale);

            Vbo.Build(Fig.Faces);
        }

        private void Preview_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClearColor((float)Proj.BgColor.X, (float)Proj.BgColor.Y, (float)Proj.BgColor.Z, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glRotated(Rot, 0, 1, 0);
            Vbo.Render();

            Gl.glFlush();

        }

        private void tbFigureName_TextChanged(object sender, EventArgs e)
        {
            Fig.Name = tbFigureName.Text;
            Proj.ChangesUnsaved = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sliderTranslateX_Scroll(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbTranslateX.Text = sliderTranslateX.Value.ToString(); CauseRedrawParrent(); DisableEvents = false;
        }

        private void sliderTranslateY_Scroll(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbTranslateY.Text = sliderTranslateY.Value.ToString(); CauseRedrawParrent(); DisableEvents = false;
        }

        private void sliderTranslateZ_Scroll(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbTranslateZ.Text = sliderTranslateZ.Value.ToString(); CauseRedrawParrent(); DisableEvents = false;
        }

        private void tbTranslateX_TextChanged(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            int Val = (int)tbTranslateX.Value;
            if (Val > sliderTranslateX.Maximum) Val = sliderTranslateX.Maximum;
            if (Val < sliderTranslateX.Minimum) Val = sliderTranslateX.Minimum;
            sliderTranslateX.Value = Val; CauseRedrawParrent(); DisableEvents = false;
        }

        private void tbTranslateY_TextChanged(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            int Val = (int)tbTranslateY.Value;
            if (Val > sliderTranslateX.Maximum) Val = sliderTranslateX.Maximum;
            if (Val < sliderTranslateX.Minimum) Val = sliderTranslateX.Minimum;
            sliderTranslateY.Value = Val; CauseRedrawParrent(); DisableEvents = false;
        }

        private void tbTranslateZ_TextChanged(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            int Val = (int)tbTranslateZ.Value;
            if (Val > sliderTranslateX.Maximum) Val = sliderTranslateX.Maximum;
            if (Val < sliderTranslateX.Minimum) Val = sliderTranslateX.Minimum;
            sliderTranslateZ.Value = Val; CauseRedrawParrent(); DisableEvents = false;
        }

        private void tbRotateX_TextChanged(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            int Val = (int)tbRotateX.Value;
            if (Val > sliderRotateX.Maximum) Val = sliderRotateX.Maximum;
            if (Val < sliderRotateX.Minimum) Val = sliderRotateX.Minimum;
            sliderRotateX.Value = Val; CauseRedrawParrent(); DisableEvents = false;
        }

        private void tbRotateY_TextChanged(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            int Val = (int)tbRotateY.Value;
            if (Val > sliderRotateY.Maximum) Val = sliderRotateY.Maximum;
            if (Val < sliderRotateY.Minimum) Val = sliderRotateY.Minimum;
            sliderRotateY.Value = Val; CauseRedrawParrent(); DisableEvents = false;
        }

        private void tbRotateZ_TextChanged(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            int Val = (int)tbRotateZ.Value;
            if (Val > sliderRotateZ.Maximum) Val = sliderRotateZ.Maximum;
            if (Val < sliderRotateZ.Minimum) Val = sliderRotateZ.Minimum;
            sliderRotateZ.Value = Val; CauseRedrawParrent(); DisableEvents = false;
        }

        private void sliderRotateX_Scroll(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbRotateX.Text = sliderRotateX.Value.ToString(); CauseRedrawParrent(); DisableEvents = false;
        }

        private void sliderRotateY_Scroll(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbRotateY.Text = sliderRotateY.Value.ToString(); CauseRedrawParrent(); DisableEvents = false;
        }

        private void sliderRotateZ_Scroll(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbRotateZ.Text = sliderRotateZ.Value.ToString(); CauseRedrawParrent(); DisableEvents = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbTranslateX.Text = "0";
            tbTranslateY.Text = "0";
            tbTranslateZ.Text = "0";
            sliderTranslateX.Value = 0;
            sliderTranslateY.Value = 0;
            sliderTranslateZ.Value = 0;
            CauseRedrawParrent(); DisableEvents = false;
        }

        private void butRotateReset_Click(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbRotateX.Text = "0";
            tbRotateY.Text = "0";
            tbRotateZ.Text = "0";
            sliderRotateX.Value = 0;
            sliderRotateY.Value = 0;
            sliderRotateZ.Value = 0;
            CauseRedrawParrent(); DisableEvents = false;
        }

        private void butScaleReset_Click(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbScaleX.Text = "1";
            tbScaleY.Text = "1";
            tbScaleZ.Text = "1";
            sliderScaleX.Value = 50;
            sliderScaleY.Value = 50;
            sliderScaleZ.Value = 50;
            CauseRedrawParrent(); DisableEvents = false;
        }

        private string ScaleValueToText(int Value)
        {
            double Val = (double)Value;
            Val = (Val / 100) * 6 - 3;
            Val = Math.Pow(10, Val);
            return Val.ToString();
        }

        private int ScaleTextToValue(string Text)
        {
            double Val = double.Parse(Text);
            Val = Math.Log10(Val);
            Val = (Val + 3) / 6 * 100;
            return (int)Val;
        }

        private void sliderScaleX_Scroll(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbScaleX.Text = ScaleValueToText(sliderScaleX.Value);

            if (chBoxScaleToghether.Checked)
            {
                tbScaleZ.Text = tbScaleX.Text;
                tbScaleY.Text = tbScaleX.Text;
            }
            CauseRedrawParrent(); DisableEvents = false;
        }


        private void sliderScaleY_Scroll(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbScaleY.Text = ScaleValueToText(sliderScaleY.Value);

            if (chBoxScaleToghether.Checked)
            {
                tbScaleZ.Text = tbScaleY.Text;
                tbScaleX.Text = tbScaleY.Text;
            }
            CauseRedrawParrent(); DisableEvents = false;
        }

        private void sliderScaleZ_Scroll(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            tbScaleZ.Text = ScaleValueToText(sliderScaleZ.Value);

            if (chBoxScaleToghether.Checked)
            {
                tbScaleX.Text = tbScaleZ.Text;
                tbScaleY.Text = tbScaleZ.Text;
            }
            CauseRedrawParrent(); DisableEvents = false;
        }

        private void tbScaleX_TextChanged(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            int Val = (int)ScaleTextToValue(tbScaleX.Text);
            if (Val > sliderScaleX.Maximum) Val = sliderScaleX.Maximum;
            if (Val < sliderScaleX.Minimum) Val = sliderScaleX.Minimum;
            sliderScaleX.Value = Val;

            if (chBoxScaleToghether.Checked)
            {
                sliderScaleZ.Value = Val;
                sliderScaleY.Value = Val;
                tbScaleZ.Text = tbScaleZ.Text;
                tbScaleY.Text = tbScaleY.Text;
            }
            CauseRedrawParrent(); DisableEvents = false;
        }

        private void tbScaleY_TextChanged(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            int Val = (int)ScaleTextToValue(tbScaleY.Text);
            if (Val > sliderScaleY.Maximum) Val = sliderScaleY.Maximum;
            if (Val < sliderScaleY.Minimum) Val = sliderScaleY.Minimum;
            sliderScaleY.Value = Val;

            if (chBoxScaleToghether.Checked)
            {
                sliderScaleX.Value = Val;
                sliderScaleZ.Value = Val;
                tbScaleX.Text = tbScaleX.Text;
                tbScaleZ.Text = tbScaleZ.Text;
            }
            CauseRedrawParrent(); DisableEvents = false;

        }

        private void tbScaleZ_TextChanged(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            int Val = (int)ScaleTextToValue(tbScaleZ.Text);
            if (Val > sliderScaleZ.Maximum) Val = sliderScaleZ.Maximum;
            if (Val < sliderScaleZ.Minimum) Val = sliderScaleZ.Minimum;
            sliderScaleZ.Value = Val;

            if (chBoxScaleToghether.Checked)
            {
                //var eh = sliderScaleX.ValueChanged;
                sliderScaleX.Value = Val;
                sliderScaleY.Value = Val;
                tbScaleX.Text = tbScaleX.Text;
                tbScaleY.Text = tbScaleY.Text;
            }
            CauseRedrawParrent(); DisableEvents = false;
        }

        private void chBoxScaleToghether_CheckedChanged(object sender, EventArgs e)
        {
            if (DisableEvents) return; DisableEvents = true;
            if (chBoxScaleToghether.Checked)
            {
                sliderScaleX_Scroll(null, null);
                sliderScaleZ_Scroll(null, null);
                sliderScaleY_Scroll(null, null);
                CauseRedrawParrent();
            }
            DisableEvents = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Proj.ChangesUnsaved = true;
            CauseRedrawParrent();
            RestoreSaved = false;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Preview.Invalidate();
            Rot += 3;
        }

        private void CauseRedrawParrent()
        {
            if ((DateTime.Now - LastRedraw).TotalMilliseconds > 200)
            {
                if (ParrentForm != null)
                {
                    Fig.Position = new Vector3((double)tbTranslateX.Value, (double)tbTranslateY.Value, (double)tbTranslateZ.Value);
                    Fig.Scale = new Vector3((double)tbScaleX.Value, (double)tbScaleY.Value, (double)tbScaleZ.Value);
                    Fig.EulerRotation = new Vector3((double)tbRotateX.Value, (double)tbRotateY.Value, (double)tbRotateZ.Value);
                    Fig.ApplyTransform(Proj.Scene);
                    Proj.Scene.DisableRays();
                    ParrentForm.UpdateVBOFlag = true;
                    ParrentForm.ExternalFig = Fig;
                    ParrentForm.Canvas.Invalidate();
                }
                LastRedraw = DateTime.Now;
            }
        }

        private void TransformEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RestoreSaved)
            {
                Fig.EulerRotation = new Vector3(SavedRot);
                Fig.Position = new Vector3(SavedPos);
                Fig.Scale = new Vector3(SavedScl);
                Fig.ApplyTransform(Proj.Scene);
                CauseRedrawParrent();
            }
        }


    }
}
