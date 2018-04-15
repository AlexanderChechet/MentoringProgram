namespace ShopApp.Task3
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addProductButton = new System.Windows.Forms.Button();
            this.clearBasketButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.totalCostLabel = new System.Windows.Forms.Label();
            this.productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productId,
            this.productName,
            this.productDescription,
            this.productCost});
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(460, 301);
            this.dataGridView1.TabIndex = 0;
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(480, 14);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(105, 23);
            this.addProductButton.TabIndex = 1;
            this.addProductButton.Text = "Add to basket";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // clearBasketButton
            // 
            this.clearBasketButton.Location = new System.Drawing.Point(479, 43);
            this.clearBasketButton.Name = "clearBasketButton";
            this.clearBasketButton.Size = new System.Drawing.Size(106, 23);
            this.clearBasketButton.TabIndex = 2;
            this.clearBasketButton.Text = "Clear basket";
            this.clearBasketButton.UseVisualStyleBackColor = true;
            this.clearBasketButton.Click += new System.EventHandler(this.clearBasketButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total : ";
            // 
            // totalCostLabel
            // 
            this.totalCostLabel.AutoSize = true;
            this.totalCostLabel.Location = new System.Drawing.Point(525, 69);
            this.totalCostLabel.Name = "totalCostLabel";
            this.totalCostLabel.Size = new System.Drawing.Size(13, 13);
            this.totalCostLabel.TabIndex = 4;
            this.totalCostLabel.Text = "0";
            // 
            // productId
            // 
            this.productId.HeaderText = "Id";
            this.productId.Name = "productId";
            // 
            // productName
            // 
            this.productName.HeaderText = "Name";
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            // 
            // productDescription
            // 
            this.productDescription.HeaderText = "Description";
            this.productDescription.Name = "productDescription";
            this.productDescription.ReadOnly = true;
            // 
            // productCost
            // 
            this.productCost.HeaderText = "Cost";
            this.productCost.Name = "productCost";
            this.productCost.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 326);
            this.Controls.Add(this.totalCostLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearBasketButton);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button clearBasketButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalCostLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCost;
    }
}

