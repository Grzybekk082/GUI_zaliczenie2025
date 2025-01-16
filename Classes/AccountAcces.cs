using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.User;
using GUI_zaliczenie2025.Admin;
using MySql.Data.MySqlClient;

namespace GUI_zaliczenie2025.Classes
{
       internal class AccountAcces
    {
        string userName, userSurename, userPassword, userLogin, userPermissions;

        static string directoryPath = Path.Combine($"{ProgramSupport.ActualyPathReturn()}\\Service\\Accounts\\usersData");

        //ścieżka do folderu z plikami "user#", przechowuje podstawowe dane logowania do konta(imie, nazwisko, login, hasło

         static string inputLogin,
                        inputPassword,
                        corectLogin,
                        corectPassword,
                        isAdmin;

        internal AccountAcces() { }
        //Konstruktor, Pobiera od nowego użytkownika podstawowe dane logowania i wywołuje w sobie funkcję tworzącą nowe konto.
        internal AccountAcces(string name, string surename, string permissions, string password, string login)
        {
            
            userName = name;
            userSurename = surename;
            userPassword = password;
            userLogin = login;
            userPermissions = permissions;

            AccountCreator(userName, userSurename, userPermissions, userPassword, userLogin);
            DataAndFilesManagement.DirectoriesCreator();
        }
        
        //Metoda sprawdza, czy Login podany przez nowego użytkownika nie istnieje już w bazie, porównuje ze sobą inputLogin
        //podany przez użytkownika oraz corectLogin wyczytany z pierwszej linii w każdym pliku w folderze userData
        static internal bool IsLoginFree( string loginInput)
        {
         bool isLoginOccupied = true;
        string inputLogin = loginInput,
               corectLogin;

            for (int i = 1; i <= ReturnUsersNumber(directoryPath); i++)
            {
                string pathUsers = $"{directoryPath}\\user{i}.txt";

                string[] allUserData = File.ReadAllLines(pathUsers);

                corectLogin = allUserData[3];

                if (corectLogin.Equals(inputLogin))
                {
                    isLoginOccupied = false;
                }
                else
                {
                    if (i == ReturnUsersNumber(directoryPath))
                    {
                        break;
                    }
                    continue;
                }
            }
            return isLoginOccupied;
        }
        //metoda porównuje uzyskane z metody zwrócone wartości prawidłowego loginu i hasła z danymi wprowadzonymi przez
        //użytkownika próbującego się zalogować i jeżeli takie dane istnieją w pojedynczym pliku "user#" użytkownik zostanie prawidłowo
        //zalogowany TOTLE


        static internal (bool, bool) LogIn2(string login, string password)
        {
            User person = null;
            string inputLogin = login,
                inputPassword = password;
            bool isCorect = false, isAdmin = false;
            string mySqlQuery = $"SELECT permissions FROM _user WHERE login='{inputLogin}' AND password='{inputPassword}'";
            MySqlConnectionStringBuilder conn_string = DatabaseConnection.ConnectionBuilder();
            try
            {
                using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
                {
                    con.Open();

                    using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) // Iterujemy przez wyniki zapytania
                            {
                                // Tworzenie obiektu User na podstawie danych z bazy
                                person = new User()
                                {
                                    Permission = reader["permissions"].ToString()
                                };

                                // Sprawdzanie uprawnień użytkownika
                                isCorect = true; // Jeśli dane zostały znalezione, zakładamy, że jest poprawny

                                if (person.Permission == "admin")
                                {
                                    isAdmin = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Błąd połączenia z bazą", "Błąd połączenia!", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            return (isCorect, isAdmin);
        }


        //////////////////////////////////
        //Metoda mająca za zadanie jedynie utworzenie pliku .txt z nowym użytkownikiem, jest wywoływana w konstruktorze
        internal void AccountCreator(string name, string surename, string permissions, string password, string login)
        {
                string userId = $"user{ReturnUsersNumber(directoryPath) + 1}.txt";
                string userPath = $"{directoryPath}\\{userId}";
                userLogin = $"{userName}.{userSurename}";
                string content = $"{userName}\n{userSurename}\n{userPermissions}\n{userPassword}\n{userLogin}\n";

                File.AppendAllText(userPath,content);
        }
        

        //Metoda korzystająca z tutle, zwracająca z folderu userData z plików "user#" prawidłowy login i hasło, dzięki tutle
        //można zwracać więcej wartości na raz.
        internal static (string , string, string )  ReturnInfo( int i)
        {

                string pathUsers = $"{directoryPath}\\user{i}.txt";
                string [] allUserData=File.ReadAllLines(pathUsers);

                corectPassword = allUserData[2];
                corectLogin = allUserData[3];
                isAdmin = allUserData[4];


            return (corectLogin,  corectPassword, isAdmin);
        }
        //Oblicza i zwraca aktualną liczbę użytkownikó w folderze userData

        static internal int ReturnUsersNumber(string path)
        {
            return Directory.GetFiles(path).Length;
        }
        //Metoda sprawdza, czy wprowadzone hasło spełnia wymagania aplikacji, czyli 1 duża litera i długość > 8
        static internal (bool isUpper,bool isLenght) isPasswordReady(string input)
        {
            char[] inputTab = input.ToCharArray();
            bool isUpper = false;
            bool isLenght = false;
            foreach (char c in inputTab)
            {
                if (char.IsUpper(c))
                {
                    isUpper = true;
                    break;
                }
            }
            if (input.Length > 8)
            {
                isLenght=true;
            }
            return (isUpper, isLenght);
        }


    }
}
