using MySql.Data.MySqlClient;
using System.IO;
using System.Windows;

namespace GUI_zaliczenie2025.Classes
{
    internal class AccountAcces
    {

        internal AccountAcces() { }
        //Konstruktor, Pobiera od nowego użytkownika podstawowe dane logowania i wywołuje w sobie funkcję tworzącą nowe konto.


        //Metoda sprawdza, czy Login podany przez nowego użytkownika nie istnieje już w bazie, porównuje ze sobą inputLogin
        //podany przez użytkownika oraz corectLogin wyczytany z pierwszej linii w każdym pliku w folderze userData
        static internal bool IsLoginFree(string loginInput)
        {
            bool isLoginOccupied = false;
            string inputLogin = loginInput.ToLower();

                
            User user = null;
            string mySqlQuery = $"SELECT id FROM _user WHERE login='{inputLogin}';";
            MySqlConnection con = DatabaseConnection.ConnectionBuilder();

            using (con)
            {
                con.Open();

                using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                {
                    // Użycie parametrów zapytania dla uniknięcia SQL Injection
                    command.Parameters.AddWithValue("@login", inputLogin);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Sprawdzamy, czy są jakieś wyniki
                        if (reader.HasRows)
                        {
                            isLoginOccupied = true;
                        }
                    }
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
            MySqlConnection con = DatabaseConnection.ConnectionBuilder();
            try
            {
                using (con)
                {
                    con.Open();

                    using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                person = new User()
                                {
                                    Permission = reader["permissions"].ToString()
                                };
                                
                                isCorect = true; 

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




        //Metoda sprawdza, czy wprowadzone hasło spełnia wymagania aplikacji, czyli 1 duża litera i długość > 8
        static internal (bool isUpper, bool isLenght) isPasswordReady(string input)
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
                isLenght = true;
            }
            return (isUpper, isLenght);
        }


    }
}
