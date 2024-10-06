using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookDemo.UserControls
{
    public partial class UC_Activity_Test_Example : UserControl
    {
        private UC_Activity parentForm;
        public UC_Activity_Test_Example()
        {
            InitializeComponent();
            
        }

        private string _title;
        private string _description;
        private string _questions;
        private string _iconPath;
        private int _testId;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; lblTitle.Text = value; }
        }

        [Category("Custom Props")]
        public int TestId
        {
            get { return _testId; }
            set { _testId = value; }
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
        public string Questions
        {
            get { return _questions; }
            set { _questions = value; lblQuestions.Text = value; }
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
                    pbIcon.Image = Properties.Resources.activity_test_img; // Ваше изображение по умолчанию
                }
            }
        }

        private Color _iconBack;

        private void UC_Activity_Test_Example_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }
    }
}
