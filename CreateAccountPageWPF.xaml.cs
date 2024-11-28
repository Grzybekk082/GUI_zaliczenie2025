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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy CreateAccountPageWPF.xaml
    /// </summary>
    public partial class CreateAccountPageWPF : UserControl
    {
        string newName, newSurename, newLogin, newPassword;
        public CreateAccountPageWPF()
        {
            InitializeComponent();
            

        }

        private void Button_Send_Request_Click(object sender, RoutedEventArgs e)
        {
            
            newName=textBoxName.Text;
            newSurename=textBoxSurename.Text;
            newPassword=textBoxPassword.Password;

            newLogin = $"{newName}.{newSurename}";
            ;
            if (String.IsNullOrEmpty(newName) || String.IsNullOrEmpty(newSurename) || String.IsNullOrEmpty(newLogin) || String.IsNullOrEmpty(newSurename))
            {
                warningLabel.Foreground = Brushes.IndianRed;
                warningLabel.Content = "Wszystkie pola muszą być wypełnione";
            }
            else
            {
                newName = char.ToUpper(newName[0]) + newName.Substring(1).ToLower();
                newSurename = char.ToUpper(newSurename[0]) + newSurename.Substring(1).ToLower();

                if (!AccountAcces.IsLoginFree(newName))
                {
                    warningLabel.Content = "Podany login jest zajęty przez istniejącego użytkownika!";

                    textBoxPassword.Clear();
                }
                else
                {
                    if(!NewUsersRequests.IsRequestLoginFree(newLogin))
                    {
                        warningLabel.Content = "Prośba z podanym loginem już istnieje.";
                    }
                    else 
                    {
                        (bool isUpper, bool isLenght) = AccountAcces.isPasswordReady(newPassword);
                        if (!isUpper)
                        {
                            warningLabel.Foreground = Brushes.IndianRed;
                            warningLabel.Content = "Hasło musi zawierać przynajmniej jedną dużą literą";
                        }
                        else
                        {
                            if (!isLenght)
                            {
                                warningLabel.Foreground = Brushes.IndianRed;
                                warningLabel.Content = "Hasło musi składać się przynajmniej z 8 znaków";
                            }
                            else
                            {
                                warningLabel.Foreground = Brushes.Black;
                                NewUsersRequests nu = new NewUsersRequests(newName, newSurename, newPassword, newLogin);
                                warningLabel.Content = "Prośba o utworzenie konta została wysłana do administratora.";
                                Thread.Sleep(3000);

                            }
                        }
                    }





                    //AccountAcces ac = new AccountAcces(newName, newSurename, newPassword, newLogin);
                }
            }

        }

        private void Button_Go_back_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new LoginPageWPF();
        }
    }
}
