using GUI_zaliczenie2025.Classes;
using Mysqlx;
using Mysqlx.Notice;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy CreateAccountPageWPF.xaml
    /// </summary>
    public partial class CreateAccountPageWPF : UserControl
    {
        string newName, newSurename, newLogin, newPassword, newPhoneNumber;
        bool isUpper, isLenght;
        public CreateAccountPageWPF()
        {
            InitializeComponent();
            string logoPath = $"{ProgramSupport.ActualyPathReturn()}\\Logo_ServiceDesk.png";
            MyLogo.Source = new BitmapImage(new Uri(logoPath));


        }

        private void Button_Send_Request_Click(object sender, RoutedEventArgs e)
        {

            newName = textBoxName.Text;
            newSurename = textBoxSurename.Text;
            newPassword = textBoxPassword.Password;
            newPhoneNumber = textBoxPhoneNumber.Text;

            newLogin = $"{newName}.{newSurename}";

            if (String.IsNullOrEmpty(newName) || String.IsNullOrEmpty(newSurename) || String.IsNullOrEmpty(newLogin) || String.IsNullOrEmpty(newSurename) || String.IsNullOrEmpty(newPhoneNumber))
            {
                warningLabel.Foreground = Brushes.IndianRed;
                warningLabel.Content = "Wszystkie pola muszą być wypełnione";
                return;
            }

            newName = char.ToUpper(newName[0]) + newName.Substring(1).ToLower();
            newSurename = char.ToUpper(newSurename[0]) + newSurename.Substring(1).ToLower();

            if (AccountAcces.IsLoginFree(newLogin))
            {
                warningLabel.Content = "Podany login jest zajęty przez istniejącego użytkownika!";

                textBoxPassword.Clear();
                return;
            }

            if (NewUsersRequests.IsRequestLoginFree(newLogin))
            {
                warningLabel.Content = "Prośba z podanym loginem już istnieje.";
                return;
            }
            (bool isUpper, bool isLenght) = AccountAcces.isPasswordReady(newPassword);

            if (!isUpper)
            {
                warningLabel.Foreground = Brushes.IndianRed;
                warningLabel.Content = "Hasło musi zawierać przynajmniej jedną dużą literą";
                return;
            }

            if (!isLenght)
            {
                warningLabel.Foreground = Brushes.IndianRed;
                warningLabel.Content = "Hasło musi składać się przynajmniej z 8 znaków";
                return;
            }

            if (!(newPhoneNumber.Length == 9 && int.TryParse(newPhoneNumber, out int phoneNumber) && phoneNumber > 0))
            {

                warningLabel.Foreground = Brushes.IndianRed;
                warningLabel.Content = "Numer telefonu musi być liczbą całkowitą oraz zawierać 9 znaków";
                return;

            }


            warningLabel.Foreground = Brushes.Black;
            NewUsersRequests nu = new NewUsersRequests(newName, newSurename, newPassword, newLogin, newPhoneNumber);
            warningLabel.Content = "Prośba o utworzenie konta została wysłana do administratora.";
            Thread.Sleep(3000);
            textBoxPassword.Password = String.Empty;
            textBoxName.Text = String.Empty;
            textBoxSurename.Text = String.Empty;
            textBoxPhoneNumber.Text = String.Empty;

















        }





        //AccountAcces ac = new AccountAcces(newName, newSurename, newPassword, newLogin);





        private void Button_Go_back_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new LoginPageWPF();
        }
    }
}








//        //AccountAcces ac = new AccountAcces(newName, newSurename, newPassword, newLogin);
//    }
//}