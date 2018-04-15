using Model.Entities;
using ShopRepository.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.Task3
{
    public partial class MainForm : Form
    {
        public List<Product> basketItems;

        private SQLiteProductRepository productRepository;
        private const string DbName = "ShopDb.sqlite";

        public MainForm()
        {
            InitializeComponent();
            productRepository = new SQLiteProductRepository(DbName);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            basketItems = new List<Product>();
            var sr = new ShopRepository.ShopRepository(DbName);
            var products = await productRepository.GetProducts();
            int i = 0;
            foreach (var product in products)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = product.Id;
                dataGridView1.Rows[i].Cells[1].Value = product.Name;
                dataGridView1.Rows[i].Cells[2].Value = product.Description;
                dataGridView1.Rows[i].Cells[3].Value = product.Cost;
                i++;
            }
        }

        private void clearBasketButton_Click(object sender, EventArgs e)
        {
            basketItems.Clear();
            totalCostLabel.Text = "0";
        }

        private async Task<int> AddToBasket(int productId)
        {
            var product = await productRepository.GetProductById(productId);
            basketItems.Add(product);
            var result = basketItems.Sum(x => x.Cost);
            return result;
        }

        private async void addProductButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                var total = await AddToBasket((int)dataGridView1.Rows[index].Cells[0].Value);
                totalCostLabel.Text = total.ToString();
            }
        }
    }
}
