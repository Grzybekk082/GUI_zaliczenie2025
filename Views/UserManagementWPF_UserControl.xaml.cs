using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Views;
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
        
        public void ShowSelectedUser_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

            Taskid = null;
            TaskLogin = null;
            var selectedItem = DataGridUserManagement.SelectedItem as Classes.User;

            if (selectedItem != null)
            {
                var (selectedLogin,selectedValue) = (selectedItem.Login,selectedItem.Id);
                Taskid += selectedValue;
                TaskLogin += selectedLogin;

            }
            GridUserManagement.Children.Clear();
            GridUserManagement.Children.Add(new SelectedUser_UserControl( this));

        }
    }
}
