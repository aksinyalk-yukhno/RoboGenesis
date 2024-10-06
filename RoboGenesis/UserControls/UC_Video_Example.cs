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
    public partial class UC_Video_Example : UserControl
    {
        public UC_Video_Example()
        {
            InitializeComponent();
        }

        private string _title;
        private string _description;
        private string _descriptionAbout;
        private Image _icon;
        private Color _iconBack;
        private string _iconPath;
        private string _filePath;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; lblTitle.Text = value; }
        }

        [Category("Custom Props")]
        public Color IconBackground
        {
            get { return _iconBack; }
            set { _iconBack = value; panel1.FillColor = value; }
        }


        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value; lblDescription.Text = value; }
        }

        [Category("Custom Props")]
        public string DescriptionAbout
        {
            get { return _descriptionAbout; }
            set { _descriptionAbout = value; }
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
                    pbIcon.Image = Properties.Resources.basket_no_img; 
                }
            }
        }

        [Category("Custom Props")]
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }
    }
}
