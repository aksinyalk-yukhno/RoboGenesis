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

namespace RoboGenesis.UserControls
{
    public partial class UC_Home_Challenge : UserControl
    {
        public UC_Home_Challenge()
        {
            InitializeComponent();
        }

        private string _title;
        private string _description;
        private string _iconPath;

        [Category("Custom Props")]
        public int ChallengeId { get; set; }

        [Category("Custom Props")]
        public bool IsCompleted { get; set; }


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
            set { _description = value; lblDescription.Text = value; }
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
        public Guna.UI2.WinForms.Guna2Button ChallengeButton
        {
            get { return guna2Button1; }
            set { guna2Button1 = value; }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            HomeHelper homeHelper = new HomeHelper();
            bool completed = true;
            DateTime completedAt = DateTime.Now;
            bool success = homeHelper.AddUserChallengeProgress(Globals.GlobalUserId, ChallengeId, completed, completedAt);

            if (success)
            {
                IsCompleted = true;
                guna2Button1.Checked = true;
                guna2Button1.Text = "Вы уже участвуете";
            }
        }

        
    }
}
