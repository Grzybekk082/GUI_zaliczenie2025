using GUI_zaliczenie2025.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Task = GUI_zaliczenie2025.Classes.Objects.Task;

namespace GUI_zaliczenie2025.Views.AdminViews
{
    /// <summary>
    /// Logika interakcji dla klasy AdminMostImportantTasks_USerControl.xaml
    /// </summary>
    public partial class AdminMostImportantTasks_USerControl : UserControl
    {
        public static string Taskid;
        public static string TaskUser;

        public AdminMostImportantTasks_USerControl()
        {
            InitializeComponent();
            string mySqlQuery = $"SELECT id, title, description, location, _user, status, technican, date_of_sla, company_name, telephone_number, priorytet, create_date FROM reports WHERE priorytet = 'high' AND (status = 'Open' OR status = 'open');";
            MostImportantTasks_DataGrid.ItemsSource = MySqlQueryImplementation.TaskQueryImplementation_Show(mySqlQuery);
        }

        public AdminMostImportantTasks_USerControl(string choose, string SearchText)
        {
            InitializeComponent();
            string mySqlQuery = $"SELECT id,title, description, location, _user, status, technican, date_of_sla, company_name, telephone_number, priorytet, create_date FROM reports WHERE priorytet = 'high' AND ({choose}  like '%{SearchText}%' AND (status = 'Open' OR status = 'open'  ));";
            MostImportantTasks_DataGrid.ItemsSource = MySqlQueryImplementation.TaskQueryImplementation_Show(mySqlQuery);
        }


        public void ShowImportantTask_ButtonClick(object sender, RoutedEventArgs e)
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
                    if (MostImportantTasks_DataGrid.SelectedItem != null)
                    {
                        Taskid = null;
                        TaskUser = null;
                        var selectedItem = MostImportantTasks_DataGrid.SelectedItem as Task;

                        Taskid = selectedItem.Id;
                        TaskUser = selectedItem.Technican;

                        AdminMostImportantTask_Grid.Children.Clear();
                        AdminMostImportantTask_Grid.Children.Add(new TicketsShowUserControlWPF("important"));

                    }

                }
                return;
            }

        }
    }
}
