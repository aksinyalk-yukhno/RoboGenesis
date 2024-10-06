using Guna.UI2.WinForms;
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
using MySql.Data.MySqlClient;
using static OutlookDemo.TestHelper;
using System.Windows.Forms.DataVisualization.Charting;

namespace OutlookDemo.UserControls
{

    public partial class UC_Inbox2 : UserControl
    {

        public UC_Inbox2()
        {
            InitializeComponent();
        }       

        MY_DB mydb = new MY_DB();
        private HomeHelper homeHelper = new HomeHelper();
        private ProductHelper productHelper = new ProductHelper();
        private TestHelper testHelper = new TestHelper();
        USER userHelper = new USER();

        public void getStats()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT COUNT(DISTINCT course_id) FROM user_course_progress WHERE user_id = @uid", mydb.getConnection);
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = Globals.GlobalUserId;

            int completedChallengesCount = homeHelper.GetCompletedChallengesCount(Globals.GlobalUserId);
            int completedTestsCount = testHelper.GetCompletedTestsCount(Globals.GlobalUserId); // Новая строка
            int orderCount = productHelper.GetOrderCount(Globals.GlobalUserId);
            int totalComments = homeHelper.GetTotalCommentsForUser(Globals.GlobalUserId);
            
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                uC_Profile_Stats_Reg.StatNumber = userHelper.getRegDateById(Globals.GlobalUserId);
                uC_Profile_Stats_Challenge.StatNumber = completedChallengesCount.ToString();
                uC_Profile_Stats_Test.StatNumber = completedTestsCount.ToString();
                uC_Profile_Stats_Product.StatNumber = orderCount.ToString();
                guna2ProgressIndicator1.NumberOfCircles = totalComments;
                lblCommentCount.Text = totalComments.ToString();
                guna2ProgressIndicator2.NumberOfCircles = Convert.ToInt32(table.Rows[0]["COUNT(DISTINCT course_id)"].ToString());
                lblCourseCount.Text = table.Rows[0]["COUNT(DISTINCT course_id)"].ToString();

                double averageCorrectRatio = GetAverageCorrectAnswerRatio(Globals.GlobalUserId);
                guna2CircleProgressBar1.Value = (int)(averageCorrectRatio * 100);
                lblAnswerRatio.Text = String.Format("{0:0}%", averageCorrectRatio * 100);

                Dictionary<DateTime, decimal> orderTotals = productHelper.GetOrderTotalsByDate(Globals.GlobalUserId);

                DataTable chartData = new DataTable();
                chartData.Columns.Add("Date", typeof(DateTime));
                chartData.Columns.Add("Total Amount", typeof(decimal));

                foreach (var kvp in orderTotals)
                {
                    chartData.Rows.Add(kvp.Key, kvp.Value);
                }
                
                chart2.DataSource = chartData;
                chart2.Series["Series1"].XValueMember = "Date";
                chart2.Series["Series1"].YValueMembers = "Total Amount";
                chart2.Series["Series1"].ChartType = SeriesChartType.Column;
            }
        }

        private void PopulateUserStatsChart()
        {
            DataTable chartData = new DataTable();
            chartData.Columns.Add("StatsType", typeof(string));
            chartData.Columns.Add("Count", typeof(int));

            // Get the total count for each user stat
            int commentCount = homeHelper.GetTotalCommentsForUser(Globals.GlobalUserId);
            int completedCoursesCount = homeHelper.GetCompletedCoursesCount(Globals.GlobalUserId);
            int completedChallengesCount = homeHelper.GetCompletedChallengesCount(Globals.GlobalUserId);
            int orderCount = productHelper.GetOrderCount(Globals.GlobalUserId);
            int completedTestsCount = testHelper.GetCompletedTestsCount(Globals.GlobalUserId);

            // Add the data to the DataTable
            chartData.Rows.Add("Комменты", commentCount);
            chartData.Rows.Add("Курсы", completedCoursesCount);
            chartData.Rows.Add("Челленджи", completedChallengesCount);
            chartData.Rows.Add("Заказы", orderCount);
            chartData.Rows.Add("Тесты", completedTestsCount);

            // Bind the DataTable to the chart
            chart1.DataSource = chartData;
            chart1.Series["Series1"].XValueMember = "StatsType";
            chart1.Series["Series1"].YValueMembers = "Count";
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
        }
        

        private class UserStats
        {
            public int CommentCount { get; set; }
            public int CompletedCoursesCount { get; set; }
            public int CompletedChallengesCount { get; set; }
            public int OrderCount { get; set; }
            public int CompletedTestsCount { get; set; }
        }
        
        private double GetAverageCorrectAnswerRatio(int userId)
        {
            List<TestStatistics> testResults = testHelper.GetAllTestResultsForUser(userId);
            if (testResults.Count == 0)
                return 0;

            int totalCorrectAnswers = 0;
            int totalQuestions = 0;

            foreach (TestStatistics result in testResults)
            {
                totalCorrectAnswers += result.CorrectAnswers;
                totalQuestions += result.CorrectAnswers + result.IncorrectAnswers;
            }

            double averageCorrectRatio = (double)totalCorrectAnswers / totalQuestions;
            return averageCorrectRatio;
        }

        public void getImageAndUsername()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `id`=@uid", mydb.getConnection);
            command.Parameters.Add("@uid",MySqlDbType.Int32).Value = Globals.GlobalUserId;
        
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0 )
            {
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxProfileImage.Image = Image.FromStream(picture);
                label3.Text = "@" + table.Rows[0]["username"];
                label14.Text = "" + table.Rows[0]["email"];
            }
        }

        private void UC_Inbox2_Load(object sender, EventArgs e)
        {
            getImageAndUsername();
            getStats();
            PopulateUserStatsChart();

        }

        private void label1_Enter(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.FromArgb(0, 118, 212);
        }

        private void label1_Leave(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.FromArgb(0, 118, 212);
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            label14.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        }

        private void label14_MouseEnter(object sender, EventArgs e)
        {
            label14.ForeColor = System.Drawing.Color.FromArgb(0, 118, 212);
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = System.Drawing.Color.FromArgb(0, 118, 212);
        }

        private void label6_MouseLeave(object sender, EventArgs e) => label6.ForeColor = System.Drawing.Color.Gray;

      
    }
}
