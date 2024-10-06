using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookDemo
{
    internal class ProductHelper
    {
        private MY_DB db = new MY_DB();

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            string query = "SELECT * FROM products";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Product product = new Product()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    Price = row["price"].ToString(),
                    IconPath = row["icon"].ToString() // Получаем путь к картинке из базы данных
                };

                products.Add(product);
            }

            return products;
        }

        public bool SaveOrder(int userId, decimal totalAmount)
        {
            string query = "INSERT INTO orders (user_id, total_amount) VALUES (@userId, @totalAmount)";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@totalAmount", totalAmount);

            db.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            db.closeConnection();

            return rowsAffected > 0;
        }

        public int GetOrderCount(int userId)
        {
            string query = "SELECT COUNT(*) FROM orders WHERE user_id = @userId";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);

            db.openConnection();
            int orderCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return orderCount;
        }

        public Dictionary<DateTime, decimal> GetOrderTotalsByDate(int userId)
        {
            Dictionary<DateTime, decimal> orderTotals = new Dictionary<DateTime, decimal>();

            string query = @"SELECT DATE(order_date) AS order_date, SUM(total_amount) AS total_amount
                     FROM orders
                     WHERE user_id = @userId
                     GROUP BY DATE(order_date)";

            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime orderDate = reader.GetDateTime("order_date");
                decimal totalAmount = reader.GetDecimal("total_amount");
                orderTotals[orderDate] = totalAmount;
            }

            reader.Close();
            db.closeConnection();

            return orderTotals;
        }

        public int GetOrderCountForDate(int userId, DateTime date)
        {
            string query = "SELECT COUNT(*) FROM orders WHERE user_id = @userId AND DATE(order_date) = @date";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@date", date.Date);

            db.openConnection();
            int orderCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return orderCount;
        }

        public class Product
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }
            public string IconPath { get; set; }
        }
    }
}
