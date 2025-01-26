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
using System.Windows.Shapes;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;

namespace GUI_zaliczenie2025.Views.UserViews
{

    public partial class UserCreateProtocol_Widnow : Window
    {
        private string Login;
        public UserCreateProtocol_Widnow()
        {
            InitializeComponent(); 
            Login= UserTasks_UserControl.login;
            string mySqlQuery = $"SELECT id,brand,model,SerialNumber,Registration_Number,category FROM resources WHERE assignment_technican='{Login}';";
            UsedDevices_DataGrid.ItemsSource = MySqlQueryImplementation.SelectedUserDevicesList_Show(mySqlQuery);
        }
    }
}
