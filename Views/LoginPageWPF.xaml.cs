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
        public CurrentPerson CRperson;
        public LoginPageWPF()
        {
            InitializeComponent();
        }
        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            
            login = textBoxLogin.Text;
            password = textBoxPassword.Text;

                (bool isCorect, bool isAdmin)  = AccountAcces.LogIn2(login, password);
                if (isCorect)
                {
                    
                    if (isAdmin)
                    {
                        CRperson = new CurrentPerson() { CurrentLogin = login };
                        Window window = Window.GetWindow(this);
                        window.Content = new AdminMainPageWPF(CRperson);
                        window.ResizeMode=ResizeMode.CanResize;
                        window.WindowState= WindowState.Maximized;
                        window.MinWidth = MinWidth = 1000;
                        
                    }
                    else
                    {
                        Window window = Window.GetWindow(this);
                        //window.Content = new UserPageWPF();
                        
                    }
                    
                }
                if (login == "" || password == "" || !isCorect)
                {
                resultLabel.Foreground= Brushes.Red;
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
