using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GUI_zaliczenie2025.Admin;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.Admin.ConfirmRequestsOptions;

namespace GUI_zaliczenie2025.Admin
{
    internal class ConfirmRequestsPage:PageCreator
    {
        internal override void Display(Stack<PageCreator> navigationStack)
        {
            for(; ; )
            {
                Console.Clear();
                Console.WriteLine("wybierz prośbę");
                Console.WriteLine();
                for (int i = 0; i < NewUsersRequests.ReturnRequestsListObject().Count; i++)
                {

                    string file = Path.GetFileName($"{NewUsersRequests.ReturnRequestList().GetValue(i)}");
                    string fileName = file.Replace(".txt", "");
                    Console.WriteLine($"{i + 1}. {fileName}");
                }
                Console.WriteLine("0. Wróć");
                int choose = int.Parse(Console.ReadLine());

                if (choose == 0)
                {
                    navigationStack.Pop();
                    Console.Clear();
                    break;
                }
                else if (choose > NewUsersRequests.ReturnRequestsListObject().Count)
                {
                    Console.WriteLine("Wykroczono poza listę próśb spróbuj ponownie");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }
                else
                {
                    navigationStack.Push(new UserRequestPage(choose-1));
                    Console.Clear();
                    break;
                }
            }


        }
 
    }

}

