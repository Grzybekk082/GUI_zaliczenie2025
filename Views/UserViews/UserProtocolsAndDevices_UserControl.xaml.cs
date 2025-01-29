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
using GUI_zaliczenie2025.Classes;

namespace GUI_zaliczenie2025.Views.UserViews
{
    /// <summary>
    /// Logika interakcji dla klasy UserProtocolsAndDevices_UserControl.xaml
    /// </summary>
    public partial class UserProtocolsAndDevices_UserControl : UserControl
    {
        private string Technican;
        public UserProtocolsAndDevices_UserControl()
        {
            InitializeComponent();
            Technican = UserMainPageWPF.Technican;
            string mySqlQuery = $"SELECT ID_protocol, Protocol, end_date, Id, title, description, location, _user, status, technican, date_of_sla, priorytet, company_name, telephone_number, create_date  FROM reports where technican ='{Technican}' AND ( status ='Closed' OR status ='closed');";
            ClosedTasks_DataGrid.ItemsSource = MySqlQueryImplementation.TaskQueryImplementation_Show(mySqlQuery);
            mySqlQuery= $"SELECT id,brand, model, SerialNumber, Registration_Number, category FROM resources WHERE assignment_technican='{Technican}';";
            UserDevices_DataGrid.ItemsSource = MySqlQueryImplementation.SelectedUserDevicesList_Show(mySqlQuery);
        }

        private void EditClosedTask_OnClick(object sender, RoutedEventArgs e)
        {

        }      
        private void EditDevice_OnClick(object sender, RoutedEventArgs e)
        {

        }  
        private void OpenEditTaskWindow_OnClick(object sender, RoutedEventArgs e)
        {

        }     
        private void OpenEditDeviceWindow_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
