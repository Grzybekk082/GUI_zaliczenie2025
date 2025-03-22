using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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

        public UserRequestPageWPF(string queryText, string SearchText)////
        {
            InitializeComponent();
            string mySqlQuery =
                $"SELECT" +
                $" id, " +
                $" Imie, " +
                $"Nazwisko, " +
                $"Login," +
                $"kolumna_dat, " +
                $"Nr_tel " +
                $"FROM user_requests WHERE {queryText} like upper('%{SearchText}%');";
            List<Person> usersList = MySqlQueryImplementation.RequestsQueryImplementation_Show(mySqlQuery);
            DataGridUserRequests.ItemsSource = usersList;
        }

        public UserRequestPageWPF()
        {
            InitializeComponent();
        }

        public void RowDoubleClickRequest(object sender, RoutedEventArgs e)
        {

            var hit = e.OriginalSource as DependencyObject;

            while (hit != null)
            {
                if (hit is DataGridColumnHeader)
                {
                    e.Handled = true;
                    return;
                }

                if (hit is not TextBlock)
                {
                    return;
                }
                if (DataGridUserRequests.SelectedItem != null)
                {
                    Taskid = null;
                    var selectedItem = DataGridUserRequests.SelectedItem as Person;

                    string selectedValue = selectedItem.Id;
                    Taskid += selectedValue;

                    //GridShortSla.Children.Clear();
                    //GridShortSla.Children.Add(new NewUserRequests_UserControl());
                    var newUserRequestConfirm_Window = new NewUserRequestConfirm_Window(_adminMainPage); ////
                    newUserRequestConfirm_Window.ShowDialog();
                    newUserRequestConfirm_Window.ResizeMode = ResizeMode.NoResize;
                }


            }
        }
    }
}
