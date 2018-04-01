using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Task2
{
    public partial class DownloadItem : UserControl
    {
        CancellationTokenSource cts;

        public DownloadItem(string url)
        {
            InitializeComponent();
            downloadUrlLabel.Text = url;
        }
        public DownloadItem()
        {
            InitializeComponent();
        }

        public async void ProcessTask()
        {
            try
            {
                string content = await CustomDownloader.DownloadUrlAsync(downloadUrlLabel.Text, cts.Token);
                downloadStatusLabel.Text = content.Length.ToString();
                cancelDownloadButton.Visible = false;
            }
            catch (OperationCanceledException)
            {
                downloadStatusLabel.Text = "Cancelled";
                startDownloadButton.Visible = true;
            }
            catch (Exception)
            {
                downloadStatusLabel.Text = "Failed";
            }
            finally
            {
                cts.Dispose();
            }
        }

        private void cancelDownloadButton_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }

        private void startDownloadButton_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            startDownloadButton.Visible = false;
            downloadStatusLabel.Text = "In progress";
            ProcessTask();
        }
    }
}
