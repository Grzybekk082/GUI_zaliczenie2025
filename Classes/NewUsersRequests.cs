using GUI_zaliczenie2025.Classes.Objects;
using MySql.Data.MySqlClient;




namespace GUI_zaliczenie2025.Classes
{
    internal class NewUsersRequests : AccountAcces
    {
        static string name, surename, password, login, phoneNumber;

        internal NewUsersRequests() { }
        internal NewUsersRequests(string newName, string newSurename, string newPassword, string newLogin, string newPhoneNumber)
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
            MySqlConnection con = DatabaseConnection.ConnectionBuilder();


            using (con)
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand($"INSERT INTO user_requests (Imie, Nazwisko, Haslo, Nr_tel, kolumna_dat) VALUES ('{name}', '{surename}', '{password}', '{phoneNumber}', '{formattedDate}') ;", con))
                {
                    command.ExecuteNonQuery();
                }
            }

        }
        //Metoda zwraca aktualną LISTE obiektów klasy PERSON (id ,imie, nazwisko, login, data wysłania prośby), potrzebna jest do wyświetlania
        //w GUI listy próśb użytkowników
        internal static List<Person> ReturnRequestsListObject()
        {
            List<Person> Requestors = new List<Person>();
            MySqlConnection con = DatabaseConnection.ConnectionBuilder();

            using (con)
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

                            Requestors.Add(new Person
                            {
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
            bool isLoginOccupied = false;
            string inputLogin = loginInput;

            User user = null;
            string mySqlQuery = $"SELECT id FROM user_requests WHERE Login='{inputLogin}';";
            MySqlConnection con = DatabaseConnection.ConnectionBuilder();

            using (con)
            {
                con.Open();

                using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                {
                    command.Parameters.AddWithValue("@login", inputLogin);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            isLoginOccupied = true;
                        }
                    }
                }
                return isLoginOccupied;
            }
        }

    }
}
