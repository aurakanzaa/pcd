namespace pcdmodul1
{
    partial class Form3
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
            this.hscLog = new System.Windows.Forms.HScrollBar();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hscLog
            // 
            this.hscLog.Location = new System.Drawing.Point(39, 30);
            this.hscLog.Maximum = 105;
            this.hscLog.Name = "hscLog";
            this.hscLog.Size = new System.Drawing.Size(396, 21);
            this.hscLog.TabIndex = 0;
            this.hscLog.ValueChanged += new System.EventHandler(this.hscLog_ValueChanged);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(507, 30);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(100, 22);
            this.tbLog.TabIndex = 1;
            this.tbLog.Text = "0";
            this.tbLog.TextChanged += new System.EventHandler(this.tbLog_TextChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(360, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.hscLog);
            this.Name = "Form3";
            this.Text = "Log Briightness";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hscLog;
        public System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button button1;
    }
}