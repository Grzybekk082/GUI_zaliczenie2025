using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GUI_zaliczenie2025.Classes;
using GUI_zaliczenie2025.User;
using GUI_zaliczenie2025.Admin;


namespace GUI_zaliczenie2025.Classes
{
    internal class NewUsersRequests : AccountAcces
    {
        static string name, surename, password, login;
        static string path = Path.Combine($"{ProgramSupport.ActualyPathReturn()}\\Service\\Administration");
        static string directoryPath = Path.Combine($"{ProgramSupport.ActualyPathReturn()}\\Service\\Accounts\\usersData");

        internal NewUsersRequests() { }
        internal NewUsersRequests(string newName, string newSurename, string newPassword, string newLogin)
        {
            name = newName;
            surename = newSurename;
            password = newPassword;
            login = newLogin;
            CreateRequest();
        }

        static void CreateRequest()
        {
            string userId = $"request{ReturnUsersNumber(path) + 1}.txt";
            string userPath = $"{path}\\{userId}";
            string content = $"{name}\n{surename}\n{password}\n{login}";
            File.AppendAllText(userPath, content);
        }

        
        internal static string[]  ReturnRequestList()
        {
            return Directory.GetFiles(path);
        }
        /// <summary>
        /// /////////////////////////////
        /// </summary>
        /// <returns></returns>
        /// Metoda 
        internal static List<Person> ReturnRequestsListObject()
        {
            List<Person> Requestors = new List<Person>();
            for (int i = 1; i<=ReturnRequestNumber();i++)
            {
                string pathUsers = $"{path}\\request{i}.txt";

                string[] allUserData = File.ReadAllLines(pathUsers);


                Requestors.Add(new Person {Name=$"{allUserData[0]}", Surename= $"{allUserData[1]}", Login= $"{allUserData[3]}" });
            }
                
            return Requestors;
        }

        internal static int ReturnRequestNumber()
        {
            return ReturnRequestList().Length;
        }
        static internal bool IsRequestLoginFree(string loginInput)
        {
            bool isLoginOccupied = true;
            string inputLogin = loginInput,
                   corectLogin;

            for (int i = 1; i <= ReturnUsersNumber(path); i++)
            {
                string pathUsers = $"{path}\\request{i}.txt";
                string[] allUserData = File.ReadAllLines(pathUsers);

                corectLogin = allUserData[3];


                if (corectLogin.Equals(inputLogin))
                {
                    isLoginOccupied = false;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return isLoginOccupied;
        }

        

    }
}
