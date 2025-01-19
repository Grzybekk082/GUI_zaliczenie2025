using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using GUI_zaliczenie2025.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Org.BouncyCastle.Utilities;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy UserManagementWPF_UserControl.xaml
    /// </summary>
    public partial class UserManagementWPF_UserControl : UserControl
    {
        public static string Taskid;
        public static string TaskLogin;

        public UserManagementWPF_UserControl()
        {
            InitializeComponent();
            DataGridUserManagement.ItemsSource = UsersManagementOperations.ReturnUsersListObject();
        }
        public UserManagementWPF_UserControl(string queryText, string SearchText)
        {

            InitializeComponent();
            string mySqlQuery =
                $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user where {queryText} = '{SearchText}' ;";
            List<User> usersList = MySqlQueryImplementation.UsersQueryImplementation(mySqlQuery);
            DataGridUserManagement.ItemsSource = usersList;

        }

        public void ShowSelectedUser_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

            Taskid = null;
            TaskLogin = null;
            var selectedItem = DataGridUserManagement.SelectedItem as User;

            if (selectedItem != null)
            {
                var (selectedLogin, selectedValue) = (selectedItem.Login, selectedItem.Id);
                Taskid += selectedValue;
                TaskLogin += selectedLogin;

            }
            GridUserManagement.Children.Clear();
            GridUserManagement.Children.Add(new SelectedUser_UserControl(this));

        }
    }
}
