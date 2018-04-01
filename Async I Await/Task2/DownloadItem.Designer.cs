namespace Task2
{
    partial class DownloadItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.downloadUrlLabel = new System.Windows.Forms.Label();
            this.cancelDownloadButton = new System.Windows.Forms.Button();
            this.downloadStatusLabel = new System.Windows.Forms.Label();
            this.startDownloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // downloadUrlLabel
            // 
            this.downloadUrlLabel.AutoSize = true;
            this.downloadUrlLabel.Location = new System.Drawing.Point(3, 5);
            this.downloadUrlLabel.MaximumSize = new System.Drawing.Size(190, 13);
            this.downloadUrlLabel.Name = "downloadUrlLabel";
            this.downloadUrlLabel.Size = new System.Drawing.Size(20, 13);
            this.downloadUrlLabel.TabIndex = 0;
            this.downloadUrlLabel.Text = "Url";
            // 
            // cancelDownloadButton
            // 
            this.cancelDownloadButton.Location = new System.Drawing.Point(272, 0);
            this.cancelDownloadButton.Name = "cancelDownloadButton";
            this.cancelDownloadButton.Size = new System.Drawing.Size(78, 22);
            this.cancelDownloadButton.TabIndex = 1;
            this.cancelDownloadButton.Text = "Cancel";
            this.cancelDownloadButton.UseVisualStyleBackColor = true;
            this.cancelDownloadButton.Click += new System.EventHandler(this.cancelDownloadButton_Click);
            // 
            // downloadStatusLabel
            // 
            this.downloadStatusLabel.AutoSize = true;
            this.downloadStatusLabel.Location = new System.Drawing.Point(200, 5);
            this.downloadStatusLabel.Name = "downloadStatusLabel";
            this.downloadStatusLabel.Size = new System.Drawing.Size(37, 13);
            this.downloadStatusLabel.TabIndex = 2;
            this.downloadStatusLabel.Text = "Status";
            // 
            // startDownloadButton
            // 
            this.startDownloadButton.Location = new System.Drawing.Point(272, 0);
            this.startDownloadButton.Name = "startDownloadButton";
            this.startDownloadButton.Size = new System.Drawing.Size(78, 22);
            this.startDownloadButton.TabIndex = 3;
            this.startDownloadButton.Text = "Start";
            this.startDownloadButton.UseVisualStyleBackColor = true;
            this.startDownloadButton.Click += new System.EventHandler(this.startDownloadButton_Click);
            // 
            // DownloadItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.startDownloadButton);
            this.Controls.Add(this.downloadStatusLabel);
            this.Controls.Add(this.cancelDownloadButton);
            this.Controls.Add(this.downloadUrlLabel);
            this.Name = "DownloadItem";
            this.Size = new System.Drawing.Size(350, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label downloadUrlLabel;
        private System.Windows.Forms.Button cancelDownloadButton;
        private System.Windows.Forms.Label downloadStatusLabel;
        private System.Windows.Forms.Button startDownloadButton;
    }
}
