using GUI_zaliczenie2025.Classes;
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
using GUI_zaliczenie2025.Admin;
using Task = GUI_zaliczenie2025.Classes.Task;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy UserRequestPageWPF.xaml
    /// </summary>
    public partial class UserRequestPageWPF : UserControl
    {
    public static string Taskid;

    public UserRequestPageWPF()
    {
        InitializeComponent();
        
        
        DataGridUserRequests.ItemsSource = NewUsersRequests.ReturnRequestsListObject();
    }

        private void RowDoubleClickRequest(object sender, RoutedEventArgs e)
        {
            Taskid = null;
            var selectedItem = DataGridUserRequests.SelectedItem as Person;

            if (selectedItem != null)
            {
                string selectedValue = selectedItem.Id;
                Taskid += selectedValue;

            }

            //GridShortSla.Children.Clear();
            //GridShortSla.Children.Add(new NewUserRequests_UserControl());
            var newUserRequestConfirm_Window = new NewUserRequestConfirm_Window();
            newUserRequestConfirm_Window.ShowDialog();
            newUserRequestConfirm_Window.ResizeMode=ResizeMode.NoResize;
        }
    }
}
