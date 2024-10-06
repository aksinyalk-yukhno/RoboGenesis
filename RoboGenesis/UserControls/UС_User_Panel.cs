using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Reflection.Emit;

namespace OutlookDemo.UserControls
{
    public partial class UС_User_Panel : UserControl
    {
        public event EventHandler<EventArgs> ProfileButtonClicked;
        public UС_User_Panel()
        {
            InitializeComponent();
          
        }

        MY_DB mydb = new MY_DB();

        // function to display the logged in image & username
        public void getImageAndUsername()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `id`=@uid", mydb.getConnection);
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = Globals.GlobalUserId;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                // display the user image
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                guna2Button2.Image = Image.FromStream(picture);


                // display the user username & email
                label3.Text = "@" + table.Rows[0]["username"];
                label2.Text = "Вы";
            }
        }

        
        private void UС_User_Panel_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ProfileButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
