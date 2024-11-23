using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.User;
using GUI_zaliczenie2025.Admin;
using System.IO;

namespace GUI_zaliczenie2025.Admin
{
    internal class MainPageAdmin:PageCreator
    {
        internal override void Display(Stack<PageCreator> navigationStack)
        {
            DataAndFilesManagement.DirectoriesCreator();
            DataAndFilesManagement.DeleteUnnecessaryDirectories();

            Console.WriteLine("Ten użytkownik jest Administratorem serwisu");
            Console.WriteLine();
            Console.WriteLine("1. Potwierdz nowych użytkowników.");
            Console.WriteLine("0. Wyjdź");
            Console.WriteLine();
            Console.Write("Opcja : ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    navigationStack.Push(new ConfirmRequestsPage());
                    Console.Clear();
                    break;

                    //reszta opcji

                case 0:
                    navigationStack.Clear();
                    Console.Clear();
                    break;

            }
        }
    }
}
