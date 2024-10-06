using Guna.UI2.HtmlRenderer.Adapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutlookDemo.UserControls;
using MySql.Data.MySqlClient;
using Guna.UI2.WinForms;

namespace OutlookDemo.UserControls
{
    public partial class UC_InboxAuthorization : UserControl
    {
        public event EventHandler<EventArgs> AuthenticationSuccessful;
        public UC_InboxAuthorization()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            uС_InboxRegister11.Visible = true;
            uС_InboxRegister11.BringToFront();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox3.Text))
            {
                guna2TextBox3.IconLeft = Properties.Resources.iconamoon_profile1;
            }
            else
            {
                guna2TextBox3.IconLeft = Properties.Resources.iconamoon_profile2;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox1.PasswordChar = '*';

            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                guna2TextBox1.IconLeft = Properties.Resources.mdi_password1;
            }
            else
            {
                guna2TextBox1.IconLeft = Properties.Resources.mdi_password2;
            }
        }

        private bool _isPasswordVisible = false;
        private void guna2TextBox1_DoubleClick(object sender, EventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;
            if (_isPasswordVisible)
            {
                guna2TextBox1.PasswordChar = '\0'; // Сделать пароль видимым
            }
            else
            {
                guna2TextBox1.PasswordChar = '*'; // Сделать пароль невидимым
            }
        }

        public bool verifFields(string operation)
        {
            bool check = false;

            // if the operation is register
            if (operation == "login")
            {
                if (guna2TextBox3.Text.Trim().Equals("") || guna2TextBox1.Text.Trim().Equals(""))
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }

            return check;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username`=@un AND `pass`=@pass", db.getConnection);

            command.Parameters.Add("@un",MySqlDbType.VarChar).Value = guna2TextBox3.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = guna2TextBox1.Text;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if(verifFields("login")) //check for empty fields
            {
                if (table.Rows.Count > 0)
                {
                    // to display the username & image in the main form 
                    // we need to get the user id and make it global so the other form can use it

                    int userId = Convert.ToInt32(table.Rows[0][0].ToString());
                    Globals.SetGlobalUserId(userId);

                    // show the main app form
                    AuthenticationSuccessful?.Invoke(this, EventArgs.Empty);
                    
                }
                else
                {
                    // show an error message
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            uC_PasswordRecovery1.Visible = true;
            uC_PasswordRecovery1.BringToFront();
        }
    }
}
