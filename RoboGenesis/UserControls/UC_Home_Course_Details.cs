using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RoboGenesis.HomeHelper;

namespace RoboGenesis.UserControls
{
    public partial class UC_Home_Course_Details : UserControl
    {

        public UC_Home_Course_Details()
        {
            InitializeComponent();
            GenerateDynamicUserControl();
            GenerateDynamicUserControl2();
            GenerateDynamicUserControl3();

        }
        public int CurrentCourseId { get; set; }
        public void SetCourseDetails(int courseId)
        {
            CurrentCourseId = courseId;
            GenerateDynamicUserControl();
            GenerateDynamicUserControl2();
            GenerateDynamicUserControl3();  
        }


        private int _courseId;

        [Category("Custom Props")]
        public int CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }

        private string _title;
        private string _description;
        private Image _icon;
        private string _iconPath;

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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Font = new Font("Century Gothic", 9, FontStyle.Bold | FontStyle.Underline);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new Font("Century Gothic", 9, FontStyle.Regular | FontStyle.Underline);
        }

        private void GenerateDynamicUserControl()
        {
            flowLayoutPanel1.Controls.Clear();

            HomeHelper theoryHelper = new HomeHelper();
            List<HomeHelper.Theory> theories = theoryHelper.GetTheories();

            foreach (HomeHelper.Theory theory in theories)
            {
                if (theory.CourseId == CurrentCourseId)
                {
                    UC_Course_Theory theoryControl = new UC_Course_Theory();
                    theoryControl.Title = theory.Title;
                    theoryControl.Description = theory.Description;
                    theoryControl.CourseId = theory.CourseId;

                    flowLayoutPanel1.Controls.Add(theoryControl);
                    //theoryControl.Click += new EventHandler(this.UC_Home_Course_Click);

                }
            }
        }

        private void GenerateDynamicUserControl2()
        {
            flowLayoutPanel2.Controls.Clear();
            HomeHelper commentHelper = new HomeHelper();
            List<HomeHelper.Comment> comments = commentHelper.GetComments();

            foreach (HomeHelper.Comment comment in comments)
            {
                if (comment.CourseId == CurrentCourseId)
                {
                    UC_Course_Comment commentControl = new UC_Course_Comment();

                    // Получить username для текущего пользователя
                    USER userHelper = new USER();
                    string username = userHelper.getUsernameById(comment.UserId);

                    // Установить username для комментария
                    commentControl.Username = username;
                    commentControl.Description = comment.Description;
                    commentControl.CourseId = comment.CourseId;

                    flowLayoutPanel2.Controls.Add(commentControl);
                }
            }
        }


        private void GenerateDynamicUserControl3()
        {
            flowLayoutPanel3.Controls.Clear();

            HomeHelper projectHelper = new HomeHelper();
            List<HomeHelper.Project> projects = projectHelper.GetProjects();

            foreach (HomeHelper.Project project in projects)
            {
                if (project.CourseId == CurrentCourseId)  // Проверяем, соответствует ли ID курса текущему
                {
                    UC_Course_Project projectControl = new UC_Course_Project();
                    projectControl.Title = project.Title;
                    projectControl.Description = project.Description;
                    projectControl.CourseId = project.CourseId;

                    flowLayoutPanel3.Controls.Add(projectControl);
                }
            }
        }
        

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel3.Visible = true;
            flowLayoutPanel3.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel3.Visible = false;
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Text = "Пройден";
            UpdateCourseProgress(true);
        }

        private void guna2Button1_DoubleClick(object sender, EventArgs e)
        {
            guna2Button1.Checked = false;
            guna2Button1.Text = "Не пройден";
            UpdateCourseProgress(false);
        }

        private int GetCurrentUserId()
        {
            return Globals.GlobalUserId;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string commentText = commentTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(commentText))
            {
                UC_Course_Comment commentControl = new UC_Course_Comment();
                commentControl.Description = commentText;
                commentControl.CourseId = CurrentCourseId;

                // Получить идентификатор текущего пользователя
                int userId = GetCurrentUserId();

                // Получить username для текущего пользователя
                USER userHelper = new USER();
                string username = userHelper.getUsernameById(userId);

                // Установить username для комментария
                commentControl.Username = username;

                flowLayoutPanel2.Controls.Add(commentControl);
                commentTextBox.Clear();

                HomeHelper commentHelper = new HomeHelper();
                commentHelper.AddComment(commentControl.CourseId, commentControl.Description, userId);
            }
        }

        private void UpdateCourseProgress(bool completed)
        {
            int userId = GetCurrentUserId();
            HomeHelper homeHelper = new HomeHelper();
            DateTime completedAt = DateTime.Now;

            UserCourseProgress userCourseProgress = homeHelper.GetUserCourseProgress(userId, CurrentCourseId);
            if (userCourseProgress == null)
            {
                homeHelper.AddUserCourseProgress(userId, CurrentCourseId, completed, completedAt);
            }
            else
            {
                homeHelper.UpdateUserCourseProgress(userId, CurrentCourseId, completed, completedAt);
            }
        }





    }
}
