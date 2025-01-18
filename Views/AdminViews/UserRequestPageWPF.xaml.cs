using GUI_zaliczenie2025.Classes;
using System.Windows;
using System.Windows.Controls;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy UserRequestPageWPF.xaml
    /// </summary>
    public partial class UserRequestPageWPF : UserControl
    {
        public static string Taskid;

        private AdminMainPageWPF _adminMainPage;////
        public UserRequestPageWPF(AdminMainPageWPF adminMainPage)////
        {
            InitializeComponent();
            _adminMainPage = adminMainPage;/////

            DataGridUserRequests.ItemsSource = NewUsersRequests.ReturnRequestsListObject();
        }

        public UserRequestPageWPF()
        {
            InitializeComponent();
        }

        public void RowDoubleClickRequest(object sender, RoutedEventArgs e)
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
            var newUserRequestConfirm_Window = new NewUserRequestConfirm_Window(_adminMainPage);////
            newUserRequestConfirm_Window.ShowDialog();
            newUserRequestConfirm_Window.ResizeMode = ResizeMode.NoResize;
        }
    }
}
