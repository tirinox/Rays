namespace Rays.Forms
{
    partial class AppSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbFoV = new Rays.TNumEditBox();
            this.radPerspective = new System.Windows.Forms.RadioButton();
            this.radIsometry = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBoxAxisMax = new Rays.TNumEditBox();
            this.txtBoxAxisStep = new Rays.TNumEditBox();
            this.chBoxAxisCaptions = new System.Windows.Forms.CheckBox();
            this.butPickFaceHighlightColor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chBoxFaceHighlight = new System.Windows.Forms.CheckBox();
            this.chBoxDrawAxis = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chBoxCollapseConsoleOnStartUp = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labFontView = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butSelectFont = new System.Windows.Forms.Button();
            this.butBackColor = new System.Windows.Forms.Button();
            this.butForeColor = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmbBoxMinFacesCount = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbBoxOctreeDeep = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chBoxEnableOctree = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBoxThreadNum = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chBoxMultithread = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.chBoxTraceOnMove = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.chBoxLoadAllRays = new System.Windows.Forms.CheckBox();
            this.ColorDiag = new System.Windows.Forms.ColorDialog();
            this.FontDiag = new System.Windows.Forms.FontDialog();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(11, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 420);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(717, 389);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Внешний вид";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.pictureBox7);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.tbFoV);
            this.groupBox7.Controls.Add(this.radPerspective);
            this.groupBox7.Controls.Add(this.radIsometry);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox7.Location = new System.Drawing.Point(331, 139);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(380, 78);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Параметры проекции";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Rays.Properties.Resources.camera;
            this.pictureBox7.Location = new System.Drawing.Point(6, 20);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(34, 33);
            this.pictureBox7.TabIndex = 12;
            this.pictureBox7.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(195, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "Угол зрения";
            // 
            // tbFoV
            // 
            this.tbFoV.Location = new System.Drawing.Point(275, 44);
            this.tbFoV.Name = "tbFoV";
            this.tbFoV.Size = new System.Drawing.Size(100, 21);
            this.tbFoV.TabIndex = 2;
            // 
            // radPerspective
            // 
            this.radPerspective.AutoSize = true;
            this.radPerspective.Location = new System.Drawing.Point(57, 45);
            this.radPerspective.Name = "radPerspective";
            this.radPerspective.Size = new System.Drawing.Size(102, 19);
            this.radPerspective.TabIndex = 1;
            this.radPerspective.TabStop = true;
            this.radPerspective.Text = "Перспектива";
            this.radPerspective.UseVisualStyleBackColor = true;
            // 
            // radIsometry
            // 
            this.radIsometry.AutoSize = true;
            this.radIsometry.Location = new System.Drawing.Point(57, 20);
            this.radIsometry.Name = "radIsometry";
            this.radIsometry.Size = new System.Drawing.Size(91, 19);
            this.radIsometry.TabIndex = 0;
            this.radIsometry.TabStop = true;
            this.radIsometry.Text = "Изометрия";
            this.radIsometry.UseVisualStyleBackColor = true;
            this.radIsometry.CheckedChanged += new System.EventHandler(this.radIsometry_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.txtBoxAxisMax);
            this.groupBox4.Controls.Add(this.txtBoxAxisStep);
            this.groupBox4.Controls.Add(this.chBoxAxisCaptions);
            this.groupBox4.Controls.Add(this.butPickFaceHighlightColor);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.chBoxFaceHighlight);
            this.groupBox4.Controls.Add(this.chBoxDrawAxis);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(331, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(380, 126);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Область отображения";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Цвет";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rays.Properties.Resources.application_home;
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 33);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // txtBoxAxisMax
            // 
            this.txtBoxAxisMax.AllowNegative = false;
            this.txtBoxAxisMax.Location = new System.Drawing.Point(91, 92);
            this.txtBoxAxisMax.Name = "txtBoxAxisMax";
            this.txtBoxAxisMax.Size = new System.Drawing.Size(105, 21);
            this.txtBoxAxisMax.TabIndex = 10;
            // 
            // txtBoxAxisStep
            // 
            this.txtBoxAxisStep.AllowNegative = false;
            this.txtBoxAxisStep.Location = new System.Drawing.Point(91, 66);
            this.txtBoxAxisStep.Name = "txtBoxAxisStep";
            this.txtBoxAxisStep.Size = new System.Drawing.Size(105, 21);
            this.txtBoxAxisStep.TabIndex = 9;
            // 
            // chBoxAxisCaptions
            // 
            this.chBoxAxisCaptions.AutoSize = true;
            this.chBoxAxisCaptions.Location = new System.Drawing.Point(91, 41);
            this.chBoxAxisCaptions.Name = "chBoxAxisCaptions";
            this.chBoxAxisCaptions.Size = new System.Drawing.Size(117, 19);
            this.chBoxAxisCaptions.TabIndex = 8;
            this.chBoxAxisCaptions.Text = "Подписи к осям";
            this.chBoxAxisCaptions.UseVisualStyleBackColor = true;
            // 
            // butPickFaceHighlightColor
            // 
            this.butPickFaceHighlightColor.Location = new System.Drawing.Point(278, 45);
            this.butPickFaceHighlightColor.Name = "butPickFaceHighlightColor";
            this.butPickFaceHighlightColor.Size = new System.Drawing.Size(96, 23);
            this.butPickFaceHighlightColor.TabIndex = 7;
            this.butPickFaceHighlightColor.UseVisualStyleBackColor = true;
            this.butPickFaceHighlightColor.Click += new System.EventHandler(this.butPickFaceHighlightColor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Максимум";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Шаг оси";
            // 
            // chBoxFaceHighlight
            // 
            this.chBoxFaceHighlight.AutoSize = true;
            this.chBoxFaceHighlight.Location = new System.Drawing.Point(238, 20);
            this.chBoxFaceHighlight.Name = "chBoxFaceHighlight";
            this.chBoxFaceHighlight.Size = new System.Drawing.Size(132, 19);
            this.chBoxFaceHighlight.TabIndex = 1;
            this.chBoxFaceHighlight.Text = "Подсветка граней";
            this.chBoxFaceHighlight.UseVisualStyleBackColor = true;
            // 
            // chBoxDrawAxis
            // 
            this.chBoxDrawAxis.AutoSize = true;
            this.chBoxDrawAxis.Location = new System.Drawing.Point(91, 20);
            this.chBoxDrawAxis.Name = "chBoxDrawAxis";
            this.chBoxDrawAxis.Size = new System.Drawing.Size(105, 19);
            this.chBoxDrawAxis.TabIndex = 0;
            this.chBoxDrawAxis.Text = "Рисовать оси";
            this.chBoxDrawAxis.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chBoxCollapseConsoleOnStartUp);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.labFontView);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.butSelectFont);
            this.groupBox1.Controls.Add(this.butBackColor);
            this.groupBox1.Controls.Add(this.butForeColor);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 162);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Окно сообщений";
            // 
            // chBoxCollapseConsoleOnStartUp
            // 
            this.chBoxCollapseConsoleOnStartUp.AutoSize = true;
            this.chBoxCollapseConsoleOnStartUp.Location = new System.Drawing.Point(9, 133);
            this.chBoxCollapseConsoleOnStartUp.Name = "chBoxCollapseConsoleOnStartUp";
            this.chBoxCollapseConsoleOnStartUp.Size = new System.Drawing.Size(249, 19);
            this.chBoxCollapseConsoleOnStartUp.TabIndex = 14;
            this.chBoxCollapseConsoleOnStartUp.Text = "Свернуть окно сообщений при запуске";
            this.chBoxCollapseConsoleOnStartUp.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Rays.Properties.Resources.application_osx_terminal;
            this.pictureBox2.Location = new System.Drawing.Point(6, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 33);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // labFontView
            // 
            this.labFontView.Location = new System.Drawing.Point(54, 41);
            this.labFontView.Name = "labFontView";
            this.labFontView.Size = new System.Drawing.Size(151, 30);
            this.labFontView.TabIndex = 6;
            this.labFontView.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Шрифт сообщений";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Цвет шрифта сообщений";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Цвет фона окна сообщений";
            // 
            // butSelectFont
            // 
            this.butSelectFont.Image = global::Rays.Properties.Resources.font;
            this.butSelectFont.Location = new System.Drawing.Point(211, 19);
            this.butSelectFont.Name = "butSelectFont";
            this.butSelectFont.Size = new System.Drawing.Size(96, 48);
            this.butSelectFont.TabIndex = 2;
            this.butSelectFont.Text = "Выбор";
            this.butSelectFont.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butSelectFont.UseVisualStyleBackColor = true;
            this.butSelectFont.Click += new System.EventHandler(this.butSelectFont_Click);
            // 
            // butBackColor
            // 
            this.butBackColor.Location = new System.Drawing.Point(211, 74);
            this.butBackColor.Name = "butBackColor";
            this.butBackColor.Size = new System.Drawing.Size(96, 23);
            this.butBackColor.TabIndex = 1;
            this.butBackColor.UseVisualStyleBackColor = true;
            this.butBackColor.Click += new System.EventHandler(this.butBackColor_Click);
            // 
            // butForeColor
            // 
            this.butForeColor.Location = new System.Drawing.Point(211, 103);
            this.butForeColor.Name = "butForeColor";
            this.butForeColor.Size = new System.Drawing.Size(96, 23);
            this.butForeColor.TabIndex = 0;
            this.butForeColor.UseVisualStyleBackColor = true;
            this.butForeColor.Click += new System.EventHandler(this.butForeColor_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(717, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Производительность";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmbBoxMinFacesCount);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.pictureBox6);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.cmbBoxOctreeDeep);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.chBoxEnableOctree);
            this.groupBox6.Location = new System.Drawing.Point(302, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(409, 191);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Окто-дерево";
            // 
            // cmbBoxMinFacesCount
            // 
            this.cmbBoxMinFacesCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxMinFacesCount.FormattingEnabled = true;
            this.cmbBoxMinFacesCount.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "15",
            "20",
            "30",
            "50"});
            this.cmbBoxMinFacesCount.Location = new System.Drawing.Point(273, 154);
            this.cmbBoxMinFacesCount.Name = "cmbBoxMinFacesCount";
            this.cmbBoxMinFacesCount.Size = new System.Drawing.Size(118, 23);
            this.cmbBoxMinFacesCount.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(228, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "Минимальное число полигонов в узле";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Rays.Properties.Resources.sitemap_color;
            this.pictureBox6.Location = new System.Drawing.Point(9, 20);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(34, 33);
            this.pictureBox6.TabIndex = 12;
            this.pictureBox6.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(243, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Максимальная глубина рекурсии дерева";
            // 
            // cmbBoxOctreeDeep
            // 
            this.cmbBoxOctreeDeep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxOctreeDeep.FormattingEnabled = true;
            this.cmbBoxOctreeDeep.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "15",
            "20",
            "30",
            "50"});
            this.cmbBoxOctreeDeep.Location = new System.Drawing.Point(273, 123);
            this.cmbBoxOctreeDeep.Name = "cmbBoxOctreeDeep";
            this.cmbBoxOctreeDeep.Size = new System.Drawing.Size(118, 23);
            this.cmbBoxOctreeDeep.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(65, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(326, 75);
            this.label10.TabIndex = 1;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // chBoxEnableOctree
            // 
            this.chBoxEnableOctree.AutoSize = true;
            this.chBoxEnableOctree.Location = new System.Drawing.Point(68, 98);
            this.chBoxEnableOctree.Name = "chBoxEnableOctree";
            this.chBoxEnableOctree.Size = new System.Drawing.Size(159, 19);
            this.chBoxEnableOctree.TabIndex = 0;
            this.chBoxEnableOctree.Text = "Включить окто-дерево";
            this.chBoxEnableOctree.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbBoxThreadNum);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chBoxMultithread);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 172);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Потоки";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Rays.Properties.Resources.arrow_divide;
            this.pictureBox3.Location = new System.Drawing.Point(9, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 33);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Количество потоков";
            // 
            // cmbBoxThreadNum
            // 
            this.cmbBoxThreadNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxThreadNum.FormattingEnabled = true;
            this.cmbBoxThreadNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "32",
            "64",
            "128",
            "255"});
            this.cmbBoxThreadNum.Location = new System.Drawing.Point(152, 103);
            this.cmbBoxThreadNum.Name = "cmbBoxThreadNum";
            this.cmbBoxThreadNum.Size = new System.Drawing.Size(111, 23);
            this.cmbBoxThreadNum.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 60);
            this.label4.TabIndex = 1;
            this.label4.Text = "Многопоточность не блокирует \r\nприложение во время расчетов\r\nи ускоряет вычислени" +
                "я на много-\r\nядерных системах.";
            // 
            // chBoxMultithread
            // 
            this.chBoxMultithread.AutoSize = true;
            this.chBoxMultithread.Location = new System.Drawing.Point(65, 80);
            this.chBoxMultithread.Name = "chBoxMultithread";
            this.chBoxMultithread.Size = new System.Drawing.Size(189, 19);
            this.chBoxMultithread.TabIndex = 0;
            this.chBoxMultithread.Text = "Включить многопоточность";
            this.chBoxMultithread.UseVisualStyleBackColor = true;
            this.chBoxMultithread.CheckedChanged += new System.EventHandler(this.chBoxMultithread_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(717, 389);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Функции";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBox5);
            this.groupBox5.Controls.Add(this.chBoxTraceOnMove);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(4, 78);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(702, 66);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Редактирование сцены";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Rays.Properties.Resources.rainbow;
            this.pictureBox5.Location = new System.Drawing.Point(6, 20);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(34, 33);
            this.pictureBox5.TabIndex = 12;
            this.pictureBox5.TabStop = false;
            // 
            // chBoxTraceOnMove
            // 
            this.chBoxTraceOnMove.AutoSize = true;
            this.chBoxTraceOnMove.Location = new System.Drawing.Point(48, 28);
            this.chBoxTraceOnMove.Name = "chBoxTraceOnMove";
            this.chBoxTraceOnMove.Size = new System.Drawing.Size(446, 19);
            this.chBoxTraceOnMove.TabIndex = 0;
            this.chBoxTraceOnMove.Text = "Трассировать лучи при каждом изменении на сцене (не рекомендуется)";
            this.chBoxTraceOnMove.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox4);
            this.groupBox3.Controls.Add(this.chBoxLoadAllRays);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(4, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(702, 66);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Загрузка";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Rays.Properties.Resources.lightning_go;
            this.pictureBox4.Location = new System.Drawing.Point(6, 20);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 33);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // chBoxLoadAllRays
            // 
            this.chBoxLoadAllRays.AutoSize = true;
            this.chBoxLoadAllRays.Location = new System.Drawing.Point(48, 28);
            this.chBoxLoadAllRays.Name = "chBoxLoadAllRays";
            this.chBoxLoadAllRays.Size = new System.Drawing.Size(378, 19);
            this.chBoxLoadAllRays.TabIndex = 0;
            this.chBoxLoadAllRays.Text = "Загружать и отображать ранее построенные лучи из файла";
            this.chBoxLoadAllRays.UseVisualStyleBackColor = true;
            // 
            // ColorDiag
            // 
            this.ColorDiag.FullOpen = true;
            // 
            // FontDiag
            // 
            this.FontDiag.AllowVerticalFonts = false;
            this.FontDiag.FontMustExist = true;
            this.FontDiag.ShowEffects = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Image = global::Rays.Properties.Resources.accept;
            this.buttonOK.Location = new System.Drawing.Point(535, 438);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(98, 42);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::Rays.Properties.Resources.delete;
            this.buttonCancel.Location = new System.Drawing.Point(638, 438);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 42);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AppSettings
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(748, 489);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppSettings";
            this.Text = "Настройки приложения Rays";
            this.Load += new System.EventHandler(this.AppSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butBackColor;
        private System.Windows.Forms.Button butForeColor;
        private System.Windows.Forms.ColorDialog ColorDiag;
        private System.Windows.Forms.Button butSelectFont;
        private System.Windows.Forms.FontDialog FontDiag;
        private System.Windows.Forms.Label labFontView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBoxThreadNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chBoxMultithread;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chBoxLoadAllRays;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chBoxFaceHighlight;
        private System.Windows.Forms.CheckBox chBoxDrawAxis;
        private System.Windows.Forms.CheckBox chBoxAxisCaptions;
        private System.Windows.Forms.Button butPickFaceHighlightColor;
        private System.Windows.Forms.Label label7;
        private TNumEditBox txtBoxAxisMax;
        private TNumEditBox txtBoxAxisStep;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox chBoxCollapseConsoleOnStartUp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.CheckBox chBoxTraceOnMove;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbBoxOctreeDeep;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chBoxEnableOctree;
        private System.Windows.Forms.ComboBox cmbBoxMinFacesCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radPerspective;
        private System.Windows.Forms.RadioButton radIsometry;
        private System.Windows.Forms.Label label12;
        private TNumEditBox tbFoV;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}