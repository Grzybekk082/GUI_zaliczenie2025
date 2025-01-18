using Google.Protobuf.WellKnownTypes;
using GUI_zaliczenie2025.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_zaliczenie2025.Classes
{
    internal class ActualTasksOperations
    {

        //static List<SearchQuery> searchQueries;
        static string mySqlQuery = $"SELECT id,title, description, location, _user, status, date_of_sla, company_name, telephone_number, priorytet, create_date FROM reports;";
        static string modifyMySqlQuery = $"SELECT id,title, description, location, _user, status, date_of_sla, company_name, telephone_number, priorytet, create_date FROM reports;";

        static bool isTextInt = true;

        private static string login= UserManagementWPF_UserControl.TaskLogin;

        public ActualTasksOperations() { }

        //Metoda sprawdzająca czy wprowadzony tekst do wyszukiwarki  TaskSearchButton_click klasy AdminMainPageWPF()  jest liczbą całkowitą
        internal static (string warningLabeltext, bool isTextInt) IsInputInt(string choose, string SearchText)
        {
            if (!int.TryParse(SearchText, out int intSearchText))
            {
                
                return ("Podaj dodatnią liczbę całkowitą", !isTextInt);
            }

            return (null, isTextInt);
        }
        //Metoda zmieniająca kwerendę dla wyszukiwarki w zależności od wyboru filtrowania dla metody TaskSearchButton_click klasy AdminMainPageWPF()
        internal static  List<Task> MessageBoxShowObject(string choose = null, string SearchText = null)
        {
            List<Task> requests;
            isTextInt = true;
           
            
                if(choose=="Id")
                {
                    mySqlQuery = $"select id,title, description, location, _user, status, date_of_sla, company_name, telephone_number, priorytet, create_date from reports where {choose} ={SearchText};";



                }
                else
                {
                    mySqlQuery = $"select id,title, description, location, _user, status, date_of_sla, company_name, telephone_number, priorytet, create_date from reports where upper({choose})  like upper('%{SearchText}%');";
                }

            

            requests= ReturnRequestsListObject();
            return requests;
        }
        //Metoda zwracająca listę obiektów typu Task 
        internal static List<Task> ReturnRequestsListObject(bool forTaskAssign=false)
        {
            if (forTaskAssign)
            {

                mySqlQuery =$"SELECT id,title, description, location, _user, status, date_of_sla, company_name, telephone_number, priorytet, create_date FROM reports WHERE _user != '{AssignToUser_Window.SelectedUserLogin}';";
            }
            List<Task> Requestors = MySqlQueryImplementation.TaskQueryImplementation(mySqlQuery);

            mySqlQuery = modifyMySqlQuery;
            return Requestors;
        }
    }
}
