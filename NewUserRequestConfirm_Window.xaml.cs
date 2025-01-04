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
using System.Windows.Shapes;


namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy NewUserRequestConfirm_Window.xaml
    /// </summary>
    public partial class NewUserRequestConfirm_Window : Window
    {
        internal static List<Classes.Person> ReturnSelectedTask()
        {
            string taskId = UserRequestPageWPF.Taskid;

            List<Classes.Person> SelectedTask = new List<Classes.Person>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";

            using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT " +
                                                               $"id," +
                                                               $"Imie," +
                                                               $" Nazwisko," +
                                                               $" Login," +
                                                               $" kolumna_dat" +
                                                               $" FROM user_requests WHERE id='{taskId}';", con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            SelectedTask.Add(new Classes.Person()
                            {
                                Id = $"{reader["Id"].ToString()}",
                                Name = $"{reader["Imie"].ToString()}",
                                Surename = $"{reader["Nazwisko"].ToString()}",
                                Login = $"{reader["Login"].ToString()}",
                                Date_of_Request = $"{reader["Kolumna_dat"].ToString()}",

                            });

                        }
                        con.Close();
                    }
                }
            }
            return SelectedTask;
        }
        public NewUserRequestConfirm_Window()
        {
            InitializeComponent();
            this.DataContext = ReturnSelectedTask();
        }
    }
}
