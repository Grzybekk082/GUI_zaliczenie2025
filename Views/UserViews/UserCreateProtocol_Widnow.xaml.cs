using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using Microsoft.IdentityModel.Tokens;

namespace GUI_zaliczenie2025.Views.UserViews
{
    public partial class UserCreateProtocol_Widnow : Window
    {
        private List<Device> UsedDevices = new List<Device>();
        private string ProtocolDescription;
        private string Login;
        public UserCreateProtocol_Widnow()
        {
            InitializeComponent(); 
            Login= UserTasks_UserControl.login;
            string mySqlQuery = $"SELECT id,brand,model,SerialNumber,Registration_Number,category FROM resources WHERE assignment_technican='{Login}';";
            UsedDevices_DataGrid.ItemsSource = MySqlQueryImplementation.SelectedUserDevicesList_Show(mySqlQuery);
        }


        private void CreateProtocol_buttonClick(object sender, RoutedEventArgs e)
        {
            if (ProtocolDescription_TextBox.Text.IsNullOrEmpty() || ProtocolDescription_TextBox.Text.Length < 10)
            {
                MessageBox.Show("Opis wykonanych czynności musi być uzupełniony i zawierać przynajmniej 10 znaków!",
                    "Błędny opis Protokołu", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ProtocolDescription = ProtocolDescription_TextBox.Text;
                MessageBox.Show(UsedDevices.ToString(), "Napis", MessageBoxButton.OK);

                

            }



        }


        private void SelectUsedDevice_RowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            var hit = e.OriginalSource as DependencyObject;

            while (hit != null)
            {
                if (hit is DataGridColumnHeader)
                {
                    e.Handled = true;
                    return;
                }

                if (hit is TextBlock)
                {
                    if (UsedDevices_DataGrid.SelectedItem != null)
                    {
                        UsedDevices.Add(UsedDevices_DataGrid.SelectedItem as Device);
                    }
                }
                return;
            }
            
        }
    }

}
