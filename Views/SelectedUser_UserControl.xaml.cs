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
            DevicesComboBox.ItemsSource= UsersManagementOperations.ReturnDevicesListObject(false);
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
        
        
    }
}
