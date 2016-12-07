namespace Rays
{
    partial class TransformEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransformEditor));
            this.Preview = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chBoxFigureEnabled = new System.Windows.Forms.CheckBox();
            this.tbFigureName = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sliderTranslateZ = new System.Windows.Forms.TrackBar();
            this.sliderTranslateY = new System.Windows.Forms.TrackBar();
            this.sliderTranslateX = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.butRotateReset = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.sliderRotateZ = new System.Windows.Forms.TrackBar();
            this.sliderRotateY = new System.Windows.Forms.TrackBar();
            this.sliderRotateX = new System.Windows.Forms.TrackBar();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.butScaleReset = new System.Windows.Forms.Button();
            this.chBoxScaleToghether = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.sliderScaleZ = new System.Windows.Forms.TrackBar();
            this.sliderScaleY = new System.Windows.Forms.TrackBar();
            this.sliderScaleX = new System.Windows.Forms.TrackBar();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbScaleZ = new Rays.TNumEditBox();
            this.tbScaleY = new Rays.TNumEditBox();
            this.tbScaleX = new Rays.TNumEditBox();
            this.tbRotateZ = new Rays.TNumEditBox();
            this.tbRotateY = new Rays.TNumEditBox();
            this.tbRotateX = new Rays.TNumEditBox();
            this.tbTranslateZ = new Rays.TNumEditBox();
            this.tbTranslateY = new Rays.TNumEditBox();
            this.tbTranslateX = new Rays.TNumEditBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTranslateZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTranslateY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTranslateX)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderRotateZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderRotateY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderRotateX)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderScaleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderScaleX)).BeginInit();
            this.SuspendLayout();
            // 
            // Preview
            // 
            this.Preview.AccumBits = ((byte)(0));
            this.Preview.AutoCheckErrors = false;
            this.Preview.AutoFinish = false;
            this.Preview.AutoMakeCurrent = true;
            this.Preview.AutoSwapBuffers = true;
            this.Preview.BackColor = System.Drawing.Color.White;
            this.Preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Preview.ColorBits = ((byte)(32));
            this.Preview.DepthBits = ((byte)(16));
            this.Preview.Location = new System.Drawing.Point(15, 19);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(128, 128);
            this.Preview.StencilBits = ((byte)(0));
            this.Preview.TabIndex = 0;
            this.Preview.Paint += new System.Windows.Forms.PaintEventHandler(this.Preview_Paint);
            this.Preview.Resize += new System.EventHandler(this.Preview_Resize);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Preview);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Внешний вид";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chBoxFigureEnabled);
            this.groupBox2.Controls.Add(this.tbFigureName);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 111);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Общее";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя фигуры";
            // 
            // chBoxFigureEnabled
            // 
            this.chBoxFigureEnabled.AutoSize = true;
            this.chBoxFigureEnabled.Location = new System.Drawing.Point(15, 75);
            this.chBoxFigureEnabled.Name = "chBoxFigureEnabled";
            this.chBoxFigureEnabled.Size = new System.Drawing.Size(117, 17);
            this.chBoxFigureEnabled.TabIndex = 2;
            this.chBoxFigureEnabled.Text = "Фигура включена";
            this.chBoxFigureEnabled.UseVisualStyleBackColor = true;
            // 
            // tbFigureName
            // 
            this.tbFigureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFigureName.Location = new System.Drawing.Point(15, 37);
            this.tbFigureName.Name = "tbFigureName";
            this.tbFigureName.Size = new System.Drawing.Size(128, 24);
            this.tbFigureName.TabIndex = 0;
            this.tbFigureName.TextChanged += new System.EventHandler(this.tbFigureName_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::Rays.Properties.Resources.delete;
            this.buttonCancel.Location = new System.Drawing.Point(711, 293);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 42);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Image = global::Rays.Properties.Resources.accept;
            this.buttonOK.Location = new System.Drawing.Point(607, 295);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(98, 42);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.sliderTranslateZ);
            this.groupBox3.Controls.Add(this.sliderTranslateY);
            this.groupBox3.Controls.Add(this.sliderTranslateX);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbTranslateZ);
            this.groupBox3.Controls.Add(this.tbTranslateY);
            this.groupBox3.Controls.Add(this.tbTranslateX);
            this.groupBox3.Location = new System.Drawing.Point(176, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 275);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Позиция";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "Сброс";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "-1000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "-1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "-1000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "+1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "+1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "+1000";
            // 
            // sliderTranslateZ
            // 
            this.sliderTranslateZ.Location = new System.Drawing.Point(29, 199);
            this.sliderTranslateZ.Maximum = 1000;
            this.sliderTranslateZ.Minimum = -1000;
            this.sliderTranslateZ.Name = "sliderTranslateZ";
            this.sliderTranslateZ.Size = new System.Drawing.Size(138, 45);
            this.sliderTranslateZ.TabIndex = 35;
            this.sliderTranslateZ.TickFrequency = 100;
            this.sliderTranslateZ.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sliderTranslateZ.Scroll += new System.EventHandler(this.sliderTranslateZ_Scroll);
            // 
            // sliderTranslateY
            // 
            this.sliderTranslateY.Location = new System.Drawing.Point(29, 122);
            this.sliderTranslateY.Maximum = 1000;
            this.sliderTranslateY.Minimum = -1000;
            this.sliderTranslateY.Name = "sliderTranslateY";
            this.sliderTranslateY.Size = new System.Drawing.Size(138, 45);
            this.sliderTranslateY.TabIndex = 34;
            this.sliderTranslateY.TickFrequency = 100;
            this.sliderTranslateY.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sliderTranslateY.Scroll += new System.EventHandler(this.sliderTranslateY_Scroll);
            // 
            // sliderTranslateX
            // 
            this.sliderTranslateX.Location = new System.Drawing.Point(30, 45);
            this.sliderTranslateX.Maximum = 1000;
            this.sliderTranslateX.Minimum = -1000;
            this.sliderTranslateX.Name = "sliderTranslateX";
            this.sliderTranslateX.Size = new System.Drawing.Size(138, 45);
            this.sliderTranslateX.TabIndex = 33;
            this.sliderTranslateX.TickFrequency = 100;
            this.sliderTranslateX.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sliderTranslateX.Scroll += new System.EventHandler(this.sliderTranslateX_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(27, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "Z =";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(26, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Y =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(27, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "X =";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.butRotateReset);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.sliderRotateZ);
            this.groupBox4.Controls.Add(this.sliderRotateY);
            this.groupBox4.Controls.Add(this.sliderRotateX);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.tbRotateZ);
            this.groupBox4.Controls.Add(this.tbRotateY);
            this.groupBox4.Controls.Add(this.tbRotateX);
            this.groupBox4.Location = new System.Drawing.Point(390, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(203, 275);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Вращение";
            // 
            // butRotateReset
            // 
            this.butRotateReset.Location = new System.Drawing.Point(119, 235);
            this.butRotateReset.Name = "butRotateReset";
            this.butRotateReset.Size = new System.Drawing.Size(75, 23);
            this.butRotateReset.TabIndex = 44;
            this.butRotateReset.Text = "Сброс";
            this.butRotateReset.UseVisualStyleBackColor = true;
            this.butRotateReset.Click += new System.EventHandler(this.butRotateReset_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "-180°";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "-180°";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "-180°";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(159, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "+180°";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(159, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "+180°";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(159, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "+180°";
            // 
            // sliderRotateZ
            // 
            this.sliderRotateZ.Location = new System.Drawing.Point(28, 199);
            this.sliderRotateZ.Maximum = 180;
            this.sliderRotateZ.Minimum = -180;
            this.sliderRotateZ.Name = "sliderRotateZ";
            this.sliderRotateZ.Size = new System.Drawing.Size(138, 45);
            this.sliderRotateZ.TabIndex = 35;
            this.sliderRotateZ.TickFrequency = 18;
            this.sliderRotateZ.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sliderRotateZ.Scroll += new System.EventHandler(this.sliderRotateZ_Scroll);
            // 
            // sliderRotateY
            // 
            this.sliderRotateY.Location = new System.Drawing.Point(28, 122);
            this.sliderRotateY.Maximum = 180;
            this.sliderRotateY.Minimum = -180;
            this.sliderRotateY.Name = "sliderRotateY";
            this.sliderRotateY.Size = new System.Drawing.Size(138, 45);
            this.sliderRotateY.TabIndex = 34;
            this.sliderRotateY.TickFrequency = 18;
            this.sliderRotateY.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sliderRotateY.Scroll += new System.EventHandler(this.sliderRotateY_Scroll);
            // 
            // sliderRotateX
            // 
            this.sliderRotateX.Location = new System.Drawing.Point(29, 45);
            this.sliderRotateX.Maximum = 180;
            this.sliderRotateX.Minimum = -180;
            this.sliderRotateX.Name = "sliderRotateX";
            this.sliderRotateX.Size = new System.Drawing.Size(138, 45);
            this.sliderRotateX.TabIndex = 33;
            this.sliderRotateX.TickFrequency = 18;
            this.sliderRotateX.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sliderRotateX.Scroll += new System.EventHandler(this.sliderRotateX_Scroll);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(26, 176);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 16);
            this.label17.TabIndex = 32;
            this.label17.Text = "Z =";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(25, 97);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 16);
            this.label18.TabIndex = 31;
            this.label18.Text = "Y =";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(26, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 16);
            this.label19.TabIndex = 30;
            this.label19.Text = "X =";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.butScaleReset);
            this.groupBox5.Controls.Add(this.chBoxScaleToghether);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.sliderScaleZ);
            this.groupBox5.Controls.Add(this.sliderScaleY);
            this.groupBox5.Controls.Add(this.sliderScaleX);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.tbScaleZ);
            this.groupBox5.Controls.Add(this.tbScaleY);
            this.groupBox5.Controls.Add(this.tbScaleX);
            this.groupBox5.Location = new System.Drawing.Point(599, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(210, 275);
            this.groupBox5.TabIndex = 43;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Масштабирование";
            // 
            // butScaleReset
            // 
            this.butScaleReset.Location = new System.Drawing.Point(126, 235);
            this.butScaleReset.Name = "butScaleReset";
            this.butScaleReset.Size = new System.Drawing.Size(75, 23);
            this.butScaleReset.TabIndex = 43;
            this.butScaleReset.Text = "Сброс";
            this.butScaleReset.UseVisualStyleBackColor = true;
            this.butScaleReset.Click += new System.EventHandler(this.butScaleReset_Click);
            // 
            // chBoxScaleToghether
            // 
            this.chBoxScaleToghether.AutoSize = true;
            this.chBoxScaleToghether.Location = new System.Drawing.Point(6, 239);
            this.chBoxScaleToghether.Name = "chBoxScaleToghether";
            this.chBoxScaleToghether.Size = new System.Drawing.Size(85, 17);
            this.chBoxScaleToghether.TabIndex = 42;
            this.chBoxScaleToghether.Text = "Все вместе";
            this.chBoxScaleToghether.UseVisualStyleBackColor = true;
            this.chBoxScaleToghether.CheckedChanged += new System.EventHandler(this.chBoxScaleToghether_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 209);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 13);
            this.label20.TabIndex = 41;
            this.label20.Text = "0.001";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 133);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 13);
            this.label21.TabIndex = 40;
            this.label21.Text = "0.001";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 13);
            this.label22.TabIndex = 39;
            this.label22.Text = "0.001";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(170, 209);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 38;
            this.label23.Text = "1000";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(170, 133);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(31, 13);
            this.label24.TabIndex = 37;
            this.label24.Text = "1000";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(170, 56);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(31, 13);
            this.label25.TabIndex = 36;
            this.label25.Text = "1000";
            // 
            // sliderScaleZ
            // 
            this.sliderScaleZ.Location = new System.Drawing.Point(36, 199);
            this.sliderScaleZ.Maximum = 100;
            this.sliderScaleZ.Name = "sliderScaleZ";
            this.sliderScaleZ.Size = new System.Drawing.Size(138, 45);
            this.sliderScaleZ.TabIndex = 35;
            this.sliderScaleZ.TickFrequency = 5;
            this.sliderScaleZ.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sliderScaleZ.Value = 100;
            this.sliderScaleZ.Scroll += new System.EventHandler(this.sliderScaleZ_Scroll);
            // 
            // sliderScaleY
            // 
            this.sliderScaleY.Location = new System.Drawing.Point(36, 122);
            this.sliderScaleY.Maximum = 100;
            this.sliderScaleY.Name = "sliderScaleY";
            this.sliderScaleY.Size = new System.Drawing.Size(138, 45);
            this.sliderScaleY.TabIndex = 34;
            this.sliderScaleY.TickFrequency = 5;
            this.sliderScaleY.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sliderScaleY.Value = 100;
            this.sliderScaleY.Scroll += new System.EventHandler(this.sliderScaleY_Scroll);
            // 
            // sliderScaleX
            // 
            this.sliderScaleX.Location = new System.Drawing.Point(37, 45);
            this.sliderScaleX.Maximum = 100;
            this.sliderScaleX.Name = "sliderScaleX";
            this.sliderScaleX.Size = new System.Drawing.Size(138, 45);
            this.sliderScaleX.TabIndex = 33;
            this.sliderScaleX.TickFrequency = 5;
            this.sliderScaleX.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sliderScaleX.Value = 100;
            this.sliderScaleX.Scroll += new System.EventHandler(this.sliderScaleX_Scroll);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(34, 176);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 16);
            this.label26.TabIndex = 32;
            this.label26.Text = "Z =";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(33, 97);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(30, 16);
            this.label27.TabIndex = 31;
            this.label27.Text = "Y =";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label28.Location = new System.Drawing.Point(34, 22);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 16);
            this.label28.TabIndex = 30;
            this.label28.Text = "X =";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbScaleZ
            // 
            this.tbScaleZ.AllowNegative = false;
            this.tbScaleZ.DecimalLength = 3;
            this.tbScaleZ.Location = new System.Drawing.Point(69, 173);
            this.tbScaleZ.Name = "tbScaleZ";
            this.tbScaleZ.Size = new System.Drawing.Size(96, 20);
            this.tbScaleZ.TabIndex = 29;
            this.tbScaleZ.Text = "0,000";
            this.tbScaleZ.TextChanged += new System.EventHandler(this.tbScaleZ_TextChanged);
            // 
            // tbScaleY
            // 
            this.tbScaleY.AllowNegative = false;
            this.tbScaleY.DecimalLength = 3;
            this.tbScaleY.Location = new System.Drawing.Point(69, 96);
            this.tbScaleY.Name = "tbScaleY";
            this.tbScaleY.Size = new System.Drawing.Size(96, 20);
            this.tbScaleY.TabIndex = 28;
            this.tbScaleY.Text = "0,000";
            this.tbScaleY.TextChanged += new System.EventHandler(this.tbScaleY_TextChanged);
            // 
            // tbScaleX
            // 
            this.tbScaleX.AllowNegative = false;
            this.tbScaleX.DecimalLength = 3;
            this.tbScaleX.Location = new System.Drawing.Point(69, 19);
            this.tbScaleX.Name = "tbScaleX";
            this.tbScaleX.Size = new System.Drawing.Size(96, 20);
            this.tbScaleX.TabIndex = 27;
            this.tbScaleX.Text = "0,000";
            this.tbScaleX.TextChanged += new System.EventHandler(this.tbScaleX_TextChanged);
            // 
            // tbRotateZ
            // 
            this.tbRotateZ.DecimalLength = 1;
            this.tbRotateZ.Location = new System.Drawing.Point(61, 173);
            this.tbRotateZ.Name = "tbRotateZ";
            this.tbRotateZ.Size = new System.Drawing.Size(96, 20);
            this.tbRotateZ.TabIndex = 29;
            this.tbRotateZ.Text = "0,0";
            this.tbRotateZ.TextChanged += new System.EventHandler(this.tbRotateZ_TextChanged);
            // 
            // tbRotateY
            // 
            this.tbRotateY.DecimalLength = 1;
            this.tbRotateY.Location = new System.Drawing.Point(61, 96);
            this.tbRotateY.Name = "tbRotateY";
            this.tbRotateY.Size = new System.Drawing.Size(96, 20);
            this.tbRotateY.TabIndex = 28;
            this.tbRotateY.Text = "0,0";
            this.tbRotateY.TextChanged += new System.EventHandler(this.tbRotateY_TextChanged);
            // 
            // tbRotateX
            // 
            this.tbRotateX.DecimalLength = 1;
            this.tbRotateX.Location = new System.Drawing.Point(61, 19);
            this.tbRotateX.Name = "tbRotateX";
            this.tbRotateX.Size = new System.Drawing.Size(96, 20);
            this.tbRotateX.TabIndex = 27;
            this.tbRotateX.Text = "0,0";
            this.tbRotateX.TextChanged += new System.EventHandler(this.tbRotateX_TextChanged);
            // 
            // tbTranslateZ
            // 
            this.tbTranslateZ.DecimalLength = 2;
            this.tbTranslateZ.Location = new System.Drawing.Point(62, 173);
            this.tbTranslateZ.Name = "tbTranslateZ";
            this.tbTranslateZ.Size = new System.Drawing.Size(96, 20);
            this.tbTranslateZ.TabIndex = 29;
            this.tbTranslateZ.Text = "0,00";
            this.tbTranslateZ.TextChanged += new System.EventHandler(this.tbTranslateZ_TextChanged);
            // 
            // tbTranslateY
            // 
            this.tbTranslateY.DecimalLength = 2;
            this.tbTranslateY.Location = new System.Drawing.Point(62, 96);
            this.tbTranslateY.Name = "tbTranslateY";
            this.tbTranslateY.Size = new System.Drawing.Size(96, 20);
            this.tbTranslateY.TabIndex = 28;
            this.tbTranslateY.Text = "0,00";
            this.tbTranslateY.TextChanged += new System.EventHandler(this.tbTranslateY_TextChanged);
            // 
            // tbTranslateX
            // 
            this.tbTranslateX.DecimalLength = 2;
            this.tbTranslateX.Location = new System.Drawing.Point(62, 19);
            this.tbTranslateX.Name = "tbTranslateX";
            this.tbTranslateX.Size = new System.Drawing.Size(96, 20);
            this.tbTranslateX.TabIndex = 27;
            this.tbTranslateX.Text = "0,00";
            this.tbTranslateX.TextChanged += new System.EventHandler(this.tbTranslateX_TextChanged);
            // 
            // TransformEditor
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(823, 347);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransformEditor";
            this.Text = "Редактор фигур и их трансформаций";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransformEditor_FormClosing);
            this.Load += new System.EventHandler(this.TransformEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTranslateZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTranslateY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderTranslateX)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderRotateZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderRotateY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderRotateX)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderScaleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderScaleX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl Preview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbFigureName;
        private System.Windows.Forms.CheckBox chBoxFigureEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private TNumEditBox tbTranslateZ;
        private TNumEditBox tbTranslateY;
        private TNumEditBox tbTranslateX;
        private System.Windows.Forms.TrackBar sliderTranslateX;
        private System.Windows.Forms.TrackBar sliderTranslateZ;
        private System.Windows.Forms.TrackBar sliderTranslateY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar sliderRotateZ;
        private System.Windows.Forms.TrackBar sliderRotateY;
        private System.Windows.Forms.TrackBar sliderRotateX;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private TNumEditBox tbRotateZ;
        private TNumEditBox tbRotateY;
        private TNumEditBox tbRotateX;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TrackBar sliderScaleZ;
        private System.Windows.Forms.TrackBar sliderScaleY;
        private System.Windows.Forms.TrackBar sliderScaleX;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private TNumEditBox tbScaleZ;
        private TNumEditBox tbScaleY;
        private TNumEditBox tbScaleX;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button butRotateReset;
        private System.Windows.Forms.Button butScaleReset;
        private System.Windows.Forms.CheckBox chBoxScaleToghether;
        private System.Windows.Forms.Timer timer1;
    }
}