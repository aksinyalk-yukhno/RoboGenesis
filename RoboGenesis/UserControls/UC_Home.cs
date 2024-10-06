using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static RoboGenesis.HomeHelper;

namespace RoboGenesis.UserControls
{
    public partial class UC_Home : UserControl
    {
        public event EventHandler<UC_Home_Course_Details> Course_Clicked;
        public UC_InboxAuthorization authControl;
        public uС_InboxRegister1 regControl;
        private UC_Inbox2 inboxForm;

        public UC_Home()
        {
            InitializeComponent();
            GenerateDynamicUserControl();
            GenerateDynamicUserControl2();
            GenerateDynamicUserControl3();
            
        }
        

        private void GenerateDynamicUserControl()
        {
            flowLayoutPanel1.Controls.Clear();

            HomeHelper homeHelper = new HomeHelper();
            List<HomeHelper.Course> courses = homeHelper.GetCourses();

            foreach (HomeHelper.Course course in courses)
            {
                UC_Home_Course courseControl = new UC_Home_Course();
                courseControl.Title = course.Title;
                courseControl.Description = course.Description;
                courseControl.IconPath = course.IconPath;
                courseControl.CourseId = course.Id;

                int enrollmentCount = homeHelper.GetEnrollmentCount(course.Id);
                courseControl.EnrollmentCount = enrollmentCount;

                int CommentCount = homeHelper.GetCommentCount(course.Id);
                courseControl.CommentCount = CommentCount;


                flowLayoutPanel1.Controls.Add(courseControl);
                courseControl.Click += new EventHandler(this.UC_Home_Course_Click);
            }
        }

        private void UC_Home_Course_Click(object sender, EventArgs e)
        {
            
            UC_Home_Course selectedCourse = (UC_Home_Course)sender;
            UC_Home_Course_Details uC_Home_Course_Details = new UC_Home_Course_Details();
            uC_Home_Course_Details.Title = selectedCourse.Title;
            uC_Home_Course_Details.Description = selectedCourse.Description;
            uC_Home_Course_Details.IconPath = selectedCourse.IconPath;
            uC_Home_Course_Details.SetCourseDetails(selectedCourse.CourseId);

            this.Controls.Add(uC_Home_Course_Details);
           
            uC_Home_Course_Details.BringToFront();

        }

        private void GenerateDynamicUserControl2()
        {
            flowLayoutPanel2.Controls.Clear();

            HomeHelper challengeHelper = new HomeHelper();
            List<Challenge> challenges = challengeHelper.GetChallengesWithCategories();
            List<int> completedChallenges = challengeHelper.GetCompletedChallengesForUser(Globals.GlobalUserId);

            foreach (HomeHelper.Challenge challenge in challenges)
            {

                UC_Home_Challenge challengeControl = new UC_Home_Challenge();
                challengeControl.ChallengeId = challenge.Id;
                challengeControl.Title = challenge.Title;
                challengeControl.Description = challenge.Description;
                challengeControl.IconPath = challenge.IconPath;
                bool isCompleted = completedChallenges.Contains(challenge.Id);

                challengeControl.ChallengeButton.Checked = isCompleted;
                challengeControl.ChallengeButton.Text = isCompleted ? "Вы уже участвуете" : "Участвовать";

                flowLayoutPanel2.Controls.Add(challengeControl);
            }
        }

        private void GenerateDynamicUserControl3()
        {
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel3.Padding = new Padding(0, 0, 0, 0);

            HomeHelper categoryHelper = new HomeHelper();
            List<HomeHelper.Category> categories = categoryHelper.GetCategories();
            
            foreach (HomeHelper.Category category in categories)
            {
                UC_Home_Category categoryControl = new UC_Home_Category();
                categoryControl.Name = category.Name;
                categoryControl.IconPath = category.IconPath;
                categoryControl.Margin = new Padding(0); // Устанавливаем нулевой отступ для элемента
                flowLayoutPanel3.Controls.Add(categoryControl);
            }
        }

        private List<UC_Home_Course> FindMatchingCourseElements(string searchText)
        {
            List<UC_Home_Course> matchingElements = new List<UC_Home_Course>();

            foreach (UC_Home_Course control in flowLayoutPanel1.Controls)
            {
                if (control.Title.ToLower().Contains(searchText.ToLower()))
                {
                    matchingElements.Add(control);
                }
            }

            return matchingElements;
        }

        private List<UC_Home_Challenge> FindMatchingChallengeElements(string searchText)
        {
            List<UC_Home_Challenge> matchingElements = new List<UC_Home_Challenge>();

            foreach (UC_Home_Challenge control in flowLayoutPanel2.Controls)
            {
                if (control.Title.ToLower().Contains(searchText.ToLower()) ||
                    control.Description.ToLower().Contains(searchText.ToLower()))
                {
                    matchingElements.Add(control);
                }
            }

            return matchingElements;
        }

        private List<UC_Home_Category> FindMatchingCategoryElements(string searchText)
        {
            List<UC_Home_Category> matchingElements = new List<UC_Home_Category>();

            foreach (UC_Home_Category control in flowLayoutPanel3.Controls)
            {
                if (control.Name.ToLower().Contains(searchText.ToLower()))
                {
                    matchingElements.Add(control);
                }
            }

            return matchingElements;
        }


        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                guna2TextBox2.IconLeft = Properties.Resources.table_search1;
                // Показать все элементы управления в flowLayoutPanel1
                foreach (UC_Home_Course control in flowLayoutPanel1.Controls)
                {
                    control.Visible = true;
                }
                // Показать все элементы управления в flowLayoutPanel2
                foreach (UC_Home_Challenge control in flowLayoutPanel2.Controls)
                {
                    control.Visible = true;
                }
                // Показать все элементы управления в flowLayoutPanel3
                foreach (UC_Home_Category control in flowLayoutPanel3.Controls)
                {
                    control.Visible = true;
                }
            }
            else
            {
                guna2TextBox2.IconLeft = Properties.Resources.table_search2;
                // Скрыть все элементы управления в flowLayoutPanel1
                foreach (UC_Home_Course control in flowLayoutPanel1.Controls)
                {
                    control.Visible = false;
                }
                // Скрыть все элементы управления в flowLayoutPanel2
                foreach (UC_Home_Challenge control in flowLayoutPanel2.Controls)
                {
                    control.Visible = false;
                }
                // Скрыть все элементы управления в flowLayoutPanel3
                foreach (UC_Home_Category control in flowLayoutPanel3.Controls)
                {
                    control.Visible = false;
                }

                // Найти и показать соответствующие элементы управления в flowLayoutPanel1
                List<UC_Home_Course> matchingCourseElements = FindMatchingCourseElements(guna2TextBox2.Text);
                foreach (UC_Home_Course control in matchingCourseElements)
                {
                    control.Visible = true;
                }

                // Найти и показать соответствующие элементы управления в flowLayoutPanel2
                List<UC_Home_Challenge> matchingChallengeElements = FindMatchingChallengeElements(guna2TextBox2.Text);
                foreach (UC_Home_Challenge control in matchingChallengeElements)
                {
                    control.Visible = true;
                }

                // Найти и показать соответствующие элементы управления в flowLayoutPanel3
                List<UC_Home_Category> matchingCategoryElements = FindMatchingCategoryElements(guna2TextBox2.Text);
                foreach (UC_Home_Category control in matchingCategoryElements)
                {
                    control.Visible = true;
                }
            }
        }

    }
}
