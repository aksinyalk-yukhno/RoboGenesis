using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookDemo.UserControls
{
    public partial class UC_Home_Category : UserControl
    {
        public UC_Home_Category()
        {
            InitializeComponent();
            guna2Button4.Resize += Guna2Button4_Resize;
        }
        private const int _widthPadding = 40;

        private void Guna2Button4_Resize(object sender, EventArgs e)
        {
            var btn = (Guna2Button)sender;
            using (Graphics g = btn.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(btn.Text, btn.Font);
                int width = (int)textSize.Width + btn.Padding.Horizontal + _widthPadding;

                btn.Width = width;
            }
        }

        private string _name;
        private string _iconPath;

        [Category("Custom Props")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                guna2Button4.Text = value;
                guna2Button4.Invalidate(); // Вызываем перерисовку кнопки
            }
        }

        [Category("Custom Props")]
        public string IconPath
        {
            get { return _iconPath; }
            set
            {
                _iconPath = value;
                if (!string.IsNullOrEmpty(_iconPath))
                {
                    guna2Button4.Image = Image.FromFile(_iconPath);
                }
                else
                {
                    guna2Button4.Image = Properties.Resources.basket_no_img;
                }
                guna2Button4.Invalidate(); // Вызываем перерисовку кнопки
            }
        }

        private bool isguna2Button4_Click = false;

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!isguna2Button4_Click)
            {
                guna2Button4.BorderColor = System.Drawing.Color.FromArgb(0, 118, 212);
                isguna2Button4_Click = true;
            }
            else
            {
                guna2Button4.BorderColor = System.Drawing.Color.FromArgb(240, 240, 240);
                isguna2Button4_Click = false;
            }
        }
    }


}

