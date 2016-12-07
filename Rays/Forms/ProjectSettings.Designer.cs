namespace Rays.Forms
{
    partial class ProjectSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabView = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chBoxRayAlphaPower = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.butRayColor = new System.Windows.Forms.Button();
            this.radTubeColorChangeOnReflect = new System.Windows.Forms.RadioButton();
            this.radTubeColorFixed = new System.Windows.Forms.RadioButton();
            this.cmbBoxLineWidth = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radFullPolyhedron = new System.Windows.Forms.RadioButton();
            this.radCenterDirection = new System.Windows.Forms.RadioButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLightZ = new Rays.TNumEditBox();
            this.tbLightY = new Rays.TNumEditBox();
            this.tbLightX = new Rays.TNumEditBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butLightColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butBackColor = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabAntenna = new System.Windows.Forms.TabPage();
            this.tabVars = new System.Windows.Forms.TabPage();
            this.chBoxDefaults = new System.Windows.Forms.CheckBox();
            this.ColorDiag = new System.Windows.Forms.ColorDialog();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tabMaterials = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabView.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCommon);
            this.tabControl1.Controls.Add(this.tabView);
            this.tabControl1.Controls.Add(this.tabAntenna);
            this.tabControl1.Controls.Add(this.tabVars);
            this.tabControl1.Controls.Add(this.tabMaterials);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 403);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.groupBox1);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 27);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(717, 372);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = "Общее";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 360);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название и описание";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(180, 52);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(510, 291);
            this.tbDescription.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Описание проекта";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(180, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(510, 26);
            this.tbName.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Название проекта";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Rays.Properties.Resources.application_edit;
            this.pictureBox2.Location = new System.Drawing.Point(6, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 33);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.groupBox3);
            this.tabView.Controls.Add(this.groupBox2);
            this.tabView.Location = new System.Drawing.Point(4, 27);
            this.tabView.Name = "tabView";
            this.tabView.Padding = new System.Windows.Forms.Padding(3);
            this.tabView.Size = new System.Drawing.Size(717, 372);
            this.tabView.TabIndex = 1;
            this.tabView.Text = "Визуализатор";
            this.tabView.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chBoxRayAlphaPower);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.cmbBoxLineWidth);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(349, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 233);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Лучевые трубки";
            // 
            // chBoxRayAlphaPower
            // 
            this.chBoxRayAlphaPower.AutoSize = true;
            this.chBoxRayAlphaPower.Location = new System.Drawing.Point(15, 190);
            this.chBoxRayAlphaPower.Name = "chBoxRayAlphaPower";
            this.chBoxRayAlphaPower.Size = new System.Drawing.Size(341, 19);
            this.chBoxRayAlphaPower.TabIndex = 22;
            this.chBoxRayAlphaPower.Text = "Падение прозрачности трубки при падении мощности";
            this.chBoxRayAlphaPower.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.butRayColor);
            this.groupBox5.Controls.Add(this.radTubeColorChangeOnReflect);
            this.groupBox5.Controls.Add(this.radTubeColorFixed);
            this.groupBox5.Location = new System.Drawing.Point(9, 102);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(347, 73);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Расцветка";
            // 
            // butRayColor
            // 
            this.butRayColor.Location = new System.Drawing.Point(204, 17);
            this.butRayColor.Name = "butRayColor";
            this.butRayColor.Size = new System.Drawing.Size(96, 23);
            this.butRayColor.TabIndex = 17;
            this.butRayColor.UseVisualStyleBackColor = true;
            this.butRayColor.Click += new System.EventHandler(this.butRayColor_Click);
            // 
            // radTubeColorChangeOnReflect
            // 
            this.radTubeColorChangeOnReflect.AutoSize = true;
            this.radTubeColorChangeOnReflect.Location = new System.Drawing.Point(6, 46);
            this.radTubeColorChangeOnReflect.Name = "radTubeColorChangeOnReflect";
            this.radTubeColorChangeOnReflect.Size = new System.Drawing.Size(257, 19);
            this.radTubeColorChangeOnReflect.TabIndex = 1;
            this.radTubeColorChangeOnReflect.TabStop = true;
            this.radTubeColorChangeOnReflect.Text = "Меняется при отражении/прохождении";
            this.radTubeColorChangeOnReflect.UseVisualStyleBackColor = true;
            // 
            // radTubeColorFixed
            // 
            this.radTubeColorFixed.AutoSize = true;
            this.radTubeColorFixed.Location = new System.Drawing.Point(6, 21);
            this.radTubeColorFixed.Name = "radTubeColorFixed";
            this.radTubeColorFixed.Size = new System.Drawing.Size(151, 19);
            this.radTubeColorFixed.TabIndex = 0;
            this.radTubeColorFixed.TabStop = true;
            this.radTubeColorFixed.Text = "Фиксированный цвет";
            this.radTubeColorFixed.UseVisualStyleBackColor = true;
            // 
            // cmbBoxLineWidth
            // 
            this.cmbBoxLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxLineWidth.FormattingEnabled = true;
            this.cmbBoxLineWidth.Items.AddRange(new object[] {
            "0.5",
            "0.7",
            "1.0",
            "1.5",
            "2.0",
            "2.5",
            "3.0",
            "4.0",
            "5.0"});
            this.cmbBoxLineWidth.Location = new System.Drawing.Point(213, 49);
            this.cmbBoxLineWidth.Name = "cmbBoxLineWidth";
            this.cmbBoxLineWidth.Size = new System.Drawing.Size(96, 23);
            this.cmbBoxLineWidth.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(315, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "px";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(209, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Толщина линии";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radFullPolyhedron);
            this.groupBox4.Controls.Add(this.radCenterDirection);
            this.groupBox4.Location = new System.Drawing.Point(46, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 76);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Стиль отображения";
            // 
            // radFullPolyhedron
            // 
            this.radFullPolyhedron.AutoSize = true;
            this.radFullPolyhedron.Location = new System.Drawing.Point(6, 45);
            this.radFullPolyhedron.Name = "radFullPolyhedron";
            this.radFullPolyhedron.Size = new System.Drawing.Size(108, 19);
            this.radFullPolyhedron.TabIndex = 1;
            this.radFullPolyhedron.TabStop = true;
            this.radFullPolyhedron.Text = "Многогранник";
            this.radFullPolyhedron.UseVisualStyleBackColor = true;
            // 
            // radCenterDirection
            // 
            this.radCenterDirection.AutoSize = true;
            this.radCenterDirection.Location = new System.Drawing.Point(6, 20);
            this.radCenterDirection.Name = "radCenterDirection";
            this.radCenterDirection.Size = new System.Drawing.Size(127, 19);
            this.radCenterDirection.TabIndex = 0;
            this.radCenterDirection.TabStop = true;
            this.radCenterDirection.Text = "Центральный луч";
            this.radCenterDirection.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Rays.Properties.Resources.rainbow;
            this.pictureBox3.Location = new System.Drawing.Point(6, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 33);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbLightZ);
            this.groupBox2.Controls.Add(this.tbLightY);
            this.groupBox2.Controls.Add(this.tbLightX);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.butLightColor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.butBackColor);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 188);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Освещение";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(191, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Z =";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(191, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Y =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(191, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "X =";
            // 
            // tbLightZ
            // 
            this.tbLightZ.Location = new System.Drawing.Point(227, 154);
            this.tbLightZ.Name = "tbLightZ";
            this.tbLightZ.Size = new System.Drawing.Size(96, 21);
            this.tbLightZ.TabIndex = 23;
            // 
            // tbLightY
            // 
            this.tbLightY.Location = new System.Drawing.Point(227, 121);
            this.tbLightY.Name = "tbLightY";
            this.tbLightY.Size = new System.Drawing.Size(96, 21);
            this.tbLightY.TabIndex = 22;
            // 
            // tbLightX
            // 
            this.tbLightX.Location = new System.Drawing.Point(226, 93);
            this.tbLightX.Name = "tbLightX";
            this.tbLightX.Size = new System.Drawing.Size(96, 21);
            this.tbLightX.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Координаты источника света";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Цвет источника света";
            // 
            // butLightColor
            // 
            this.butLightColor.Location = new System.Drawing.Point(227, 24);
            this.butLightColor.Name = "butLightColor";
            this.butLightColor.Size = new System.Drawing.Size(96, 23);
            this.butLightColor.TabIndex = 18;
            this.butLightColor.UseVisualStyleBackColor = true;
            this.butLightColor.Click += new System.EventHandler(this.butLightColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Цвет заливки фона";
            // 
            // butBackColor
            // 
            this.butBackColor.Location = new System.Drawing.Point(227, 52);
            this.butBackColor.Name = "butBackColor";
            this.butBackColor.Size = new System.Drawing.Size(96, 23);
            this.butBackColor.TabIndex = 16;
            this.butBackColor.UseVisualStyleBackColor = true;
            this.butBackColor.Click += new System.EventHandler(this.butBackColor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rays.Properties.Resources.lightbulb;
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 33);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // tabAntenna
            // 
            this.tabAntenna.Location = new System.Drawing.Point(4, 27);
            this.tabAntenna.Name = "tabAntenna";
            this.tabAntenna.Size = new System.Drawing.Size(717, 372);
            this.tabAntenna.TabIndex = 3;
            this.tabAntenna.Text = "Антенна";
            this.tabAntenna.UseVisualStyleBackColor = true;
            // 
            // tabVars
            // 
            this.tabVars.Location = new System.Drawing.Point(4, 27);
            this.tabVars.Name = "tabVars";
            this.tabVars.Size = new System.Drawing.Size(717, 372);
            this.tabVars.TabIndex = 2;
            this.tabVars.Text = "Трассировщик";
            this.tabVars.UseVisualStyleBackColor = true;
            // 
            // chBoxDefaults
            // 
            this.chBoxDefaults.AutoSize = true;
            this.chBoxDefaults.Location = new System.Drawing.Point(16, 435);
            this.chBoxDefaults.Name = "chBoxDefaults";
            this.chBoxDefaults.Size = new System.Drawing.Size(359, 17);
            this.chBoxDefaults.TabIndex = 5;
            this.chBoxDefaults.Text = "Использовать эти настройки как начальные для новых проектов";
            this.chBoxDefaults.UseVisualStyleBackColor = true;
            // 
            // ColorDiag
            // 
            this.ColorDiag.FullOpen = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::Rays.Properties.Resources.delete;
            this.buttonCancel.Location = new System.Drawing.Point(636, 421);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 42);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Image = global::Rays.Properties.Resources.accept;
            this.buttonOK.Location = new System.Drawing.Point(532, 421);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(98, 42);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click_1);
            // 
            // tabMaterials
            // 
            this.tabMaterials.Location = new System.Drawing.Point(4, 27);
            this.tabMaterials.Name = "tabMaterials";
            this.tabMaterials.Size = new System.Drawing.Size(717, 372);
            this.tabMaterials.TabIndex = 4;
            this.tabMaterials.Text = "Материалы";
            this.tabMaterials.UseVisualStyleBackColor = true;
            // 
            // ProjectSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 471);
            this.Controls.Add(this.chBoxDefaults);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectSettings";
            this.Text = "Настройки проекта";
            this.Load += new System.EventHandler(this.ProjectSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabView.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.TabPage tabView;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox chBoxDefaults;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAntenna;
        private System.Windows.Forms.TabPage tabVars;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private TNumEditBox tbLightZ;
        private TNumEditBox tbLightY;
        private TNumEditBox tbLightX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butLightColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butBackColor;
        private System.Windows.Forms.ColorDialog ColorDiag;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radFullPolyhedron;
        private System.Windows.Forms.RadioButton radCenterDirection;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button butRayColor;
        private System.Windows.Forms.RadioButton radTubeColorChangeOnReflect;
        private System.Windows.Forms.RadioButton radTubeColorFixed;
        private System.Windows.Forms.ComboBox cmbBoxLineWidth;
        private System.Windows.Forms.CheckBox chBoxRayAlphaPower;
        private System.Windows.Forms.TabPage tabMaterials;
    }
}