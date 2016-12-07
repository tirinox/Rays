using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace Rays.Forms
{
    public partial class AboutForm : Form
    {
        public const string SiteName = "http://rays.tirinox.ru";
        private int ClickCnt = 0;

        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            var Name = Assembly.GetEntryAssembly().GetName();

            VersionLabel.Text = " v." + Name.Version.Major + "." + Name.Version.MajorRevision + "." + Name.Version.Build;
            GoToSite.Text = SiteName;
        }

        private void GoToSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(SiteName);
        }

        // Пасхалка :)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClickCnt++;
            if (ClickCnt == 13)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile("fuel.dll");
                }
                catch
                {
                    Text = "No beer :(";
                }
            }
        }

        private void AboutForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                e.Handled = true;
                Close();
            }
        }
    }
}
