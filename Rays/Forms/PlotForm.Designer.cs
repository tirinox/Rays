namespace Rays.Forms
{
    partial class PlotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotForm));
            this.Canvas = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.AccumBits = ((byte)(0));
            this.Canvas.AutoCheckErrors = false;
            this.Canvas.AutoFinish = false;
            this.Canvas.AutoMakeCurrent = true;
            this.Canvas.AutoSwapBuffers = true;
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.ColorBits = ((byte)(32));
            this.Canvas.DepthBits = ((byte)(16));
            this.Canvas.Location = new System.Drawing.Point(12, 12);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(722, 405);
            this.Canvas.StencilBits = ((byte)(0));
            this.Canvas.TabIndex = 0;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // PlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 429);
            this.Controls.Add(this.Canvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlotForm";
            this.Text = "Графики";
            this.Load += new System.EventHandler(this.PlotForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl Canvas;
    }
}