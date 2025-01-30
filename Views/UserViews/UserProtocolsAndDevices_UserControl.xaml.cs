using GUI_zaliczenie2025.Classes;
using System.Windows;
using System.Windows.Controls;
using GUI_zaliczenie2025.Classes.Objects;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Utilities;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace GUI_zaliczenie2025.Views.UserViews
{
    /// <summary>
    /// Logika interakcji dla klasy UserProtocolsAndDevices_UserControl.xaml
    /// </summary>
    public partial class UserProtocolsAndDevices_UserControl : UserControl
    {
        public string Technican;
        private string UsedForTaskId;
        private string ProtocolId;
        private string ProtocolTechnican;
        public static string TaskId;
        public static UserProtocolsAndDevices_UserControl Instance { get; private set; }
        public UserProtocolsAndDevices_UserControl()
        {
            InitializeComponent();
            Instance = this;
            Technican = UserMainPageWPF.Technican;
            string mySqlQuery = $"SELECT ID_protocol, Protocol, end_date, Id, title, description, location, _user, status, technican, date_of_sla, priorytet, company_name, telephone_number, create_date  FROM reports where technican='{Technican}' AND( status ='Closed' OR status ='closed')";
            ClosedTasks_DataGrid.ItemsSource = MySqlQueryImplementation.ProtocolsQueryImplementation_Show(mySqlQuery);
            mySqlQuery = $"SELECT id,brand, model, SerialNumber, Registration_Number, category FROM resources WHERE assignment_technican='{Technican}';";
            UserDevices_DataGrid.ItemsSource = MySqlQueryImplementation.SelectedUserDevicesList_Show(mySqlQuery);
        }

        private void EditClosedTask_OnClick(object sender, RoutedEventArgs e)
        {

        }
        private void EditDevice_OnClick(object sender, MouseButtonEventArgs e)
        {
            Device device = new Device();
            device.Id = ((Device)UserDevices_DataGrid.SelectedItem).Id;
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
                    if (UserDevices_DataGrid.SelectedItem != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Czy zwrócić urządzenie na główną kolejkę?", "Zwracanie urządzenia", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            try
                            {
                                string mySqlQuery = $"UPDATE resources SET assignment_technican = null WHERE id ='{device.Id}';";
                                MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery);
                                MessageBox.Show("Zwrócono urządzenie na główną kolejkę", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                                mySqlQuery = $"SELECT id,brand, model, SerialNumber, Registration_Number, category FROM resources WHERE assignment_technican='{Technican}';";
                                UserDevices_DataGrid.ItemsSource = MySqlQueryImplementation.SelectedUserDevicesList_Show(mySqlQuery);
                                UserDevices_DataGrid.Items.Refresh();
                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show($"Błąd przetwarzania prośby : {ex}", "Sukces", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                        }
                        else
                        {
                            return;
                        }

                    }
                }
                return;
            }
        }
        private void OpenEditTaskWindow_OnClick(object sender, RoutedEventArgs e)
        {
            if (ClosedTasks_DataGrid.SelectedItem == null)
            {
                MessageBox.Show("Wybierz konkretny protokół dwukrotnym kliknięciem", "Brak wyboru protokołu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                UsedForTaskId = ((ClosedTaskProtocol)ClosedTasks_DataGrid.SelectedItem).Id;
                ProtocolId = ((ClosedTaskProtocol)ClosedTasks_DataGrid.SelectedItem).NewTask_Id;
                TaskId = ((ClosedTaskProtocol)ClosedTasks_DataGrid.SelectedItem).Id;
                ProtocolTechnican = ((ClosedTaskProtocol)ClosedTasks_DataGrid.SelectedItem).Technican;
                string mySqlQueryDevices = $"SELECT id,brand,model,SerialNumber,Registration_Number,category FROM resources WHERE used_for_report ='{UsedForTaskId}';";
                string mySqlQueryProtocol = $"SELECT ID_protocol, Protocol, end_date FROM reports WHERE ID_protocol ='{ProtocolId}';";
                (Protocol ProtocolData, List<Device> DevicesData) dataForEdit = MySqlQueryImplementation.ProtocolModifyQueryImplementation_Show(mySqlQueryProtocol, mySqlQueryDevices);
                UserCreateProtocol_Widnow window = new UserCreateProtocol_Widnow(dataForEdit.ProtocolData, dataForEdit.DevicesData, true, ProtocolTechnican);
                window.ShowDialog();
                UserDevices_DataGrid.Items.Refresh();
            }
        }
        private void OpenEditDeviceWindow_OnClick(object sender, RoutedEventArgs e)
        {

            AssignToUser_Window window = new AssignToUser_Window(true);
            window.ShowDialog();


        }


    }
}
