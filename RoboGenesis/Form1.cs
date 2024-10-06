using Guna.UI2.WinForms;
using RoboGenesis.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboGenesis
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            uC_Shelf1.Visible = false;
            uC_Shop1.Visible = false;
            uC_Activity1.Visible = false;
            uC_Inbox1.Visible = false;

            uC_Home1.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uC_Shelf1.Visible = false;
            uC_Shop1.Visible = false;
            uC_Activity1.Visible = false;
            uC_Inbox1.Visible = false;

            uC_Home1.Visible = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            uC_Home1.Visible = false;
            uC_Shelf1.Visible = false;
            uC_Inbox1.Visible = false;
            uC_Activity1.Visible = false;

            uC_Shop1.Visible = true;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            uC_Home1.Visible = false;
            uC_Shelf1.Visible = false;
            uC_Shop1.Visible = false;
            uC_Activity1.Visible = false;

            uC_Inbox1.Visible = true;

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            uC_Home1.Visible = false;
            uC_Shelf1.Visible = false;
            uC_Shop1.Visible = false;
            uC_Inbox1.Visible = false;

            uC_Activity1.Visible = true;
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            uC_Home1.Visible = false;
            uC_Shop1.Visible = false;
            uC_Inbox1.Visible = false;
            uC_Activity1.Visible = false;

            uC_Shelf1.Visible = true;
        }

        private void uC_Activity1_Load(object sender, EventArgs e)
        {

        }

        private void uC_Home1_Load(object sender, EventArgs e)
        {

        }
    }
}
