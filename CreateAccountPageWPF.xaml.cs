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
            newLogin=textBoxLogin.Text;
            newPassword=textBoxPassword.Text;

            if (!AccountAcces.IsLoginFree(newName))
            {
                warningLabel.Content = "Podany login jest zajęty!";

                textBoxLogin.Clear();
            }
            else
            {
                NewUsersRequests nu = new NewUsersRequests(newName, newSurename, newPassword, newLogin);
                warningLabel.Content = "Prośba o utworzenie konta została wysłana do administratora.";

                //AccountAcces ac = new AccountAcces(newName, newSurename, newPassword, newLogin);
            }
        }
    }
}
