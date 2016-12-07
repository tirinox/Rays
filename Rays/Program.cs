using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Rays
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Forms.MainForm Mf = new Forms.MainForm();

            if (args.Length != 0)
            {
                Mf.StartFile = args[0];
            }

            Application.Run(Mf);
        }
    }
}
