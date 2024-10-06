using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Devices;
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
using static RoboGenesis.BookHelper;

namespace RoboGenesis.UserControls
{
    public partial class UC_Shelf : UserControl
    {


        public UC_Shelf()
        {
            InitializeComponent();
            GenerateDynamicUserControl();
            GenerateDynamicUserControl2();
            GenerateDynamicUserControl3();
           
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                guna2TextBox1.IconLeft = Properties.Resources.table_search1;
            }
            else
            {
                guna2TextBox1.IconLeft = Properties.Resources.table_search2;
            }
        }

        private void UC_Shelf_Load(object sender, EventArgs e)
        {

        }

        private void GenerateDynamicUserControl()
        {
            flowLayoutPanel1.Controls.Clear();

            BookHelper bookHelper = new BookHelper();
            List<BookHelper.Book> books = bookHelper.GetBooks();

            foreach (BookHelper.Book book in books)
            {
                UC_Book_Example bookControl = new UC_Book_Example();
                bookControl.Title = book.Title;
                bookControl.Description = book.Description;
                bookControl.DescriptionAbout = book.DescriptionAbout;
                bookControl.IconPath = book.IconPath;
                bookControl.FilePath = book.FilePath;
                if (!string.IsNullOrEmpty(book.IconPath))
                {
                    bookControl.Icon = Image.FromFile(book.IconPath);
                }

                bookControl.IconBackground = System.Drawing.Color.FromArgb(224, 224, 224);

                flowLayoutPanel1.Controls.Add(bookControl);
                bookControl.Click += new EventHandler(this.UC_Book_Example_Click);
            }

        }

        private void GenerateDynamicUserControl2()
        {
            flowLayoutPanel2.Controls.Clear();

            BookHelper articleHelper = new BookHelper();
            List<BookHelper.Article> articles = articleHelper.GetArticles();

            foreach (BookHelper.Article article in articles)
            {
                UC_Article_Example articleControl = new UC_Article_Example();
                articleControl.Title = article.Title;
                articleControl.Description = article.Description;
                articleControl.DescriptionAbout = article.DescriptionAbout;
                articleControl.IconPath = article.IconPath;
                articleControl.FilePath = article.FilePath;
                if (!string.IsNullOrEmpty(article.IconPath))
                {
                    articleControl.Icon = Image.FromFile(article.IconPath);
                }
                articleControl.IconBackground = System.Drawing.Color.FromArgb(224, 224, 224);

                flowLayoutPanel2.Controls.Add(articleControl);
                articleControl.Click += new EventHandler(this.UC_Article_Example_Click);
            }
        }


        private void GenerateDynamicUserControl3()
        {
            flowLayoutPanel3.Controls.Clear();

            BookHelper videoHelper = new BookHelper();
            List<BookHelper.Video> videos = videoHelper.GetVideo();

            foreach (BookHelper.Video video in videos)
            {
                UC_Video_Example videoControl = new UC_Video_Example();
                videoControl.Title = video.Title;
                videoControl.Description = video.Description;
                videoControl.DescriptionAbout = video.DescriptionAbout;
                videoControl.IconPath = video.IconPath;
                videoControl.FilePath = video.FilePath;
                if (!string.IsNullOrEmpty(video.IconPath))
                {
                    videoControl.Icon = Image.FromFile(video.IconPath);
                }
                videoControl.IconBackground = System.Drawing.Color.FromArgb(224, 224, 224);

                flowLayoutPanel3.Controls.Add(videoControl);
                videoControl.Click += new EventHandler(this.UC_Video_Example_Click);


            }
        }

        private List<UC_Book_Example> FindMatchingBookElements(string searchText)
        {
            List<UC_Book_Example> matchingElements = new List<UC_Book_Example>();

            foreach (UC_Book_Example control in flowLayoutPanel1.Controls)
            {
                if (control.Title.ToLower().Contains(searchText.ToLower()) ||
                    control.Description.ToLower().Contains(searchText.ToLower()))
                {
                    matchingElements.Add(control);
                }
            }

            return matchingElements;
        }

        private List<UC_Article_Example> FindMatchingArticleElements(string searchText)
        {
            List<UC_Article_Example> matchingElements = new List<UC_Article_Example>();

            foreach (UC_Article_Example control in flowLayoutPanel2.Controls)
            {
                if (control.Title.ToLower().Contains(searchText.ToLower()) ||
                    control.Description.ToLower().Contains(searchText.ToLower()))
                {
                    matchingElements.Add(control);
                }
            }

            return matchingElements;
        }

        private List<UC_Video_Example> FindMatchingVideoElements(string searchText)
        {
            List<UC_Video_Example> matchingElements = new List<UC_Video_Example>();

            foreach (UC_Video_Example control in flowLayoutPanel3.Controls)
            {
                if (control.Title.ToLower().Contains(searchText.ToLower()) ||
                    control.Description.ToLower().Contains(searchText.ToLower()))
                {
                    matchingElements.Add(control);
                }
            }

            return matchingElements;
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                guna2TextBox1.IconLeft = Properties.Resources.table_search1;
                // Показать все элементы управления в flowLayoutPanel1
                foreach (UC_Book_Example control in flowLayoutPanel1.Controls)
                {
                    control.Visible = true;
                }
                // Показать все элементы управления в flowLayoutPanel2
                foreach (UC_Article_Example control in flowLayoutPanel2.Controls)
                {
                    control.Visible = true;
                }
                // Показать все элементы управления в flowLayoutPanel3
                foreach (UC_Video_Example control in flowLayoutPanel3.Controls)
                {
                    control.Visible = true;
                }
            }
            else
            {
                guna2TextBox1.IconLeft = Properties.Resources.table_search2;
                // Скрыть все элементы управления в flowLayoutPanel1
                foreach (UC_Book_Example control in flowLayoutPanel1.Controls)
                {
                    control.Visible = false;
                }
                // Скрыть все элементы управления в flowLayoutPanel2
                foreach (UC_Article_Example control in flowLayoutPanel2.Controls)
                {
                    control.Visible = false;
                }
                // Скрыть все элементы управления в flowLayoutPanel3
                foreach (UC_Video_Example control in flowLayoutPanel3.Controls)
                {
                    control.Visible = false;
                }

                // Найти и показать соответствующие элементы управления в flowLayoutPanel1
                List<UC_Book_Example> matchingBookElements = FindMatchingBookElements(guna2TextBox1.Text);
                foreach (UC_Book_Example control in matchingBookElements)
                {
                    control.Visible = true;
                }

                // Найти и показать соответствующие элементы управления в flowLayoutPanel2
                List<UC_Article_Example> matchingArticleElements = FindMatchingArticleElements(guna2TextBox1.Text);
                foreach (UC_Article_Example control in matchingArticleElements)
                {
                    control.Visible = true;
                }

                // Найти и показать соответствующие элементы управления в flowLayoutPanel3
                List<UC_Video_Example> matchingVideoElements = FindMatchingVideoElements(guna2TextBox1.Text);
                foreach (UC_Video_Example control in matchingVideoElements)
                {
                    control.Visible = true;
                }
            }
        }

        void UC_Book_Example_Click(object sender, EventArgs e)
        {
            UC_Book_Example obj = (UC_Book_Example)sender;

            pbIcon.Image = obj.Icon;
            
            lblTitle.Text = obj.Title;
            lblContent.Text = "Автор: " + obj.Description;
            lblDescriptionAbout.Text = obj.DescriptionAbout;
            

        }

        void UC_Article_Example_Click(object sender, EventArgs e)
        {
            UC_Article_Example obj = (UC_Article_Example)sender;

            pbIcon.Image = obj.Icon;
            lblTitle.Text = obj.Title;
            lblContent.Text = "Автор: " + obj.Description;
            lblDescriptionAbout.Text = obj.DescriptionAbout;
        }

        void UC_Video_Example_Click(object sender, EventArgs e)
        {
            UC_Video_Example obj = (UC_Video_Example)sender;

            pbIcon.Image = obj.Icon;
            lblTitle.Text = obj.Title;
            lblContent.Text = "Автор: " + obj.Description;
            lblDescriptionAbout.Text = obj.DescriptionAbout;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Visible = false;
            flowLayoutPanel3.Visible = false;
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel1.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel3.Visible = false;
            flowLayoutPanel2.Visible = true;
            flowLayoutPanel2.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = false;
            flowLayoutPanel3.Visible = true;
            flowLayoutPanel3.BringToFront();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;

            // Определите, какой пользовательский элемент управления вызвал событие
            if (flowLayoutPanel1.Visible)
            {
                UC_Book_Example bookControl = flowLayoutPanel1.Controls.OfType<UC_Book_Example>().FirstOrDefault(control => control.Visible);
                if (bookControl != null)
                {
                    filePath = bookControl.FilePath;
                }
            }
            else if (flowLayoutPanel2.Visible)
            {
                UC_Article_Example articleControl = flowLayoutPanel2.Controls.OfType<UC_Article_Example>().FirstOrDefault(control => control.Visible);
                if (articleControl != null)
                {
                    filePath = articleControl.FilePath;
                }
            }
            else if (flowLayoutPanel3.Visible)
            {
                UC_Video_Example videoControl = flowLayoutPanel3.Controls.OfType<UC_Video_Example>().FirstOrDefault(control => control.Visible);
                if (videoControl != null)
                {
                    filePath = videoControl.FilePath;
                }
            }

            // Проверьте, есть ли путь к файлу, и откройте файл, если он существует
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                try
                {
                    System.Diagnostics.Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось открыть файл. Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
  
