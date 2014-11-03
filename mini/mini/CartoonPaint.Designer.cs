namespace mini
{
    partial class CartoonPaint
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
            this.result = new Emgu.CV.UI.ImageBox();
            this.btn_sketch = new System.Windows.Forms.Button();
            this.txt_r = new System.Windows.Forms.TextBox();
            this.txt_l = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.result)).BeginInit();
            this.SuspendLayout();
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(411, 117);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(799, 563);
            this.result.TabIndex = 2;
            this.result.TabStop = false;
            // 
            // btn_sketch
            // 
            this.btn_sketch.Location = new System.Drawing.Point(95, 76);
            this.btn_sketch.Name = "btn_sketch";
            this.btn_sketch.Size = new System.Drawing.Size(75, 23);
            this.btn_sketch.TabIndex = 3;
            this.btn_sketch.Text = "Sketch";
            this.btn_sketch.UseVisualStyleBackColor = true;
            this.btn_sketch.Click += new System.EventHandler(this.btn_sketch_Click);
            // 
            // txt_r
            // 
            this.txt_r.Location = new System.Drawing.Point(285, 117);
            this.txt_r.Name = "txt_r";
            this.txt_r.Size = new System.Drawing.Size(100, 20);
            this.txt_r.TabIndex = 4;
            // 
            // txt_l
            // 
            this.txt_l.Location = new System.Drawing.Point(285, 170);
            this.txt_l.Name = "txt_l";
            this.txt_l.Size = new System.Drawing.Size(100, 20);
            this.txt_l.TabIndex = 5;
            // 
            // CartoonPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.txt_l);
            this.Controls.Add(this.txt_r);
            this.Controls.Add(this.btn_sketch);
            this.Controls.Add(this.result);
            this.Name = "CartoonPaint";
            this.Text = "CartoonPaint";
            ((System.ComponentModel.ISupportInitialize)(this.result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox result;
        private System.Windows.Forms.Button btn_sketch;
        private System.Windows.Forms.TextBox txt_r;
        private System.Windows.Forms.TextBox txt_l;
    }
}