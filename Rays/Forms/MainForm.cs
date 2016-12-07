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
using System.IO;
using System.Threading;
using Rays._3D;
using System.Reflection;

namespace Rays.Forms
{
    public partial class MainForm : Form
    {
        public string StartFile = "";
        public Project3D Proj = new Project3D();
        public Tracer3D Tracer = new Tracer3D();

        private int FileHistorySz = 5;
        private MiniHelpForm MiniHelp = null;
        private TransformEditor TransformEdit = null;

        private DateTime StartTime = DateTime.Now;

        public bool UpdateVBOFlag = false;
        public Figure3D ExternalFig = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private Octree oct = null;
    
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (UpdateVBOFlag)
                {
                    
                    ExternalFig.BuildVBO(ExternalFig == Proj.Scene.Selected);
                    UpdateVBOFlag = false;
                }

                Gl.glClearColor((float)Proj.BgColor.X, (float)Proj.BgColor.Y, (float)Proj.BgColor.Z, 1);
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                Gl.glEnable(Gl.GL_DEPTH_TEST);
                Proj.Camera.See((double)Canvas.Width / Canvas.Height);
                Proj.SetupLight();
                Proj.Scene.Render(false);

                //    Scene.TEST_Render();
               
                Utils.GColor(Color.Aquamarine);
                if (oct != null)
                    oct.Render();

                Gl.glFlush();
            }
            catch (Exception ex)
            {
                ConsWrite("Paint ex: " + ex.Message + " " + ex.StackTrace);
            }

        }

        #region MOUSE_EVENTS
        private bool mouseDown = false;
        private int lastX = -1, lastY = -1;
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouseDown = true;
                lastX = e.X;
                lastY = e.Y;
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

            Canvas.Invalidate();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && Canvas.Height > 0)
            {
                if (lastX != -1)
                {
                    double drxs = e.X - lastX;
                    double drys = e.Y - lastY;
                    Proj.Camera.Rotation(drys, drxs);
                }

                lastX = e.X;
                lastY = e.Y;

                Canvas_Resize(sender, null);
                Canvas.Invalidate();
            }
        }

        public void Canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            Canvas_Resize(sender, null);
            Canvas.Invalidate();
        }

        #endregion

        
        private void Canvas_Resize(object sender, EventArgs e)
        {
            float h = Canvas.Height;
            float w = Canvas.Width;
            if (h == 0)
                h = 1;

            float ratio = w / h;

            Gl.glViewport(0, 0, (int)w, (int)h);

            Proj.Camera.See(ratio);
        }

        #region "Updates"
        private void UpdateWindowTitle()
        {
            this.Text = Utils.GetProgramName() + " - " + Proj.Name;
            if (Proj.FileName != string.Empty)
                this.Text += " (" + Proj.FileName + ")";
            if (Proj.ChangesUnsaved)
                this.Text += " * ";

            toolStripButtonSaveScene.Enabled = Proj.ChangesUnsaved;
            сохранитьToolStripMenuItem.Enabled = Proj.ChangesUnsaved;

            bool AnySel = Proj != null && Proj.Scene.Selected != null;
            вырезатьОбъектToolStripMenuItem.Enabled = AnySel;
            удалитьОбъектToolStripMenuItem.Enabled = AnySel;
            копироватьОбъектToolStripMenuItem.Enabled = AnySel;
            трансформацияОбъектаToolStripMenuItem.Enabled = AnySel;
        }

        public void UpdateInterfaceFromSettings()
        {
            this.Cons.ForeColor = Rays.Properties.Settings.Default.ConsForeColor;
            this.Cons.BackColor = Rays.Properties.Settings.Default.ConsBackColor;
            this.Cons.Font = Rays.Properties.Settings.Default.ConsFont;
        }


        private void UpdateFileHistory(string FileName)
        {
            недавниеФайлыToolStripMenuItem.Visible = Rays.Properties.Settings.Default.StoreFileHistory;
            if (Rays.Properties.Settings.Default.FileHistory == null)
                Rays.Properties.Settings.Default.FileHistory = new System.Collections.Specialized.StringCollection();
            if (FileName != string.Empty && !Rays.Properties.Settings.Default.FileHistory.Contains(FileName.Trim()))
            {
                if (Rays.Properties.Settings.Default.FileHistory.Count >= FileHistorySz)
                    Rays.Properties.Settings.Default.FileHistory.RemoveAt(Rays.Properties.Settings.Default.FileHistory.Count - 1);
                Rays.Properties.Settings.Default.FileHistory.Insert(0, FileName);
                Rays.Properties.Settings.Default.Save();

            }
            int hi = 1;
            недавниеФайлыToolStripMenuItem.DropDownItems.Clear();
            if (Rays.Properties.Settings.Default.StoreFileHistory)
            {
                foreach (string HistoryEntry in Rays.Properties.Settings.Default.FileHistory)
                {
                    if (File.Exists(HistoryEntry))
                    {
                        ToolStripMenuItem tsmi = new ToolStripMenuItem(hi + ". " + HistoryEntry, null, new EventHandler(OpenRecentFile));
                        недавниеФайлыToolStripMenuItem.DropDownItems.Add(tsmi);
                        ++hi;
                    }
                }
            }
        }
        #endregion

        #region "Form load event"
        private void MainForm_Load(object sender, EventArgs e)
        {
            Canvas.InitializeContexts();


            this.Canvas.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseWheel);

            ConsWrite("Приложение Rays запущено.");

            UpdateWindowTitle();
            UpdateInterfaceFromSettings();

            lOGENABLERToolStripMenuItem.Checked = Rays.Properties.Settings.Default.LogEnable;
            multiThreadToolStripMenuItem.Checked = Rays.Properties.Settings.Default.MultiThread;

            StartTime = DateTime.Now;

            Utils.SetupGL();

            Proj.Scene.BuildVBO(false);

            int p = 0, i = 0;
            foreach (ToolStripMenuItem item in количествоНачальныхToolStripMenuItem.DropDownItems)
            {
                toolStripComboBoxIR.Items.Add(item.Text);
                if (item.Checked)
                    p = i;
                ++i;
            }
            toolStripComboBoxIR.SelectedIndex = p;

            i = 0;
            foreach (ToolStripMenuItem item in количествоВидимыхToolStripMenuItem.DropDownItems)
            {
                toolStripComboBoxVR.Items.Add(item.Text);

                if (item.Checked)
                    p = i;
                ++i;
            }
            toolStripComboBoxVR.SelectedIndex = p;

            i = 0;
            foreach (ToolStripMenuItem item in грубинаТрассировкиToolStripMenuItem.DropDownItems)
            {
                toolStripComboBoxTD.Items.Add(item.Text);
                if (item.Checked)
                    p = i;
                ++i;
            }
            toolStripComboBoxTD.SelectedIndex = p;

            this.WindowState = FormWindowState.Maximized;

            if (Rays.Properties.Settings.Default.CollapseConsoleOnStartUp)
                toolStripButton3_Click(null, null);

            Scene3D.Cw = ConsWrite;
            Figure3D.Cw = ConsWrite;
            VBO.Cw = ConsWrite;

            lOGENABLERToolStripMenuItem_Click(null, null);
            FormSceneObjectList();

            ProperlyOpenFile(StartFile);
        }
        #endregion

        #region "Console"
        public void NullWrite(string s)
        { }

        public void ConsWrite(string s)
        {
            const int MaxConsSz = 500;
            Cons.AppendText(DateTime.Now.ToString("H:m:s  ") + s + "\n");
            if (Cons.Lines.Length > MaxConsSz)
            {
                int numOfLines = Cons.Lines.Length - MaxConsSz;
                var lines = this.Cons.Lines;
                var newLines = lines.Skip(numOfLines);
                this.Cons.Lines = newLines.ToArray();
            }
            Cons.SelectionStart = Cons.Text.Length;
            Cons.ScrollToCaret();
        }

        public void ConsWriteThr(string s)
        {
            if (Cons.InvokeRequired)
            {
                Cons.BeginInvoke(new CW(ConsWrite), new object[] { s });
            }
            else
                ConsWrite(s);
        }
        #endregion

        #region "Всякая фигня с интерфейсом"
        private void завершитьRaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  Application.Exit();
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            очиститьСообщенияToolStripMenuItem_Click(sender, e);
        }

        private void OpenSettings(int Tab)
        {
            var f = new AppSettings();
            f.tabControl1.SelectedIndex = Tab;
            var dres = f.ShowDialog();

            if (dres == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    UpdateInterfaceFromSettings();
                    Proj.Scene.BuildVBO(false);

                    Rays.Properties.Settings.Default.Save();

                    Canvas.Invalidate();

                    ConsWrite("[i] Настройки сохранены.");

                }
                catch (Exception ex)
                {
                    ConsWrite(@"/!\ Произошла ошибка при сохранении настроек: " + ex.Message);
                }
            }

            f.Dispose();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenSettings(0);
        }

        private int oldSplitPos = 0;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            свернутьСообщенияToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            развернутьСообщенияToolStripMenuItem_Click(sender, e);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (MiniHelp != null && !MiniHelp.IsDisposed)
                {
                    MiniHelp.TopMost = false;
                    MiniHelp.WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
                if (MiniHelp != null && !MiniHelp.IsDisposed)
                {
                    MiniHelp.TopMost = true;
                    MiniHelp.WindowState = FormWindowState.Normal;
                }
            }

            int d = splitContainer1.Height - 55;
            if (d < splitContainer1.Panel1MinSize && d > splitContainer1.Panel2MinSize)
                if (splitContainer1.SplitterDistance > d)
                    splitContainer1.SplitterDistance = d;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            копироватьСообщенияToolStripMenuItem_Click(sender, e);
        }

        private void toolStripReloadScene_Click(object sender, EventArgs e)
        {
            перезагрузтитьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripOpenScene_Click(object sender, EventArgs e)
        {
            выполнитьToolStripMenuItem_Click(sender, e);
        }

        private void выполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile.InitialDirectory =
                Rays.Properties.Settings.Default.LastPath == string.Empty || !Directory.Exists(Rays.Properties.Settings.Default.LastPath) ?
                Path.GetDirectoryName(Application.ExecutablePath) : Rays.Properties.Settings.Default.LastPath;
            OpenFile.Filter = "C# скрипт (*.cs)|*.cs|Все файлы|*.*";
            OpenFile.FileName = "";

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                ExecuteCS(OpenFile.FileName);
            }
            try
            {
                Rays.Properties.Settings.Default.LastPath = Path.GetDirectoryName(OpenFile.FileName);
                Rays.Properties.Settings.Default.Save();
            }
            catch { }
        }

        private void ExecuteCS(string FileName = "")
        {
            DialogResult r = AskForUnsaved();
            if (r != System.Windows.Forms.DialogResult.Cancel)
            {
                ButtonAbortCalc_Click(null, null);
                Proj.Scene.Open(FileName);
                Canvas.Invalidate();
                UpdateWindowTitle();
                UpdateFileHistory(FileName);
                FormSceneObjectList();
            }
        }

        private void перезагрузтитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCS();
        }

        private void toolStripResetView_Click(object sender, EventArgs e)
        {
            сбросToolStripMenuItem_Click(sender, e);
        }

        private void toolStripTrace_Click(object sender, EventArgs e)
        {
            трассироватьToolStripMenuItem_Click(sender, e);
        }

        private void ProcessUpdateInvoker(int Perc, bool Completed)
        {

            if (Completed)
            {
                TracingCompletedInfo();
            }
            else
            {
                if (Perc % 10 == 0)
                    this.BarProgress.Value = Perc;

            }
        }

        private void TracingCompletedInfo()
        {
            this.BarProgress.Value = 0;
            CalculationControlsVisibility(false);
            Proj.ChangesUnsaved = true;
            UpdateWindowTitle();
            TimeSpan esl = DateTime.Now - StartTime;

            ConsWrite("Трассировка лучей завершена. Всего построено лучей: " + Proj.Scene.AllRays.Count + ". Время: " + esl.TotalSeconds + " сек.");
            Proj.Scene.BuildVBO(true);
            Canvas.Invalidate();
            ConsWrite("Отрисовка сцены завершена.");
        }

        private void ProcessUpdate(int Perc, bool Completed)
        {
            this.BeginInvoke(new ProgressUpdateDelegate(ProcessUpdateInvoker), new object[] { Perc, Completed });
        }

        private void CalculationControlsVisibility(bool Visible)
        {
            BarProgress.Visible = Visible;
            ProgressLabel.Visible = Visible;
            ButtonAbortCalc.Visible = Visible;
            ProgressSeparator.Visible = Visible;
        }

        private void трассироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tracer.InWork)
            {
                ConsWrite("/!\\ Трассировка уже выполняется!");
                return;
            }

            BarProgress.Value = 0;

            oct = null;

            Tracer.MaxTraceSteps = int.Parse(toolStripComboBoxTD.Text);

            ConsWrite("Начинается трассировка лучей... Глубина: " + Tracer.MaxTraceSteps + ", число начальных лучей: " + Proj.Scene.InitialRays.Count + ".");

            CalculationControlsVisibility(true);
            StartTime = DateTime.Now;
            Timer1Sec.Enabled = true;
            Timer1Sec_Tick(null, null);

            Proj.Scene.RaysVisible = false;
            Proj.Scene.TransformFiguresAndMergeFaces();

            if (Rays.Properties.Settings.Default.MultiThread)
            {
                Tracer.ProgressUpdateD = ProcessUpdate;
                Tracer.RayTracingThreaded(Proj.Scene);
            }
            else
            {
                Tracer.ProgressUpdateD = null;
                Tracer.RayTracing(Proj.Scene);

                TracingCompletedInfo();
            }

        }

        private void приблизитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proj.Camera.ProcessKey(Camera3DMovements.Forward);
            Canvas_Resize(sender, null);
            Canvas.Invalidate();
        }

        private void отдалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proj.Camera.ProcessKey(Camera3DMovements.Back);
            Canvas_Resize(sender, null);
            Canvas.Invalidate();
        }

        private void toolStripZoomIn_Click(object sender, EventArgs e)
        {
            приблизитьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripZoomOut_Click(object sender, EventArgs e)
        {
            отдалитьToolStripMenuItem_Click(sender, e);
        }

        private void сбросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proj.Camera = new Camera3D();
            Canvas_Resize(sender, e);
            Canvas.Invalidate();
        }

        private bool SelectC_InitialRays(int c)
        {
            if (c < 1 || c > 50000)
            {
                ConsWrite("/i\\ Недопустимое число начальных лучей: " + c + "! Должно быть от 1 до 50000.");
                return false;
            }
            //scene.InitialRayCount = c;
            //scene.InitialRaysCast(c);
            toolStripComboBoxIR.Text = c.ToString();
            //  ConsWrite("[i] Создан набор из " + scene.InitialRays.Lines.Count + " начальных лучей.");
            //            трассироватьToolStripMenuItem_Click(null, null);
            //MCalc.Visible = false;
            return true;
        }

        private bool SelectC_VisibleRays(int c)
        {
            if (c < 1 || c > 100)
            {
                ConsWrite("/i\\ Недопустимое число видимых лучей: " + c + "! Должно быть от 1 до 100.");
                return false;
            }
            //scene.VisibleRayPercent = c;
            //     ConsWrite("[i] Будет отображаться " + c + "% построенных лучей.");

            Proj.Scene.PercentVisible = c;
            Proj.Scene.BuildVBO(true);

            toolStripComboBoxVR.Text = c.ToString();
            Canvas.Invalidate();

            return true;
        }

        private bool SelectC_TraceDepth(int c)
        {
            if (c < 1 || c > 20)
            {
                ConsWrite("/i\\ Недопустимое число шагов трассировки лучей: " + c + "! Должно быть от 1 до 20.");
                return false;
            }
            //scene.CallDepth = c;
            toolStripComboBoxTD.Text = c.ToString();
            //  ConsWrite("[i] Углубина трассировки лучей " + scene.CallDepth + " шаг.");
            //           трассироватьToolStripMenuItem_Click(null, null);
            //MCalc.Visible = false;
            return true;
        }

        private void toolStripMenuItemIR_1_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in количествоНачальныхToolStripMenuItem.DropDownItems)
                item.Checked = false;
            ToolStripMenuItem it = sender as ToolStripMenuItem;
            if (it != null)
            {
                it.Checked = true;
                int cnt = int.Parse(it.Text);
                SelectC_InitialRays(cnt);
            }
        }

        private void toolStripMenuItemVR_100_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in количествоВидимыхToolStripMenuItem.DropDownItems)
                item.Checked = false;
            ToolStripMenuItem it = sender as ToolStripMenuItem;
            if (it != null)
            {
                it.Checked = true;
                char[] procc = { '%' };
                int cnt = int.Parse(it.Text.Trim(procc));
                SelectC_VisibleRays(cnt);
            }
        }

        private void toolStripMenuItemTD_2_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in грубинаТрассировкиToolStripMenuItem.DropDownItems)
                item.Checked = false;
            ToolStripMenuItem it = sender as ToolStripMenuItem;
            if (it != null)
            {
                it.Checked = true;
                int cnt = int.Parse(it.Text);
                SelectC_TraceDepth(cnt);
            }
        }



        private void toolStripComboBoxIR_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int v;
                if (!int.TryParse(toolStripComboBoxIR.Text, out v))
                {
                    ConsWrite("/!\\ Поле допускает только числовые значения!");
                    return;
                }
                if (!SelectC_InitialRays(v))
                    toolStripComboBoxIR.Text = 500.ToString();
                e.Handled = true;
            }
        }

        private void toolStripComboBoxIR_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectC_InitialRays(int.Parse(toolStripComboBoxIR.Items[toolStripComboBoxIR.SelectedIndex] as string));
        }

        private void toolStripComboBoxVR_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int v;
                if (!int.TryParse(toolStripComboBoxVR.Text, out v))
                {
                    ConsWrite("/!\\ Поле допускает только числовые значения!");
                    return;
                }
                if (!SelectC_VisibleRays(v))
                {
                    toolStripComboBoxIR.Text = "100%";
                    SelectC_VisibleRays(100);
                }
                e.Handled = true;
            }
        }

        private void toolStripComboBoxVR_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] procc = { '%' };
            int cnt = int.Parse((toolStripComboBoxVR.Items[toolStripComboBoxVR.SelectedIndex] as string).Trim(procc));
            SelectC_VisibleRays(cnt);
        }

        private void toolStripComboBoxTD_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int v;
                if (!int.TryParse(toolStripComboBoxTD.Text, out v))
                {
                    ConsWrite("/!\\ Поле допускает только числовые значения!");
                    return;
                }
                if (!SelectC_TraceDepth(v))
                {
                    toolStripComboBoxTD.Text = "5";
                    SelectC_TraceDepth(5);
                }
                e.Handled = true;
            }
        }

        private void toolStripComboBoxTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectC_TraceDepth(int.Parse(toolStripComboBoxTD.Items[toolStripComboBoxTD.SelectedIndex] as string));
        }

        private void картаИнтенсивностиПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DateTime dt = DateTime.Now;
            ConsWrite("[i] Построение карты интенсивности поля...");

            Canvas.Invalidate();

            TimeSpan esl = DateTime.Now - dt;
            ConsWrite("[i] Построение карты интенсивности поля завершено. Время: " + esl.TotalSeconds + " сек.");

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            картаИнтенсивностиПоляToolStripMenuItem_Click(null, null);
        }

        private void скрытьКартуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MCalc.Visible = false;
            Canvas.Invalidate();
        }
        #endregion

        public double rys1 = 0, rxs1 = 0;
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            bool InvF = false;


            switch (e.KeyCode)
            {
                case Keys.W:
                    Proj.Camera.ProcessKey(Camera3DMovements.Forward);
                    InvF = true;
                    break;
                case Keys.S:
                    Proj.Camera.ProcessKey(Camera3DMovements.Back);
                    InvF = true;
                    break;
                case Keys.A:
                    Proj.Camera.ProcessKey(Camera3DMovements.StrafeLeft);
                    InvF = true;
                    break;
                case Keys.D:
                    Proj.Camera.ProcessKey(Camera3DMovements.StrafeRight);
                    InvF = true;
                    break;
                case Keys.Space:
                    Proj.Camera.ProcessKey(Camera3DMovements.Up);
                    InvF = true;
                    break;
                case Keys.C:
                    Proj.Camera.ProcessKey(Camera3DMovements.Down);
                    InvF = true;
                    break;
                case Keys.I:
                    if (Proj.Scene.Selected != null) Proj.Scene.Selected.Transpose1(new Rays._3D.Vector3(0, 0, 5));
                    трассироватьToolStripMenuItem_Click(null, null);
                    InvF = true;
                    break;
                case Keys.K:
                    if (Proj.Scene.Selected != null) Proj.Scene.Selected.Transpose1(new Rays._3D.Vector3(0, 0, -5));
                    трассироватьToolStripMenuItem_Click(null, null);
                    InvF = true;
                    break;
                case Keys.J:
                    if (Proj.Scene.Selected != null) Proj.Scene.Selected.Transpose1(new Rays._3D.Vector3(5, 0, 0));
                    трассироватьToolStripMenuItem_Click(null, null);
                    InvF = true;
                    break;
                case Keys.L:
                    if (Proj.Scene.Selected != null) Proj.Scene.Selected.Transpose1(new Rays._3D.Vector3(-5, 0, 0));
                    трассироватьToolStripMenuItem_Click(null, null);
                    InvF = true;
                    break;
                case Keys.Add:
                    if (Proj.Scene.Selected != null) Proj.Scene.Selected.Scale1(new Rays._3D.Vector3(1.1, 1.1, 1.1));
                    трассироватьToolStripMenuItem_Click(null, null);
                    InvF = true;
                    break;
                case Keys.Subtract:
                    if (Proj.Scene.Selected != null) Proj.Scene.Selected.Scale1(new Rays._3D.Vector3(0.9, 0.9, 0.9));
                    трассироватьToolStripMenuItem_Click(null, null);
                    InvF = true;
                    break;
                case Keys.U:
                    if (Proj.Scene.Selected != null) Proj.Scene.Selected.Rotate1(5, 'x');
                    трассироватьToolStripMenuItem_Click(null, null);
                    InvF = true;
                    break;
                case Keys.O:
                    if (Proj.Scene.Selected != null) Proj.Scene.Selected.Rotate1(-5, 'x');
                    трассироватьToolStripMenuItem_Click(null, null);
                    InvF = true;
                    break;
                case Keys.PageDown:
                    if (Proj.Scene.Selected != null) Proj.Scene.Selected.Transpose1(new Rays._3D.Vector3(0, -5, 0));
                    трассироватьToolStripMenuItem_Click(null, null);
                    InvF = true;
                    break;
                case Keys.PageUp:
                    if (Proj.Scene.Selected != null) Proj.Scene.Selected.Transpose1(new Rays._3D.Vector3(0, 5, 0));
                    трассироватьToolStripMenuItem_Click(null, null);
                    InvF = true;
                    break;
            }
            if (InvF)
            {
                Canvas_Resize(null, null);
                Canvas.Invalidate();
                e.Handled = true;
            }
        }

        private void reinitOpenGLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canvas.DestroyContexts();
            Canvas.InitializeContexts();
            Utils.SetupGL();
        }

        private void lOGENABLERToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Rays.Properties.Settings.Default.LogEnable = lOGENABLERToolStripMenuItem.Checked;
            Rays.Properties.Settings.Default.Save();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AboutForm();
            f.ShowDialog();
            f.Dispose();
        }

        private void multiThreadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rays.Properties.Settings.Default.MultiThread = multiThreadToolStripMenuItem.Checked;
            Rays.Properties.Settings.Default.Save();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proj.FileName != string.Empty)
                SaveProject(Proj.FileName);
            else
                сохранитькакToolStripMenuItem_Click(sender, e);
        }

        private DialogResult AskForUnsaved()
        {
            if (Proj.ChangesUnsaved)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения в проекте \"" + Proj.Name + "\"?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        SaveProject(Proj.FileName);
                        return result;
                    case System.Windows.Forms.DialogResult.Cancel:
                    case System.Windows.Forms.DialogResult.No:
                        return result;

                }
            }
            return System.Windows.Forms.DialogResult.Yes;
        }

        private void открытьСценуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            OpenFile.Filter = "Rays проект (*.ray)|*.ray|XML файлы (*.xml)|*.xml|Все файлы|*.*";
            OpenFile.FileName = "";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                LoadProject(OpenFile.FileName);
                Canvas_Resize(sender, null);
                Canvas.Invalidate();
                UpdateWindowTitle();
                UpdateFileHistory(OpenFile.FileName);

            }
        }

        private void LoadProject(string FileName)
        {
            try
            {
                ButtonAbortCalc_Click(null, null);
                ConsWrite("[i] Начинается загрузка файла \"" + FileName + "\".");
                DateTime Dt = DateTime.Now;
                Proj = Project3D.Load(FileName);
                Proj.FileName = FileName;

                TimeSpan Ts = DateTime.Now - Dt;
                ConsWrite("[i] Загрузка файла завершена \"" + FileName + "\" за " + Ts.TotalSeconds + " сек.");

                FormSceneObjectList();

            }
            catch (Exception ex)
            {
                ConsWrite(@"/!\ Произошла ошибка при загрузке сцены: " + ex.Message + " " + ex.StackTrace);
            }
        }

        private void SaveProject(string FileName, bool AsDefault = false)
        {
            try
            {
                ButtonAbortCalc_Click(null, null);
                ConsWrite("[i] Начинается сохранение файла \"" + FileName + "\".");
                DateTime Dt = DateTime.Now;
                Proj.Save(FileName);
                TimeSpan Ts = DateTime.Now - Dt;
                ConsWrite("[i] Сохранение файла завершено \"" + FileName + "\" за " + Ts.TotalSeconds + " сек.");
                if (!AsDefault)
                {
                    Proj.FileName = FileName;
                    Proj.ChangesUnsaved = false;
                    UpdateFileHistory(FileName);
                    UpdateWindowTitle();
                }
            }
            catch (Exception ex)
            {
                ConsWrite(@"/!\ Произошла ошибка при сохранении сцены: " + ex.Message + " " + ex.StackTrace);
            }
        }

        private void новыяСценаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonAbortCalc_Click(null, null);
            DialogResult r = AskForUnsaved();
            if (r != System.Windows.Forms.DialogResult.Cancel)
            {
                Proj = new Project3D();
            }

            Canvas.Invalidate();
            UpdateWindowTitle();
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile.InitialDirectory = Rays.Properties.Settings.Default.LastPath == string.Empty ||
                !Directory.Exists(Rays.Properties.Settings.Default.LastPath) ?
                Path.GetDirectoryName(Application.ExecutablePath) : Rays.Properties.Settings.Default.LastPath;
            SaveFile.Filter = "Rays проект (*.ray)|*.ray|XML файлы (*.xml)|*.xml|Все файлы|*.*";
            SaveFile.FileName = "Новый.ray";
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                SaveProject(SaveFile.FileName);
                UpdateWindowTitle();
            }

            try
            {
                Rays.Properties.Settings.Default.LastPath = Path.GetDirectoryName(SaveFile.FileName);
                Rays.Properties.Settings.Default.Save();
            }
            catch { }

        }

        private void toolStripButtonNewScene_Click(object sender, EventArgs e)
        {
            новыяСценаToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonSceneOpen_Click(object sender, EventArgs e)
        {
            открытьСценуToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonSaveScene_Click(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem_Click(sender, e);
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettings(0);
        }

        private void ButtonAbortCalc_Click(object sender, EventArgs e)
        {
            if (Tracer.InWork)
            {
                Tracer.AbortCalculation();
                ConsWrite(@"/!\ Трассировка лучей прервана вручную!");
            }
            CalculationControlsVisibility(false);
        }

        private void Timer1Sec_Tick(object sender, EventArgs e)
        {

            var esl = DateTime.Now - StartTime;

            ProgressLabel.Text = "Прошло " + esl.Minutes.ToString("00") + ":" + esl.Seconds.ToString("00");

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AskForUnsaved() == System.Windows.Forms.DialogResult.Cancel)
                e.Cancel = true;
            else
                ButtonAbortCalc_Click(null, null);

        }


        private void памяткаПоКлавишамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MiniHelp == null || MiniHelp.IsDisposed)
                MiniHelp = new MiniHelpForm();
            MiniHelp.Show();
        }


        private void OpenRecentFile(object sender, EventArgs e)
        {
            var Item = sender as ToolStripMenuItem;
            if (Item != null)
            {
                string fName = Item.Text.Substring(2);
                ProperlyOpenFile(fName);
            }
        }

        private void ProperlyOpenFile(string FileName)
        {
            UpdateFileHistory(FileName);
            if (FileName == string.Empty)
                return;
            string ext = Path.GetExtension(FileName).ToUpper();
            if (ext == ".CS")
                ExecuteCS(FileName);
            else if (ext == ".RAY")
                LoadProject(FileName);
            else
                ConsWrite("/!\\ Неизвестное расширение файла. Используйте *.CS или *.RAY.");
            Canvas.Invalidate();

        }


        private void tsbMiniHelp_Click(object sender, EventArgs e)
        {
            памяткаПоКлавишамToolStripMenuItem_Click(sender, e);
        }

        private void копироватьСообщенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Cons.Text);
        }

        private void развернутьСообщенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oldSplitPos > 0)
            {
                splitContainer1.SplitterDistance = oldSplitPos;
                if (splitContainer1.SplitterDistance > splitContainer1.Height - 55)
                    splitContainer1.SplitterDistance = Math.Abs(splitContainer1.Height - 260);
            }
        }

        private void свернутьСообщенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oldSplitPos != splitContainer1.SplitterDistance)
                oldSplitPos = splitContainer1.SplitterDistance;
            splitContainer1.SplitterDistance = Math.Abs(splitContainer1.Height - 60);
        }

        private void очиститьСообщенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cons.Text = "";
        }

        private void OpenProjectSettings(int Tab)
        {
            var f = new ProjectSettings(Proj);
            f.tabControl1.SelectedIndex = Tab;
            var dres = f.ShowDialog();

            if (dres == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Proj.ChangesUnsaved = true;
                    UpdateWindowTitle();

                    Proj.Scene.BuildVBO(true);
                    Proj.Scene.TransformFiguresAndMergeFaces();
                    Canvas.Invalidate();
                    ConsWrite("[i] Настройки проекта \"" + Proj.Name + "\" сохранены.");

                }
                catch (Exception ex)
                {
                    ConsWrite(@"/!\ Произошла ошибка при сохранении настроек проекта: " + ex.Message);
                }
            }

            f.Dispose();
        }

        private void параметрыПроектаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProjectSettings(0);
        }

        private void octreeBuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ТЕСТ
            //         Proj.Scene.MyOctree.BuildTree(Proj.Scene.Figs[0].Faces);
            ConsWrite("Деревяха запилена! :)");
            oct = Proj.Scene.MyOctree;
            Canvas.Invalidate();
        }

        private void lOGENABLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lOGENABLERToolStripMenuItem.Checked)
            {
                Tracer3D.cw = ConsWriteThr;
                Plane3D.cw = ConsWriteThr;
                Ray3D.cw = ConsWriteThr;
                Tube3D.cw = ConsWriteThr;
                Triangle.cw = ConsWriteThr;
                Octree.cw = ConsWriteThr;
            }
            else
            {
                Tracer3D.cw = null;
                Plane3D.cw = null;
                Ray3D.cw = null;
                Tube3D.cw = null;
                Triangle.cw = null;
                Octree.cw = null;
            }
        }

        public void ObjectSelect_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem Item in объектыНаСценеToolStripMenuItem.DropDownItems)
            {
                Item.Checked = sender as ToolStripMenuItem == Item;
                if (Item.Checked)
                {
                    Proj.Scene.SelectFigure(Item.Tag as Figure3D);
                    if (Proj.Scene.Selected != null)
                    {
                        ConsWrite("Selected figure <" + Proj.Scene.Selected.Name + "> with ID = " + Proj.Scene.Selected.ID);
                        UpdateWindowTitle();
                        Canvas.Invalidate();
                    }
                    return;

                }
            }
        }

        public void FormSceneObjectList()
        {
            объектыНаСценеToolStripMenuItem.DropDownItems.Clear();

            int i = 1;
            foreach (Figure3D F in Proj.Scene.Figs)
            {
                string FigureName = F.GetName();
                var MenuItem = new ToolStripMenuItem(i.ToString() + ". " + FigureName, null, new EventHandler(ObjectSelect_Click));
                if (Proj.Scene.Selected == F)
                    MenuItem.Checked = true;
                MenuItem.Tag = F;
                объектыНаСценеToolStripMenuItem.DropDownItems.Add(MenuItem);
                ++i;
            }
        }

        private void Canvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
         //     ConsWrite("Double click");
            Proj.Camera.See(0, false);
            Proj.Scene.PickFigure(e.X, e.Y);
          /*  if (Proj.Scene.Selected != null)
                 ConsWrite(Proj.Scene.Selected.ID.ToString());
            else
                 ConsWrite("miss pick!");*/
            Canvas.Invalidate();
            UpdateWindowTitle();
            FormSceneObjectList();
        }

        private void скрытьЛучиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proj.Scene.DisableRays();
            Canvas.Invalidate();
        }

        private void трансформацияОбъектаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (TransformEdit != null && !TransformEdit.IsDisposed)
            {
                TransformEdit.Close();
                TransformEdit.Dispose();
            }
            if (Proj.Scene.Selected == null)
                return;
            TransformEdit = new TransformEditor(Proj);
            TransformEdit.ParrentForm = this;
            TransformEdit.Show();

        }

        private void удалитьОбъектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Proj.Scene.Selected != null)
            {
                try
                {
                    string FigName = Proj.Scene.Selected.GetName();
                    Proj.Scene.RemoveFigure(Proj.Scene.Selected);
                    ConsWrite("[i] Фигура удалена <" + FigName + ">.");

                    Canvas.Invalidate();
                }
                catch(Exception ex)
                {
                    ConsWrite("Error. " + ex.Message);
                }
            }
        }

        private void memoryUsageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total memory usage in bytes: " + GC.GetTotalMemory(false));
        }

        private void использованиеПамятиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsWrite("Программой используется " + Utils.MemoryToStr(GC.GetTotalMemory(false)) + " памяти.");
        }
    }
}
