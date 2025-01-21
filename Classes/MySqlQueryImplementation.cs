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

        public static List<Task> TaskQueryImplementation_Show(string commandText)
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
                                Technican= $"{reader["technican"].ToString()}",
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






        public static List<Objects.User> UsersQueryImplementation_Show(string commandText)
        {
            List<Objects.User> Tasks = new List<Objects.User>();
            MySqlConnection connection = DatabaseConnection.ConnectionBuilder();

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

                            Tasks.Add(new Classes.Objects.User
                            {
                                Id = $"{reader["id"].ToString()}",
                                Name = $"{reader["name"].ToString()}",
                                Surname = $"{reader["surname"].ToString()}",
                                Login = $"{reader["login"].ToString()}",
                                Departament = $"{reader["departament"].ToString()}",
                                Permission = $"{reader["permissions"].ToString()}",
                                Phone_Number = $"{reader["tel"].ToString()}",
                                Email = $"{reader["email"].ToString()}"
                            });

                        }
                        connection.Close();
                    }
                }
            }

            return Tasks;
        }






        public static List<Person> RequestsQueryImplementation_Show(string commandText)
        {
            List<Objects.Person> Tasks = new List<Objects.Person>();
            MySqlConnection connection = DatabaseConnection.ConnectionBuilder();

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

                            Tasks.Add(new Classes.Objects.Person
                            {
                                Id = $"{reader["id"].ToString()}",
                                Name = $"{reader["Imie"].ToString()}",
                                Surename = $"{reader["Nazwisko"].ToString()}",
                                Login = $"{reader["Login"].ToString()}",
                                Date_of_Request = $"{reader["kolumna_dat"].ToString()}",
                                Phone_Number = $"{reader["Nr_tel"].ToString()}"
                            });

                        }
                        connection.Close();
                    }
                }
            }

            return Tasks;
        }


        public static List<AssignUser> AssignUSerToTaskImplementation_Show(string commandText)
        {
            List<Objects.AssignUser> Tasks = new List<Objects.AssignUser>();
            MySqlConnection connection = DatabaseConnection.ConnectionBuilder();

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

                            Tasks.Add(new Classes.Objects.AssignUser
                            {
                                Name = $"{reader["name"].ToString()}",
                                Surname = $"{reader["surname"].ToString()}",
                                Login = $"{reader["login"].ToString()}"

                            });

                        }
                        connection.Close();
                    }
                }
            }

            return Tasks;
        }

        public static List<Task> AssignUSerToTaskImplementation_Upadate(string commandText)
        {
            List<Objects.Task> Tasks = new List<Objects.Task>();
            MySqlConnection connection = DatabaseConnection.ConnectionBuilder();

            MySqlCommand command = new MySqlCommand(commandText, connection);
            using (connection)
            {
                connection.Open();
                using (command)
                {
                    command.ExecuteNonQuery();
                }
            }

            return Tasks;
        }
    }
}
