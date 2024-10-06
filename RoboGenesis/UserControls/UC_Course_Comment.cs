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
    public partial class UC_Course_Comment : UserControl
    {
        public UC_Course_Comment()
        {
            InitializeComponent();
        }

        private string _username;
        private string _description;
        private int _courseId;

        [Category("Custom Props")]
        public string Username
        {
            get { return _username; }
            set { _username = value; lblUsername.Text = "@" + value; }
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value; lblDescription.Text = value; }
        }

        [Category("Custom Props")]
        public int CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }
    }
}
