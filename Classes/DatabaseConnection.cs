using MySql.Data.MySqlClient;

namespace GUI_zaliczenie2025.Classes
{
    public class DatabaseConnection
    {
        public static MySqlConnectionStringBuilder ConnectionBuilder()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";
            return conn_string;
        }

    }
}
