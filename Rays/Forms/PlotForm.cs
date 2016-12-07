using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;
using Rays._3D;

namespace Rays.Forms
{
    public partial class PlotForm : Form
    {
        private FontGL MyFont;
        private Graphic3D Gr = new Graphic3D(Graphic3D.Styles.Graphic2D, 100);

        public PlotForm()
        {
            InitializeComponent();
        }

        private void PlotForm_Load(object sender, EventArgs e)
        {
            Canvas.InitializeContexts();
            Utils.SetupGL();
            MyFont = new FontGL("Verdana", 10);
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gr.Render(Canvas.Width, Canvas.Height);

            Gl.glFlush();
        }
    }
}
