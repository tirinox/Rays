using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rays.Forms
{
    public partial class AppSettings : Form
    {
        public static int PageTab = 0;

        public AppSettings()
        {
            InitializeComponent();
        }

        private void AppSettings_Load(object sender, EventArgs e)
        {
            butBackColor.BackColor = Rays.Properties.Settings.Default.ConsBackColor;
            butForeColor.BackColor = Rays.Properties.Settings.Default.ConsForeColor;
            labFontView.Text = Rays.Properties.Settings.Default.ConsFont.FontFamily.GetName(0);
            labFontView.Font = Rays.Properties.Settings.Default.ConsFont;
            chBoxMultithread.Checked = Rays.Properties.Settings.Default.MultiThread;
            cmbBoxThreadNum.Text = Rays.Properties.Settings.Default.NumThreads.ToString();
            chBoxLoadAllRays.Checked = Rays.Properties.Settings.Default.LoadAllRays;
            chBoxDrawAxis.Checked = Rays.Properties.Settings.Default.DrawAxis;
            txtBoxAxisMax.Text = Rays.Properties.Settings.Default.AxisMax.ToString();
            txtBoxAxisStep.Text = Rays.Properties.Settings.Default.AxisStep.ToString();
            chBoxAxisCaptions.Checked = Rays.Properties.Settings.Default.AxisCaptions;
            butPickFaceHighlightColor.BackColor = Rays.Properties.Settings.Default.FaceHighlightColor;
            chBoxFaceHighlight.Checked = Rays.Properties.Settings.Default.FaceHighlight;
            chBoxCollapseConsoleOnStartUp.Checked = Rays.Properties.Settings.Default.CollapseConsoleOnStartUp;
            chBoxTraceOnMove.Checked = Rays.Properties.Settings.Default.TraceOnMove;
            chBoxEnableOctree.Checked = Rays.Properties.Settings.Default.OctreeEnable;
            cmbBoxOctreeDeep.Text = Rays.Properties.Settings.Default.OctreeDeepness.ToString();
            cmbBoxMinFacesCount.Text = Rays.Properties.Settings.Default.OctreeMinFaces.ToString();
            tbFoV.Text = Rays.Properties.Settings.Default.GLPerspectiveFoV.ToString();
            radIsometry.Checked = !Rays.Properties.Settings.Default.GLPerspective;
            radPerspective.Checked = Rays.Properties.Settings.Default.GLPerspective;

            tabControl1.SelectedIndex = PageTab;
        }

        private void MessageBoxError(string Param)
        {
            MessageBox.Show(this, "Значение \"" + Param + "\" не сохранено. Данные некорректны!", "Произошла ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            try
            {
                Rays.Properties.Settings.Default.NumThreads = int.Parse(cmbBoxThreadNum.Items[cmbBoxThreadNum.SelectedIndex].ToString());
                Rays.Properties.Settings.Default.LoadAllRays = chBoxLoadAllRays.Checked;
                Rays.Properties.Settings.Default.MultiThread = chBoxMultithread.Checked;

                Rays.Properties.Settings.Default.LoadAllRays = chBoxLoadAllRays.Checked;

                Rays.Properties.Settings.Default.DrawAxis = chBoxDrawAxis.Checked;
                if((double)txtBoxAxisMax.Value > 1 && (double)txtBoxAxisMax.Value < 1000000)
                    Rays.Properties.Settings.Default.AxisMax = (double)txtBoxAxisMax.Value;
                else
                    MessageBoxError("Максимум осей");
                if ((double)txtBoxAxisStep.Value > Math.Abs((double)txtBoxAxisMax.Value) * 0.0001 && (double)txtBoxAxisStep.Value <= Math.Abs((double)txtBoxAxisMax.Value))
                    Rays.Properties.Settings.Default.AxisStep = (double)txtBoxAxisStep.Value;
                else
                    MessageBoxError("Шаг оси");
                Rays.Properties.Settings.Default.AxisCaptions = chBoxAxisCaptions.Checked;
                Rays.Properties.Settings.Default.FaceHighlight = chBoxFaceHighlight.Checked;

                Rays.Properties.Settings.Default.CollapseConsoleOnStartUp = chBoxCollapseConsoleOnStartUp.Checked;
                Rays.Properties.Settings.Default.ConsBackColor = butBackColor.BackColor;
                Rays.Properties.Settings.Default.ConsForeColor = butForeColor.BackColor;
                Rays.Properties.Settings.Default.FaceHighlightColor = butPickFaceHighlightColor.BackColor;
                Rays.Properties.Settings.Default.ConsFont = labFontView.Font;

                Rays.Properties.Settings.Default.TraceOnMove = chBoxTraceOnMove.Checked;

                Rays.Properties.Settings.Default.OctreeEnable = chBoxEnableOctree.Checked;
                Rays.Properties.Settings.Default.OctreeDeepness = ushort.Parse(cmbBoxOctreeDeep.Text);
                Rays.Properties.Settings.Default.OctreeMinFaces = uint.Parse(cmbBoxMinFacesCount.Text);

                Rays.Properties.Settings.Default.GLPerspective = radPerspective.Checked;
                if ((double)tbFoV.Value > 1 && (double)tbFoV.Value < 180)
                    Rays.Properties.Settings.Default.GLPerspectiveFoV = (double)tbFoV.Value;
                else
                    MessageBoxError("Угол обзора");
                   
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

        private void butForeColor_Click(object sender, EventArgs e)
        {
            ColorDiag.Color = butForeColor.BackColor;
            if (ColorDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                butForeColor.BackColor = ColorDiag.Color;
                Rays.Properties.Settings.Default.ConsForeColor = ColorDiag.Color;
            }
        }

        private void butBackColor_Click(object sender, EventArgs e)
        {
            ColorDiag.Color = butBackColor.BackColor;
            if (ColorDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                butBackColor.BackColor = ColorDiag.Color;
        }

        private void butSelectFont_Click(object sender, EventArgs e)
        {
            FontDiag.Font = labFontView.Font;
            if (FontDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                labFontView.Font = FontDiag.Font;
                labFontView.Text = Rays.Properties.Settings.Default.ConsFont.FontFamily.GetName(0);
            }
        }

        private void chBoxMultithread_CheckedChanged(object sender, EventArgs e)
        {
            cmbBoxThreadNum.Enabled = chBoxMultithread.Checked;
        }

        private void butPickFaceHighlightColor_Click(object sender, EventArgs e)
        {
            ColorDiag.Color = butPickFaceHighlightColor.BackColor;
            if (ColorDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                butPickFaceHighlightColor.BackColor = ColorDiag.Color;
        }

        private void radIsometry_CheckedChanged(object sender, EventArgs e)
        {
            tbFoV.Enabled = !radIsometry.Checked;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageTab = tabControl1.SelectedIndex;
        }
    }
}
