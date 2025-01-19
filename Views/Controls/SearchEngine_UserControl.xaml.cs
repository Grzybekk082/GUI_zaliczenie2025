using GUI_zaliczenie2025.Classes;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;
using GUI_zaliczenie2025.Classes.Objects;

namespace GUI_zaliczenie2025.Views.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy SearchEngine_UserControl.xaml
    /// </summary>
    public partial class SearchEngine_UserControl : UserControl
    {
        private AdminMainPageWPF _CRinstance;
        private string _MotherClass;
        private Dictionary<int, string> searchList;

        public SearchEngine_UserControl()
        {
        }
        public SearchEngine_UserControl(AdminMainPageWPF Instacne, string MotherClass)
        {
            _MotherClass = MotherClass;
            _CRinstance = Instacne;
            InitializeComponent();
            if (MotherClass == "UserManagementWPF")
            {
                searchList = new Dictionary<int, string>()
                {
                    {1,"Imię"},
                    {2,"Nazwisko"},
                    {3,"Login"}
                };
            }
            if (MotherClass == "UserManagementWPF")
            {
                searchList = new Dictionary<int, string>()
                {
                    {1,"Imię"},
                    {2,"Nazwisko"},
                    {3,"Login"}
                };
            }
        }


        internal void TaskSearchButton_click(object sender, RoutedEventArgs e)
        {
            SearchEngine_ComboBox.Items.Clear();
            SearchEngine_ComboBox.ItemsSource = searchList;


            string choose = SearchEngine_ComboBox.Text;
            string SearchText = SearchEngine_TextBox.Text;
            (string warningText, bool isInt) IsInputIntReturns = ActualTasksOperations.IsInputInt(choose, SearchText);
            if (choose.IsNullOrEmpty() || SearchText.IsNullOrEmpty())
            {

                warningSearchLabel.Visibility = Visibility.Visible;

                warningSearchLabel.Content = "Pole wyszukiwania i lista rozwijana muszą być uzupełnione !";
                ComboBox comboBox = SearchEngine_ComboBox;

                comboBox.Items.Clear();
            }
            else
            {
                if (choose == "Id")
                {
                    if (IsInputIntReturns.isInt)
                    {
                        _CRinstance.Main_Content_Change_Grid.Children.Clear();
                        _CRinstance.Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl(choose, SearchText));
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
                    _CRinstance.Main_Content_Change_Grid.Children.Clear();
                    _CRinstance.Main_Content_Change_Grid.Children.Add(new ShortSlaPageWPF_UserControl(choose, SearchText));
                    SearchEngine_TextBox.Clear();
                    warningSearchLabel.Visibility = Visibility.Hidden;
                }


                ///////////////////////////////////////////////
                /// do dokończenia działanie wyszukiwarki 
            }

        }

        
        


    }
}
