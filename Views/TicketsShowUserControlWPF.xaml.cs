using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
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
            var selectedUserLogin = ((AssignUser)AssignUserToTask_DataGrid.SelectedItem).Login;
            try
            {

                if (ShortSlaPageWPF_UserControl.TaskUser == selectedUserLogin || selectedUserLogin == ActualTechnican)
                {
                    ActualTechnican = null;
                    MessageBox.Show("Ten użytkownik jest już przypisany do tego zlecenia!", "Błędny wybór!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
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


            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Wystąpił błąd w przetwarzaniu prośby : {ex}", "Błąd przetwarzania!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
