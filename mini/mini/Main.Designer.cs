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
            ((System.ComponentModel.ISupportInitialize)(this.Original)).BeginInit();
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
            this.btn_paint.Location = new System.Drawing.Point(841, 79);
            this.btn_paint.Name = "btn_paint";
            this.btn_paint.Size = new System.Drawing.Size(130, 39);
            this.btn_paint.TabIndex = 4;
            this.btn_paint.Text = "Oil Painting ";
            this.btn_paint.UseVisualStyleBackColor = true;
            this.btn_paint.Click += new System.EventHandler(this.btn_paint_Click);
            // 
            // Original
            // 
            this.Original.Location = new System.Drawing.Point(121, 152);
            this.Original.Name = "Original";
            this.Original.Size = new System.Drawing.Size(666, 549);
            this.Original.TabIndex = 2;
            this.Original.TabStop = false;
            // 
            // btn_cartoon
            // 
            this.btn_cartoon.Location = new System.Drawing.Point(841, 152);
            this.btn_cartoon.Name = "btn_cartoon";
            this.btn_cartoon.Size = new System.Drawing.Size(130, 38);
            this.btn_cartoon.TabIndex = 5;
            this.btn_cartoon.Text = "Cartoon Effect";
            this.btn_cartoon.UseVisualStyleBackColor = true;
            this.btn_cartoon.Click += new System.EventHandler(this.btn_cartoon_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 750);
            this.Controls.Add(this.btn_cartoon);
            this.Controls.Add(this.btn_paint);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.Original);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Original)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFD;
        private Emgu.CV.UI.ImageBox Original;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Button btn_paint;
        private System.Windows.Forms.Button btn_cartoon;
    }
}

