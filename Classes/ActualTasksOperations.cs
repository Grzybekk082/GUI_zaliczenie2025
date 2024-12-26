using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_zaliczenie2025.Classes
{
    internal class ActualTasksOperations
    {
        internal static List<Task> ReturnRequestsListObject()
        {
            List<Task> Requestors = new List<Task>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3306;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";

            using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT id,title, description, location, _user, status, date_of_sla, company_name, telephone_number FROM reports;", con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Requestors.Add(new Task {
                                Id = $"{reader["id"].ToString()}",
                                Title = $"{reader["title"].ToString()}", Description = $"{reader["description"].ToString()}",
                                Location = $"{reader["location"].ToString()}", User = $"{reader["_user"].ToString()}", Status = $"{reader["status"].ToString()}",
                                SLA = $"{reader["date_of_sla"].ToString()}", Company = $"{reader["company_name"].ToString()}",
                                TelNumber = $"{reader["telephone_number"].ToString()}"
                            });

                        }
                        con.Close();
                    }
                }
            }

            return Requestors;
        }
    }
}
