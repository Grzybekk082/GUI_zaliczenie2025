using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Classes.Objects;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;

namespace GUI_zaliczenie2025.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ShowProtocol_UserControl.xaml
    /// </summary>
    public partial class ShowProtocol_UserControl : UserControl
    {
        private string ProtocolDescription;
        private string ProtocolDescriptionChanges;
        private string TaskId;
        private TextBox textBox;
        private List<ClosedTaskProtocol>? Protocol;
        public ShowProtocol_UserControl(string taskId)
        {

            InitializeComponent();
            TaskId = taskId;
            string mySqlQuery = $"SELECT ID_protocol, Protocol, end_date, Id, title, description, location, _user, status, technican, date_of_sla, priorytet, company_name, telephone_number, create_date  FROM reports where Id ='{TaskId}'";
            Protocol= MySqlQueryImplementation.ProtocolsQueryImplementation_Show(mySqlQuery);

             mySqlQuery = $"SELECT id, brand, model, SerialNumber, Registration_Number, category FROM resources where used_for_report ='{TaskId}'";
            UsedDevices_DataGrid.ItemsSource = MySqlQueryImplementation.SelectedUserDevicesList_Show(mySqlQuery);

            DataContext = Protocol;
            if (!(Protocol != null && Protocol.Any()))
            {
                Console.WriteLine("Kolekcja jest pusta lub null.");
                return;
            }

            var enumerator = Protocol.GetEnumerator();

            if (enumerator.MoveNext())
            {
                ProtocolDescription = enumerator.Current.Protocol_Description;

            }

        }

        private void ChangeProtocolDescription(object sender, System.Windows.RoutedEventArgs e)
        {
 
            textBox = new TextBox();
            textBox.Background=Brushes.AntiqueWhite;
            textBox.Text = ProtocolDescription;
            textBox.TextWrapping= TextWrapping.Wrap;
            textBox.Margin = new Thickness(5, 5, 5, 5);
            textBox.FontSize=14;
            textBox.FontWeight= FontWeights.Bold;
            textBox.Foreground=Brushes.DimGray;
            textBox.Focus();
            
            textBox.AcceptsReturn = true;

            ChangeProtocolDescription_Button.Visibility = Visibility.Hidden;
            CancelChanges_Button.Visibility = Visibility.Visible;
            ConfirmChanges_Button.Visibility = Visibility.Visible;
            ProtocolDescription_Grid.Children.Clear();
            ProtocolDescription_Grid.Children.Add(textBox);
        }



        private void ConfirmChanges_Button_OnClick(object sender, RoutedEventArgs e)
        {
            ProtocolDescriptionChanges = textBox.Text;

            if (ProtocolDescription == ProtocolDescriptionChanges)
            {
                MessageBox.Show("Nie wprowadzono zmian.", "Plik bez zmian", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
            if (ProtocolDescriptionChanges.IsNullOrEmpty())
            {
                MessageBox.Show("Protokół nie może być pusty!", "Próba zapisu pustego dokumentu!", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
            char[] splitChars = ProtocolDescriptionChanges.ToCharArray();
            if (splitChars.Length >= 65534)
            {
                MessageBox.Show("Przekroczono liczbę dozwolonych znaków opisu protokołu!", "Za długi tekst!", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
            try
            {

                string mySqlQuery = $"UPDATE reports SET Protocol ='{ProtocolDescriptionChanges}' WHERE Id = '{TaskId}'";

                MySqlQueryImplementation.GenericMethodTest_Upadate(mySqlQuery);
                string mySqlQuery2 = $"SELECT ID_protocol, Protocol, end_date, Id, title, description, location, _user, status, technican, date_of_sla, priorytet, company_name, telephone_number, create_date  FROM reports where Id ='{TaskId}'";

                ProtocolDescription_TextBlock.DataContext = MySqlQueryImplementation.ProtocolsQueryImplementation_Show(mySqlQuery2);
                MessageBox.Show("Zmiany zostały zapisane.", "Zmiany zapisane", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                ProtocolDescription = ProtocolDescriptionChanges;
                ChangeProtocolDescription_Button.Visibility = Visibility.Visible;
                CancelChanges_Button.Visibility = Visibility.Hidden;
                ConfirmChanges_Button.Visibility = Visibility.Hidden;
                ProtocolDescription_Grid.Children.Clear();
                ProtocolDescription_Grid.Children.Add(ProtocolDescription_TextBlock);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Błąd przetwarzania prośby! " + ex, "Błąd przetwarzania!", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }


        }

        private void CancelChanges_Button_OnClick(object sender, RoutedEventArgs e)
        {
            ChangeProtocolDescription_Button.Visibility = Visibility.Visible;
            CancelChanges_Button.Visibility = Visibility.Hidden;
            ConfirmChanges_Button.Visibility = Visibility.Hidden;
            ProtocolDescription_Grid.Children.Clear();
            ProtocolDescription_Grid.Children.Add(ProtocolDescription_TextBlock);
        }
    }
}
