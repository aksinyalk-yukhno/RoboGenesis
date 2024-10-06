using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OutlookDemo.UserControls
{
    public partial class UC_PasswordRecovery : UserControl
    {
        public UC_PasswordRecovery()
        {
            InitializeComponent();
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            string email = guna2TextBox1.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email.", "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool emailExists = await CheckEmailExistsAsync(email);
            if (emailExists)
            {
                string newPassword = GenerateRandomPassword();
                bool updateSuccess = await UpdatePasswordAsync(email, newPassword);
                if (updateSuccess)
                {
                    bool emailSent = await SendPasswordEmailAsync(email, newPassword);
                    if (emailSent)
                    {
                        MessageBox.Show("A new password has been sent to your email.", "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to send email. Please try again.", "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong. Please try again.", "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("This email is not registered.", "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task<bool> CheckEmailExistsAsync(string email)
        {
            bool emailExists = false;

            MY_DB db = new MY_DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `email`=@mail", db.getConnection);
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = email;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            try
            {
                await Task.Run(() =>
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                });

                if (table.Rows.Count > 0)
                {
                    emailExists = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return emailExists;
        }

        private async Task<bool> UpdatePasswordAsync(string email, string newPassword)
        {
            bool success = false;

            MY_DB db = new MY_DB();
            MySqlCommand updateCommand = new MySqlCommand("UPDATE `users` SET `pass`=@pass WHERE `email`=@mail", db.getConnection);
            updateCommand.Parameters.Add("@pass", MySqlDbType.VarChar).Value = newPassword;
            updateCommand.Parameters.Add("@mail", MySqlDbType.VarChar).Value = email;

            try
            {
                db.openConnection();
                int rowsAffected = await updateCommand.ExecuteNonQueryAsync();
                db.closeConnection();

                if (rowsAffected > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return success;
        }

        private async Task<bool> SendPasswordEmailAsync(string email, string newPassword)
        {
            bool emailSent = false;

            try
            {
                await Task.Run(() =>
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("libraryservices.mrk@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Восстановление пароля";
                    mail.Body = $"Ваш новый пароль: {newPassword}";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("libraryservices.mrk@gmail.com", "mbnp ifbs jply ldkv");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    emailSent = true;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return emailSent;
        }

        private string GenerateRandomPassword(int length = 12)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            byte[] random = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
            }
            var chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random[i] % validChars.Length];
            }

            return new string(chars);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                guna2TextBox1.IconLeft = Properties.Resources.ic_email1;
            }
            else
            {
                guna2TextBox1.IconLeft = Properties.Resources.ic_email2;
            }
        }
    }
}