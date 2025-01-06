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
            // w MainWindow rozpoczyna się działanie programu, tu umiszczac bedziemy wszystkie podstrony itp, tak jak implemenujrmy metody do Program Main

            //Poniżej podmieniamy widok głównego okna MainContent widokiem strony logowania LogInPAgeWPF używająć ich wartości x:name w plikach xaml
            Window window=Window.GetWindow(this);

            //Przywróć przy oddawaniu projektu

            //window.Content = new LoginPageWPF();

            //usuń przed oddaniem>>
            window.Content = new AdminMainPageWPF();
            window.ResizeMode = ResizeMode.CanResize;
            window.WindowState = WindowState.Maximized;
            window.MinWidth = MinWidth = 1000;
        }


    }
}