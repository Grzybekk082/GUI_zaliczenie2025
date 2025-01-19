using MySql.Data.MySqlClient;
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

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy TicketsShowUserControlWPF.xaml
    /// </summary>
    public partial class TicketsShowUserControlWPF : UserControl
    {

        internal static List<Classes.Objects.Task> ReturnSelectedTask()
        {
            string taskId = ShortSlaPageWPF_UserControl.Taskid;

            string command = $"SELECT id,title," +
                $" description," +
                $" location," +
                $" _user," +
                $" status," +
                $" date_of_sla," +
                $" priorytet," +
                $" company_name," +
                $" telephone_number," +
                $" create_date" +
                $" FROM reports WHERE id='{taskId}';";
            List<Classes.Objects.Task> SelectedTask = MySqlQueryImplementation.TaskQueryImplementation(command);

            return SelectedTask;
        }
        public TicketsShowUserControlWPF()
        {
            InitializeComponent();
            this.DataContext = ReturnSelectedTask();    
            
        }
    }
}
