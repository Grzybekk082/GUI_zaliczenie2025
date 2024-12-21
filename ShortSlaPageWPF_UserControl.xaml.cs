using GUI_zaliczenie2025.Classes;
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

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy ShortSlaPageWPF_UserControl.xaml
    /// </summary>
    public partial class ShortSlaPageWPF_UserControl : UserControl
    {
        public ShortSlaPageWPF_UserControl()
        {
            InitializeComponent();
            DataGridShortSla.ItemsSource = ActualTasksOperations.ReturnRequestsListObject();
        }
    }
}
