using System.Diagnostics.Metrics;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Reflection;

namespace GUI_zaliczenie2025.Views.AdminViews
{
    /// <summary>
    /// Logika interakcji dla klasy Administration_Window.xaml
    /// </summary>
    public partial class Administration_Window : Window
    {
        private AdminMainPageWPF CRInstance;
        private int RequestCounter;
        public Administration_Window()
        {
        }
        public Administration_Window(AdminMainPageWPF Instance)
        {
            CRInstance = Instance;
            

            InitializeComponent();
            string mySqlQuery = "SELECT id, name, surname, login, departament, permissions FROM _user WHERE new_password IS NOT NULL";
            PasswordsList_DataGrid.ItemsSource = MySqlQueryImplementation.PasswordChangeList_Show(mySqlQuery);
        }

        private void PasswordsList_DataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var hit = e.OriginalSource as DependencyObject;

            while (hit != null)
            {
                if (hit is DataGridColumnHeader)
                {
                    e.Handled = true;
                    return;
                }

                if (hit is TextBlock)
                {
                    if (PasswordsList_DataGrid.SelectedItem != null)
                    {

                        var selectedItem = PasswordsList_DataGrid.SelectedItem as PasswordRequest;

                        string userId = selectedItem.Id;
                        string userName = selectedItem.Name;
                        string userSurname = selectedItem.Surname;
                        string mySqlQuery = $"SELECT new_password FROM _user WHERE id = '{userId}'";
                        string newPassword = MySqlQueryImplementation.GetNewPassword_Show(mySqlQuery);
                        MessageBoxResult result = MessageBox.Show($"Potwierdzić zmianę hasła dla użytkownika {userName} {userSurname}? Opcja 'NIE' automatycznie usunie prośbę z listy.", "Nowe hasło", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            mySqlQuery = $"UPDATE _user SET password = '{newPassword}', new_password = NULL WHERE id = '{userId}'";
                            MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery);
                            mySqlQuery = "SELECT id, name, surname, login, departament, permissions FROM _user WHERE new_password IS NOT NULL";
                            PasswordsList_DataGrid.ItemsSource = MySqlQueryImplementation.PasswordChangeList_Show(mySqlQuery);
                            RequestCounter = PasswordsList_DataGrid.Items.Count;
                            PasswordsList_DataGrid.Items.Refresh();
                            MessageBox.Show($"Zmieniono hasło dla użytkownika {userName} {userSurname}", "Sukces!", MessageBoxButton.OK, MessageBoxImage.Information);

                            if (RequestCounter == 0)
                            {
                                CRInstance.AdminRequestCounter_Border.Visibility = Visibility.Collapsed;
                            }

                            CRInstance.AdminRequestCounter_TextBlock.Text = RequestCounter.ToString();
                        }
                        if (result == MessageBoxResult.No)
                        {
                            mySqlQuery = $"UPDATE _user SET new_password = NULL WHERE id = '{userId}'";
                            MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery);
                            mySqlQuery = "SELECT id, name, surname, login, departament, permissions FROM _user WHERE new_password IS NOT NULL";
                            PasswordsList_DataGrid.ItemsSource = MySqlQueryImplementation.PasswordChangeList_Show(mySqlQuery);
                            RequestCounter = PasswordsList_DataGrid.Items.Count;
                            PasswordsList_DataGrid.Items.Refresh();
                            MessageBox.Show($"Prośba użytkownika {userName} {userSurname} została usunięta", "Usunięto prośbę", MessageBoxButton.OK, MessageBoxImage.Information);

                            if (RequestCounter == 0)
                            {
                                CRInstance.AdminRequestCounter_Border.Visibility = Visibility.Collapsed;
                            }

                            CRInstance.AdminRequestCounter_TextBlock.Text = RequestCounter.ToString();

                        }

                    }

                }
                return;
            }
        }
    }
}
