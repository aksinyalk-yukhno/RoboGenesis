using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OutlookDemo.HomeHelper;

namespace OutlookDemo
{
    internal class HomeHelper
    {
        private MY_DB db = new MY_DB();

        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();

            string query = "SELECT * FROM courses";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Course course = new Course
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    IconPath = row["icon"].ToString()
                };

                courses.Add(course);
            }

            return courses;
        }

        public List<Challenge> GetChallenges()
        {
            List<Challenge> challenges = new List<Challenge>();

            string query = "SELECT * FROM challenges";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Challenge challenge = new Challenge
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    IconPath = row["icon"].ToString() // Получаем путь к картинке из базы данных
                };

                challenges.Add(challenge);
            }

            return challenges;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            string query = "SELECT * FROM categories";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                Category category = new Category
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    IconPath = row["icon"].ToString()
                };
                categories.Add(category);
            }
            return categories;
        }

        public List<Challenge> GetChallengesWithCategories()
        {
            List<Challenge> challenges = new List<Challenge>();
            string query = @"SELECT c.id, c.title, c.description, c.icon, 
                     GROUP_CONCAT(cat.name) AS categories
                     FROM challenges c
                     LEFT JOIN challenge_categories cc ON c.id = cc.challenge_id
                     LEFT JOIN categories cat ON cc.category_id = cat.id
                     GROUP BY c.id, c.title, c.description, c.icon";

            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Challenge challenge = new Challenge
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    IconPath = row["icon"].ToString(),
                    Categories = row["categories"].ToString().Split(',').Select(name => new Category { Name = name.Trim() }).ToList()
                };

                challenges.Add(challenge);
            }

            return challenges;
        }

        public List<Theory> GetTheories()
        {
            List<Theory> theories = new List<Theory>();

            string query = "SELECT * FROM theories";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Theory theory = new Theory
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    CourseId = Convert.ToInt32(row["course_id"]),
                    Description = row["description"].ToString(),
                };

                theories.Add(theory);
            }

            return theories;
        }

        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();

            string query = "SELECT * FROM projects";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Project project = new Project
                {
                    Id = Convert.ToInt32(row["id"]),
                    CourseId = Convert.ToInt32(row["course_id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                };

                projects.Add(project);
            }

            return projects;
        }

        public List<Comment> GetComments()
        {
            List<Comment> comments = new List<Comment>();

            string query = "SELECT * FROM comments";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Comment comment = new Comment
                {
                    Id = Convert.ToInt32(row["id"]),
                    CourseId = Convert.ToInt32(row["course_id"]),
                    UserId = Convert.ToInt32(row["user_id"]),
                    Description = row["description"].ToString(),
                };

                comments.Add(comment);
            }

            return comments;
        }

        public bool AddComment(int courseId, string description, int userId)
        {
            DateTime created_at = DateTime.Now;
            try
            {
                string query = "INSERT INTO comments (course_id, description, user_id, created_at) VALUES (@courseId, @description, @userId, @created_at)";
                MySqlCommand command = new MySqlCommand(query, db.getConnection);
                command.Parameters.AddWithValue("@courseId", courseId);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@created_at", created_at);
                db.openConnection();
                int rowsAffected = command.ExecuteNonQuery();
                db.closeConnection();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении комментария: " + ex.Message);
                return false;
            }
        }

        public UserCourseProgress GetUserCourseProgress(int userId, int courseId)
        {
            string query = "SELECT * FROM user_course_progress WHERE user_id = @userId AND course_id = @courseId";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@courseId", courseId);

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            UserCourseProgress userCourseProgress = null;
            if (reader.Read())
            {
                userCourseProgress = new UserCourseProgress
                {
                    Id = Convert.ToInt32(reader["id"]),
                    UserId = userId,
                    CourseId = courseId,
                    Completed = Convert.ToBoolean(reader["completed"])
                };
            }

            reader.Close();
            db.closeConnection();

            return userCourseProgress;
        }

        public bool UpdateUserCourseProgress(int userId, int courseId, bool completed, DateTime completed_at)
        {
            string query = "UPDATE user_course_progress SET completed = @completed, completed_at = @completed_at WHERE user_id = @userId AND course_id = @courseId";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@completed", completed);
            command.Parameters.AddWithValue("@completed_at", completed_at);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@courseId", courseId);

            db.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            db.closeConnection();

            return rowsAffected > 0;
        }


        public bool AddUserCourseProgress(int userId, int courseId, bool completed, DateTime completed_at)
        {
            string query = "INSERT INTO user_course_progress (user_id, course_id, completed, completed_at) VALUES (@userId, @courseId, @completed, @completed_at)";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@courseId", courseId);
            command.Parameters.AddWithValue("@completed", completed);
            command.Parameters.AddWithValue("@completed_at", completed_at);

            db.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            db.closeConnection();

            return rowsAffected > 0;
        }


        public int GetEnrollmentCount(int courseId)
        {
            string query = "SELECT COUNT(*) FROM user_course_progress WHERE course_id = @courseId AND completed = true";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@courseId", courseId);

            db.openConnection();
            int enrollmentCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return enrollmentCount;
        }

        public int GetCommentCount(int courseId)
        {
            string query = "SELECT COUNT(*) FROM comments WHERE course_id = @courseId";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@courseId", courseId);

            db.openConnection();
            int commentCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return commentCount;
        }

        public int GetCompletedCoursesCount(int userId)
        {
            string query = "SELECT COUNT(DISTINCT course_id) FROM user_course_progress WHERE user_id = @userId";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);

            db.openConnection();
            int completedCoursesCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return completedCoursesCount;
        }

        public bool AddUserChallengeProgress(int userId, int challengeId, bool completed, DateTime completed_at)
        {
            string query = "INSERT INTO user_challenge_progress (user_id, challenge_id, completed, completed_at) VALUES (@userId, @challengeId, @completed, @completed_at)";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@challengeId", challengeId);
            command.Parameters.AddWithValue("@completed", completed);
            command.Parameters.AddWithValue("@completed_at", completed_at);

            db.openConnection();
            int rowsAffected = command.ExecuteNonQuery();
            db.closeConnection();

            return rowsAffected > 0;
        }

        public int GetCompletedChallengesCount(int userId)
        {
            string query = "SELECT COUNT(DISTINCT challenge_id) FROM user_challenge_progress WHERE user_id = @userId AND completed = true";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);

            db.openConnection();
            int completedChallengesCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return completedChallengesCount;
        }

        public List<int> GetCompletedChallengesForUser(int userId)
        {
            List<int> completedChallenges = new List<int>();
            string query = "SELECT challenge_id FROM user_challenge_progress WHERE user_id = @userId AND completed = true";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int challengeId = Convert.ToInt32(reader["challenge_id"]);
                completedChallenges.Add(challengeId);
            }

            reader.Close();
            db.closeConnection();

            return completedChallenges;
        }

        public int GetTotalCommentsForUser(int userId)
        {
            string query = "SELECT COUNT(*) FROM comments WHERE user_id = @userId";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);

            db.openConnection();
            int totalComments = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return totalComments;
        }


        public int GetCommentCountForDate(int userId, DateTime date)
        {
            string query = "SELECT COUNT(*) FROM comments WHERE user_id = @userId AND DATE(created_at) = @date";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@date", date.Date);

            db.openConnection();
            int commentCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return commentCount;
        }

        public int GetCompletedCoursesCountForDate(int userId, DateTime date)
        {
            string query = "SELECT COUNT(DISTINCT course_id) FROM user_course_progress WHERE user_id = @userId AND DATE(completed_at) = @date";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@date", date.Date);

            db.openConnection();
            int completedCoursesCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();

            return completedCoursesCount;
        }

        public int GetCompletedChallengesCountForDate(int userId, DateTime date)
        {
            string query = "SELECT COUNT(DISTINCT challenge_id) FROM user_challenge_progress WHERE user_id = @userId AND DATE(created_at) = @date AND completed = true";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@date", date.Date);

            db.openConnection();
            int completedChallengesCount = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();
            return completedChallengesCount;
        }

        public class Course
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string IconPath { get; set; }
        }
        public class Challenge
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string IconPath { get; set; }
            public List<Category> Categories { get; set; }
        }

        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string IconPath { get; set; }
        }

        public class Theory
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int CourseId { get; set; }
            public string Description { get; set; }
            
        }

        public class Project
        {
            public int Id { get; set; }
            public int CourseId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }

        }

        public class Comment
        {
            public int Id { get; set; }
            public int CourseId { get; set; }
            public int UserId { get; set; }
            public DateTime Created_At { get; set; }
            public string Description { get; set; }
            
        }

        public class UserCourseProgress
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int CourseId { get; set; }
            public bool Completed { get; set; }
            public DateTime Completed_At { get; set; }
        }
    }
}
