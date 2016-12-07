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
    public partial class MiniHelpForm : Form
    {
        public MiniHelpForm()
        {
            InitializeComponent();
        }

        private void MiniHelpForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("Data/buttonCamera.png");
        }

        private void MiniHelpForm_Activated(object sender, EventArgs e)
        {
            Opacity = 100;
        }

        private void MiniHelpForm_Deactivate(object sender, EventArgs e)
        {
            Opacity = 70;
        }

        private void MiniHelpForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                e.Handled = true;
                Close();
            }
        }
    }
}
