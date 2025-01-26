using GUI_zaliczenie2025.Classes;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GUI_zaliczenie2025.Views.UserViews
{
    /// <summary>
    /// Logika interakcji dla klasy UserMainPageWPF.xaml
    /// </summary>
    public partial class UserMainPageWPF : UserControl
    {
        public static CurrentPerson CRperson;
        public static string Technican;

        public UserMainPageWPF()
        {
        }

        public UserMainPageWPF(CurrentPerson person)
        {
            CRperson = person;
            InitializeComponent();
            CurrentPersonLabel.DataContext = CRperson;
            Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl());
            MySqlConnection connection = DatabaseConnection.ConnectionBuilder();

            string mySqlQuery = $"SELECT name, surname FROM _user WHERE login = '{UserMainPageWPF.CRperson.CurrentLogin}' ;";

            MySqlCommand command = new MySqlCommand(mySqlQuery, connection);
            using (connection)
            {
                connection.Open();
                using (command)
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Technican = $"{reader["name"].ToString()} {reader["surname"].ToString()}";
                        }
                        connection.Close();
                    }
                }
            }
        }

        private void LogOut_ButtonClick(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new LoginPageWPF();
            window.ResizeMode = ResizeMode.NoResize;
            window.WindowState = WindowState.Normal;
            window.Width = 600;
            window.Height = 450;
        }

        private void UserMainPageButtonOnclick(object sender, RoutedEventArgs e)
        {
            //Do poprawienia - klikniecie przycisku ma podmieniać jedynie GRID mainContent zamiast tworzenia nowej instancji strony.

            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl());
        }

        private void UserTasks_ButtonClick(object sender, RoutedEventArgs e)
        {
            //Do poprawienia - klikniecie przycisku ma podmieniać jedynie GRID mainContent zamiast tworzenia nowej instancji strony.
            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new UserTasks_UserControl());
        }

        private void UserProtocolsAndDevices_ButtonClick(object sender, RoutedEventArgs e)
        {
            //Do poprawienia - klikniecie przycisku ma podmieniać jedynie GRID mainContent zamiast tworzenia nowej instancji strony.
            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new UserProtocolsAndDevices_UserControl());
        }
    }
}
