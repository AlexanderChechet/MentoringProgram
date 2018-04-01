﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addDownloadButton_Click(object sender, EventArgs e)
        {
            var url = textBox1.Text;
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                var control = new DownloadItem(url);
                downloadListPanel.Controls.Add(control);
            }
            else
            {
                MessageBox.Show("Wrong url", "Wrong url");
            }
        }
    }
}
