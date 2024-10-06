using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RoboGenesis
{
    internal class MY_DB
    {
        // the connection
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;username=root;password=753295305lk;database=robogenesis_db");
        
        // return the connection
        public MySqlConnection getConnection
        {
            get
            {
                return con;
            }
        }

        //open the connection
        public void openConnection()
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        // close the connection
        public void closeConnection()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
