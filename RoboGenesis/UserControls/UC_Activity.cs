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
using static OutlookDemo.HomeHelper;

namespace OutlookDemo.UserControls
{
    public partial class UC_Activity : UserControl
    {
   
        public UC_Activity()
        {
            InitializeComponent();
            GenerateDynamicUserControl();
           
        }

        private void UС_User_Panel1_ProfileButtonClicked (object sender, EventArgs e)
        {
            

        }
        public void ShowForm3()
        {
            //uC_NoAuth_Form1.Visible = true;
        }


        private void GenerateDynamicUserControl()
        {
            flowLayoutPanel1.Controls.Clear();

            TestHelper testHelper = new TestHelper();
            List<TestHelper.Test> tests = testHelper.GetTests();

            foreach (TestHelper.Test test in tests)
            {
                UC_Activity_Test_Example testControl = new UC_Activity_Test_Example();
                testControl.Title = test.Title;
                testControl.Description = test.Description;
                testControl.Questions = test.Questions;
                testControl.IconPath = test.IconPath;
                testControl.IconBackground = System.Drawing.Color.FromArgb(224, 224, 224);
                testControl.TestId = test.Id;

                flowLayoutPanel1.Controls.Add(testControl);
                testControl.Click += new EventHandler(this.UC_Activity_Test_Example_Click);
            }
        }

        private void UC_Activity_Test_Example_Click(object sender, EventArgs e)
        {
            UC_Activity_Test_Example selectedTest = (UC_Activity_Test_Example)sender;
            UC_Activity_Test_Details uC_Activity_Test_Details = new UC_Activity_Test_Details();
            uC_Activity_Test_Details.Title = selectedTest.Title;
            uC_Activity_Test_Details.Description = selectedTest.Description;
            uC_Activity_Test_Details.Questions = selectedTest.Questions;
            uC_Activity_Test_Details.IconPath = selectedTest.IconPath;
            uC_Activity_Test_Details.SetTestDetails(selectedTest.TestId);

            this.Controls.Add(uC_Activity_Test_Details);

            uC_Activity_Test_Details.BringToFront();
        }

        private List<UC_Activity_Test_Example> FindMatchingElements(string searchText)
        {
            List<UC_Activity_Test_Example> matchingElements = new List<UC_Activity_Test_Example>();

            foreach (UC_Activity_Test_Example control in flowLayoutPanel1.Controls)
            {
                if (control.Title.ToLower().Contains(searchText.ToLower()) ||
                    control.Description.ToLower().Contains(searchText.ToLower()) ||
                    control.Questions.ToLower().Contains(searchText.ToLower()))
                {
                    matchingElements.Add(control);
                }
            }

            return matchingElements;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                guna2TextBox1.IconLeft = Properties.Resources.table_search1;
                // Показать все элементы управления
                foreach (UC_Activity_Test_Example control in flowLayoutPanel1.Controls)
                {
                    control.Visible = true;
                }
            }
            else
            {
                guna2TextBox1.IconLeft = Properties.Resources.table_search2;
                // Скрыть все элементы управления
                foreach (UC_Activity_Test_Example control in flowLayoutPanel1.Controls)
                {
                    control.Visible = false;
                }

                // Найти и показать соответствующие элементы управления
                List<UC_Activity_Test_Example> matchingElements = FindMatchingElements(guna2TextBox1.Text);
                foreach (UC_Activity_Test_Example control in matchingElements)
                {
                    control.Visible = true;
                }
            }
        }


        private List<UC_Activity_Event_Example> LoadEventsForDate(DateTime date)
        {
            List<UC_Activity_Event_Example> eventControls = new List<UC_Activity_Event_Example>();

            EVENT eventHelper = new EVENT();
            List<EVENT.Event> events = eventHelper.GetEventsForDate(date);

            foreach (EVENT.Event evt in events)
            {
                UC_Activity_Event_Example eventControl = new UC_Activity_Event_Example();
                eventControl.Title = evt.Title;
                eventControl.Description = evt.Description;
                eventControl.PicturePath = evt.PicturePath;
                eventControl.StartTime = evt.StartTime;
                eventControl.EndTime = evt.EndTime;
                eventControls.Add(eventControl);
            }

            return eventControls;
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Получить выбранную дату
            DateTime selectedDate = guna2DateTimePicker1.Value.Date;

            // Загрузить события для выбранной даты
            List<UC_Activity_Event_Example> events = LoadEventsForDate(selectedDate);

            // Очистить flowLayoutPanel2
            flowLayoutPanel2.Controls.Clear();

            // Добавить новые элементы UC_Activity_Event_Example
            foreach (UC_Activity_Event_Example eventControl in events)
            {
                flowLayoutPanel2.Controls.Add(eventControl);
            }
        }

        private void UC_Activity_Load(object sender, EventArgs e)
        {
          
        }
    }
}
