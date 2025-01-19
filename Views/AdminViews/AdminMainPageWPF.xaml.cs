﻿using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Views.AdminViews;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;
using GUI_zaliczenie2025.Views.Controls;


namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPageWPF.xaml
    /// </summary>
    /// 
    public partial class AdminMainPageWPF : UserControl
    {
        private bool isTextInt = true;
        public object send;
        public RoutedEventArgs argE;
        private CurrentPerson CRperson;
        public AdminMainPageWPF() { }
        public AdminMainPageWPF(CurrentPerson person)
        {
            CRperson = person;
            InitializeComponent();
            send = null;
            argE = null;
            CurrentPersonLabel.DataContext = CRperson;
            SearchEngineControl_Grid.Children.Clear();
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl( this, "AdminMainPageWPF"));
            // do poprawki ma generować tabele
            //ListVievUserRequests.ItemsSource = NewUsersRequests.ReturnRequestsListObject();

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

        internal void UserRequestsButtonOnclick(object sender, RoutedEventArgs e)
        {
            send = sender;
            argE = e;
            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new UserRequestPageWPF(this));
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl(this, "UserRequestPageWPF"));
            /////
            Main_Admin_24h_Button.Visibility = Visibility.Hidden;
            Main_Admin_SLA_Button.Visibility = Visibility.Hidden;
        }
        private void AdminMainPageButtonOnclick(object sender, RoutedEventArgs e)
        {
            //Do poprawienia - klikniecie przycisku ma podmieniać jedynie GRID mainContent zamiast tworzenia nowej instancji strony.

            Main_Content_Change_Grid.Children.Clear();
            Main_Admin_24h_Button.Visibility = Visibility.Visible;
            Main_Admin_SLA_Button.Visibility = Visibility.Visible;

        }

        private void ChangeToSla_ButtonOnClick(object sender, RoutedEventArgs e)
        {

            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl());
        }

        private void UserManagement_ButtonOnClick(object sender, RoutedEventArgs e)
        {

            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new UserManagementWPF_UserControl());
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl(this, "UserManagementWPF"));

        }

        private void AdministrativeRequests_ButtonClick(object sender, RoutedEventArgs e)
        {
            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new AdministrativeRequests_UserControl());
        }

    }
}
