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

namespace GUI_zaliczenie2025.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ProtocolManagement_UserControl.xaml
    /// </summary>
    public partial class ProtocolManagement_UserControl : UserControl
    {
        public ProtocolManagement_UserControl()
        {
            InitializeComponent();
            string mySqlQuery = $"SELECT ID_protocol, Protocol, end_date, Id, title, description, location, _user, status, technican, date_of_sla, priorytet, company_name, telephone_number, create_date  FROM reports where status ='Closed'";
            ProtocolManagment_DataGrid.ItemsSource = MySqlQueryImplementation.ProtocolsQueryImplementation_Show(mySqlQuery);
        }
    }
}
