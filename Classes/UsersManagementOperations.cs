using GUI_zaliczenie2025.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_zaliczenie2025.Classes
{
    internal class UsersManagementOperations
    {
        private static string mySqlQuery= $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user;";
        private static string mySqlQueryDefault= $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user;";
        private SelectedUser_UserControl _SelectedUser;
        private static string loginSelected;
        private static string idSelected;
        private static bool isUserSelected;
        public UsersManagementOperations(){}

        public UsersManagementOperations(SelectedUser_UserControl SelectedUser)
        {
            _SelectedUser = SelectedUser;
            loginSelected= UserManagementWPF_UserControl.TaskLogin;
            idSelected = UserManagementWPF_UserControl.Taskid;
        }
        


        internal static List<User> ReturnUsersListObject(bool isSelected=false)
        {
            mySqlQuery = mySqlQueryDefault;
            isUserSelected = isSelected;
            if (isUserSelected)
            {
                mySqlQuery = $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user WHERE id = '{idSelected}';";
            }

            List<User> Requestors = new List<User>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";


            using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();

                using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Requestors.Add(new User
                            {
                                Id = $"{reader["id"].ToString()}",
                                Name = $"{reader["name"].ToString()}",
                                Surname = $"{reader["surname"].ToString()}",
                                Login = $"{reader["login"].ToString()}",
                                Departament = $"{reader["departament"].ToString()}",
                                Permission = $"{reader["permissions"].ToString()}",
                                Phone_Number = $"{reader["tel"].ToString()}",
                                Email = $"{reader["email"].ToString()}"
                            });

                        }
                        con.Close();
                    }
                }
            }
            isUserSelected=false;


            return Requestors;
        }

        internal static List<User> ReturnDevicesListObject()
        {
            mySqlQuery = $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user;";
            List<User> Requestors = new List<User>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";


            using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();

                using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Requestors.Add(new User
                            {
                                Id = $"{reader["id"].ToString()}",
                                Name = $"{reader["name"].ToString()}",
                                Surname = $"{reader["surname"].ToString()}",
                                Login = $"{reader["login"].ToString()}",
                                Departament = $"{reader["departament"].ToString()}",
                                Permission = $"{reader["permissions"].ToString()}",
                                Phone_Number = $"{reader["tel"].ToString()}",
                                Email = $"{reader["email"].ToString()}"
                            });

                        }
                        con.Close();
                    }
                }
            }
            return Requestors;
        }

        internal static List<Task> ReturnTasksListObject()
        {
            List<Task> Tasks = new List<Task>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";

            

            mySqlQuery = $"SELECT id,location, title, status FROM reports WHERE _user = '{loginSelected}';";

            using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();

                using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Tasks.Add(new Task
                            {
                                Id = $"{reader["id"].ToString()}",
                                Location = $"{reader["location"].ToString()}",
                                Title = $"{reader["title"].ToString()}",
                                Status = $"{reader["status"].ToString()}"

                            });

                        }
                        con.Close();
                    }
                }
            }
            return Tasks;
        }
    }
}
