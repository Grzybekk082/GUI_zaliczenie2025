﻿using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace GUI_zaliczenie2025.Views.UserViews
{
    public partial class UserCreateProtocol_Widnow : Window
    {
        private List<Device> UsedDevices = new List<Device>();
        private List<Device> BaseListOfDevice = new List<Device>();

        private string ProtocolDescription = null;
        private string Login;
        private string Technican;
        private string ProtocolId;

        int Hours;
        int Minutes;

        private bool IsModified = false;

        private SavedDateTime Date = new SavedDateTime();

        public UserCreateProtocol_Widnow()
        {
            InitializeComponent();
            Technican = UserTasks_UserControl.Technican;
            Login = UserTasks_UserControl.login;
            string mySqlQuery = $"SELECT id,brand,model,SerialNumber,Registration_Number,category FROM resources WHERE assignment_technican='{Technican}';";
            BaseListOfDevice = MySqlQueryImplementation.SelectedUserDevicesList_Show(mySqlQuery);
            UsedDevices_DataGrid.ItemsSource = BaseListOfDevice;
            SelectedUsedDevices_DataGrid.ItemsSource = UsedDevices;
            CreateProtocol_Button.IsEnabled = false;
            AssumedInformation_Grid.Visibility = Visibility.Collapsed;
        }

        public UserCreateProtocol_Widnow(Protocol userProtocol, List<Device> userDevice, bool isModified, string protocolTechnican)
        {
            InitializeComponent();
            this.IsModified = isModified;
            UsedDevices = userDevice;
            SelectedUsedDevices_DataGrid.ItemsSource = UsedDevices;

            ProtocolDescription = ((Protocol)userProtocol).UserDescription;
            ProtocolDescription_TextBox.Text = ProtocolDescription;

            string dateText = ((Protocol)userProtocol).EndTime;
            string[] parts = dateText.Split(new char[] { ' ' });
            string[] parts2 = parts[0].Split(new char[] { '.' });
            string dataTextReplace = $"{parts2[2]}-{parts2[1]}-{parts2[0]} {parts[1]}";
            Date.SavedDate = $"{dataTextReplace}";

            ProtocolId = ((Protocol)userProtocol).ProtocolId;
            Technican = protocolTechnican;
            Login = UserTasks_UserControl.login;

            string mySqlQuery = $"SELECT id,brand,model,SerialNumber,Registration_Number,category FROM resources WHERE assignment_technican='{Technican}';";
            BaseListOfDevice = MySqlQueryImplementation.SelectedUserDevicesList_Show(mySqlQuery);

            CreateWindow_Header.Text = "Modyfikuj stworzony protokół poprzez poprawę czasu, opisu bądz użytych urządzeń";

            UsedDevices_DataGrid.ItemsSource = BaseListOfDevice;
            SelectedUsedDevices_DataGrid.ItemsSource = UsedDevices;
            CreateProtocol_Button.IsEnabled = true;

            CreateProtocol_Button.Content = "Zatwierdz zmiany";
            AssumedInformation_TextBlock.DataContext = Date;
            AssumedInformation_Grid.Visibility = Visibility.Visible;
        }


        private void CreateProtocol_buttonClick(object sender, RoutedEventArgs e)
        {
            if (ProtocolDescription_TextBox.Text.IsNullOrEmpty() || ProtocolDescription_TextBox.Text.Length < 10)
            {

                MessageBox.Show("Opis musi mieć przynajmniej 10 znaków", "Opis nie spełnia wymagań", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //try
                //{
                if (IsModified)
                {
                    string mySqlQuery = $"UPDATE reports SET" +
                                        $" end_date = '{Date.SavedDate}'," +
                                        $"Protocol = '{ProtocolDescription}'" +
                                        $" WHERE ID_protocol ='{ProtocolId}';";
                    MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery);

                    foreach (var device in UsedDevices)
                    {
                        string mySqlQuery2 = $"UPDATE resources SET" +
                                             $" assignment_technican = '{null}'," +
                                             $"used_for_report='{UserProtocolsAndDevices_UserControl.TaskId}'" +
                                             $" WHERE id ='{device.Id}';";
                        MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery2);
                    }

                    foreach (var device in BaseListOfDevice)
                    {
                        string mySqlQuery2 = $"UPDATE resources SET" +
                                             $" assignment_technican = '{Technican}'," +
                                             $"used_for_report='{null}'" +
                                             $" WHERE id ='{device.Id}';";
                        MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery2);
                    }

                    MessageBox.Show("Pomyślnie modyfikowano protokół", "Sukces!", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    mySqlQuery = $"SELECT id,brand, model, SerialNumber, Registration_Number, category FROM resources WHERE assignment_technican='{Technican}';";

                    UserProtocolsAndDevices_UserControl.Instance.UserDevices_DataGrid.ItemsSource = MySqlQueryImplementation.SelectedUserDevicesList_Show(mySqlQuery);
                    UserProtocolsAndDevices_UserControl.Instance.UserDevices_DataGrid.Items.Refresh();
                }
                else
                {
                    string mySqlQuery = $"UPDATE reports SET" +
                                        $" status ='Closed'," +
                                        $"end_date = '{Date.SavedDate}'," +
                                        $"Protocol = '{ProtocolDescription}'" +
                                        $" WHERE ID ='{UserShowSelectedTask_UserControl.TaskId}';";
                    MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery);

                    foreach (var device in UsedDevices)
                    {
                        string mySqlQuery2 = $"UPDATE resources SET" +
                                             $" assignment_technican = NULL," +
                                             $"used_for_report='{UserShowSelectedTask_UserControl.TaskId}'" +
                                             $" WHERE id ='{device.Id}';";
                        MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery2);
                    }

                    MessageBox.Show("Pomyślnie utworzono protokół", "Sukces!", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }


                //}
                //catch (MySqlException ex)
                //{

                //    MessageBox.Show("Błąd przetwarzania prośby!", "Błąd!", MessageBoxButton.OK,
                //        MessageBoxImage.Error);

                //}


            }



        }


        private void SelectUsedDevice_RowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            bool isSelected = false;
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
                        foreach (var device in UsedDevices)
                        {
                            if (device == UsedDevices_DataGrid.SelectedItem as Device)
                            {
                                MessageBox.Show("To urządzenie zostało już wybrane", "Błąd przypisania",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                                isSelected = true;
                            }

                        }
                        if (isSelected)
                        {
                            return;
                        }

                        UsedDevices.Add(UsedDevices_DataGrid.SelectedItem as Device);
                        BaseListOfDevice.Remove(UsedDevices_DataGrid.SelectedItem as Device);
                        UsedDevices_DataGrid.ItemsSource = BaseListOfDevice;
                        UsedDevices_DataGrid.Items.Refresh();
                        SelectedUsedDevices_DataGrid.Items.Refresh();
                        CreateProtocol_Button.IsEnabled = (Date.SavedDate == null || string.IsNullOrEmpty(ProtocolDescription) || ProtocolDescription.Length < 10) ? false : true;

                    }
                }
                return;
            }

        }

        private void RemoveSelectUsedDevice_RowDoubleClick(object sender, MouseButtonEventArgs e)
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
                    if (SelectedUsedDevices_DataGrid.SelectedItem != null)
                    {
                        UsedDevices.Remove(SelectedUsedDevices_DataGrid.SelectedItem as Device);
                        BaseListOfDevice.Add(SelectedUsedDevices_DataGrid.SelectedItem as Device);
                        SelectedUsedDevices_DataGrid.Items.Refresh();
                        UsedDevices_DataGrid.Items.Refresh();
                        CreateProtocol_Button.IsEnabled = (Date.SavedDate == null || string.IsNullOrEmpty(ProtocolDescription) || ProtocolDescription.Length < 10) ? false : true;
                    }
                }
                return;
            }

        }

        private void SaveTime_ButtonOnClick(object sender, RoutedEventArgs e)
        {

            if (ChooseDate_DataPicker.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Nie wybrano daty wykonania zlecenia!", "Brak daty!", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                if (!int.TryParse(Hours_TextBox.Text, out Hours) ||
                    !int.TryParse(Minutes_TextBox.Text, out Minutes))
                {
                    MessageBox.Show("Podany czas musi być liczbą w realnym przedziale godzinowym!", "Błędny format!",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    if (Hours > 23 || Hours < 0 || Minutes > 59 || Minutes < 0)
                    {
                        MessageBox.Show("Podany czas wykracza poza prawidłowy zakres!", "Błędny zakres czasu!",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {

                        string dateText = ChooseDate_DataPicker.Text;
                        string[] parts = dateText.Split(new char[] { '.' });
                        string dataTextReplace = $"{parts[2]}-{parts[1]}-{parts[0]}";
                        Date.SavedDate = $"{dataTextReplace} {Hours_TextBox.Text}:{Minutes_TextBox.Text}:00";

                        AssumedInformation_TextBlock.DataContext = null;
                        AssumedInformation_TextBlock.DataContext = Date;

                        AssumedInformation_Grid.Visibility = Visibility.Visible;
                        CreateProtocol_Button.IsEnabled = (Date.SavedDate == null || string.IsNullOrEmpty(ProtocolDescription) || ProtocolDescription.Length < 10) ? false : true;
                    }
                }
            }

        }

        private void ProtocolDescription_TextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ProtocolDescription = ProtocolDescription_TextBox.Text;
            CreateProtocol_Button.IsEnabled = (Date.SavedDate == null || string.IsNullOrEmpty(ProtocolDescription) || ProtocolDescription.Length < 10) ? false : true;
        }
    }

}
