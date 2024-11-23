using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.User;
using GUI_zaliczenie2025.Admin;



namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            string login=textBoxLogin.Text;
            string password=textBoxPassword.Text;
            LoginPageWPF loginPageWPF = new LoginPageWPF();
            loginPageWPF;
        }
    }
}