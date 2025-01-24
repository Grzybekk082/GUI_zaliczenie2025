using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using System.Windows.Controls;
using System.Windows.Input;

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
            string mySqlQuery = $"SELECT ID_protocol, Protocol, end_date, Id, title, description, location, _user, status, technican, date_of_sla, priorytet, company_name, telephone_number, create_date  FROM reports where status ='Closed' OR status ='Resolved'";
            ProtocolManagment_DataGrid.ItemsSource = MySqlQueryImplementation.ProtocolsQueryImplementation_Show(mySqlQuery);
        }



        private void OpenNewTask_OnClick(object sender, MouseButtonEventArgs e)
        {
            string TaskId = ((ClosedTaskProtocol)ProtocolManagment_DataGrid.SelectedItem).Id;
            this.ProtocolManagement_Grid.Children.Clear();
            this.ProtocolManagement_Grid.Children.Add(new ShowProtocol_UserControl(TaskId));
        }
    }
}
