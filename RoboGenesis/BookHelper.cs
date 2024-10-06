using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGenesis
{
    internal class BookHelper
    {
        private MY_DB db = new MY_DB();

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            string query = "SELECT * FROM books";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Book book = new Book
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    DescriptionAbout = row["description_about"].ToString(),
                    FilePath = row["file_path"].ToString(),
                    IconPath = row["icon"].ToString()
                };

                books.Add(book);
            }

            return books;
        }

        public List<Article> GetArticles()
        {
            List<Article> articles = new List<Article>();

            string query = "SELECT * FROM articles";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Article article = new Article
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    DescriptionAbout = row["description_about"].ToString(),
                    FilePath = row["file_path"].ToString(),
                    IconPath = row["icon"].ToString()
                };

                articles.Add(article);
            }

            return articles;
        }

        public List<Video> GetVideo()
        {
            List<Video> videos = new List<Video>();

            string query = "SELECT * FROM videos";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Video video = new Video
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    DescriptionAbout = row["description_about"].ToString(),
                    FilePath = row["file_path"].ToString(),
                    IconPath = row["icon"].ToString() 
                };

                videos.Add(video);
            }

            return videos;
        }


        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string DescriptionAbout { get; set; }
            public string FilePath { get; set; }
            public string IconPath { get; set; }
        }

        public class Article
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string DescriptionAbout { get; set; }
            public string FilePath { get; set; }
            public string IconPath { get; set; }
        }

        public class Video
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string DescriptionAbout { get; set; }
            public string FilePath { get; set; }
            public string IconPath { get; set; }
        }
    }
}
