using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace RoboGenesis
{
    class USER
    {
        MY_DB db = new MY_DB();

        // function to check the username

        public bool usernameExists (string username)
        {
            string query = "SELECT * FROM `users` WHERE `username`=@un";
            
            MySqlCommand  command = new MySqlCommand(query, db.getConnection);
             
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = username;


            MySqlDataAdapter adapter = new MySqlDataAdapter (command);
            
            DataTable table = new DataTable();

            adapter.Fill (table);

            // if the username exists return true
            if(table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool insertUser(string email, string username, string password, MemoryStream picture)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`email`, `username`, `pass`, `picture`, `registration_date`) VALUES (@el, @un, @pass, @pic, @regDate)", db.getConnection);

            command.Parameters.Add("@el", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = picture.ToArray();
            command.Parameters.Add("@regDate", MySqlDbType.DateTime).Value = DateTime.Now; // Add the registration date parameter

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public string getUsernameById(int userId)
        {
            string username = "";
            string query = "SELECT username FROM users WHERE id = @id";

            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = userId;

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                username = reader["username"].ToString();
            }

            reader.Close();
            db.closeConnection();

            return username;
        }

        public string getRegDateById(int userId)
        {
            string regDate = "";
            string query = "SELECT registration_date FROM users WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = userId;

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                regDate = reader["registration_date"].ToString();
            }
            reader.Close();
            db.closeConnection();

            return regDate;
        }
    }
}
