using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using GUI_zaliczenie2025.Views.AdminViews;
using GUI_zaliczenie2025.Views.UserViews;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy TicketsShowUserControlWPF.xaml
    /// </summary>
    public partial class TicketsShowUserControlWPF : UserControl
    {
        internal static string TaskId;
        private string ActualTechnican;

        public TicketsShowUserControlWPF()
        {

            InitializeComponent();

            TaskId = ShortSlaPageWPF_UserControl.Taskid;
            ActualTechnican = ShortSlaPageWPF_UserControl.TaskUser;
            this.DataContext = ReturnSelectedTask();
            string mySqlQuery = $"SELECT name, surname, login FROM _user";
            this.AssignUserToTask_DataGrid.ItemsSource = MySqlQueryImplementation.AssignUSerToTaskImplementation_Show(mySqlQuery);

        }

        public TicketsShowUserControlWPF(string typeOfObject, bool isUserViev = false)
        {
            InitializeComponent();


            if (isUserViev)
            {

                AssignToTask_Grid.Visibility = Visibility.Collapsed;

            }

            if (typeOfObject == "important")
            {
                TakeTask_Button.Visibility = Visibility.Collapsed;
                if (isUserViev)
                {
                    TakeTask_Button.Visibility = Visibility.Visible;
                }
                TaskId = AdminMostImportantTasks_USerControl.Taskid;
                ActualTechnican = AdminMostImportantTasks_USerControl.TaskUser;
            }

            if (typeOfObject == "normal")
            {
                TakeTask_Button.Visibility = Visibility.Collapsed;
                if (isUserViev)
                {
                    TakeTask_Button.Visibility = Visibility.Visible;
                }
                TaskId = ShortSlaPageWPF_UserControl.Taskid;
                ActualTechnican = ShortSlaPageWPF_UserControl.TaskUser;
            }


            this.DataContext = ReturnSelectedTask();
            string mySqlQuery = $"SELECT name, surname, login FROM _user";
            this.AssignUserToTask_DataGrid.ItemsSource = MySqlQueryImplementation.AssignUSerToTaskImplementation_Show(mySqlQuery);

        }



        internal static List<Classes.Objects.Task> ReturnSelectedTask()
        {


            string command = $"SELECT id,title," +
                             $" description," +
                             $" location," +
                             $" _user," +
                             $" status," +
                             $" technican," +
                             $" date_of_sla," +
                             $" priorytet," +
                             $" company_name," +
                             $" telephone_number," +
                             $" create_date" +
                             $" FROM reports WHERE id='{TaskId}';";
            List<Classes.Objects.Task> SelectedTask = MySqlQueryImplementation.TaskQueryImplementation_Show(command);

            return SelectedTask;
        }

        //Do poprawy zabezpieczenie sprawdzające czy użytkownik jest już przypisany do zlecenia
        private void AssignUserToTask_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {


            var hit = e.OriginalSource as DependencyObject;

            while (hit != null)
            {
                if (hit is DataGridColumnHeader)
                {
                    e.Handled = true;
                    return;
                }

                if (hit is not TextBlock)
                {
                    return;
                }

                if (AssignUserToTask_DataGrid.SelectedItem == null)
                {
                    return;
                }

                var selectedUserLogin = $"{((AssignUser)AssignUserToTask_DataGrid.SelectedItem).Name} {((AssignUser)AssignUserToTask_DataGrid.SelectedItem).Surname}";

                try
                {

                    if (selectedUserLogin == ActualTechnican)
                    {
                        MessageBox.Show("Ten użytkownik jest już przypisany do tego zlecenia!", "Błędny wybór!",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    ActualTechnican = null;
                    MessageBoxResult result = MessageBox.Show($"Czy przipsać zlecenie do użytkownika {selectedUserLogin}?",
                        "Przypisz zlecenie",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            string mySqlQuery = $"UPDATE reports SET technican ='{selectedUserLogin}' WHERE Id = '{TaskId}';";
                            MySqlQueryImplementation.AssignUSerToTaskImplementation_Upadate(mySqlQuery);
                            this.DataContext = ReturnSelectedTask();
                            ActualTechnican = selectedUserLogin;

                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show($"Wystąpił błąd w przetwarzaniu prośby : {ex}", "Błąd przetwarzania!",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Wystąpił błąd w przetwarzaniu prośby : {ex}", "Błąd przetwarzania!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }



            

        }

        private void UserTakeTask_ButtonClick(object sender, RoutedEventArgs e)
        {
            string technican = UserMainPageWPF.Technican;
            if (technican == ActualTechnican)
            {
                MessageBox.Show("Już zostałeś przypisany do tego zlecenia!", "Próba ponownego przypisana",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {


                string mySqlQuery = $"UPDATE reports SET technican ='{technican}' WHERE Id = '{TaskId}';";
                MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery);
                MessageBox.Show("Pomyślnie przypisano zlecenie", "Sukces", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                this.DataContext = ReturnSelectedTask();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Wystąpił błąd w przetwarzaniu prośby : {ex}", "Błąd przetwarzania!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
