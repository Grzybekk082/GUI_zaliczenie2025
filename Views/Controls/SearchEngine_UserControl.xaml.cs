using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Views.AdminViews;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace GUI_zaliczenie2025.Views.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy SearchEngine_UserControl.xaml
    /// </summary>
    public partial class SearchEngine_UserControl : UserControl
    {
        private AdminMainPageWPF _CRinstance;
        private string _MotherClass;
        private Dictionary<string, string> searchList;



        public SearchEngine_UserControl()
        {
        }
        public SearchEngine_UserControl(AdminMainPageWPF Instacne, string MotherClass)
        {
            InitializeComponent();
            _CRinstance = Instacne;
            _MotherClass = MotherClass;


            if (MotherClass == "MostImportantTasksWPF")
            {
                searchList = new Dictionary<string, string>()
                {
                    {"Id","id"},
                    {"technican","technik"},
                    {"company_name","company"},
                    {"location","location"}
                };

                SearchEngine_ComboBox.ItemsSource = searchList.Values;
            }

            if (MotherClass == "UserManagementWPF")
            {
                searchList = new Dictionary<string, string>()
                {
                    {"name","Imię"},
                    {"surname","Nazwisko"},
                    {"login","Login"}
                };

                SearchEngine_ComboBox.ItemsSource = searchList.Values;
            }

            if (MotherClass == "AdminMainPageWPF")
            {
                searchList = new Dictionary<string, string>()
                {
                    {"Id","id"},
                    {"technican","technik"},
                    {"status","status"},
                    {"company_name","company"},
                    {"location","location"},
                    {"priorytet","priorytet"},
                };

                SearchEngine_ComboBox.ItemsSource = searchList.Values;
            }

            if (MotherClass == "UserRequestPageWPF")
            {
                searchList = new Dictionary<string, string>()
                {
                    {"Imie","Imię"},
                    {"Nazwisko","Nazwisko"},
                    {"Login","Login"}
                };

                SearchEngine_ComboBox.ItemsSource = searchList.Values;
            }

            if (MotherClass == "ProtocolManagementWPF")
            {
                searchList = new Dictionary<string, string>()
                {
                    {"Id","id"},
                    {"technican","technik"},
                    {"company_name","company"},
                    {"location","location"},
                    {"priorytet","priorytet"},
                };

                SearchEngine_ComboBox.ItemsSource = searchList.Values;
            }

        }




        internal void TaskSearchButton_click(object sender, RoutedEventArgs e)
        {



            string choose = SearchEngine_ComboBox.Text;
            string SearchText = SearchEngine_TextBox.Text;
            string queryText = null;
            foreach (var element in searchList)
            {
                if (choose == element.Value)
                {
                    queryText = element.Key;
                    break;
                }
            }
            (string warningText, bool isInt) IsInputIntReturns = ActualTasksOperations.IsInputInt(queryText, SearchText);
            if (queryText.IsNullOrEmpty() || queryText.IsNullOrEmpty())
            {

                warningSearchLabel.Visibility = Visibility.Visible;

                warningSearchLabel.Content = "Pole wyszukiwania i lista rozwijana muszą być uzupełnione !";
                ComboBox comboBox = SearchEngine_ComboBox;

                comboBox.Items.Clear();
            }
            else
            {
                if (queryText == "Id" || queryText == "id")
                {
                    if (IsInputIntReturns.isInt)
                    {
                        _CRinstance.Main_Content_Change_Grid.Children.Clear();
                        _CRinstance.Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl(queryText, SearchText));
                        SearchEngine_TextBox.Clear();

                        warningSearchLabel.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        SearchEngine_TextBox.Clear();
                        warningSearchLabel.Visibility = Visibility.Visible;
                        warningSearchLabel.Content = IsInputIntReturns.warningText;
                    }
                }
                else
                {
                    if (_MotherClass == "MostImportantTasksWPF")
                    {
                        SearchingForImportantTasks(queryText, SearchText);
                    }
                    if (_MotherClass == "AdminMainPageWPF")
                    {
                        SearchingForTasks(queryText, SearchText);
                    }
                    if (_MotherClass == "UserManagementWPF")
                    {
                        SearchingForUser(queryText, SearchText);
                    }
                    if (_MotherClass == "UserRequestPageWPF")
                    {
                        SearchingForRequests(queryText, SearchText);
                    }
                    if (_MotherClass == "ProtocolManagementWPF")
                    {
                        SearchingForProtocols(queryText, SearchText);
                    }
                    //_CRinstance.Main_Content_Change_Grid.Children.Clear();
                    //_CRinstance.Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl(queryText, SearchText));
                    //SearchEngine_TextBox.Clear();
                    //warningSearchLabel.Visibility = Visibility.Hidden;
                }


                ///////////////////////////////////////////////
                /// do dokończenia działanie wyszukiwarki 
            }

        }

        private void SearchingForUser(string queryText, string SearchText)
        {
            _CRinstance.Main_Content_Change_Grid.Children.Clear();
            _CRinstance.Main_Content_Change_Grid.Children.Add(new UserManagementWPF_UserControl(queryText, SearchText));
            SearchEngine_TextBox.Clear();
            warningSearchLabel.Visibility = Visibility.Hidden;
        }

        private void SearchingForRequests(string queryText, string SearchText)
        {
            _CRinstance.Main_Content_Change_Grid.Children.Clear();
            _CRinstance.Main_Content_Change_Grid.Children.Add(new UserRequestPageWPF(queryText, SearchText));
            SearchEngine_TextBox.Clear();
            warningSearchLabel.Visibility = Visibility.Hidden;
        }
        private void SearchingForTasks(string queryText, string SearchText)
        {
            _CRinstance.Main_Content_Change_Grid.Children.Clear();
            _CRinstance.Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl(queryText, SearchText));
            SearchEngine_TextBox.Clear();
            warningSearchLabel.Visibility = Visibility.Hidden;
        }

        private void SearchingForImportantTasks(string queryText, string SearchText)
        {
            _CRinstance.Main_Content_Change_Grid.Children.Clear();
            _CRinstance.Main_Content_Change_Grid.Children.Add(new AdminMostImportantTasks_USerControl(queryText, SearchText));
            SearchEngine_TextBox.Clear();
            warningSearchLabel.Visibility = Visibility.Hidden;
        }

        private void SearchingForProtocols(string queryText, string SearchText)
        {
            _CRinstance.Main_Content_Change_Grid.Children.Clear();
            _CRinstance.Main_Content_Change_Grid.Children.Add(new ProtocolManagement_UserControl(queryText, SearchText));
            SearchEngine_TextBox.Clear();
            warningSearchLabel.Visibility = Visibility.Hidden;
        }




    }
}
