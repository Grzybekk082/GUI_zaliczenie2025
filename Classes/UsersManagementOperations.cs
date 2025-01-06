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
        static string mySqlQuery = $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user;";
        static string modifyMySqlQuery = $"SELECT id,name, surname, login, departament, permissions, tel, email FROM _user;";

        internal static List<User> ReturnRequestsListObject()
        {

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
    }
}
