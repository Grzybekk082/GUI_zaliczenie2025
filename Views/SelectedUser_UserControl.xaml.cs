using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025;
using Task = GUI_zaliczenie2025.Classes.Task;
using MySql.Data.MySqlClient;

namespace GUI_zaliczenie2025.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SelectedUser_UserControl.xaml
    /// </summary>
    public partial class SelectedUser_UserControl : UserControl
    {
        internal bool isSelected = false;
        internal bool isTask= false;
        private UserManagementWPF_UserControl CurrentInstance;
        public SelectedUser_UserControl(){}
        public SelectedUser_UserControl(UserManagementWPF_UserControl CurrentInstance)
        {
            InitializeComponent();
            this.CurrentInstance = CurrentInstance;
            isSelected =true;
            UsersManagementOperations managementOperations = new UsersManagementOperations(this);
            this.DataContext = UsersManagementOperations.ReturnUsersListObject(isSelected);

            TasksComboBox.ItemsSource = UsersManagementOperations.ReturnTasksListObject();
            DevicesComboBox.ItemsSource= UsersManagementOperations.ReturnDevicesListObject(false,false);
        }


        private void AssignTaskToUser_OnClick(object sender, RoutedEventArgs e)
        {
            isTask= true;
            AssignToUser_Window assignTaskToUser_Window = new AssignToUser_Window( this, isTask);
            assignTaskToUser_Window.ShowDialog();
        } 
        private void AssignDeviceToUser_OnClick(object sender, RoutedEventArgs e)
        {
            isTask = false;
            AssignToUser_Window assignTaskToUser_Window = new AssignToUser_Window( this, isTask );
            assignTaskToUser_Window.ShowDialog();
        }


        private void UserTaskOperation_OnClick(object sender, MouseButtonEventArgs e)
        {

            Task task = (Task)TasksComboBox.SelectedItem;


            if (task != null)
            {
                string taskId = task.Id;
                MessageBoxResult result= MessageBox.Show("Zwrócić zlecenie na główną kolejkę?",
                    "Zwróć zlecenie",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question,
                    defaultResult:MessageBoxResult.No);
               if (result == MessageBoxResult.Yes)
               {
                   try
                   {
                       string mySqlQuery = $"Update reports SET _user = NULL WHERE id = '{taskId}';";


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
                           }
                       }
                       MessageBox.Show("Zlecenie zostało zwrócone na główną kolejkę", "Zlecenie zwrócone", MessageBoxButton.OK, MessageBoxImage.Information);
                       TasksComboBox.ItemsSource = UsersManagementOperations.ReturnTasksListObject();
                        TasksComboBox.Items.Refresh();
                    }
                   catch (MySqlException ex)
                   {
                       MessageBox.Show($"Wystąpił błąd w przetwarzaniu prośby : {ex}" ,"Błąd przetwarzania!", MessageBoxButton.OK , MessageBoxImage.Error );
                   }
               }

            }
        }

        private void UserDeviceOperation_OnClick(object sender, MouseButtonEventArgs e)
        {

            Device device = (Device)DevicesComboBox.SelectedItem;


            if (device != null)
            {
                string deviceId = device.Id;
                MessageBoxResult result = MessageBox.Show("Zwrócić zlecenie na główną kolejkę?",
                    "Zwróć zlecenie",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question,
                    defaultResult: MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        string mySqlQuery = $"Update resources SET assignment_technican = NULL WHERE id = '{deviceId}';";


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
                            }
                        }
                        MessageBox.Show("Urządzenie zostało zwrócone na główną kolejkę", "Urządzenie zwrócone", MessageBoxButton.OK, MessageBoxImage.Information);
                        DevicesComboBox.ItemsSource = UsersManagementOperations.ReturnDevicesListObject(false, false);
                        DevicesComboBox.Items.Refresh();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"Wystąpił błąd w przetwarzaniu prośby : {ex}", "Błąd przetwarzania!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }

        }
    }
}
