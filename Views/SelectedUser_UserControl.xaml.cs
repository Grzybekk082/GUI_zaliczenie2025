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
        public SelectedUser_UserControl()
        {
            InitializeComponent();
            isSelected=true;
            UsersManagementOperations managementOperations = new UsersManagementOperations(this);
            this.DataContext = UsersManagementOperations.ReturnUsersListObject(isSelected);
            
            DevicesComboBox.ItemsSource= UsersManagementOperations.ReturnDevicesListObject();
            TasksComboBox.ItemsSource = UsersManagementOperations.ReturnTasksListObject();
        }


        private void AssignTaskToUser_OnClick(object sender, RoutedEventArgs e)
        {
            isTask= true;
            AssignTaskToUser_Window assignTaskToUser_Window = new AssignTaskToUser_Window( this, isTask);
            assignTaskToUser_Window.ShowDialog();
        } 
        private void AssignDeviceToUser_OnClick(object sender, RoutedEventArgs e)
        {
            isTask = false;
            AssignTaskToUser_Window assignTaskToUser_Window = new AssignTaskToUser_Window( this, isTask );
            assignTaskToUser_Window.ShowDialog();
        }
        
        
    }
}
