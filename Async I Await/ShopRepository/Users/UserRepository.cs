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

        public async Task<User> GetUserById(int id)
        {
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                User user;
                await dbConnection.OpenAsync();
                var sqlSelect = "SELECT id, name, surname, age FROM Users WHERE id = @Id";
                using (var command = new SQLiteCommand(sqlSelect, dbConnection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Id", id));
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            user = new User();
                            user.Id = reader.GetInt32(0);
                            user.Name = reader.GetString(1);
                            user.Surname = reader.GetString(2);
                            user.Age = reader.GetInt32(3);
                            return user;
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<User>> GetUsers()
        {
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                List<User> result = new List<User>();
                await dbConnection.OpenAsync().ConfigureAwait(false);
                var sqlSelect = "SELECT id, name, surname, age FROM Users";
                using (var command = new SQLiteCommand(sqlSelect, dbConnection))
                {
                    using (var reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync().ConfigureAwait(false))
                        {
                            var user = new User();
                            user.Id = reader.GetInt32(0);
                            user.Name = reader.GetString(1);
                            user.Surname = reader.GetString(2);
                            user.Age = reader.GetInt32(3);
                            result.Add(user);
                        }
                        return result;
                    }
                }
            }
        }

        public async Task AddUser(User user)
        {
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                await dbConnection.OpenAsync();
                var sqlInsert = "INSERT INTO Users (name, surname, age) VALUES (@Name, @Surname, @Age)";
                using (var command = new SQLiteCommand(sqlInsert, dbConnection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Name", user.Name));
                    command.Parameters.Add(new SQLiteParameter("@Surname", user.Surname));
                    command.Parameters.Add(new SQLiteParameter("@Age", user.Age));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EditUser(User user)
        {
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                await dbConnection.OpenAsync();
                var sqlUpdate = "UPDATE Users SET name = @Name, surname = @Surname, age = @Age WHERE id = @Id";
                using (var command = new SQLiteCommand(sqlUpdate, dbConnection))
                {

                    command.Parameters.Add(new SQLiteParameter("@Id", user.Id));
                    command.Parameters.Add(new SQLiteParameter("@Name", user.Name));
                    command.Parameters.Add(new SQLiteParameter("@Surname", user.Surname));
                    command.Parameters.Add(new SQLiteParameter("@Age", user.Age));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteUser(int id)
        {
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                await dbConnection.OpenAsync();
                var sqlUpdate = "DELETE FROM Users WHERE id = @Id";
                using (var command = new SQLiteCommand(sqlUpdate, dbConnection))
                {
                    command.Parameters.Add(new SQLiteParameter("@Id", id));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
