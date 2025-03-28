﻿using MySql.Data.MySqlClient;
using System.Windows;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;


namespace GUI_zaliczenie2025
{

    /// <summary>
    /// Logika interakcji dla klasy NewUserRequestConfirm_Window.xaml
    /// </summary>
    public partial class NewUserRequestConfirm_Window : Window
    {
        private string userPermission;
        private string userDepartament;

        private AdminMainPageWPF _adminMainPage;
        /////
        public NewUserRequestConfirm_Window(AdminMainPageWPF adminMainPage)
        {
            InitializeComponent();
            this.DataContext = ReturnSelectedTask();
            _adminMainPage = adminMainPage;
            ConfirmButton.IsEnabled = false;
        }

        internal static List<Person> ReturnSelectedTask()
        {
            string taskId = UserRequestPageWPF.Taskid;

            List<Person> SelectedTask = new List<Person>();
            MySqlConnection con = DatabaseConnection.ConnectionBuilder();

            using (con)
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT " +
                                                               $"id," +
                                                               $"Imie," +
                                                               $" Nazwisko," +
                                                               $" Login," +
                                                               $" kolumna_dat" +
                                                               $" FROM user_requests WHERE id='{taskId}';", con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            SelectedTask.Add(new Classes.Objects.Person()
                            {
                                Id = $"{reader["Id"].ToString()}",
                                Name = $"{reader["Imie"].ToString()}",
                                Surename = $"{reader["Nazwisko"].ToString()}",
                                Login = $"{reader["Login"].ToString()}",
                                Date_of_Request = $"{reader["Kolumna_dat"].ToString()}",

                            });

                        }
                        con.Close();
                    }
                }
            }
            return SelectedTask;
        }


        public void DeleteUserRequestButton_Click(object sender, RoutedEventArgs e)
        {
            var taskId = UserRequestPageWPF.Taskid;

            if (string.IsNullOrEmpty(taskId))
            {
                MessageBox.Show("Nie wybrano żadnej prośby do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var conn_string = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3308,
                UserID = "root",
                Password = "2137",
                Database = "servicedeskv2"
            };

            try
            {
                using (var con = new MySqlConnection(conn_string.ToString()))
                {
                    con.Open();
                    using (var command = new MySqlCommand($"DELETE FROM user_requests WHERE id='{taskId}';", con))
                    {
                        var rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Prośba została pomyślnie usunięta.", "Sukces", MessageBoxButton.OK);
                            Window window = this;
                            window.Close();
                            _adminMainPage.Main_Content_Change_Grid.Children.Clear();
                            _adminMainPage.UserRequestsButtonOnclick(_adminMainPage.send, _adminMainPage.argE);
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono prośby do usunięcia.", "Błąd", MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                        }

                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas usuwania prośby: {ex.Message}", "Błąd", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void ConfirmUserRequestButton_Click(object sender, RoutedEventArgs e)
        {
            userPermission = PermisionComboBox.Text;
            userPermission = userPermission == "Technik" ? "Technican" : userPermission;
            userPermission = userPermission == "Administrator" ? "admin" : userPermission;

            userDepartament = DepartamentComboBox.Text;

            userDepartament = userDepartament == "1 linia wsparcia" ? "1 linia" : userDepartament;
            userDepartament = userDepartament == "Specjalista" ? "2 linia" : userDepartament;
            userDepartament = userDepartament == "Serwis terenowy" ? "3 linia" : userDepartament;


            //MessageBox.Show(userDepartament + "    " + userPermission);



            var taskId = UserRequestPageWPF.Taskid;

            if (string.IsNullOrEmpty(taskId))
            {
                MessageBox.Show("Nie wybrano żadnej prośby do zatwierdzenia.", "Błąd", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            var conn_string = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3308,
                UserID = "root",
                Password = "2137",
                Database = "servicedeskv2"
            };

            try
            {
                using (var con = new MySqlConnection(conn_string.ToString()))
                {
                    con.Open();

                    using (var selectCommand =
                           new MySqlCommand($"SELECT Imie, Nazwisko, Login, Haslo, Nr_tel FROM user_requests WHERE id='{taskId}';", con))
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var name = reader["Imie"].ToString();
                            var surename = reader["Nazwisko"].ToString();
                            var login = reader["Login"].ToString().ToLower();
                            var pass = reader["Haslo"].ToString();
                            var tell = reader["Nr_tel"].ToString();

                            reader.Close();
                            using (var insertCommand =
                                   new MySqlCommand(
                                       $"INSERT INTO _user (name, surname, login, password, permissions, departament, tel) VALUES (@name, @surename, @login, @pass, @permission, @departament, @tell );", con))
                            {
                                insertCommand.Parameters.AddWithValue("@name", name);
                                insertCommand.Parameters.AddWithValue("@surename", surename);
                                insertCommand.Parameters.AddWithValue("@login", login);
                                insertCommand.Parameters.AddWithValue("@pass", pass);
                                insertCommand.Parameters.AddWithValue("@tell", tell);
                                insertCommand.Parameters.AddWithValue("@permission", userPermission);
                                insertCommand.Parameters.AddWithValue("@departament", userDepartament);

                                var rowsAffected = insertCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Użytkownik został pomyślnie dodany do bazy danych.", "Sukces",
                                        MessageBoxButton.OK, MessageBoxImage.Information);



                                    using (var deleteCommand =
                                           new MySqlCommand($"DELETE FROM user_requests WHERE id='{taskId}';", con))
                                    {
                                        deleteCommand.ExecuteNonQuery();
                                    }

                                    Window window = this;
                                    window.Close();
                                    _adminMainPage.Main_Content_Change_Grid.Children.Clear();
                                    _adminMainPage.UserRequestsButtonOnclick(_adminMainPage.send, _adminMainPage.argE);
                                }
                                else
                                {
                                    MessageBox.Show("Nie udało się dodać użytkownika do bazy danych.", "Błąd",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono prośby o podanym ID.", "Błąd", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas przetwarzania prośby: {ex.Message}", "Błąd", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }


        }



        private void PermisionComboBox_OnSelected(object sender, RoutedEventArgs e)
        {
            userDepartament = DepartamentComboBox.Text;
            ConfirmButton.IsEnabled = string.IsNullOrEmpty(userDepartament) ? false : true;

        }

        private void DepartmentComboBox_OnSelected(object sender, RoutedEventArgs e)
        {
            userPermission = PermisionComboBox.Text;
            ConfirmButton.IsEnabled = string.IsNullOrEmpty(userPermission) ? false : true;

        }
    }
}
