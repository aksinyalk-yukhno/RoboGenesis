using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboGenesis.UserControls
{
    public partial class UC_Home_Course : UserControl
    { 
        public UC_Home_Course()
        {
            InitializeComponent();
        }

        private string _title;
        private string _description;
        private Image _icon;
        private string _iconPath;
        private int _courseId;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; lblTitle.Text = value; }
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [Category("Custom Props")]
        public int CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pbIcon.Image = value; }
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
                    pbIcon.Image = Image.FromFile(_iconPath);
                }
                else
                {
                    pbIcon.Image = Properties.Resources.basket_no_img; // Ваше изображение по умолчанию
                }
            }
        }

        private int _enrollmentCount;

        [Category("Custom Props")]
        public int EnrollmentCount
        {
            get { return _enrollmentCount; }
            set { _enrollmentCount = value; guna2Button21.Text = value.ToString(); }
        }

        private int _commentCount;

        [Category("Custom Props")]
        public int CommentCount
        {
            get { return _commentCount; }
            set { _commentCount = value;  guna2Button20.Text = value.ToString(); }
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e) => guna2Button22_Click(sender, e);
        private void label8_Click(object sender, EventArgs e) => guna2Button22_Click(sender, e);

        private void pbIcon_MouseEnter(object sender, EventArgs e)
        {
            guna2Button22.BorderColor = System.Drawing.Color.FromArgb(51, 153, 255);
        }

        private void pbIcon_MouseLeave(object sender, EventArgs e)
        {
            guna2Button22.BorderColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {

        }
    }
}
