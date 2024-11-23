using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GUI_zaliczenie2025.Classes;

namespace GUI_zaliczenie2025.Admin.ConfirmRequestsOptions
{
    internal class UserRequestPage:PageCreator
    {
        int requestNumber;

        internal UserRequestPage() { }
        internal UserRequestPage(int index)
        {
            requestNumber=index;
        }
        internal override void Display(Stack<PageCreator> navigationStack)
        {
            string file = Path.Combine($"{NewUsersRequests.ReturnRequestList().GetValue(requestNumber)}");
            StreamReader sr = new StreamReader(file);
            string name = sr.ReadLine();
            string surename = sr.ReadLine();
            string password = sr.ReadLine();
            string login = sr.ReadLine();
            Console.WriteLine(name);
            Console.WriteLine(surename);
            sr.Dispose();
            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine("0. wróć");
            Console.WriteLine("1. Zostań i rozważ prośbę o utworzenie konta");
            Console.Write("Wybierz Opcje: ");

            int choose = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (choose)
            {
                case 0:
                    navigationStack.Pop();
                    Console.Clear();
                break;

                case 1:
                    Console.WriteLine("0. wróć");
                    Console.WriteLine("1. Usuń prośbę");
                    Console.WriteLine("2. Nadaj uprawniena");
                    Console.WriteLine("Wybierz opcję: ");
                    choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 0:
                            navigationStack.Pop();
                        break;

                        case 1:
                            File.Delete(file);
                            Console.WriteLine("prośba usunięta.");
                            Thread.Sleep(2000);
                            Console.Clear();
                        break;

                        case 2:
                            for (; ; )
                            {
                                Console.WriteLine("Admin - wpisz 'true'");
                                Console.WriteLine("User - wpisz 'false'");
                                string permission= Console.ReadLine().ToLower();
                                if(permission =="true"||permission=="false")
                                {
                                    if(permission =="true".ToLower())
                                    {
                                        StreamWriter sw = new StreamWriter(file);
                                        sw.WriteLine($"{name}\n{surename}\ntrue\n{password}\n{login}");
                                        sw.Dispose();
                                        Console.WriteLine("Nadano uprawnienia administratora.");
                                        Thread.Sleep(2000);
                                        Console.Clear() ;
                                        break;
                                    }
                                    else
                                    {
                                        StreamWriter sw = new StreamWriter(file);
                                        sw.WriteLine($"{name}\n{surename}\nfalse\n{password}\n{login}");
                                        sw.Dispose();
                                        Console.WriteLine("Nadano uprawnienia użytkownika.");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    }

                                }
                                else 
                                {
                                    Console.WriteLine("Błędnie podane uprawnienia.");
                                    continue;
                                }
                                
                            }

                        break;
                    }
                
                break;

            }

        }

    }
}
