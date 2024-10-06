using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookDemo
{
    internal class TestHelper
    {
        private MY_DB db = new MY_DB();

        public List<Test> GetTests()
        {
            List<Test> tests = new List<Test>();

            string query = "SELECT * FROM tests";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Test test = new Test
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    Questions = row["questions"].ToString(),
                    IconPath = row["icon"].ToString() // Получаем путь к картинке из базы данных
                };

                tests.Add(test);
            }

            return tests;
        }

        public List<Question> GetQuestions()
        {
            List<Question> questions = new List<Question>();
            string query = "SELECT * FROM questions";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Question question = new Question
                {
                    Id = Convert.ToInt32(row["id"]),
                    TestId = Convert.ToInt32(row["test_id"]),
                    Description = row["question_text"].ToString(),
                    Option_1 = row["option1"].ToString(),
                    Option_2 = row["option2"].ToString(),
                    Option_3 = row["option3"].ToString(),
                    Option_4 = row["option4"].ToString(),
                    CorrectAnswer = Convert.ToInt32(row["correct_answer"])
                };
                questions.Add(question);
            }

            return questions;
        }

        public void SaveTestResult(int userId, int testId, int correctAnswers, int incorrectAnswers, List<int> userAnswers)
        {
            string userAnswersString = string.Join(",", userAnswers);
            string query = "INSERT INTO test_results (user_id, test_id, correct_answers, incorrect_answers, user_answers) " +
                           "VALUES (@userId, @testId, @correctAnswers, @incorrectAnswers, @userAnswers)";

            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@testId", testId);
            command.Parameters.AddWithValue("@correctAnswers", correctAnswers);
            command.Parameters.AddWithValue("@incorrectAnswers", incorrectAnswers);
            command.Parameters.AddWithValue("@userAnswers", userAnswersString);

            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }

        public TestStatistics GetTestResults(int userId, int testId)
        {
            string query = "SELECT correct_answers, incorrect_answers, user_answers FROM test_results WHERE user_id = @userId AND test_id = @testId ORDER BY created_at DESC LIMIT 1";

            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@testId", testId);

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            TestStatistics result = null;

            if (reader.Read())
            {
                result = new TestStatistics
                {
                    CorrectAnswers = Convert.ToInt32(reader["correct_answers"]),
                    IncorrectAnswers = Convert.ToInt32(reader["incorrect_answers"]),
                    UserAnswers = reader["user_answers"].ToString().Split(',').Select(int.Parse).ToList()
                };
            }

            reader.Close();
            db.closeConnection();

            return result;
        }

        public int GetCompletedTestsCount(int userId)
        {
            string query = "SELECT COUNT(DISTINCT test_id) FROM test_results WHERE user_id = @userId";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);

            db.openConnection();
            int completedTestsCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return completedTestsCount;
        }

        public List<TestStatistics> GetAllTestResultsForUser(int userId)
        {
            List<TestStatistics> results = new List<TestStatistics>();
            string query = "SELECT correct_answers, incorrect_answers, user_answers FROM test_results WHERE user_id = @userId";

            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                TestStatistics result = new TestStatistics
                {
                    CorrectAnswers = Convert.ToInt32(reader["correct_answers"]),
                    IncorrectAnswers = Convert.ToInt32(reader["incorrect_answers"]),
                    UserAnswers = reader["user_answers"].ToString().Split(',').Select(int.Parse).ToList()
                };
                results.Add(result);
            }

            reader.Close();
            db.closeConnection();

            return results;
        }

        public int GetCompletedTestsCountForDate(int userId, DateTime date)
        {
            string query = "SELECT COUNT(DISTINCT test_id) FROM test_results WHERE user_id = @userId AND DATE(created_at) = @date";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@date", date.Date);

            db.openConnection();
            int completedTestsCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return completedTestsCount;
        }

        public class Test
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Questions { get; set; }
            public string IconPath { get; set; }
        }

        public class Question
        {
            public int Id { get; set; }
            public int TestId { get; set; }
            public string Description { get; set; }
            public string Option_1 { get; set; }
            public string Option_2 { get; set; }
            public string Option_3 { get; set; }
            public string Option_4 { get; set; }
            public int CorrectAnswer { get; set; }
        }

        public class TestStatistics
        {
            public int CorrectAnswers { get; set; }
            public int IncorrectAnswers { get; set; }
            public List<int> UserAnswers { get; set; }

            public TestStatistics()
            {
                UserAnswers = new List<int>();
            }
        }
    }
}
