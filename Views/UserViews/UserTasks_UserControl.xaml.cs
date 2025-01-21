using GUI_zaliczenie2025.Classes;
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

namespace GUI_zaliczenie2025.Views.UserViews
{
    /// <summary>
    /// Logika interakcji dla klasy UserTasks_UserControl.xaml
    /// </summary>
    public partial class UserTasks_UserControl : UserControl
    {
        private string login; 
        public UserTasks_UserControl()
        {
            InitializeComponent();
            


            login = UserMainPageWPF.CRperson.CurrentLogin;

            string command = $"SELECT id,title," +
                                                    $" description," +
                                                    $" location," +
                                                    $" _user," +
                                                    $" status," +
                                                    $" technican," +
                                                    $" date_of_sla," +
                                                    $" priorytet," +
                                                    $" company_name," +
                                                    $" telephone_number," +
                                                    $" create_date" +
                                                    $" FROM reports WHERE _user='{login}' AND status !='Closed';";

            List<Classes.Objects.Task> Tasks= MySqlQueryImplementation.TaskQueryImplementation_Show(command);


            UserTasks_DataGrid.ItemsSource = Tasks;

        }



        
    }
}
