using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository.Orders
{
    public class OrderRepository
    {
        private string connectionString;

        public OrderRepository(string name)
        {
            connectionString = $"Data Source={name};Version=3;"; ;
        }

        public List<Order> GetUserOrders(int userId)
        {
            var result = new List<Order>();
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                var sqlSelect = "SELECT id, productId, userId FROM Orders WHERE @UserId";
                var command = new SQLiteCommand(sqlSelect, dbConnection);
                command.Parameters.Add(new SQLiteParameter("@UserId", userId));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var order = new Order();
                    order.Id = reader.GetInt32(0);
                    order.ProductId = reader.GetInt32(1);
                    order.UserId = reader.GetInt32(2);
                    result.Add(order);
                }
            }
            return result;
        }
    }
}
