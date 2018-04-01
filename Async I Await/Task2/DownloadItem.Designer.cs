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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // downloadUrlLabel
            // 
            this.downloadUrlLabel.AutoSize = true;
            this.downloadUrlLabel.Location = new System.Drawing.Point(3, 0);
            this.downloadUrlLabel.MaximumSize = new System.Drawing.Size(260, 13);
            this.downloadUrlLabel.Name = "downloadUrlLabel";
            this.downloadUrlLabel.Size = new System.Drawing.Size(20, 13);
            this.downloadUrlLabel.TabIndex = 0;
            this.downloadUrlLabel.Text = "Url";
            // 
            // cancelDownloadButton
            // 
            this.cancelDownloadButton.Location = new System.Drawing.Point(269, 3);
            this.cancelDownloadButton.Name = "cancelDownloadButton";
            this.cancelDownloadButton.Size = new System.Drawing.Size(78, 36);
            this.cancelDownloadButton.TabIndex = 1;
            this.cancelDownloadButton.Text = "Cancel";
            this.cancelDownloadButton.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 16);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // DownloadItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cancelDownloadButton);
            this.Controls.Add(this.downloadUrlLabel);
            this.Name = "DownloadItem";
            this.Size = new System.Drawing.Size(350, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label downloadUrlLabel;
        private System.Windows.Forms.Button cancelDownloadButton;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
