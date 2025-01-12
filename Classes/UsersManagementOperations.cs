using GUI_zaliczenie2025.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.IdentityModel.Tokens;

namespace GUI_zaliczenie2025.Classes
{
    internal class UsersManagementOperations
    {
        private static string mySqlQuery= $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user;";
        private static string mySqlQueryDefault= $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user;";
        private SelectedUser_UserControl _SelectedUser;
        private static string loginSelected;
        private static string idSelected;
        private static bool isUserSelected;
        public UsersManagementOperations(){}

        public UsersManagementOperations(SelectedUser_UserControl SelectedUser)
        {
            _SelectedUser = SelectedUser;
            loginSelected= UserManagementWPF_UserControl.TaskLogin;
            idSelected = UserManagementWPF_UserControl.Taskid;
        }

        //!!!!!!!!!!!!!!!!!!!! METODY ZWRACAJĄCE DANE Z BAZY DANYCH !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //Metoda zwracająca dane danego użytkownika do strony AssignTaskToUser_Window
        internal static List<User> ReturnUsersListObject(bool isSelected=false)
        {
            mySqlQuery = mySqlQueryDefault;
            isUserSelected = isSelected;
            if (isUserSelected)
            {
                mySqlQuery = $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user WHERE id = '{idSelected}';";
            }

            List<User> Requestors = new List<User>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";


            using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();

                using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Requestors.Add(new User
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
                        con.Close();
                    }
                }
            }
            isUserSelected=false;


            return Requestors;
        }
        //Metoda zwracająca listę urządzeń przypisanych do użytkownika
        internal static List<Device> ReturnDevicesListObject( bool showAll=false, bool showWitchoutUser=false)
        {

            List<Device> Devices = new List<Device>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";
            if (showAll)
            {
                mySqlQuery = $"SELECT id,brand, model, SerialNumber, Registration_Number, category FROM resources;";
            }
            if(showWitchoutUser)
            {
                mySqlQuery = $"SELECT id,brand, model, SerialNumber, Registration_Number, category FROM resources WHERE assignment_technican != '{AssignToUser_Window.SelectedUserLogin}' OR assignment_technican is NULL;";
            }
            else
            {
                mySqlQuery = $"SELECT id,brand, model, SerialNumber, Registration_Number, category FROM resources WHERE assignment_technican='{AssignToUser_Window.SelectedUserLogin}';";
            }

            try
            {

                using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
                {
                    con.Open();

                    using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Devices.Add(new Device
                                {
                                    Id = $"{reader["id"].ToString()}",
                                    Brand = $"{reader["brand"].ToString()}",
                                    Model = $"{reader["model"].ToString()}",
                                    Serial_Number = $"{reader["SerialNumber"].ToString()}",
                                    Registration_Number = $"{reader["Registration_Number"].ToString()}",
                                    Category = $"{reader["category"].ToString()}"

                                });

                            }

                            con.Close();
                        }
                    }
                }

               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas przetwarzania prośby: {ex.Message}", "Błąd", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            return Devices;
        }
        //Metoda zwracająca listę zadań przypisanych do użytkownika
        internal static List<Task> ReturnTasksListObject()
        {
            List<Task> Tasks = new List<Task>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";

            

            mySqlQuery = $"SELECT id,location, title, status FROM reports WHERE _user = '{loginSelected}';";

            using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();

                using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Tasks.Add(new Task
                            {
                                Id = $"{reader["id"].ToString()}",
                                Location = $"{reader["location"].ToString()}",
                                Title = $"{reader["title"].ToString()}",
                                Status = $"{reader["status"].ToString()}"

                            });

                        }
                        con.Close();
                    }
                }
            }
            return Tasks;
        }

        //!!!!!!!!!!!!!!!!!!!! METODY WPROWADZAJĄCE DANE DO BAZY DANYCH !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //Metoda dodająca zaznaczone zadania w klasie AssignTaskToUser_Window do użytkownika
        internal static void AssignTaskToUser()
        {
            
            try
            {
                List<string> SelectedIdsOfTasks = AssignToUser_Window.SelectedId;
                if (SelectedIdsOfTasks.IsNullOrEmpty())
                {
                    MessageBox.Show("Do Listy nie dodano żadnego elementu.", "Brak wyboru",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    string mySqlQuery = $"UPDATE reports SET _user = '{loginSelected}' WHERE id IN ({string.Join(",", SelectedIdsOfTasks)});";
                    MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
                    conn_string.Server = "localhost";
                    conn_string.Port = 3308;
                    conn_string.UserID = "root";
                    conn_string.Password = "2137";
                    conn_string.Database = "servicedeskv2";
                    using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
                    {
                        con.Open();
                        using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                        {
                            command.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                    MessageBox.Show("Zlecenia zostały przypisane do użytkownika.", "Sukces",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas przetwarzania prośby: {ex.Message}", "Błąd", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }
        //Metoda dodająca zaznaczone urządzenia w klasie AssignTaskToUser_Window do użytkownika
        internal static void AssignDeviceToUser()
        {
            try
            {

                List<string> SelectedIdsOfDevieces = AssignToUser_Window.SelectedId;
                if (SelectedIdsOfDevieces.IsNullOrEmpty())
                {
                    MessageBox.Show("Do Listy nie dodano żadnego elementu.", "Brak wyboru",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    string mySqlQuery = $"UPDATE resources SET assignment_technican = '{loginSelected}' WHERE id IN ({string.Join(",", SelectedIdsOfDevieces)});";
                    MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
                    conn_string.Server = "localhost";
                    conn_string.Port = 3308;
                    conn_string.UserID = "root";
                    conn_string.Password = "2137";
                    conn_string.Database = "servicedeskv2";
                    using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
                    {
                        con.Open();
                        using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                        {
                            command.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                    MessageBox.Show("Urządzenia zostały przypisane do użytkownika.", "Sukces",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas przetwarzania prośby: {ex.Message}", "Błąd", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
