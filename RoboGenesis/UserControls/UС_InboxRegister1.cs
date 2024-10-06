using Guna.UI2.HtmlRenderer.Adapters;
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

namespace RoboGenesis.UserControls
{
    public partial class uС_InboxRegister1 : UserControl
    {

        public uС_InboxRegister1()
        {
            InitializeComponent();
            
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

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                guna2TextBox2.IconLeft = Properties.Resources.ic_email1;
            }
            else
            {
                guna2TextBox2.IconLeft = Properties.Resources.ic_email2;
            }
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

        private void label4_Click(object sender, EventArgs e)
        {
            this.Visible = false;    
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProfileImage.Image = Image.FromFile(opf.FileName);
            }
        }

        // function to check empty fields
        public bool verifFields(string operation)
        {
            bool check = false;

            // if the operation is register
            if(operation == "register")
            {
                if(guna2TextBox3.Text.Trim().Equals("") || guna2TextBox2.Text.Trim().Equals("") || guna2TextBox1.Text.Trim().Equals("") || pictureBoxProfileImage.Image == null)
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }
            else if (operation == "login")
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
            string email = guna2TextBox2.Text;
            string username = guna2TextBox3.Text;
            string password = guna2TextBox1.Text;

            USER user = new USER();

            if (verifFields("register"))
            {
                MemoryStream pic = new MemoryStream();
                pictureBoxProfileImage.Image.Save(pic, pictureBoxProfileImage.Image.RawFormat);
                
                if (!user.usernameExists(username)) //check if the username already exists
                {
                    if(user.insertUser(email, username, password, pic))
                    {
                        MessageBox.Show("Registration Completed Successfuly", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("This Username Already Exists. Try Another One", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("* Required Fields - Email / Username / Password / Image" , "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
