using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.User;
using GUI_zaliczenie2025.Admin;
using System.Threading;


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

            return rootDirectoryPath;
        }


    }


}
