using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using System.Windows;

namespace GUI_zaliczenie2025.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ChangePassword_Window.xaml
    /// </summary>
    public partial class ChangePassword_Window : Window
    {
        private string TechnicanLogin;
        private string NewPassword;
        private string RepeatNewPassword;
        public ChangePassword_Window()
        {
            InitializeComponent();
        }

        private void SendForChangePassword_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                List<User> selectedUser = new List<User>();
                TechnicanLogin = technicanLogin_TextBox.Text;
                string mySqlQuery = $"SELECT id, name, surname, login, departament, permissions, tel, email " +
                                    $"FROM _user WHERE login ='{TechnicanLogin}'";
                selectedUser = MySqlQueryImplementation.UsersQueryImplementation_Show(mySqlQuery);
                if (selectedUser.Count > 0)
                {
                    NewPassword = NewPassword_TextBox.Password;
                    RepeatNewPassword = RepeatNewPassword_TextBox.Password;
                    if (NewPassword == RepeatNewPassword)
                    {
                        (bool isUpper, bool isLenght) isPasswordCorrect = AccountAcces.isPasswordReady(NewPassword);
                        if (!isPasswordCorrect.isLenght)
                        {
                            MessageBox.Show("Hasło jest za krótkie, przynajmniej 8 znków", "Błędne hasło",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        if (!isPasswordCorrect.isUpper)
                        {
                            MessageBox.Show("Hasło musi zawierać przynajmniej jedną dużą literę", "Błędne hasło",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        if (isPasswordCorrect.isLenght && isPasswordCorrect.isUpper)
                        {
                            try
                            {
                                mySqlQuery = $"UPDATE _user SET new_password ='{NewPassword}' WHERE login = '{TechnicanLogin}'";
                                MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery);
                                MessageBox.Show($"Wysłano prośbę do administratora", "Sukces", MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Błąd przetwarzania prośby : {ex}", "Błąd", MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Błędnie przepisano nowe hasło do drugiej rubryki", "Błędne hasło",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Podano nieistniejący login, spróbuj ponownie.", "Błędny login", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przetwarzania prośby : {ex}", "Błąd", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }
    }
}
