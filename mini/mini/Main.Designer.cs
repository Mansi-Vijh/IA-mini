namespace mini
{
    partial class Main
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
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.btn_browse = new System.Windows.Forms.Button();
            this.btn_paint = new System.Windows.Forms.Button();
            this.Original = new Emgu.CV.UI.ImageBox();
            this.btn_cartoon = new System.Windows.Forms.Button();
            this.result = new Emgu.CV.UI.ImageBox();
            this.txt_r = new System.Windows.Forms.TextBox();
            this.txt_l = new System.Windows.Forms.TextBox();
            this.lbl_radius = new System.Windows.Forms.Label();
            this.lbl_intensity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.result)).BeginInit();
            this.SuspendLayout();
            // 
            // openFD
            // 
            this.openFD.FileName = "openFileDialog1";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(121, 62);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(120, 23);
            this.btn_browse.TabIndex = 3;
            this.btn_browse.Text = "Choose Image";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // btn_paint
            // 
            this.btn_paint.Location = new System.Drawing.Point(634, 164);
            this.btn_paint.Name = "btn_paint";
            this.btn_paint.Size = new System.Drawing.Size(130, 49);
            this.btn_paint.TabIndex = 4;
            this.btn_paint.Text = "Oil Painting ";
            this.btn_paint.UseVisualStyleBackColor = true;
            this.btn_paint.Click += new System.EventHandler(this.btn_paint_Click);
            // 
            // Original
            // 
            this.Original.Location = new System.Drawing.Point(43, 147);
            this.Original.Name = "Original";
            this.Original.Size = new System.Drawing.Size(487, 480);
            this.Original.TabIndex = 2;
            this.Original.TabStop = false;
            // 
            // btn_cartoon
            // 
            this.btn_cartoon.Location = new System.Drawing.Point(634, 328);
            this.btn_cartoon.Name = "btn_cartoon";
            this.btn_cartoon.Size = new System.Drawing.Size(130, 52);
            this.btn_cartoon.TabIndex = 5;
            this.btn_cartoon.Text = "Cartoon Effect";
            this.btn_cartoon.UseVisualStyleBackColor = true;
            this.btn_cartoon.Click += new System.EventHandler(this.btn_cartoon_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(845, 147);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(487, 480);
            this.result.TabIndex = 6;
            this.result.TabStop = false;
            // 
            // txt_r
            // 
            this.txt_r.Location = new System.Drawing.Point(677, 237);
            this.txt_r.Name = "txt_r";
            this.txt_r.Size = new System.Drawing.Size(100, 20);
            this.txt_r.TabIndex = 7;
            // 
            // txt_l
            // 
            this.txt_l.Location = new System.Drawing.Point(678, 272);
            this.txt_l.Name = "txt_l";
            this.txt_l.Size = new System.Drawing.Size(100, 20);
            this.txt_l.TabIndex = 8;
            // 
            // lbl_radius
            // 
            this.lbl_radius.AutoSize = true;
            this.lbl_radius.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_radius.Location = new System.Drawing.Point(622, 239);
            this.lbl_radius.Name = "lbl_radius";
            this.lbl_radius.Size = new System.Drawing.Size(46, 15);
            this.lbl_radius.TabIndex = 9;
            this.lbl_radius.Text = "Radius";
            // 
            // lbl_intensity
            // 
            this.lbl_intensity.AutoSize = true;
            this.lbl_intensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_intensity.Location = new System.Drawing.Point(621, 272);
            this.lbl_intensity.Name = "lbl_intensity";
            this.lbl_intensity.Size = new System.Drawing.Size(51, 15);
            this.lbl_intensity.TabIndex = 10;
            this.lbl_intensity.Text = "Intensity";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.lbl_intensity);
            this.Controls.Add(this.lbl_radius);
            this.Controls.Add(this.txt_l);
            this.Controls.Add(this.txt_r);
            this.Controls.Add(this.result);
            this.Controls.Add(this.btn_cartoon);
            this.Controls.Add(this.btn_paint);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.Original);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFD;
        private Emgu.CV.UI.ImageBox Original;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Button btn_paint;
        private System.Windows.Forms.Button btn_cartoon;
        private Emgu.CV.UI.ImageBox result;
        private System.Windows.Forms.TextBox txt_r;
        private System.Windows.Forms.TextBox txt_l;
        private System.Windows.Forms.Label lbl_radius;
        private System.Windows.Forms.Label lbl_intensity;
    }
}

