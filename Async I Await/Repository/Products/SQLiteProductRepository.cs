using Model.Entities;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace ShopRepository.Products
{
    public class SQLiteProductRepository : IProductRepository
    {
        private string connectionString;

        public SQLiteProductRepository(string name)
        {
            connectionString = $"Data Source={name};Version=3;"; ;
        }
        public async Task<List<Product>> GetProducts()
        {
            var result = new List<Product>();
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                await dbConnection.OpenAsync();
                var sqlSelect = "SELECT id, name, description, cost FROM Products";
                using (var command = new SQLiteCommand(sqlSelect, dbConnection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var product = new Product();
                            product.Id = reader.GetInt32(0);
                            product.Name = reader.GetString(1);
                            product.Description = reader.GetString(2);
                            product.Cost = reader.GetInt32(3);
                            result.Add(product);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<Product> GetProductById(int id)
        {
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                await dbConnection.OpenAsync();
                var sqlSelect = "SELECT id, name, description, cost FROM Products WHERE id = @Id";
                using (var command = new SQLiteCommand(sqlSelect, dbConnection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Id", id));
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var product = new Product();
                            product.Id = reader.GetInt32(0);
                            product.Name = reader.GetString(1);
                            product.Description = reader.GetString(2);
                            product.Cost = reader.GetInt32(3);
                            return product;
                        }
                    }
                }
                return null;
            }
        }
    }
}
