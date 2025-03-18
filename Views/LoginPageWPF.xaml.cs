using GUI_zaliczenie2025.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GUI_zaliczenie2025.Views.UserViews;
using GUI_zaliczenie2025.Views;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPageWPF.xaml
    /// </summary>
    public partial class LoginPageWPF : UserControl
    {
        private string _login, _password;
        public string Login { get => _login; set => _login=value; }
        public string Password { get => _password; set => _password = value; }

        public CurrentPerson CRperson;
        private int WrongDataCounter=0;
        public LoginPageWPF()
        {
            InitializeComponent();
            ChangePassword_Button.Visibility = Visibility.Collapsed;
            ResetPassword_Label.Visibility = Visibility.Collapsed;
        }
        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {



            Login = textBoxLogin.Text;
            Password = textBoxPassword.Text;

            (bool isCorect, bool isAdmin) = AccountAcces.LogIn2(Login, Password);
            if (isCorect)
            {
                CRperson = new CurrentPerson() { CurrentLogin = Login };
                if (isAdmin)
                {
                    Window window = Window.GetWindow(this);
                    window.Content = new AdminMainPageWPF(CRperson);
                    window.ResizeMode = ResizeMode.CanResize;
                    window.WindowState = WindowState.Maximized;
                    window.MinWidth = MinWidth = 1000;

                }
                else
                {
                    Window window = Window.GetWindow(this);
                    window.Content = new UserMainPageWPF(CRperson);
                    window.ResizeMode = ResizeMode.CanResize;
                    window.WindowState = WindowState.Maximized;
                    window.MinWidth = MinWidth = 1000;

                }

            }
            if (Login == "" || Password == "" || !isCorect)
            {
                resultLabel.Foreground = Brushes.Red;
                resultLabel.Content = $"Błędne dane logowania!\nSpróbuj ponownie.";

                WrongDataCounter++;
                if (WrongDataCounter >2)
                {
                    ResetPassword_Label.Content = $"Nie pamiętasz hasła? Wyślij prośbę do administratora o odzyskanie hasła.";
                    ResetPassword_Label.Visibility = Visibility.Visible;
                    ChangePassword_Button.Visibility = Visibility.Visible;
                }




            }


        }

        private void Button_Create_Account_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new CreateAccountPageWPF();

        }

        private void ChangePassword_Button_OnClick(object sender, RoutedEventArgs e)
        {
            WrongDataCounter = 0;
            ChangePassword_Window window = new ChangePassword_Window();
            window.ShowDialog();
            ResetPassword_Label.Visibility = Visibility.Collapsed;
            ChangePassword_Button.Visibility = Visibility.Collapsed;
            resultLabel.Content = "";

        }
    }
}
