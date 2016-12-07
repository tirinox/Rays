namespace Rays.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Canvas = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.consoleToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripClearCons = new System.Windows.Forms.ToolStripButton();
            this.toolStripConsColorScheme = new System.Windows.Forms.ToolStripButton();
            this.toolStripConsMinimize = new System.Windows.Forms.ToolStripButton();
            this.toolStripConsMaximize = new System.Windows.Forms.ToolStripButton();
            this.toolStripConsCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMiniHelp = new System.Windows.Forms.ToolStripButton();
            this.ProgressSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.BarProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.ProgressLabel = new System.Windows.Forms.ToolStripLabel();
            this.ButtonAbortCalc = new System.Windows.Forms.ToolStripButton();
            this.Cons = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыяСценаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьСценуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитькакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.недавниеФайлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.выполнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перезагрузтитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.завершитьRaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сбросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приблизитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отдалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.сообщенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьСообщенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.развернутьСообщенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьСообщенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьСообщенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вырезатьОбъектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьОбъектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьОбъектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьОбъектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объектыНаСценеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.трансформацияОбъектаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.диаграммаНаправленностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыПроектаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лучиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.трассироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоНачальныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIR_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIR_5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIR_20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIR_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIR_500 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIR_1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIR_5000 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIR_10000 = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоВидимыхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVR_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVR_50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVR_10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVR_5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVR_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVR_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.грубинаТрассировкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTD_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTD_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTD_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTD_5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTD_7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTD_10 = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьЛучиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вычисленияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.картаИнтенсивностиПоляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьКартуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.памяткаПоКлавишамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.использованиеПамятиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEBUGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOGENABLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinitOpenGLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiThreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.octreeBuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotSampleGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryUsageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNewScene = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSceneOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveScene = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripOpenScene = new System.Windows.Forms.ToolStripButton();
            this.toolStripReloadScene = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripResetView = new System.Windows.Forms.ToolStripButton();
            this.toolStripZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTrace = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxIR = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxVR = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxTD = new System.Windows.Forms.ToolStripComboBox();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.Timer1Sec = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.consoleToolStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 83);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Canvas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.consoleToolStrip);
            this.splitContainer1.Panel2.Controls.Add(this.Cons);
            this.splitContainer1.Size = new System.Drawing.Size(875, 429);
            this.splitContainer1.SplitterDistance = 302;
            this.splitContainer1.TabIndex = 2;
            // 
            // Canvas
            // 
            this.Canvas.AccumBits = ((byte)(0));
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.AutoCheckErrors = false;
            this.Canvas.AutoFinish = false;
            this.Canvas.AutoMakeCurrent = true;
            this.Canvas.AutoSwapBuffers = true;
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.ColorBits = ((byte)(32));
            this.Canvas.DepthBits = ((byte)(16));
            this.Canvas.ForeColor = System.Drawing.Color.White;
            this.Canvas.Location = new System.Drawing.Point(3, 8);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(869, 291);
            this.Canvas.StencilBits = ((byte)(0));
            this.Canvas.TabIndex = 2;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Canvas_KeyDown);
            this.Canvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDoubleClick);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            this.Canvas.Resize += new System.EventHandler(this.Canvas_Resize);
            // 
            // consoleToolStrip
            // 
            this.consoleToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.consoleToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripClearCons,
            this.toolStripConsColorScheme,
            this.toolStripConsMinimize,
            this.toolStripConsMaximize,
            this.toolStripConsCopy,
            this.toolStripSeparator11,
            this.tsbMiniHelp,
            this.ProgressSeparator,
            this.BarProgress,
            this.ProgressLabel,
            this.ButtonAbortCalc});
            this.consoleToolStrip.Location = new System.Drawing.Point(0, 0);
            this.consoleToolStrip.Name = "consoleToolStrip";
            this.consoleToolStrip.Size = new System.Drawing.Size(875, 39);
            this.consoleToolStrip.TabIndex = 1;
            this.consoleToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(76, 36);
            this.toolStripLabel1.Text = "Сообщения:";
            // 
            // toolStripClearCons
            // 
            this.toolStripClearCons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripClearCons.Image = global::Rays.Properties.Resources.page_delete;
            this.toolStripClearCons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripClearCons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClearCons.Name = "toolStripClearCons";
            this.toolStripClearCons.Size = new System.Drawing.Size(36, 36);
            this.toolStripClearCons.Text = "Очистить сообщения";
            this.toolStripClearCons.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripConsColorScheme
            // 
            this.toolStripConsColorScheme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripConsColorScheme.Image = ((System.Drawing.Image)(resources.GetObject("toolStripConsColorScheme.Image")));
            this.toolStripConsColorScheme.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripConsColorScheme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConsColorScheme.Name = "toolStripConsColorScheme";
            this.toolStripConsColorScheme.Size = new System.Drawing.Size(36, 36);
            this.toolStripConsColorScheme.Text = "Цветовая схема";
            this.toolStripConsColorScheme.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripConsMinimize
            // 
            this.toolStripConsMinimize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripConsMinimize.Image = global::Rays.Properties.Resources.arrow_down;
            this.toolStripConsMinimize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripConsMinimize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConsMinimize.Name = "toolStripConsMinimize";
            this.toolStripConsMinimize.Size = new System.Drawing.Size(36, 36);
            this.toolStripConsMinimize.Text = "Свернуть сообщения";
            this.toolStripConsMinimize.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripConsMaximize
            // 
            this.toolStripConsMaximize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripConsMaximize.Image = global::Rays.Properties.Resources.arrow_up;
            this.toolStripConsMaximize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripConsMaximize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConsMaximize.Name = "toolStripConsMaximize";
            this.toolStripConsMaximize.Size = new System.Drawing.Size(36, 36);
            this.toolStripConsMaximize.Text = "Развернуть сообщения";
            this.toolStripConsMaximize.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripConsCopy
            // 
            this.toolStripConsCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripConsCopy.Image = global::Rays.Properties.Resources.page_copy;
            this.toolStripConsCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripConsCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConsCopy.Name = "toolStripConsCopy";
            this.toolStripConsCopy.Size = new System.Drawing.Size(36, 36);
            this.toolStripConsCopy.Text = "Копировать текст";
            this.toolStripConsCopy.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbMiniHelp
            // 
            this.tsbMiniHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMiniHelp.Image = global::Rays.Properties.Resources.keyboard_help;
            this.tsbMiniHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMiniHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMiniHelp.Name = "tsbMiniHelp";
            this.tsbMiniHelp.Size = new System.Drawing.Size(36, 36);
            this.tsbMiniHelp.Text = "Памятка по клавиатуре";
            this.tsbMiniHelp.Click += new System.EventHandler(this.tsbMiniHelp_Click);
            // 
            // ProgressSeparator
            // 
            this.ProgressSeparator.Name = "ProgressSeparator";
            this.ProgressSeparator.Size = new System.Drawing.Size(6, 39);
            this.ProgressSeparator.Visible = false;
            // 
            // BarProgress
            // 
            this.BarProgress.AutoSize = false;
            this.BarProgress.BackColor = System.Drawing.SystemColors.Control;
            this.BarProgress.ForeColor = System.Drawing.SystemColors.Control;
            this.BarProgress.Name = "BarProgress";
            this.BarProgress.Size = new System.Drawing.Size(100, 24);
            this.BarProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.BarProgress.Visible = false;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(27, 36);
            this.ProgressLabel.Text = "----";
            this.ProgressLabel.Visible = false;
            // 
            // ButtonAbortCalc
            // 
            this.ButtonAbortCalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonAbortCalc.Image = global::Rays.Properties.Resources.stop;
            this.ButtonAbortCalc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonAbortCalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAbortCalc.Name = "ButtonAbortCalc";
            this.ButtonAbortCalc.Size = new System.Drawing.Size(36, 36);
            this.ButtonAbortCalc.Text = "Прекратить расчет";
            this.ButtonAbortCalc.Visible = false;
            this.ButtonAbortCalc.Click += new System.EventHandler(this.ButtonAbortCalc_Click);
            // 
            // Cons
            // 
            this.Cons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Cons.BackColor = System.Drawing.SystemColors.Control;
            this.Cons.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cons.ForeColor = System.Drawing.Color.DarkBlue;
            this.Cons.Location = new System.Drawing.Point(3, 34);
            this.Cons.Multiline = true;
            this.Cons.Name = "Cons";
            this.Cons.ReadOnly = true;
            this.Cons.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Cons.Size = new System.Drawing.Size(869, 86);
            this.Cons.TabIndex = 0;
            this.Cons.WordWrap = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem,
            this.редактированиеToolStripMenuItem,
            this.лучиToolStripMenuItem,
            this.вычисленияToolStripMenuItem,
            this.помощьToolStripMenuItem,
            this.dEBUGToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыяСценаToolStripMenuItem,
            this.открытьСценуToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитькакToolStripMenuItem,
            this.недавниеФайлыToolStripMenuItem,
            this.toolStripSeparator9,
            this.выполнитьToolStripMenuItem,
            this.перезагрузтитьToolStripMenuItem,
            this.toolStripMenuItem1,
            this.завершитьRaysToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // новыяСценаToolStripMenuItem
            // 
            this.новыяСценаToolStripMenuItem.Image = global::Rays.Properties.Resources.page_brick;
            this.новыяСценаToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.новыяСценаToolStripMenuItem.Name = "новыяСценаToolStripMenuItem";
            this.новыяСценаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.новыяСценаToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.новыяСценаToolStripMenuItem.Text = "&Новыя сцена";
            this.новыяСценаToolStripMenuItem.Click += new System.EventHandler(this.новыяСценаToolStripMenuItem_Click);
            // 
            // открытьСценуToolStripMenuItem
            // 
            this.открытьСценуToolStripMenuItem.Image = global::Rays.Properties.Resources.folder_brick;
            this.открытьСценуToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.открытьСценуToolStripMenuItem.Name = "открытьСценуToolStripMenuItem";
            this.открытьСценуToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьСценуToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.открытьСценуToolStripMenuItem.Text = "Открыть сцену...";
            this.открытьСценуToolStripMenuItem.Click += new System.EventHandler(this.открытьСценуToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Image = global::Rays.Properties.Resources.disk_brick;
            this.сохранитьToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.сохранитьToolStripMenuItem.Text = "&Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитькакToolStripMenuItem
            // 
            this.сохранитькакToolStripMenuItem.Image = global::Rays.Properties.Resources.disk_brick;
            this.сохранитькакToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.сохранитькакToolStripMenuItem.Name = "сохранитькакToolStripMenuItem";
            this.сохранитькакToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.сохранитькакToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.сохранитькакToolStripMenuItem.Text = "Сохранить &как...";
            this.сохранитькакToolStripMenuItem.Click += new System.EventHandler(this.сохранитькакToolStripMenuItem_Click);
            // 
            // недавниеФайлыToolStripMenuItem
            // 
            this.недавниеФайлыToolStripMenuItem.Name = "недавниеФайлыToolStripMenuItem";
            this.недавниеФайлыToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.недавниеФайлыToolStripMenuItem.Text = "Недавние файлы";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(292, 6);
            // 
            // выполнитьToolStripMenuItem
            // 
            this.выполнитьToolStripMenuItem.Image = global::Rays.Properties.Resources.folder_database;
            this.выполнитьToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.выполнитьToolStripMenuItem.Name = "выполнитьToolStripMenuItem";
            this.выполнитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.выполнитьToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.выполнитьToolStripMenuItem.Text = "&Выполнить C# скрипт...";
            this.выполнитьToolStripMenuItem.Click += new System.EventHandler(this.выполнитьToolStripMenuItem_Click);
            // 
            // перезагрузтитьToolStripMenuItem
            // 
            this.перезагрузтитьToolStripMenuItem.Image = global::Rays.Properties.Resources.database_refresh;
            this.перезагрузтитьToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.перезагрузтитьToolStripMenuItem.Name = "перезагрузтитьToolStripMenuItem";
            this.перезагрузтитьToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.перезагрузтитьToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.перезагрузтитьToolStripMenuItem.Text = "&Перезагрузить C# скрипт";
            this.перезагрузтитьToolStripMenuItem.Click += new System.EventHandler(this.перезагрузтитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(292, 6);
            // 
            // завершитьRaysToolStripMenuItem
            // 
            this.завершитьRaysToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("завершитьRaysToolStripMenuItem.Image")));
            this.завершитьRaysToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.завершитьRaysToolStripMenuItem.Name = "завершитьRaysToolStripMenuItem";
            this.завершитьRaysToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.завершитьRaysToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.завершитьRaysToolStripMenuItem.Text = "&Завершить Rays";
            this.завершитьRaysToolStripMenuItem.Click += new System.EventHandler(this.завершитьRaysToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сбросToolStripMenuItem,
            this.приблизитьToolStripMenuItem,
            this.отдалитьToolStripMenuItem,
            this.toolStripSeparator7,
            this.сообщенияToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Ви&д";
            // 
            // сбросToolStripMenuItem
            // 
            this.сбросToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сбросToolStripMenuItem.Image")));
            this.сбросToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.сбросToolStripMenuItem.Name = "сбросToolStripMenuItem";
            this.сбросToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.сбросToolStripMenuItem.Size = new System.Drawing.Size(197, 38);
            this.сбросToolStripMenuItem.Text = "&Сброс";
            this.сбросToolStripMenuItem.Click += new System.EventHandler(this.сбросToolStripMenuItem_Click);
            // 
            // приблизитьToolStripMenuItem
            // 
            this.приблизитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("приблизитьToolStripMenuItem.Image")));
            this.приблизитьToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.приблизитьToolStripMenuItem.Name = "приблизитьToolStripMenuItem";
            this.приблизитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.приблизитьToolStripMenuItem.Size = new System.Drawing.Size(197, 38);
            this.приблизитьToolStripMenuItem.Text = "&Приблизить";
            this.приблизитьToolStripMenuItem.Click += new System.EventHandler(this.приблизитьToolStripMenuItem_Click);
            // 
            // отдалитьToolStripMenuItem
            // 
            this.отдалитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("отдалитьToolStripMenuItem.Image")));
            this.отдалитьToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.отдалитьToolStripMenuItem.Name = "отдалитьToolStripMenuItem";
            this.отдалитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.отдалитьToolStripMenuItem.Size = new System.Drawing.Size(197, 38);
            this.отдалитьToolStripMenuItem.Text = "&Отдалить";
            this.отдалитьToolStripMenuItem.Click += new System.EventHandler(this.отдалитьToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(194, 6);
            // 
            // сообщенияToolStripMenuItem
            // 
            this.сообщенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьСообщенияToolStripMenuItem,
            this.развернутьСообщенияToolStripMenuItem,
            this.свернутьСообщенияToolStripMenuItem,
            this.копироватьСообщенияToolStripMenuItem});
            this.сообщенияToolStripMenuItem.Image = global::Rays.Properties.Resources.application_osx_terminal;
            this.сообщенияToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.сообщенияToolStripMenuItem.Name = "сообщенияToolStripMenuItem";
            this.сообщенияToolStripMenuItem.Size = new System.Drawing.Size(197, 38);
            this.сообщенияToolStripMenuItem.Text = "Сооб&щения";
            // 
            // очиститьСообщенияToolStripMenuItem
            // 
            this.очиститьСообщенияToolStripMenuItem.Image = global::Rays.Properties.Resources.page_delete;
            this.очиститьСообщенияToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.очиститьСообщенияToolStripMenuItem.Name = "очиститьСообщенияToolStripMenuItem";
            this.очиститьСообщенияToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.X)));
            this.очиститьСообщенияToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.очиститьСообщенияToolStripMenuItem.Text = "&Очистить сообщения";
            this.очиститьСообщенияToolStripMenuItem.Click += new System.EventHandler(this.очиститьСообщенияToolStripMenuItem_Click);
            // 
            // развернутьСообщенияToolStripMenuItem
            // 
            this.развернутьСообщенияToolStripMenuItem.Image = global::Rays.Properties.Resources.arrow_up;
            this.развернутьСообщенияToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.развернутьСообщенияToolStripMenuItem.Name = "развернутьСообщенияToolStripMenuItem";
            this.развернутьСообщенияToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Up)));
            this.развернутьСообщенияToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.развернутьСообщенияToolStripMenuItem.Text = "&Развернуть сообщения";
            this.развернутьСообщенияToolStripMenuItem.Click += new System.EventHandler(this.развернутьСообщенияToolStripMenuItem_Click);
            // 
            // свернутьСообщенияToolStripMenuItem
            // 
            this.свернутьСообщенияToolStripMenuItem.Image = global::Rays.Properties.Resources.arrow_down;
            this.свернутьСообщенияToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.свернутьСообщенияToolStripMenuItem.Name = "свернутьСообщенияToolStripMenuItem";
            this.свернутьСообщенияToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Down)));
            this.свернутьСообщенияToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.свернутьСообщенияToolStripMenuItem.Text = "С&вернуть сообщения";
            this.свернутьСообщенияToolStripMenuItem.Click += new System.EventHandler(this.свернутьСообщенияToolStripMenuItem_Click);
            // 
            // копироватьСообщенияToolStripMenuItem
            // 
            this.копироватьСообщенияToolStripMenuItem.Image = global::Rays.Properties.Resources.page_copy;
            this.копироватьСообщенияToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.копироватьСообщенияToolStripMenuItem.Name = "копироватьСообщенияToolStripMenuItem";
            this.копироватьСообщенияToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.копироватьСообщенияToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.копироватьСообщенияToolStripMenuItem.Text = "&Копировать сообщения";
            this.копироватьСообщенияToolStripMenuItem.Click += new System.EventHandler(this.копироватьСообщенияToolStripMenuItem_Click);
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вырезатьОбъектToolStripMenuItem,
            this.копироватьОбъектToolStripMenuItem,
            this.вставитьОбъектToolStripMenuItem,
            this.удалитьОбъектToolStripMenuItem,
            this.объектыНаСценеToolStripMenuItem,
            this.трансформацияОбъектаToolStripMenuItem,
            this.toolStripSeparator12,
            this.диаграммаНаправленностиToolStripMenuItem,
            this.параметрыПроектаToolStripMenuItem,
            this.toolStripSeparator8,
            this.настройкиToolStripMenuItem});
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.редактированиеToolStripMenuItem.Text = "&Редактирование";
            // 
            // вырезатьОбъектToolStripMenuItem
            // 
            this.вырезатьОбъектToolStripMenuItem.Image = global::Rays.Properties.Resources.cut;
            this.вырезатьОбъектToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.вырезатьОбъектToolStripMenuItem.Name = "вырезатьОбъектToolStripMenuItem";
            this.вырезатьОбъектToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.вырезатьОбъектToolStripMenuItem.Size = new System.Drawing.Size(274, 38);
            this.вырезатьОбъектToolStripMenuItem.Text = "Выреза&ть объект";
            // 
            // копироватьОбъектToolStripMenuItem
            // 
            this.копироватьОбъектToolStripMenuItem.Image = global::Rays.Properties.Resources.page_copy;
            this.копироватьОбъектToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.копироватьОбъектToolStripMenuItem.Name = "копироватьОбъектToolStripMenuItem";
            this.копироватьОбъектToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.копироватьОбъектToolStripMenuItem.Size = new System.Drawing.Size(274, 38);
            this.копироватьОбъектToolStripMenuItem.Text = "&Копировать объект";
            // 
            // вставитьОбъектToolStripMenuItem
            // 
            this.вставитьОбъектToolStripMenuItem.Image = global::Rays.Properties.Resources.paste_plain;
            this.вставитьОбъектToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.вставитьОбъектToolStripMenuItem.Name = "вставитьОбъектToolStripMenuItem";
            this.вставитьОбъектToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.вставитьОбъектToolStripMenuItem.Size = new System.Drawing.Size(274, 38);
            this.вставитьОбъектToolStripMenuItem.Text = "&Вставить объект";
            // 
            // удалитьОбъектToolStripMenuItem
            // 
            this.удалитьОбъектToolStripMenuItem.Image = global::Rays.Properties.Resources.cross;
            this.удалитьОбъектToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.удалитьОбъектToolStripMenuItem.Name = "удалитьОбъектToolStripMenuItem";
            this.удалитьОбъектToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.удалитьОбъектToolStripMenuItem.Size = new System.Drawing.Size(274, 38);
            this.удалитьОбъектToolStripMenuItem.Text = "&Удалить объект";
            this.удалитьОбъектToolStripMenuItem.Click += new System.EventHandler(this.удалитьОбъектToolStripMenuItem_Click);
            // 
            // объектыНаСценеToolStripMenuItem
            // 
            this.объектыНаСценеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.объектыНаСценеToolStripMenuItem.Image = global::Rays.Properties.Resources.shape_flip_horizontal;
            this.объектыНаСценеToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.объектыНаСценеToolStripMenuItem.Name = "объектыНаСценеToolStripMenuItem";
            this.объектыНаСценеToolStripMenuItem.Size = new System.Drawing.Size(274, 38);
            this.объектыНаСценеToolStripMenuItem.Text = "Объекты на сцене";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "1";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem4.Text = "2";
            // 
            // трансформацияОбъектаToolStripMenuItem
            // 
            this.трансформацияОбъектаToolStripMenuItem.Image = global::Rays.Properties.Resources.shape_group;
            this.трансформацияОбъектаToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.трансформацияОбъектаToolStripMenuItem.Name = "трансформацияОбъектаToolStripMenuItem";
            this.трансформацияОбъектаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.трансформацияОбъектаToolStripMenuItem.Size = new System.Drawing.Size(274, 38);
            this.трансформацияОбъектаToolStripMenuItem.Text = "Трансформация объекта";
            this.трансформацияОбъектаToolStripMenuItem.Click += new System.EventHandler(this.трансформацияОбъектаToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(271, 6);
            // 
            // диаграммаНаправленностиToolStripMenuItem
            // 
            this.диаграммаНаправленностиToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.диаграммаНаправленностиToolStripMenuItem.Image = global::Rays.Properties.Resources.feed;
            this.диаграммаНаправленностиToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.диаграммаНаправленностиToolStripMenuItem.Name = "диаграммаНаправленностиToolStripMenuItem";
            this.диаграммаНаправленностиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.диаграммаНаправленностиToolStripMenuItem.Size = new System.Drawing.Size(274, 38);
            this.диаграммаНаправленностиToolStripMenuItem.Text = "&Антенна";
            // 
            // параметрыПроектаToolStripMenuItem
            // 
            this.параметрыПроектаToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("параметрыПроектаToolStripMenuItem.Image")));
            this.параметрыПроектаToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.параметрыПроектаToolStripMenuItem.Name = "параметрыПроектаToolStripMenuItem";
            this.параметрыПроектаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.P)));
            this.параметрыПроектаToolStripMenuItem.Size = new System.Drawing.Size(274, 38);
            this.параметрыПроектаToolStripMenuItem.Text = "&Параметры проекта";
            this.параметрыПроектаToolStripMenuItem.Click += new System.EventHandler(this.параметрыПроектаToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(271, 6);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("настройкиToolStripMenuItem.Image")));
            this.настройкиToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(274, 38);
            this.настройкиToolStripMenuItem.Text = "&Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // лучиToolStripMenuItem
            // 
            this.лучиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.трассироватьToolStripMenuItem,
            this.количествоНачальныхToolStripMenuItem,
            this.количествоВидимыхToolStripMenuItem,
            this.грубинаТрассировкиToolStripMenuItem,
            this.скрытьЛучиToolStripMenuItem});
            this.лучиToolStripMenuItem.Name = "лучиToolStripMenuItem";
            this.лучиToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.лучиToolStripMenuItem.Text = "&Лучи";
            // 
            // трассироватьToolStripMenuItem
            // 
            this.трассироватьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("трассироватьToolStripMenuItem.Image")));
            this.трассироватьToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.трассироватьToolStripMenuItem.Name = "трассироватьToolStripMenuItem";
            this.трассироватьToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.трассироватьToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.трассироватьToolStripMenuItem.Text = "Трассировать";
            this.трассироватьToolStripMenuItem.Click += new System.EventHandler(this.трассироватьToolStripMenuItem_Click);
            // 
            // количествоНачальныхToolStripMenuItem
            // 
            this.количествоНачальныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemIR_1,
            this.toolStripMenuItemIR_5,
            this.toolStripMenuItemIR_20,
            this.toolStripMenuItemIR_100,
            this.toolStripMenuItemIR_500,
            this.toolStripMenuItemIR_1000,
            this.toolStripMenuItemIR_5000,
            this.toolStripMenuItemIR_10000});
            this.количествоНачальныхToolStripMenuItem.Name = "количествоНачальныхToolStripMenuItem";
            this.количествоНачальныхToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.количествоНачальныхToolStripMenuItem.Text = "Число начальных";
            // 
            // toolStripMenuItemIR_1
            // 
            this.toolStripMenuItemIR_1.Name = "toolStripMenuItemIR_1";
            this.toolStripMenuItemIR_1.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItemIR_1.Text = "1";
            this.toolStripMenuItemIR_1.Click += new System.EventHandler(this.toolStripMenuItemIR_1_Click);
            // 
            // toolStripMenuItemIR_5
            // 
            this.toolStripMenuItemIR_5.Name = "toolStripMenuItemIR_5";
            this.toolStripMenuItemIR_5.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItemIR_5.Text = "5";
            this.toolStripMenuItemIR_5.Click += new System.EventHandler(this.toolStripMenuItemIR_1_Click);
            // 
            // toolStripMenuItemIR_20
            // 
            this.toolStripMenuItemIR_20.Name = "toolStripMenuItemIR_20";
            this.toolStripMenuItemIR_20.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItemIR_20.Text = "20";
            this.toolStripMenuItemIR_20.Click += new System.EventHandler(this.toolStripMenuItemIR_1_Click);
            // 
            // toolStripMenuItemIR_100
            // 
            this.toolStripMenuItemIR_100.Name = "toolStripMenuItemIR_100";
            this.toolStripMenuItemIR_100.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItemIR_100.Text = "100";
            this.toolStripMenuItemIR_100.Click += new System.EventHandler(this.toolStripMenuItemIR_1_Click);
            // 
            // toolStripMenuItemIR_500
            // 
            this.toolStripMenuItemIR_500.Checked = true;
            this.toolStripMenuItemIR_500.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemIR_500.Name = "toolStripMenuItemIR_500";
            this.toolStripMenuItemIR_500.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItemIR_500.Text = "500";
            this.toolStripMenuItemIR_500.Click += new System.EventHandler(this.toolStripMenuItemIR_1_Click);
            // 
            // toolStripMenuItemIR_1000
            // 
            this.toolStripMenuItemIR_1000.Name = "toolStripMenuItemIR_1000";
            this.toolStripMenuItemIR_1000.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItemIR_1000.Text = "1000";
            this.toolStripMenuItemIR_1000.Click += new System.EventHandler(this.toolStripMenuItemIR_1_Click);
            // 
            // toolStripMenuItemIR_5000
            // 
            this.toolStripMenuItemIR_5000.Name = "toolStripMenuItemIR_5000";
            this.toolStripMenuItemIR_5000.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItemIR_5000.Text = "5000";
            this.toolStripMenuItemIR_5000.Click += new System.EventHandler(this.toolStripMenuItemIR_1_Click);
            // 
            // toolStripMenuItemIR_10000
            // 
            this.toolStripMenuItemIR_10000.Name = "toolStripMenuItemIR_10000";
            this.toolStripMenuItemIR_10000.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItemIR_10000.Text = "10000";
            this.toolStripMenuItemIR_10000.Click += new System.EventHandler(this.toolStripMenuItemIR_1_Click);
            // 
            // количествоВидимыхToolStripMenuItem
            // 
            this.количествоВидимыхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemVR_100,
            this.toolStripMenuItemVR_50,
            this.toolStripMenuItemVR_10,
            this.toolStripMenuItemVR_5,
            this.toolStripMenuItemVR_2,
            this.toolStripMenuItemVR_1,
            this.toolStripMenuItem5});
            this.количествоВидимыхToolStripMenuItem.Name = "количествоВидимыхToolStripMenuItem";
            this.количествоВидимыхToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.количествоВидимыхToolStripMenuItem.Text = "Число видимых";
            // 
            // toolStripMenuItemVR_100
            // 
            this.toolStripMenuItemVR_100.Checked = true;
            this.toolStripMenuItemVR_100.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemVR_100.Name = "toolStripMenuItemVR_100";
            this.toolStripMenuItemVR_100.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemVR_100.Text = "100%";
            this.toolStripMenuItemVR_100.Click += new System.EventHandler(this.toolStripMenuItemVR_100_Click);
            // 
            // toolStripMenuItemVR_50
            // 
            this.toolStripMenuItemVR_50.Name = "toolStripMenuItemVR_50";
            this.toolStripMenuItemVR_50.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemVR_50.Text = "50%";
            this.toolStripMenuItemVR_50.Click += new System.EventHandler(this.toolStripMenuItemVR_100_Click);
            // 
            // toolStripMenuItemVR_10
            // 
            this.toolStripMenuItemVR_10.Name = "toolStripMenuItemVR_10";
            this.toolStripMenuItemVR_10.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemVR_10.Text = "25%";
            this.toolStripMenuItemVR_10.Click += new System.EventHandler(this.toolStripMenuItemVR_100_Click);
            // 
            // toolStripMenuItemVR_5
            // 
            this.toolStripMenuItemVR_5.Name = "toolStripMenuItemVR_5";
            this.toolStripMenuItemVR_5.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemVR_5.Text = "10%";
            this.toolStripMenuItemVR_5.Click += new System.EventHandler(this.toolStripMenuItemVR_100_Click);
            // 
            // toolStripMenuItemVR_2
            // 
            this.toolStripMenuItemVR_2.Name = "toolStripMenuItemVR_2";
            this.toolStripMenuItemVR_2.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemVR_2.Text = "5%";
            this.toolStripMenuItemVR_2.Click += new System.EventHandler(this.toolStripMenuItemVR_100_Click);
            // 
            // toolStripMenuItemVR_1
            // 
            this.toolStripMenuItemVR_1.Name = "toolStripMenuItemVR_1";
            this.toolStripMenuItemVR_1.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemVR_1.Text = "2%";
            this.toolStripMenuItemVR_1.Click += new System.EventHandler(this.toolStripMenuItemVR_100_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem5.Text = "1%";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItemVR_100_Click);
            // 
            // грубинаТрассировкиToolStripMenuItem
            // 
            this.грубинаТрассировкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTD_2,
            this.toolStripMenuItemTD_3,
            this.toolStripMenuItemTD_4,
            this.toolStripMenuItemTD_5,
            this.toolStripMenuItemTD_7,
            this.toolStripMenuItemTD_10});
            this.грубинаТрассировкиToolStripMenuItem.Name = "грубинаТрассировкиToolStripMenuItem";
            this.грубинаТрассировкиToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.грубинаТрассировкиToolStripMenuItem.Text = "Грубина трассировки";
            // 
            // toolStripMenuItemTD_2
            // 
            this.toolStripMenuItemTD_2.Name = "toolStripMenuItemTD_2";
            this.toolStripMenuItemTD_2.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItemTD_2.Text = "2";
            this.toolStripMenuItemTD_2.Click += new System.EventHandler(this.toolStripMenuItemTD_2_Click);
            // 
            // toolStripMenuItemTD_3
            // 
            this.toolStripMenuItemTD_3.Name = "toolStripMenuItemTD_3";
            this.toolStripMenuItemTD_3.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItemTD_3.Text = "3";
            this.toolStripMenuItemTD_3.Click += new System.EventHandler(this.toolStripMenuItemTD_2_Click);
            // 
            // toolStripMenuItemTD_4
            // 
            this.toolStripMenuItemTD_4.Name = "toolStripMenuItemTD_4";
            this.toolStripMenuItemTD_4.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItemTD_4.Text = "4";
            this.toolStripMenuItemTD_4.Click += new System.EventHandler(this.toolStripMenuItemTD_2_Click);
            // 
            // toolStripMenuItemTD_5
            // 
            this.toolStripMenuItemTD_5.Checked = true;
            this.toolStripMenuItemTD_5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemTD_5.Name = "toolStripMenuItemTD_5";
            this.toolStripMenuItemTD_5.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItemTD_5.Text = "5";
            this.toolStripMenuItemTD_5.Click += new System.EventHandler(this.toolStripMenuItemTD_2_Click);
            // 
            // toolStripMenuItemTD_7
            // 
            this.toolStripMenuItemTD_7.Name = "toolStripMenuItemTD_7";
            this.toolStripMenuItemTD_7.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItemTD_7.Text = "7";
            this.toolStripMenuItemTD_7.Click += new System.EventHandler(this.toolStripMenuItemTD_2_Click);
            // 
            // toolStripMenuItemTD_10
            // 
            this.toolStripMenuItemTD_10.Name = "toolStripMenuItemTD_10";
            this.toolStripMenuItemTD_10.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItemTD_10.Text = "10";
            this.toolStripMenuItemTD_10.Click += new System.EventHandler(this.toolStripMenuItemTD_2_Click);
            // 
            // скрытьЛучиToolStripMenuItem
            // 
            this.скрытьЛучиToolStripMenuItem.Image = global::Rays.Properties.Resources.lightbulb_delete;
            this.скрытьЛучиToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.скрытьЛучиToolStripMenuItem.Name = "скрытьЛучиToolStripMenuItem";
            this.скрытьЛучиToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.скрытьЛучиToolStripMenuItem.Text = "&Скрыть лучи";
            this.скрытьЛучиToolStripMenuItem.Click += new System.EventHandler(this.скрытьЛучиToolStripMenuItem_Click);
            // 
            // вычисленияToolStripMenuItem
            // 
            this.вычисленияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.картаИнтенсивностиПоляToolStripMenuItem,
            this.скрытьКартуToolStripMenuItem});
            this.вычисленияToolStripMenuItem.Name = "вычисленияToolStripMenuItem";
            this.вычисленияToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.вычисленияToolStripMenuItem.Text = "&Вычисления";
            // 
            // картаИнтенсивностиПоляToolStripMenuItem
            // 
            this.картаИнтенсивностиПоляToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("картаИнтенсивностиПоляToolStripMenuItem.Image")));
            this.картаИнтенсивностиПоляToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.картаИнтенсивностиПоляToolStripMenuItem.Name = "картаИнтенсивностиПоляToolStripMenuItem";
            this.картаИнтенсивностиПоляToolStripMenuItem.RightToLeftAutoMirrorImage = true;
            this.картаИнтенсивностиПоляToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.картаИнтенсивностиПоляToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.картаИнтенсивностиПоляToolStripMenuItem.Text = "Карта интенсивности поля";
            this.картаИнтенсивностиПоляToolStripMenuItem.Click += new System.EventHandler(this.картаИнтенсивностиПоляToolStripMenuItem_Click);
            // 
            // скрытьКартуToolStripMenuItem
            // 
            this.скрытьКартуToolStripMenuItem.Name = "скрытьКартуToolStripMenuItem";
            this.скрытьКартуToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.скрытьКартуToolStripMenuItem.Text = "Скрыть карту";
            this.скрытьКартуToolStripMenuItem.Click += new System.EventHandler(this.скрытьКартуToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.помощьToolStripMenuItem1,
            this.памяткаПоКлавишамToolStripMenuItem,
            this.toolStripSeparator13,
            this.использованиеПамятиToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.помощьToolStripMenuItem.Text = "&Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("оПрограммеToolStripMenuItem.Image")));
            this.оПрограммеToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.оПрограммеToolStripMenuItem.Text = "О &программе...";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem1
            // 
            this.помощьToolStripMenuItem1.Image = global::Rays.Properties.Resources.help;
            this.помощьToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.помощьToolStripMenuItem1.Name = "помощьToolStripMenuItem1";
            this.помощьToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.помощьToolStripMenuItem1.Size = new System.Drawing.Size(219, 38);
            this.помощьToolStripMenuItem1.Text = "&Помощь";
            // 
            // памяткаПоКлавишамToolStripMenuItem
            // 
            this.памяткаПоКлавишамToolStripMenuItem.DoubleClickEnabled = true;
            this.памяткаПоКлавишамToolStripMenuItem.Image = global::Rays.Properties.Resources.keyboard_help;
            this.памяткаПоКлавишамToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.памяткаПоКлавишамToolStripMenuItem.Name = "памяткаПоКлавишамToolStripMenuItem";
            this.памяткаПоКлавишамToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.памяткаПоКлавишамToolStripMenuItem.Text = "Памятка по &клавишам";
            this.памяткаПоКлавишамToolStripMenuItem.Click += new System.EventHandler(this.памяткаПоКлавишамToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(216, 6);
            // 
            // использованиеПамятиToolStripMenuItem
            // 
            this.использованиеПамятиToolStripMenuItem.Name = "использованиеПамятиToolStripMenuItem";
            this.использованиеПамятиToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.использованиеПамятиToolStripMenuItem.Text = "&Использование памяти";
            this.использованиеПамятиToolStripMenuItem.Click += new System.EventHandler(this.использованиеПамятиToolStripMenuItem_Click);
            // 
            // dEBUGToolStripMenuItem
            // 
            this.dEBUGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lOGENABLERToolStripMenuItem,
            this.reinitOpenGLToolStripMenuItem,
            this.multiThreadToolStripMenuItem,
            this.octreeBuildToolStripMenuItem,
            this.plotSampleGraphToolStripMenuItem,
            this.memoryUsageToolStripMenuItem});
            this.dEBUGToolStripMenuItem.Name = "dEBUGToolStripMenuItem";
            this.dEBUGToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.dEBUGToolStripMenuItem.Text = "DEBUG";
            // 
            // lOGENABLERToolStripMenuItem
            // 
            this.lOGENABLERToolStripMenuItem.Checked = true;
            this.lOGENABLERToolStripMenuItem.CheckOnClick = true;
            this.lOGENABLERToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lOGENABLERToolStripMenuItem.Name = "lOGENABLERToolStripMenuItem";
            this.lOGENABLERToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.lOGENABLERToolStripMenuItem.Text = "LOG-ENABLER";
            this.lOGENABLERToolStripMenuItem.CheckedChanged += new System.EventHandler(this.lOGENABLERToolStripMenuItem_CheckedChanged);
            this.lOGENABLERToolStripMenuItem.Click += new System.EventHandler(this.lOGENABLERToolStripMenuItem_Click);
            // 
            // reinitOpenGLToolStripMenuItem
            // 
            this.reinitOpenGLToolStripMenuItem.Name = "reinitOpenGLToolStripMenuItem";
            this.reinitOpenGLToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.reinitOpenGLToolStripMenuItem.Text = "Reinit OpenGL";
            this.reinitOpenGLToolStripMenuItem.Click += new System.EventHandler(this.reinitOpenGLToolStripMenuItem_Click);
            // 
            // multiThreadToolStripMenuItem
            // 
            this.multiThreadToolStripMenuItem.Checked = true;
            this.multiThreadToolStripMenuItem.CheckOnClick = true;
            this.multiThreadToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.multiThreadToolStripMenuItem.Name = "multiThreadToolStripMenuItem";
            this.multiThreadToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.multiThreadToolStripMenuItem.Text = "MultiThread?";
            this.multiThreadToolStripMenuItem.Click += new System.EventHandler(this.multiThreadToolStripMenuItem_Click);
            // 
            // octreeBuildToolStripMenuItem
            // 
            this.octreeBuildToolStripMenuItem.Name = "octreeBuildToolStripMenuItem";
            this.octreeBuildToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.octreeBuildToolStripMenuItem.Text = "Octree Build";
            this.octreeBuildToolStripMenuItem.Click += new System.EventHandler(this.octreeBuildToolStripMenuItem_Click);
            // 
            // plotSampleGraphToolStripMenuItem
            // 
            this.plotSampleGraphToolStripMenuItem.Name = "plotSampleGraphToolStripMenuItem";
            this.plotSampleGraphToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.plotSampleGraphToolStripMenuItem.Text = "Plot sample graph";
            // 
            // memoryUsageToolStripMenuItem
            // 
            this.memoryUsageToolStripMenuItem.Name = "memoryUsageToolStripMenuItem";
            this.memoryUsageToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.memoryUsageToolStripMenuItem.Text = "Memory usage? =)";
            this.memoryUsageToolStripMenuItem.Click += new System.EventHandler(this.memoryUsageToolStripMenuItem_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.DefaultExt = "lua";
            this.OpenFile.FileName = "openFileDialog1";
            this.OpenFile.Title = "Открыть сцену";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNewScene,
            this.toolStripButtonSceneOpen,
            this.toolStripButtonSaveScene,
            this.toolStripSeparator10,
            this.toolStripOpenScene,
            this.toolStripReloadScene,
            this.toolStripSeparator1,
            this.toolStripResetView,
            this.toolStripZoomIn,
            this.toolStripZoomOut,
            this.toolStripSeparator2,
            this.toolStripTrace,
            this.toolStripSeparator5,
            this.toolStripButton2,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(875, 39);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNewScene
            // 
            this.toolStripButtonNewScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewScene.Image = global::Rays.Properties.Resources.page_brick;
            this.toolStripButtonNewScene.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonNewScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewScene.Name = "toolStripButtonNewScene";
            this.toolStripButtonNewScene.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonNewScene.Text = "Новая сцена";
            this.toolStripButtonNewScene.Click += new System.EventHandler(this.toolStripButtonNewScene_Click);
            // 
            // toolStripButtonSceneOpen
            // 
            this.toolStripButtonSceneOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSceneOpen.Image = global::Rays.Properties.Resources.folder_brick;
            this.toolStripButtonSceneOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSceneOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSceneOpen.Name = "toolStripButtonSceneOpen";
            this.toolStripButtonSceneOpen.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSceneOpen.Text = "Открыть сцену";
            this.toolStripButtonSceneOpen.Click += new System.EventHandler(this.toolStripButtonSceneOpen_Click);
            // 
            // toolStripButtonSaveScene
            // 
            this.toolStripButtonSaveScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveScene.Image = global::Rays.Properties.Resources.disk_brick;
            this.toolStripButtonSaveScene.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSaveScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveScene.Name = "toolStripButtonSaveScene";
            this.toolStripButtonSaveScene.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSaveScene.Text = "Сохранить сцену";
            this.toolStripButtonSaveScene.Click += new System.EventHandler(this.toolStripButtonSaveScene_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripOpenScene
            // 
            this.toolStripOpenScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOpenScene.Image = global::Rays.Properties.Resources.folder_database;
            this.toolStripOpenScene.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripOpenScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpenScene.Name = "toolStripOpenScene";
            this.toolStripOpenScene.Size = new System.Drawing.Size(36, 36);
            this.toolStripOpenScene.Text = "Открыть сцену";
            this.toolStripOpenScene.Click += new System.EventHandler(this.toolStripOpenScene_Click);
            // 
            // toolStripReloadScene
            // 
            this.toolStripReloadScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripReloadScene.Image = global::Rays.Properties.Resources.database_refresh;
            this.toolStripReloadScene.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripReloadScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripReloadScene.Name = "toolStripReloadScene";
            this.toolStripReloadScene.Size = new System.Drawing.Size(36, 36);
            this.toolStripReloadScene.Text = "Перезагрузить сцену";
            this.toolStripReloadScene.Click += new System.EventHandler(this.toolStripReloadScene_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripResetView
            // 
            this.toolStripResetView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripResetView.Image = ((System.Drawing.Image)(resources.GetObject("toolStripResetView.Image")));
            this.toolStripResetView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripResetView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripResetView.Name = "toolStripResetView";
            this.toolStripResetView.Size = new System.Drawing.Size(36, 36);
            this.toolStripResetView.Text = "Сброс параметров вида";
            this.toolStripResetView.Click += new System.EventHandler(this.toolStripResetView_Click);
            // 
            // toolStripZoomIn
            // 
            this.toolStripZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripZoomIn.Image")));
            this.toolStripZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripZoomIn.Name = "toolStripZoomIn";
            this.toolStripZoomIn.Size = new System.Drawing.Size(36, 36);
            this.toolStripZoomIn.Text = "Приблизить";
            this.toolStripZoomIn.Click += new System.EventHandler(this.toolStripZoomIn_Click);
            // 
            // toolStripZoomOut
            // 
            this.toolStripZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripZoomOut.Image")));
            this.toolStripZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripZoomOut.Name = "toolStripZoomOut";
            this.toolStripZoomOut.Size = new System.Drawing.Size(36, 36);
            this.toolStripZoomOut.Text = "Отдалить";
            this.toolStripZoomOut.Click += new System.EventHandler(this.toolStripZoomOut_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripTrace
            // 
            this.toolStripTrace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTrace.Image = ((System.Drawing.Image)(resources.GetObject("toolStripTrace.Image")));
            this.toolStripTrace.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripTrace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTrace.Name = "toolStripTrace";
            this.toolStripTrace.Size = new System.Drawing.Size(36, 36);
            this.toolStripTrace.Text = "Трассировать лучи";
            this.toolStripTrace.Click += new System.EventHandler(this.toolStripTrace_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel5,
            this.toolStripComboBoxIR,
            this.toolStripSeparator3,
            this.toolStripLabel6,
            this.toolStripComboBoxVR,
            this.toolStripSeparator4,
            this.toolStripLabel7,
            this.toolStripComboBoxTD});
            this.toolStrip2.Location = new System.Drawing.Point(0, 63);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(875, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(141, 22);
            this.toolStripLabel5.Text = "Число начальных лучей";
            // 
            // toolStripComboBoxIR
            // 
            this.toolStripComboBoxIR.Name = "toolStripComboBoxIR";
            this.toolStripComboBoxIR.Size = new System.Drawing.Size(75, 25);
            this.toolStripComboBoxIR.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxIR_SelectedIndexChanged);
            this.toolStripComboBoxIR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBoxIR_KeyPress);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(110, 22);
            this.toolStripLabel6.Text = "Отображать лучей";
            // 
            // toolStripComboBoxVR
            // 
            this.toolStripComboBoxVR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxVR.Name = "toolStripComboBoxVR";
            this.toolStripComboBoxVR.Size = new System.Drawing.Size(75, 25);
            this.toolStripComboBoxVR.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxVR_SelectedIndexChanged);
            this.toolStripComboBoxVR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBoxVR_KeyPress);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(126, 22);
            this.toolStripLabel7.Text = "Глубина трассировки";
            // 
            // toolStripComboBoxTD
            // 
            this.toolStripComboBoxTD.Name = "toolStripComboBoxTD";
            this.toolStripComboBoxTD.Size = new System.Drawing.Size(75, 25);
            this.toolStripComboBoxTD.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxTD_SelectedIndexChanged);
            this.toolStripComboBoxTD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBoxTD_KeyPress);
            // 
            // Timer1Sec
            // 
            this.Timer1Sec.Interval = 1000;
            this.Timer1Sec.Tick += new System.EventHandler(this.Timer1Sec_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(875, 514);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Rays v.2.0.2 © 2011 Tirinox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.consoleToolStrip.ResumeLayout(false);
            this.consoleToolStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox Cons;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выполнитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem завершитьRaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вычисленияToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.ToolStrip consoleToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripClearCons;
        private System.Windows.Forms.ToolStripButton toolStripConsColorScheme;
        private System.Windows.Forms.ToolStripButton toolStripConsMinimize;
        private System.Windows.Forms.ToolStripButton toolStripConsMaximize;
        private System.Windows.Forms.ToolStripButton toolStripConsCopy;
        private System.Windows.Forms.ToolStripMenuItem dEBUGToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripReloadScene;
        private System.Windows.Forms.ToolStripButton toolStripOpenScene;
        private System.Windows.Forms.ToolStripMenuItem перезагрузтитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripResetView;
        private System.Windows.Forms.ToolStripMenuItem лучиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem трассироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripTrace;
        private System.Windows.Forms.ToolStripMenuItem сбросToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приблизитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отдалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripZoomOut;
        private System.Windows.Forms.ToolStripMenuItem количествоНачальныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIR_1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIR_5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIR_20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIR_100;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIR_500;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIR_1000;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIR_5000;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIR_10000;
        private System.Windows.Forms.ToolStripMenuItem количествоВидимыхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVR_100;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVR_50;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVR_10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVR_5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVR_2;
        private System.Windows.Forms.ToolStripMenuItem картаИнтенсивностиПоляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVR_1;
        private System.Windows.Forms.ToolStripMenuItem грубинаТрассировкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTD_2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTD_3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTD_4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTD_5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTD_7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTD_10;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxIR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxVR;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxTD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem скрытьКартуToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ProgressSeparator;
        private System.Windows.Forms.ToolStripLabel ProgressLabel;
        private System.Windows.Forms.ToolStripProgressBar BarProgress;
        private System.Windows.Forms.ToolStripMenuItem lOGENABLERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reinitOpenGLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiThreadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыПроектаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem диаграммаНаправленностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem новыяСценаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьСценуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитькакToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewScene;
        private System.Windows.Forms.ToolStripButton toolStripButtonSceneOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveScene;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton ButtonAbortCalc;
        private System.Windows.Forms.Timer Timer1Sec;
        private System.Windows.Forms.ToolStripMenuItem памяткаПоКлавишамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem недавниеФайлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem сообщенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьСообщенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem развернутьСообщенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьСообщенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьСообщенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton tsbMiniHelp;
        private System.Windows.Forms.ToolStripMenuItem копироватьОбъектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьОбъектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вырезатьОбъектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьОбъектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem объектыНаСценеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem octreeBuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьЛучиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem трансформацияОбъектаToolStripMenuItem;
        public Tao.Platform.Windows.SimpleOpenGlControl Canvas;
        private System.Windows.Forms.ToolStripMenuItem plotSampleGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryUsageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem использованиеПамятиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
    }
}

