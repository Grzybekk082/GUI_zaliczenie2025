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

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy UserRequestPageWPF.xaml
    /// </summary>
    public partial class UserRequestPageWPF : UserControl
    {
        public UserRequestPageWPF()
        {
            InitializeComponent();
            ListVievUserRequests.ItemsSource = NewUsersRequests.ReturnRequestsListObject();
        }

        private void UserRequestsButtonOnclick(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new UserRequestPageWPF();


        }

        private void AdminMainPageButtonOnclick(object sender, RoutedEventArgs e)
        {

            Window window = Window.GetWindow(this);
            window.Content = new AdminMainPageWPF();

        }
    }
}
