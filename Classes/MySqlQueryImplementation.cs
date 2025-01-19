using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_zaliczenie2025.Classes.Objects;
using MySql.Data.MySqlClient;
using Task = GUI_zaliczenie2025.Classes.Objects.Task;

namespace GUI_zaliczenie2025.Classes
{
    public class MySqlQueryImplementation
    {

        public static List<Task> TaskQueryImplementation(string commandText)
        {
            List<Objects.Task> Tasks = new List<Objects.Task>();
            MySqlConnection connection  = DatabaseConnection.ConnectionBuilder();

            MySqlCommand command = new MySqlCommand(commandText, connection);
            using (connection)
            {
                connection.Open();
                using (command)
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Tasks.Add(new Classes.Objects.Task
                            {
                                Id = $"{reader["id"].ToString()}",
                                Title = $"{reader["title"].ToString()}",
                                Description = $"{reader["description"].ToString()}",
                                Location = $"{reader["location"].ToString()}",
                                User = $"{reader["_user"].ToString()}",
                                Status = $"{reader["status"].ToString()}",
                                SLA = $"{reader["date_of_sla"].ToString()}",
                                Priorytet = $"{reader["priorytet"].ToString()}",
                                Company = $"{reader["company_name"].ToString()}",
                                TelNumber = $"{reader["telephone_number"].ToString()}",
                                CreateDate = $"{reader["create_date"].ToString()}"
                            });

                        }
                        connection.Close();
                    }
                }
            }

            return Tasks;
        }
    }
}
