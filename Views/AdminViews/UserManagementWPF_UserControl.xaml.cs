using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using GUI_zaliczenie2025.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy UserManagementWPF_UserControl.xaml
    /// </summary>
    public partial class UserManagementWPF_UserControl : UserControl
    {
        public static string Taskid;
        public static string TaskTechnican;

        public UserManagementWPF_UserControl()
        {
            InitializeComponent();
            DataGridUserManagement.ItemsSource = UsersManagementOperations.ReturnUsersListObject();
        }
        public UserManagementWPF_UserControl(string queryText, string SearchText)
        {

            InitializeComponent();
            string mySqlQuery =
                $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user where {queryText} like upper('%{SearchText}%');";
            List<User> usersList = MySqlQueryImplementation.UsersQueryImplementation_Show(mySqlQuery);
            DataGridUserManagement.ItemsSource = usersList;

        }

        public void ShowSelectedUser_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Taskid = null;
            TaskTechnican = null;

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
                    if (DataGridUserManagement.SelectedItem != null)
                    {
                        var selectedItem = DataGridUserManagement.SelectedItem as User;

                        var (selectedLogin, selectedValue) = (($"{selectedItem.Name} {selectedItem.Surname}"), selectedItem.Id);
                        Taskid += selectedValue;
                        TaskTechnican += selectedLogin;

                        GridUserManagement.Children.Clear();
                        GridUserManagement.Children.Add(new SelectedUser_UserControl(this));
                    }


                }
                return;
            }

        }
    }
}
