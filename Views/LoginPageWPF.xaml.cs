using GUI_zaliczenie2025.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GUI_zaliczenie2025.Views.UserViews;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPageWPF.xaml
    /// </summary>
    public partial class LoginPageWPF : UserControl
    {
        string login, password, newName, newSurename, newPassword, newLogin;
        public CurrentPerson CRperson;
        public LoginPageWPF()
        {
            InitializeComponent();
        }
        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {

            login = textBoxLogin.Text;
            password = textBoxPassword.Text;

            (bool isCorect, bool isAdmin) = AccountAcces.LogIn2(login, password);
            if (isCorect)
            {
                CRperson = new CurrentPerson() { CurrentLogin = login };
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
            if (login == "" || password == "" || !isCorect)
            {
                resultLabel.Foreground = Brushes.Red;
                resultLabel.Content = $"Błędne dane logowania!\nSpróbuj ponownie.";



            }


        }

        private void Button_Create_Account_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new CreateAccountPageWPF();

        }

    }
}
