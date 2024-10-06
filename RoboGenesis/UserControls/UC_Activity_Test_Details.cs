using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RoboGenesis.TestHelper;
using static RoboGenesis.UserControls.UC_Test_Question_Example;

namespace RoboGenesis.UserControls
{
    public partial class UC_Activity_Test_Details : UserControl
    {
        public UC_Activity_Test_Details()
        {
            InitializeComponent();
        }

        private string _title;
        private string _description;
        private string _questions;
        private string _iconPath;
        private TestStatistics testStatistics;

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

        public int CurrentTestId { get; set; }
        public void SetTestDetails(int testId)
        {
            CurrentTestId = testId;
            GenerateDynamicUserControl();
        }


        private int _testId;

        [Category("Custom Props")]
        public int TestId
        {
            get { return _testId; }
            set { _testId = value; }
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

        private int GetCurrentUserId()
        {
            return Globals.GlobalUserId;
        }

        private int currentQuestionIndex = 0;

        private void ShowQuestion(int index)
        {
            for (int i = 0; i < questionControls.Count; i++)
            {
                questionControls[i].Visible = (i == index);
            }
        }

        private List<UC_Test_Question_Example> questionControls = new List<UC_Test_Question_Example>();

        private void bnOption_Click(object sender, EventArgs e)
        {
            currentQuestionIndex++;
            if (currentQuestionIndex >= questionControls.Count)
            {

                return;
            }

            ShowQuestion(currentQuestionIndex);
        }

        private void GenerateDynamicUserControl()
        {
            flowLayoutPanel1.Controls.Clear();
            questionControls.Clear();
            testStatistics = new TestStatistics();

            TestHelper questionHelper = new TestHelper();
            List<TestHelper.Question> questions = questionHelper.GetQuestions();

            foreach (TestHelper.Question question in questions)
            {
                if (question.TestId == CurrentTestId)
                {
                    UC_Test_Question_Example questionControl = new UC_Test_Question_Example();
                    questionControl.TestId = question.TestId;
                    questionControl.Description = question.Description;
                    questionControl.Option1 = question.Option_1;
                    questionControl.Option2 = question.Option_2;
                    questionControl.Option3 = question.Option_3;
                    questionControl.Option4 = question.Option_4;
                    questionControl.CorrectAnswer = question.CorrectAnswer;

                    questionControl.AnswerSelected += QuestionControl_AnswerSelected;


                    flowLayoutPanel1.Controls.Add(questionControl);
                    questionControls.Add(questionControl);
                }
            }

            ShowQuestion(currentQuestionIndex);
        }
        private void QuestionControl_AnswerSelected(object sender, UC_Test_Question_Example.AnswerEventArgs e)
        {
            UC_Test_Question_Example questionControl = (UC_Test_Question_Example)sender;
            int userAnswer = e.SelectedAnswer;

            testStatistics.UserAnswers.Add(userAnswer);

            if (userAnswer == questionControl.CorrectAnswer)
                testStatistics.CorrectAnswers++;
            else
                testStatistics.IncorrectAnswers++;

            currentQuestionIndex++;
            if (currentQuestionIndex >= questionControls.Count)
            {
                // Все вопросы пройдены, показать статистику
                ShowTestStatistics();
                return;
            }

            ShowQuestion(currentQuestionIndex);
        }

        private void ShowTestStatistics()
        {
            int userId = GetCurrentUserId(); // Получение идентификатора текущего пользователя
            new TestHelper().SaveTestResult(userId, CurrentTestId, testStatistics.CorrectAnswers, testStatistics.IncorrectAnswers, testStatistics.UserAnswers);

            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
            LoadTestResultFromDatabase(userId, CurrentTestId);

        }

        private TestHelper testHelper = new TestHelper();

        private void LoadTestResultFromDatabase(int userId, int testId)
        {
            TestStatistics result = testHelper.GetTestResults(userId, testId);
            if (result != null)
            {
                UC_Test_Result resultControl = new UC_Test_Result();
                StringBuilder description = new StringBuilder();

                List<TestHelper.Question> questions = testHelper.GetQuestions().Where(q => q.TestId == testId).ToList();

                // Добавление информации о правильных ответах
                description.AppendLine("Правильные ответы:");
                for (int i = 0; i < questions.Count; i++)
                {
                    if (result.UserAnswers.Count > i && result.UserAnswers[i] == questions[i].CorrectAnswer)
                    {
                        string correctAnswerText = GetAnswerText(questions[i], questions[i].CorrectAnswer);
                        description.AppendLine($"Вопрос {questions[i].Id}: {questions[i].Description}");
                        description.AppendLine($"Правильный ответ: {correctAnswerText}\n");
                    }
                }

                // Добавление информации о неправильных ответах
                description.AppendLine("Неправильные ответы:");
                for (int i = 0; i < questions.Count; i++)
                {
                    if (result.UserAnswers.Count > i && result.UserAnswers[i] != questions[i].CorrectAnswer)
                    {
                        string userAnswerText = GetAnswerText(questions[i], result.UserAnswers[i]);
                        string correctAnswerText = GetAnswerText(questions[i], questions[i].CorrectAnswer);
                        description.AppendLine($"Вопрос {questions[i].Id}: {questions[i].Description}");
                        description.AppendLine($"Ваш ответ: {userAnswerText}");
                        description.AppendLine($"Верный ответ: {correctAnswerText}\n");
                    }
                }

                resultControl.Description = description.ToString();
                resultControl.CorrectNumber = result.CorrectAnswers;
                resultControl.WrongNumber = result.IncorrectAnswers;
                int totalQuestions = result.CorrectAnswers + result.IncorrectAnswers;
                resultControl.PerNumber = (int)Math.Round((result.CorrectAnswers * 100.0 / totalQuestions));

                flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel2.Controls.Add(resultControl);
            }
        }


        private string GetAnswerText(TestHelper.Question question, int answerId)
        {
            switch (answerId)
            {
                case 1:
                    return question.Option_1;
                case 2:
                    return question.Option_2;
                case 3:
                    return question.Option_3;
                case 4:
                    return question.Option_4;
                default:
                    return string.Empty;
            }
        }

    }
}

