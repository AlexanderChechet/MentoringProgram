using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository.Products
{
    public class ProductRepository
    {
        private string connectionString;

        public ProductRepository(string name)
        {
            connectionString = $"Data Source={name};Version=3;"; ;
        }
        public List<Product> GetProducts()
        {
            var result = new List<Product>();
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                var sqlSelect = "SELECT id, name, description, cost FROM Products";
                var command = new SQLiteCommand(sqlSelect, dbConnection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = new Product();
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.Description = reader.GetString(2);
                    product.Cost = reader.GetInt32(3);
                    result.Add(product);
                }
            }
            return result;
        }
    }
}
