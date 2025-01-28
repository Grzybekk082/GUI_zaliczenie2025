using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Logika interakcji dla klasy UserShowSelectedTask_UserControl.xaml
    /// </summary>
    public partial class UserShowSelectedTask_UserControl : UserControl
    {
        public static string TaskId;
        public UserShowSelectedTask_UserControl()
        {
            InitializeComponent();
            TaskId = UserTasks_UserControl.Taskid;
            string mySqlQuery = $"SELECT id,title," +
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
                                                    $" FROM reports WHERE id='{TaskId}';";
            this.DataContext = MySqlQueryImplementation.TaskQueryImplementation_Show(mySqlQuery);
        }


        private void CreateProtocol_ButtonClick(object sender, RoutedEventArgs e)
        {
            UserCreateProtocol_Widnow window = new UserCreateProtocol_Widnow();
            window.ShowDialog();

        }
    }
}
