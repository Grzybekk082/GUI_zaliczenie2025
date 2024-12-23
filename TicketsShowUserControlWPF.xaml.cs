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
         
        internal List<Classes.Task> ReturnSelectedTask()
        {
            string taskId = ShortSlaPageWPF_UserControl.Taskid;

            List<Classes.Task> SelectedTask = new List<Classes.Task>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";

            using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT id,title, description, location, _user, status, date_of_sla, company_name, telephone_number FROM reports WHERE id='{taskId}';", con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            SelectedTask.Add(new Classes.Task
                            {
                                Id = $"{reader["id"].ToString()}",
                                Title = $"{reader["title"].ToString()}",
                                Description = $"{reader["description"].ToString()}",
                                Location = $"{reader["location"].ToString()}",
                                User = $"{reader["_user"].ToString()}",
                                Status = $"{reader["status"].ToString()}",
                                SLA = $"{reader["date_of_sla"].ToString()}",
                                Company = $"{reader["company_name"].ToString()}",
                                TelNumber = $"{reader["telephone_number"].ToString()}"
                            });

                        }
                        con.Close();
                    }
                }
            }
            return SelectedTask;
        }
        public TicketsShowUserControlWPF()
        {
            InitializeComponent();


            //DataGridShortSla.ItemsSource = ReturnSelectedTask();
        }
    }
}
