using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository.Users
{
    public class UserRepository
    {
        private string connectionString;

        public UserRepository(string name)
        {
            connectionString = $"Data Source={name};Version=3;"; ;
        }

        public User GetUserById(int id)
        {
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                User user;
                dbConnection.Open();
                var sqlSelect = "SELECT id, name, surname, age FROM Users WHERE id = @Id";
                var command = new SQLiteCommand(sqlSelect, dbConnection);
                command.Parameters.Add(new SQLiteParameter("@Id", id));
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new User();
                    user.Id = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Surname = reader.GetString(2);
                    user.Age = reader.GetInt32(3);
                    return user;
                }
            }
            return null;
        }
    }
}
