namespace Task2
{
    partial class MainForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addDownloadButton = new System.Windows.Forms.Button();
            this.downloadListPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(279, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Url to download";
            // 
            // addDownloadButton
            // 
            this.addDownloadButton.Location = new System.Drawing.Point(297, 27);
            this.addDownloadButton.Name = "addDownloadButton";
            this.addDownloadButton.Size = new System.Drawing.Size(75, 23);
            this.addDownloadButton.TabIndex = 2;
            this.addDownloadButton.Text = "Download";
            this.addDownloadButton.UseVisualStyleBackColor = true;
            this.addDownloadButton.Click += new System.EventHandler(this.addDownloadButton_Click);
            // 
            // downloadListPanel
            // 
            this.downloadListPanel.Location = new System.Drawing.Point(12, 68);
            this.downloadListPanel.Name = "downloadListPanel";
            this.downloadListPanel.Size = new System.Drawing.Size(360, 205);
            this.downloadListPanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Download list";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 285);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.downloadListPanel);
            this.Controls.Add(this.addDownloadButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addDownloadButton;
        private System.Windows.Forms.Panel downloadListPanel;
        private System.Windows.Forms.Label label2;
    }
}

