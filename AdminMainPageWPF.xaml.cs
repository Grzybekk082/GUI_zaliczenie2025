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

           // do poprawki ma generować tabele
            //ListVievUserRequests.ItemsSource = NewUsersRequests.ReturnRequestsListObject();

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

        private void ChangeToSla_ButtonOnClick(object sender, RoutedEventArgs e)
        {
            Main_Content_Change_Grid.Children.Clear();
            Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl());
        }

        private void TaskSearchButton_click(object sender, RoutedEventArgs e)
        {
            

            string choose = SearchForComboBox.Text;
            string SearchText = SearchTextBox.Text;
            MessageBox.Show(choose + SearchText);
        }


    }
}
