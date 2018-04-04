using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository
{
    public class ShopRepository
    {
        private string connectionString;
        public ShopRepository(string name)
        {
            connectionString = $"Data Source={name};Version=3;";
        }
        public void CreateDatabase(string name)
        {
            SQLiteConnection.CreateFile(name);
        }

        public void CreateProductTable()
        {
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();

                string sqlCreate = "CREATE TABLE Products (id INTEGER PRIMARY KEY AUTOINCREMENT, name NVARCHAR(20), description NVARCHAR(200), cost INTEGER)";

                var createCommand = new SQLiteCommand(sqlCreate, dbConnection);
                createCommand.ExecuteNonQuery();

                var sb = new StringBuilder();
                sb.Append("INSERT INTO Products (name, description, cost) VALUES");
                sb.Append("('TestName1', 'TestDescription1', 100),");
                sb.Append("('TestName2', 'TestDescription2', 200),");
                sb.Append("('TestName3', 'TestDescription3', 300),");
                sb.Append("('TestName4', 'TestDescription4', 400),");
                sb.Append("('TestName5', 'TestDescription5', 500),");
                sb.Append("('TestName6', 'TestDescription6', 600),");
                sb.Append("('TestName7', 'TestDescription7', 700),");
                sb.Append("('TestName8', 'TestDescription8', 800),");
                sb.Append("('TestName9', 'TestDescription9', 900),");
                sb.Append("('TestName10', 'TestDescription10', 1000),");
                sb.Append("('TestName11', 'TestDescription11', 1100),");
                sb.Append("('TestName12', 'TestDescription12', 1200),");
                sb.Append("('TestName13', 'TestDescription13', 1300),");
                sb.Append("('TestName14', 'TestDescription14', 1400),");
                sb.Append("('TestName15', 'TestDescription15', 1500),");
                sb.Append("('TestName16', 'TestDescription16', 1600),");
                sb.Append("('TestName17', 'TestDescription17', 1700),");
                sb.Append("('TestName18', 'TestDescription18', 1800),");
                sb.Append("('TestName19', 'TestDescription19', 1900),");
                sb.Append("('TestName20', 'TestDescription20', 2000)");

                var sqlInsert = sb.ToString();
                var insertCommand = new SQLiteCommand(sqlInsert, dbConnection);
                insertCommand.ExecuteNonQuery();
            }
        }

        public void CreateUserTable()
        {
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();

                //string sqlCreate = "CREATE TABLE Users (id INTEGER PRIMARY KEY AUTOINCREMENT, name NVARCHAR(20), surname NVARCHAR(200), age INTEGER)";

                //var createCommand = new SQLiteCommand(sqlCreate, dbConnection);
                //createCommand.ExecuteNonQuery();

                var sb = new StringBuilder();
                sb.Append("INSERT INTO Users (name, surname, age) VALUES");
                sb.Append("('TestName1', 'TestSurname1', 100),");
                sb.Append("('TestName2', 'TestSurname2', 200),");
                sb.Append("('TestName3', 'TestSurname3', 300),");
                sb.Append("('TestName4', 'TestSurname4', 400),");
                sb.Append("('TestName5', 'TestSurname5', 500),");
                sb.Append("('TestName6', 'TestSurname6', 600),");
                sb.Append("('TestName7', 'TestSurname7', 700),");
                sb.Append("('TestName8', 'TestSurname8', 800),");
                sb.Append("('TestName9', 'TestSurname9', 900)");

                var sqlInsert = sb.ToString();
                var insertCommand = new SQLiteCommand(sqlInsert, dbConnection);
                insertCommand.ExecuteNonQuery();
            }
        }

        public void CreateOrderTable()
        {
            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();

                string sqlCreate = "CREATE TABLE Orders (id INTEGER PRIMARY KEY AUTOINCREMENT, productId INTEGER, userId INTEGER)";

                var createCommand = new SQLiteCommand(sqlCreate, dbConnection);
                createCommand.ExecuteNonQuery();
            }
        }
    }
}
