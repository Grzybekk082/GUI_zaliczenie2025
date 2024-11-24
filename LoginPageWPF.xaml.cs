using GUI_zaliczenie2025.Classes;
using System;
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
    /// Logika interakcji dla klasy LoginPageWPF.xaml
    /// </summary>
    public partial class LoginPageWPF : UserControl
    {
        string login, password, newName, newSurename, newPassword, newLogin;

        public LoginPageWPF()
        {
            InitializeComponent();
        }
        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            
            login = textBoxLogin.Text;
            password = textBoxPassword.Text;

                bool isCorect = AccountAcces.LogIn(login, password).Item1;
                if (isCorect)
                {
                    bool isAdmin = AccountAcces.LogIn(login, password).Item2;
                    if (isAdmin)
                    {
                        Window window = Window.GetWindow(this);
                        window.Content = new AdminPageWPF();
                    }
                    else
                    {
                        Window window = Window.GetWindow(this);
                        //window.Content = new UserPageWPF();
                        
                    }
                    
                }
                if (login == "" || password == "" || !isCorect)
                {

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
