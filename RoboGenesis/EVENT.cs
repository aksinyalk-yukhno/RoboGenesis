using MySql.Data.MySqlClient;
using OutlookDemo.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookDemo
{
    class EVENT
    {
        MY_DB db = new MY_DB();

        public List<Event> GetEventsForDate(DateTime date)
        {
            List<Event> events = new List<Event>();
            string query = "SELECT * FROM events WHERE date = @date";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date.Date;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Event evt = new Event
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    Date = Convert.ToDateTime(row["date"]),
                    StartTime = date.Date + (TimeSpan)row["start_time"],
                    EndTime = date.Date + (TimeSpan)row["end_time"],
                    PicturePath = row["picture"].ToString() // Получаем путь к картинке из базы данных
                };
                events.Add(evt);
            }

            return events;
        }

        // Класс для представления события
        public class Event
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string PicturePath { get; set; }
        }

    }
}
