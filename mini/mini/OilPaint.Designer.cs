namespace mini
{
    partial class OilPaint
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
            this.Result = new Emgu.CV.UI.ImageBox();
            this.lbl_header = new System.Windows.Forms.Label();
            this.txt_r = new System.Windows.Forms.TextBox();
            this.txt_l = new System.Windows.Forms.TextBox();
            this.lbl_r = new System.Windows.Forms.Label();
            this.lbl_l = new System.Windows.Forms.Label();
            this.btn_show = new System.Windows.Forms.Button();
            this.My_Timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Result)).BeginInit();
            this.SuspendLayout();
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(343, 40);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(808, 555);
            this.Result.TabIndex = 2;
            this.Result.TabStop = false;
           
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_header.Location = new System.Drawing.Point(78, 78);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(101, 20);
            this.lbl_header.TabIndex = 3;
            this.lbl_header.Text = "Enter Details";
            // 
            // txt_r
            // 
            this.txt_r.Location = new System.Drawing.Point(141, 119);
            this.txt_r.Name = "txt_r";
            this.txt_r.Size = new System.Drawing.Size(100, 20);
            this.txt_r.TabIndex = 4;
            // 
            // txt_l
            // 
            this.txt_l.Location = new System.Drawing.Point(182, 155);
            this.txt_l.Name = "txt_l";
            this.txt_l.Size = new System.Drawing.Size(100, 20);
            this.txt_l.TabIndex = 5;
            // 
            // lbl_r
            // 
            this.lbl_r.AutoSize = true;
            this.lbl_r.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_r.Location = new System.Drawing.Point(79, 120);
            this.lbl_r.Name = "lbl_r";
            this.lbl_r.Size = new System.Drawing.Size(56, 17);
            this.lbl_r.TabIndex = 6;
            this.lbl_r.Text = "Radius:";
            // 
            // lbl_l
            // 
            this.lbl_l.AutoSize = true;
            this.lbl_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_l.Location = new System.Drawing.Point(79, 155);
            this.lbl_l.Name = "lbl_l";
            this.lbl_l.Size = new System.Drawing.Size(97, 17);
            this.lbl_l.TabIndex = 7;
            this.lbl_l.Text = "Intensity level:";
            // 
            // btn_show
            // 
            this.btn_show.Location = new System.Drawing.Point(82, 195);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(75, 23);
            this.btn_show.TabIndex = 8;
            this.btn_show.Text = "Show";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.btn_click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OilPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_show);
            this.Controls.Add(this.lbl_l);
            this.Controls.Add(this.lbl_r);
            this.Controls.Add(this.txt_l);
            this.Controls.Add(this.txt_r);
            this.Controls.Add(this.lbl_header);
            this.Controls.Add(this.Result);
            this.Name = "OilPaint";
            this.Text = "OilPaint";
            ((System.ComponentModel.ISupportInitialize)(this.Result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox Result;
        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.TextBox txt_r;
        private System.Windows.Forms.TextBox txt_l;
        private System.Windows.Forms.Label lbl_r;
        private System.Windows.Forms.Label lbl_l;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.Timer My_Timer;
        private System.Windows.Forms.Button button1;
    }
}