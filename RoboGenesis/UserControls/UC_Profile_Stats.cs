using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookDemo.UserControls
{
    public partial class UC_Profile_Stats : UserControl
    {
        public UC_Profile_Stats()
        {
            InitializeComponent();
        }

        public string StatNumber
        {
            get { return label6.Text; }
            set { label6.Text = value; }
        }

        public string StatName
        {
            get { return label7.Text; }
            set { label7.Text = value; }
        }

        public Image StatImage
        {
            get { return guna2PictureBox1.Image; }
            set { guna2PictureBox1.Image = value; }
        }

        private void UC_Profile_Stats_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = System.Drawing.Color.FromArgb(0, 118, 212);
            label6.BackColor = System.Drawing.Color.White;
            label7.ForeColor = System.Drawing.Color.FromArgb(0, 118, 212);
            label7.BackColor = System.Drawing.Color.White;
            guna2PictureBox1.BackColor = System.Drawing.Color.White;
            guna2Panel1.FillColor = System.Drawing.Color.White;

        }

        private void UC_Profile_Stats_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            label6.BackColor = System.Drawing.Color.Transparent;
            label7.ForeColor = System.Drawing.Color.Gray;
            label7.BackColor = System.Drawing.Color.Transparent;
            guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            guna2Panel1.FillColor = System.Drawing.Color.AliceBlue;
        }

        private void guna2PictureBox1_MouseEnter(object sender, EventArgs e) => UC_Profile_Stats_MouseEnter(sender, e);
        private void guna2PictureBox1_MouseLeave(object sender, EventArgs e) => UC_Profile_Stats_MouseLeave(sender, e);

        private void label6_MouseEnter(object sender, EventArgs e) => UC_Profile_Stats_MouseEnter(sender, e);
        private void label6_MouseLeave(object sender, EventArgs e) => UC_Profile_Stats_MouseLeave(sender, e);

        private void label7_MouseEnter(object sender, EventArgs e) => UC_Profile_Stats_MouseEnter(sender, e);
        private void label7_MouseLeave(object sender, EventArgs e) => UC_Profile_Stats_MouseLeave(sender, e);

        private void guna2Panel1_MouseEnter(object sender, EventArgs e) => UC_Profile_Stats_MouseEnter(sender, e);
        private void guna2Panel1_MouseLeave(object sender, EventArgs e) => UC_Profile_Stats_MouseLeave(sender, e);

    }
}
