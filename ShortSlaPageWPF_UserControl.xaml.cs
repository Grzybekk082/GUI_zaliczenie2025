using Google.Protobuf.WellKnownTypes;
using GUI_zaliczenie2025.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
using Task = GUI_zaliczenie2025.Classes.Task;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy ShortSlaPageWPF_UserControl.xaml
    /// </summary>
    public partial class ShortSlaPageWPF_UserControl : UserControl
    {
        public static string Taskid;
        
        public ShortSlaPageWPF_UserControl()
        {
            InitializeComponent();
            DataGridShortSla.ItemsSource = ActualTasksOperations.ReturnRequestsListObject();

            
        }
        public ShortSlaPageWPF_UserControl(string choose ,string search)
        {
            InitializeComponent();
            DataGridShortSla.ItemsSource = ActualTasksOperations.MessageBoxShowObject(choose,search);

        }
        private void RowDoubleClicktask(object sender, RoutedEventArgs e)
        {
            Taskid = null;
            var selectedItem = DataGridShortSla.SelectedItem as Task; 

            if (selectedItem != null)
            {
                string selectedValue = selectedItem.Id;
                Taskid += selectedValue;

            }
            GridShortSla.Children.Clear();
            GridShortSla.Children.Add(new TicketsShowUserControlWPF());
        }


    }
}
