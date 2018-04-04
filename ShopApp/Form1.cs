using ShopRepository.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp
{
    public partial class Form1 : Form
    {
        private const string DbName = "ShopDb.sqlite";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var sr = new ShopRepository.ShopRepository(DbName);
            var productRepository = new ProductRepository(DbName);
            var products = productRepository.GetProducts();
            int i = 0;
            foreach (var product in products)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = product.Name;
                dataGridView1.Rows[i].Cells[1].Value = product.Description;
                dataGridView1.Rows[i].Cells[2].Value = product.Cost;
                i++;
            }
        }
    }
}
