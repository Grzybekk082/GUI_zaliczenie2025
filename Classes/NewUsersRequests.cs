using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.User;
using GUI_zaliczenie2025.Admin;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;




namespace GUI_zaliczenie2025.Classes
{
    internal class NewUsersRequests : AccountAcces
    {
        static string name, surename, password, login, phoneNumber;
        static string path = Path.Combine($"{ProgramSupport.ActualyPathReturn()}\\Service\\Administration");
        static string directoryPath = Path.Combine($"{ProgramSupport.ActualyPathReturn()}\\Service\\Accounts\\usersData");




        internal NewUsersRequests() { }
        internal NewUsersRequests(string newName, string newSurename, string newPassword, string newLogin , string newPhoneNumber)
        {
            name = newName;
            surename = newSurename;
            password = newPassword;
            login = newLogin;
            phoneNumber = newPhoneNumber;

            CreateRequest();
        }

        static void CreateRequest()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("yyyy-MM-dd HH-mm-ss");
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";

            using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand($"INSERT INTO user_requests (Imie, Nazwisko, Haslo, Nr_tel, kolumna_dat) VALUES ('{name}', '{surename}', '{password}', '{phoneNumber}', '{formattedDate}') ;", con))
                {
                    command.ExecuteNonQuery();
                }
            }
 
        }

        //Metoda zwracająca tablicę aktualnych próśb użytkowników
        internal static string[]  ReturnRequestList()
        {
            return Directory.GetFiles(path);
        }
        //Metoda zwraca aktualną LISTE obiektów klasy PERSON (id ,imie, nazwisko, login, data wysłania prośby), potrzebna jest do wyświetlania
        //w GUI listy próśb użytkowników
        internal static List<Person> ReturnRequestsListObject()
        {
            List<Person> Requestors = new List<Person>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";

            using ( MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand($"SELECT" +
                                                               $" id, " +
                                                               $" Imie, " +
                                                               $"Nazwisko, " +
                                                               $"Login," +
                                                               $"kolumna_dat, " +
                                                               $"Nr_tel " +
                                                               $"FROM user_requests;", con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Requestors.Add(new Person {
                                Id = $"{reader["Id"].ToString()}",
                                Name = $"{reader["Imie"].ToString()}",
                                Surename = $"{reader["Nazwisko"].ToString()}",
                                Login = $"{reader["Login"].ToString()}",
                                Date_of_Request = $"{reader["Kolumna_dat"].ToString()}",
                                Phone_Number = $"{reader["Nr_tel"].ToString()}",
                            });
                        }
                    }
                }
            }

            return Requestors;
        }

        //}
        //Metoda sprawdzająca na etapie tworzenia przez użytkownika prośby czy utworzony przez niego login nie 
        //jest już zajęty.
        static internal bool IsRequestLoginFree(string loginInput)
        {
            bool isLoginOccupied = true;
            string inputLogin = loginInput,
                   corectLogin;

            List<Person> Requestors = ReturnRequestsListObject();

            foreach (Person person in Requestors) {
                corectLogin = person.Login;


                if (corectLogin.Equals(inputLogin))
                {
                    isLoginOccupied = false;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return isLoginOccupied;
        }



        

    }
}
