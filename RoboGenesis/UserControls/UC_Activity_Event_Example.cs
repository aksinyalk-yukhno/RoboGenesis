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

namespace OutlookDemo.UserControls
{
    public partial class UC_Activity_Event_Example : UserControl
    {
        public UC_Activity_Event_Example()
        {
            InitializeComponent();
        }

        private string _title;
        private DateTime _date;
        private string _picturePath;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; lblTitle.Text = value; }
        }

        [Category("Custom Props")]
        public string PicturePath
        {
            get { return _picturePath; }
            set
            {
                _picturePath = value;
                if (!string.IsNullOrEmpty(_picturePath))
                {
                    pbIcon.Image = Image.FromFile(_picturePath);
                }
                else
                {
                    pbIcon.Image = Properties.Resources.basket_no_img;
                }
            }
        }


        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value; lblDescription.Text = value; }
        }
        private string _description;

        [Category("Custom Props")]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; lblDate.Text = value.ToShortDateString(); }
        }

        [Category("Custom Props")]
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; lblStartTime.Text = value.ToShortTimeString(); }
        }
        private DateTime _startTime;

        [Category("Custom Props")]
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; lblEndTime.Text = value.ToShortTimeString(); }
        }
        private DateTime _endTime;



    }
}
