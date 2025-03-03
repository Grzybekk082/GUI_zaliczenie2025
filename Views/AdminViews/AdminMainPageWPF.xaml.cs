﻿using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Views;
using GUI_zaliczenie2025.Views.AdminViews;
using GUI_zaliczenie2025.Views.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


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
        private int AdminRequestCounter;
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
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl(this, "AdminMainPageWPF"));
            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl());
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl(this, "AdminMainPageWPF"));

            Main_Admin_SLA_Button.Background=Brushes.DimGray;
            MainPage_Button.Background= Brushes.DimGray;

            string mySqlQuery = "SELECT id, name, surname, login, departament, permissions FROM _user WHERE new_password IS NOT NULL";
            AdminRequestCounter = MySqlQueryImplementation.PasswordChangeList_Show(mySqlQuery).Count;
            if (AdminRequestCounter > 0)
            {
                AdminRequestCounter_TextBlock.Text = AdminRequestCounter.ToString();
                AdminRequestCounter_Border.Visibility = Visibility.Visible;
            }
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

            MainPage_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            UserManagement_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            ShowProtocols_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            UserRequests_Button.Background = Brushes.DimGray;
        }
        private void AdminMainPageButtonOnclick(object sender, RoutedEventArgs e)
        {
            //Do poprawienia - klikniecie przycisku ma podmieniać jedynie GRID mainContent zamiast tworzenia nowej instancji strony.

            Main_Content_Change_Grid.Children.Clear();
            Main_Admin_24h_Button.Visibility = Visibility.Visible;
            Main_Admin_SLA_Button.Visibility = Visibility.Visible;
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl(this, "AdminMainPageWPF"));
            Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl());
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl(this, "AdminMainPageWPF"));

            Main_Admin_SLA_Button.Background = Brushes.DimGray;
            MainPage_Button.Background = Brushes.DimGray;
            Main_Admin_24h_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");

            UserManagement_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            UserRequests_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            ShowProtocols_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
        }


        private void ChangeToSla_ButtonOnClick(object sender, RoutedEventArgs e)
        {

            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl());
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl(this, "AdminMainPageWPF"));

            Main_Admin_24h_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            Main_Admin_SLA_Button.Background = Brushes.DimGray;
        }

        private void UserManagement_ButtonOnClick(object sender, RoutedEventArgs e)
        {

            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new UserManagementWPF_UserControl());
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl(this, "UserManagementWPF"));

            Main_Admin_24h_Button.Visibility = Visibility.Hidden;
            Main_Admin_SLA_Button.Visibility = Visibility.Hidden;

            MainPage_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            UserRequests_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            ShowProtocols_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            UserManagement_Button.Background = Brushes.DimGray;

        }

        private void AdministrativeRequests_ButtonClick(object sender, RoutedEventArgs e)
        {
            Administration_Window window = new Administration_Window(this);
            window.ShowDialog();
        }
        private void ShowProtocols_ButtonOnclick(object sender, RoutedEventArgs e)
        {
            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new ProtocolManagement_UserControl());
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl(this, "ProtocolManagementWPF"));
            Main_Admin_24h_Button.Visibility = Visibility.Hidden;
            Main_Admin_SLA_Button.Visibility = Visibility.Hidden;

            MainPage_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            UserRequests_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            UserManagement_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            ShowProtocols_Button.Background = Brushes.DimGray;

        }

        private void MostImportantTasks_ButtonClick(object sender, RoutedEventArgs e)
        {

            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new AdminMostImportantTasks_USerControl());
            SearchEngineControl_Grid.Children.Add(new SearchEngine_UserControl(this, "MostImportantTasksWPF"));


            Main_Admin_SLA_Button.Background = (Brush)new BrushConverter().ConvertFromString("#FFB5B5B5");
            Main_Admin_24h_Button.Background = Brushes.DimGray;
        }


    }
}
