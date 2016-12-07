using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rays._3D;
using System.Globalization;

namespace Rays.Forms
{
    public partial class ProjectSettings : Form
    {
        public static int PageTab = 0;
        public Project3D Proj = null;

        public ProjectSettings(Project3D prj)
        {
            Proj = prj;
            InitializeComponent();
        }

        private void buttonOK_Click_1(object sender, EventArgs e)
        {
            if (chBoxDefaults.Checked)
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            else
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            try
            {
                Proj.LightColor = Utils.ConvertVector4FromColor(butLightColor.BackColor);
                Proj.BgColor = Utils.ConvertVector4FromColor(butBackColor.BackColor);
                Proj.Name = Utils.StringLimited(tbName.Text, 512);
                Proj.Description = Utils.StringLimited(tbDescription.Text, 65536);
                Proj.LightPosition.X = (double)tbLightX.Value;
                Proj.LightPosition.Y = (double)tbLightY.Value;
                Proj.LightPosition.Z = (double)tbLightZ.Value;

                Proj.RayAlphaPower = chBoxRayAlphaPower.Checked;
                Proj.RayColor = Utils.ConvertVector4FromColor(butRayColor.BackColor);
                Proj.RayFixedColor = radTubeColorFixed.Checked;
                Proj.LineWidth = double.Parse(cmbBoxLineWidth.Text, CultureInfo.InvariantCulture);
                Proj.TubeRenderStyle = radFullPolyhedron.Checked ? Tube3D.RenderStyle.FullPolyhedron : Tube3D.RenderStyle.CenterDirectionOnly;
            }
            finally
            {
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void ProjectSettings_Load(object sender, EventArgs e)
        {
            tbName.Text = Proj.Name;
            tbDescription.Text = Proj.Description;
            tbLightX.Text = Proj.LightPosition.X.ToString();
            tbLightY.Text = Proj.LightPosition.Y.ToString();
            tbLightZ.Text = Proj.LightPosition.Z.ToString();
            butBackColor.BackColor = Utils.ConvertColorFromVector4(Proj.BgColor);
            butLightColor.BackColor = Utils.ConvertColorFromVector4(Proj.LightColor);

            radCenterDirection.Checked = Proj.TubeRenderStyle == Tube3D.RenderStyle.CenterDirectionOnly;
            radFullPolyhedron.Checked = Proj.TubeRenderStyle == Tube3D.RenderStyle.FullPolyhedron;
            radTubeColorChangeOnReflect.Checked = !Proj.RayFixedColor;
           
            radTubeColorFixed.Checked = Proj.RayFixedColor;
            
            cmbBoxLineWidth.Text = Proj.LineWidth.ToString("0.0", CultureInfo.InvariantCulture);
            butRayColor.BackColor = Utils.ConvertColorFromVector4(Proj.RayColor);
            chBoxRayAlphaPower.Checked = Proj.RayAlphaPower;

            tabControl1.SelectedIndex = PageTab;
        }

        private void butBackColor_Click(object sender, EventArgs e)
        {
            ColorDiag.Color = butBackColor.BackColor;
            if (ColorDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                butBackColor.BackColor = ColorDiag.Color;
            }
        }

        private void butLightColor_Click(object sender, EventArgs e)
        {
            ColorDiag.Color = butLightColor.BackColor;
            if (ColorDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                butLightColor.BackColor = ColorDiag.Color;
            }
        }

        private void butRayColor_Click(object sender, EventArgs e)
        {
            ColorDiag.Color = butRayColor.BackColor;
            if (ColorDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                butRayColor.BackColor = ColorDiag.Color;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageTab = tabControl1.SelectedIndex;
        }
    }
}
