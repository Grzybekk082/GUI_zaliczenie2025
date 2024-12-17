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




namespace GUI_zaliczenie2025.Classes
{
    internal class NewUsersRequests : AccountAcces
    {
        static string name, surename, password, login;
        static string path = Path.Combine($"{ProgramSupport.ActualyPathReturn()}\\Service\\Administration");
        static string directoryPath = Path.Combine($"{ProgramSupport.ActualyPathReturn()}\\Service\\Accounts\\usersData");

        internal NewUsersRequests() { }
        internal NewUsersRequests(string newName, string newSurename, string newPassword, string newLogin)
        {
            name = newName;
            surename = newSurename;
            password = newPassword;
            login = newLogin;
            CreateRequest();
        }

        static void CreateRequest()
        {
            string userId = $"request{ReturnUsersNumber(path) + 1}.txt";
            string userPath = $"{path}\\{userId}";
            string content = $"{name}\n{surename}\n{password}\n{login}";
            File.AppendAllText(userPath, content);
        }

        //Metoda zwracająca tablicę aktualnych próśb użytkowników
        internal static string[]  ReturnRequestList()
        {
            return Directory.GetFiles(path);
        }
        //Metoda zwraca aktualną LISTE obiektów klasy PERSON (imie, nazwisko, login), potrzebna jest do wyświetlania
        //w GUI listy próśb użytkowników
        internal static List<Person> ReturnRequestsListObject()
        {
            List<Person> Requestors = new List<Person>();
            //for (int i = 1; i<=ReturnRequestNumber();i++)
            //{
            //    string pathUsers = $"{path}\\request{i}.txt";

            //    string[] allUserData = File.ReadAllLines(pathUsers);


            //    Requestors.Add(new Person {Name=$"{allUserData[0]}", Surename= $"{allUserData[1]}", Login= $"{allUserData[3]}" });
            //}
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";

            
            using ( MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT Imie, Nazwisko, Login FROM user_requests;", con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Requestors.Add(new Person { Name = $"{reader["Imie"].ToString()}", Surename = $"{reader["Nazwisko"].ToString()}", Login = $"{reader["Login"].ToString()}" });
                            
                        }
                    }
                }
            }

            return Requestors;
        }
        //Metoda zwracająca aktualną liczbę próśb o dołączenie 
        internal static int ReturnRequestNumber()
        {
            return ReturnRequestList().Length;
        }
        //Metoda sprawdzająca na etapie tworzenia przez użytkownika prośby czy utworzony przez niego login nie 
        //jest już zajęty.
        static internal bool IsRequestLoginFree(string loginInput)
        {
            bool isLoginOccupied = true;
            string inputLogin = loginInput,
                   corectLogin;

            for (int i = 1; i <= ReturnUsersNumber(path); i++)
            {
                string pathRequest = $"{path}\\request{i}.txt";
                string[] allRequestData = File.ReadAllLines(pathRequest);

                corectLogin = allRequestData[3];


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
