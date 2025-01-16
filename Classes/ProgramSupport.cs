using System.IO;
using System.Reflection;


namespace GUI_zaliczenie2025.Classes
{
    //Klasa utworzona w celu poprawnienia uniwersalności programu, klasa będzie rozwijana w miare potrzEB
    internal class ProgramSupport
    {
        //Metoda pobiera aktualną ścieżkę głównego folderu programu, aby w przypadku udostępnienia programu 
        //innym lub zmianie lokalizacji programu działał on nadal prawidłowo.
        static internal string ActualyPathReturn()
        {
            string fullPath = Assembly.GetExecutingAssembly().Location;
            string directoryPath = Path.GetDirectoryName(fullPath);
            string parentDirectoryPath = Directory.GetParent(directoryPath).FullName;
            string rootDirectoryPath = Directory.GetParent(parentDirectoryPath).FullName;
            string rootParentDirectoryPath = Directory.GetParent(rootDirectoryPath).FullName;


            return rootParentDirectoryPath;
        }


    }


}
