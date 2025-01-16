using System.IO;


namespace GUI_zaliczenie2025.Classes
{
    internal class DataAndFilesManagement
    {

        static string pathOfDirectory = Path.Combine($"{ProgramSupport.ActualyPathReturn()}\\Service\\Accounts\\usersFiles");
        static string directoryPath = Path.Combine($"{ProgramSupport.ActualyPathReturn()}\\Service\\Accounts\\usersData");
        static string pathOfUsers = Path.Combine();
        static int directoryEqual = Directory.GetDirectories(pathOfDirectory).Length;

        //Metoda każdorazowo przy prawidłowym zalogowaniu się użytkownika sprawdza, czy w folderze userFiles znajdują się podfoldery dla wszystkich
        //użytkowników z folderu userData, jeżeli jest różnica np. został wcześniej dodany nowy użytkownik, metoda utworzy jego folder
        //Po prawidłowym zalogowaniu do serwisu






    }
}
