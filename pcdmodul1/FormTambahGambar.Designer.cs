namespace pcdmodul1
{
    partial class FormTambahGambar
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
            this.pbInput1 = new System.Windows.Forms.PictureBox();
            this.pbInput2 = new System.Windows.Forms.PictureBox();
            this.pbOutput = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pilihGambarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.btnTmbh = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbInput1
            // 
            this.pbInput1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbInput1.Location = new System.Drawing.Point(12, 72);
            this.pbInput1.Name = "pbInput1";
            this.pbInput1.Size = new System.Drawing.Size(500, 350);
            this.pbInput1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInput1.TabIndex = 0;
            this.pbInput1.TabStop = false;
            // 
            // pbInput2
            // 
            this.pbInput2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbInput2.Location = new System.Drawing.Point(540, 72);
            this.pbInput2.Name = "pbInput2";
            this.pbInput2.Size = new System.Drawing.Size(500, 350);
            this.pbInput2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInput2.TabIndex = 1;
            this.pbInput2.TabStop = false;
            // 
            // pbOutput
            // 
            this.pbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOutput.Location = new System.Drawing.Point(1046, 72);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(500, 350);
            this.pbOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOutput.TabIndex = 2;
            this.pbOutput.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pilihGambarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1529, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pilihGambarToolStripMenuItem
            // 
            this.pilihGambarToolStripMenuItem.Name = "pilihGambarToolStripMenuItem";
            this.pilihGambarToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.pilihGambarToolStripMenuItem.Text = "pilih gambar";
            this.pilihGambarToolStripMenuItem.Click += new System.EventHandler(this.pilihGambarToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1529, 24);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStrip2
            // 
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Location = new System.Drawing.Point(0, 473);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1529, 22);
            this.statusStrip2.TabIndex = 5;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // btnTmbh
            // 
            this.btnTmbh.Location = new System.Drawing.Point(1306, 449);
            this.btnTmbh.Name = "btnTmbh";
            this.btnTmbh.Size = new System.Drawing.Size(75, 23);
            this.btnTmbh.TabIndex = 6;
            this.btnTmbh.Text = "Tambah";
            this.btnTmbh.UseVisualStyleBackColor = true;
            this.btnTmbh.Click += new System.EventHandler(this.btnTmbh_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 428);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(223, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // FormTambahGambar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 519);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnTmbh);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pbOutput);
            this.Controls.Add(this.pbInput2);
            this.Controls.Add(this.pbInput1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTambahGambar";
            this.Text = "FormTambahGambar";
            ((System.ComponentModel.ISupportInitialize)(this.pbInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbInput1;
        private System.Windows.Forms.PictureBox pbInput2;
        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pilihGambarToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.Button btnTmbh;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}