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

namespace GUI_zaliczenie2025.Views.UserViews
{
    /// <summary>
    /// Logika interakcji dla klasy UserMainPageWPF.xaml
    /// </summary>
    public partial class UserMainPageWPF : UserControl
    {
        public static CurrentPerson CRperson;


        public UserMainPageWPF()
        {
        }

        public UserMainPageWPF(CurrentPerson person)
        {
            CRperson = person;
            InitializeComponent();
            CurrentPersonLabel.DataContext = CRperson;
            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl());
        }

        private void LogOut_ButtonClick(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new LoginPageWPF();
            window.ResizeMode = ResizeMode.NoResize;
            window.WindowState = WindowState.Normal;
            window.Width = 600;
            window.Height = 450;
        }

        private void UserMainPageButtonOnclick(object sender, RoutedEventArgs e)
        {
            //Do poprawienia - klikniecie przycisku ma podmieniać jedynie GRID mainContent zamiast tworzenia nowej instancji strony.

            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl());
        }

        private void UserTasks_ButtonClick(object sender, RoutedEventArgs e)
        {
            //Do poprawienia - klikniecie przycisku ma podmieniać jedynie GRID mainContent zamiast tworzenia nowej instancji strony.
            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new UserTasks_UserControl());
        }

        private void UserProtocolsAndDevices_ButtonClick(object sender, RoutedEventArgs e)
        {
            //Do poprawienia - klikniecie przycisku ma podmieniać jedynie GRID mainContent zamiast tworzenia nowej instancji strony.
            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new UserProtocolsAndDevices_UserControl());
        }
    }
}
