using GUI_zaliczenie2025.Classes;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
using GUI_zaliczenie2025.Views;


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
        public AdminMainPageWPF(){}
        public AdminMainPageWPF(CurrentPerson person)
        {
           CRperson= person;
            InitializeComponent();
            send = null;
            argE = null;
            CurrentPersonLabel.DataContext= CRperson;
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
            /////
            Main_Admin_24h_Button.Visibility=Visibility.Hidden;
            Main_Admin_SLA_Button.Visibility=Visibility.Hidden;
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
        }

        internal void TaskSearchButton_click(object sender, RoutedEventArgs e)
        {

            
             
            string choose = SearchForComboBox.Text;
            string SearchText = SearchTextBox.Text;
            (string warningText, bool isInt) IsInputIntReturns = ActualTasksOperations.IsInputInt(choose, SearchText);
            if (choose.IsNullOrEmpty() || SearchText.IsNullOrEmpty())
            {

                warningSearchLabel.Visibility= Visibility.Visible;

                warningSearchLabel.Content = "Pole wyszukiwania i lista rozwijana muszą być uzupełnione !";
            }
            else
            {
                if (choose == "Id")
                {
                    if (IsInputIntReturns.isInt)
                    {
                        Main_Content_Change_Grid.Children.Clear();
                        Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl(choose, SearchText));
                        SearchTextBox.Clear();
                        
                        warningSearchLabel.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        SearchTextBox.Clear();
                        warningSearchLabel.Visibility = Visibility.Visible;
                        warningSearchLabel.Content = IsInputIntReturns.warningText;
                    }
                }
                else
                {
                    Main_Content_Change_Grid.Children.Clear();
                    Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl(choose, SearchText));
                    SearchTextBox.Clear();
                    warningSearchLabel.Visibility = Visibility.Hidden;
                }



            }

        }
        //Do poprawienia - klikniecie przycisku wczesne SLA ma pomijać metodę showMessage i od razu pokazywać wynik.
    }
}
