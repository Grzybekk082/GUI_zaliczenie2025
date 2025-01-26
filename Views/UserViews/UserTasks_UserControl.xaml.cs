using GUI_zaliczenie2025.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Task = GUI_zaliczenie2025.Classes.Objects.Task;

namespace GUI_zaliczenie2025.Views.UserViews
{
    /// <summary>
    /// Logika interakcji dla klasy UserTasks_UserControl.xaml
    /// </summary>
    public partial class UserTasks_UserControl : UserControl
    {
        private string login;
        public static string Taskid;
        public UserTasks_UserControl()
        {
            InitializeComponent();



            login = UserMainPageWPF.CRperson.CurrentLogin;

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
                                                    $" FROM reports WHERE _user='{login}' AND status !='Closed';";

            List<Classes.Objects.Task> Tasks = MySqlQueryImplementation.TaskQueryImplementation_Show(command);


            UserTasks_DataGrid.ItemsSource = Tasks;

        }


        private void ShowTicket_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            var hit = e.OriginalSource as DependencyObject;

            while (hit != null)
            {
                if (hit is DataGridColumnHeader)
                {
                    e.Handled = true;
                    return;
                }

                if (hit is TextBlock)
                {
                    if (UserTasks_DataGrid.SelectedItem != null)
                    {

                        Taskid = null;

                        var selectedItem = UserTasks_DataGrid.SelectedItem as Task;

                        Taskid = selectedItem.Id;

                        UserTasks_Grid.Children.Clear();
                        UserTasks_Grid.Children.Add(new UserShowSelectedTask_UserControl());
                    }
                }
                return;
            }

        }
    }
}
