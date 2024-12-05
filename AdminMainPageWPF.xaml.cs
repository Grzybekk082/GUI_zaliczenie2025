using GUI_zaliczenie2025.Classes;
using System;
using System.Collections;
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
    /// Logika interakcji dla klasy AdminPageWPF.xaml
    /// </summary>
    /// 
    public partial class AdminMainPageWPF : UserControl
    {
        
        public AdminMainPageWPF()
        {
           
            InitializeComponent();
            ListBoxuserRequests.ItemsSource = NewUsersRequests.ReturnRequestsListObject();
        }


        

        

        private void UserRequestsButtonOnclick(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new UserRequestPageWPF();
            window.ResizeMode = ResizeMode.CanResize;
            window.WindowState = WindowState.Maximized;
            
        }


    }
}
