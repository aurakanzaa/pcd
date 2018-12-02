namespace pcdmodul1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bukaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpanToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.keluarAplikasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tentangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbInput = new System.Windows.Forms.PictureBox();
            this.pbOutput = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bukaToolStripMenuItem,
            this.tentangToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1218, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bukaToolStripMenuItem
            // 
            this.bukaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpanToolStripMenuItem,
            this.simpanToolStripMenuItem2,
            this.keluarAplikasiToolStripMenuItem});
            this.bukaToolStripMenuItem.Name = "bukaToolStripMenuItem";
            this.bukaToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.bukaToolStripMenuItem.Text = "&File";
            // 
            // simpanToolStripMenuItem
            // 
            this.simpanToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("simpanToolStripMenuItem.Image")));
            this.simpanToolStripMenuItem.Name = "simpanToolStripMenuItem";
            this.simpanToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.simpanToolStripMenuItem.Text = "&Buka";
            this.simpanToolStripMenuItem.Click += new System.EventHandler(this.simpanToolStripMenuItem_Click);
            // 
            // simpanToolStripMenuItem2
            // 
            this.simpanToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("simpanToolStripMenuItem2.Image")));
            this.simpanToolStripMenuItem2.Name = "simpanToolStripMenuItem2";
            this.simpanToolStripMenuItem2.Size = new System.Drawing.Size(216, 26);
            this.simpanToolStripMenuItem2.Text = "&Simpan Sebagai";
            this.simpanToolStripMenuItem2.Click += new System.EventHandler(this.simpanToolStripMenuItem2_Click);
            // 
            // keluarAplikasiToolStripMenuItem
            // 
            this.keluarAplikasiToolStripMenuItem.Name = "keluarAplikasiToolStripMenuItem";
            this.keluarAplikasiToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.keluarAplikasiToolStripMenuItem.Text = "&Keluar Aplikasi";
            this.keluarAplikasiToolStripMenuItem.Click += new System.EventHandler(this.keluarAplikasiToolStripMenuItem_Click);
            // 
            // tentangToolStripMenuItem
            // 
            this.tentangToolStripMenuItem.Name = "tentangToolStripMenuItem";
            this.tentangToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.tentangToolStripMenuItem.Text = "Tentang";
            this.tentangToolStripMenuItem.Click += new System.EventHandler(this.tentangToolStripMenuItem_Click_1);
            // 
            // pbInput
            // 
            this.pbInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbInput.Location = new System.Drawing.Point(12, 31);
            this.pbInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbInput.Name = "pbInput";
            this.pbInput.Size = new System.Drawing.Size(501, 350);
            this.pbInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInput.TabIndex = 1;
            this.pbInput.TabStop = false;
            // 
            // pbOutput
            // 
            this.pbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOutput.Location = new System.Drawing.Point(705, 31);
            this.pbOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(501, 350);
            this.pbOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOutput.TabIndex = 2;
            this.pbOutput.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 671);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1218, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(261, 398);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(711, 129);
            this.flowLayoutPanel1.TabIndex = 36;
            this.flowLayoutPanel1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 693);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pbOutput);
            this.Controls.Add(this.pbInput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bukaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpanToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbInput;
        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.ToolStripMenuItem simpanToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem keluarAplikasiToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem tentangToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

