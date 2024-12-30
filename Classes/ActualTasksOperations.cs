using Google.Protobuf.WellKnownTypes;
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
        static string mySqlQuery = $"SELECT id,title, description, location, _user, status, date_of_sla, company_name, telephone_number, priorytet, technican, create_date FROM reports;";

        List<Task> SearchList=new List<Task>();
        public ActualTasksOperations() { }
        //public ActualTasksOperations(string id = null, 
        //                            string location=null, 
        //                            string status = null, 
        //                            string technican=null, 
        //                            string company=null, 
        //                            string priority=null)
        //{ 
        //searchQueries= new List<SearchQuery>();
        //    searchQueries.Add(new SearchQuery
        //    {
        //       idQ = id,
        //       locationQ = location,
        //       statusQ = status,
        //       technicanQ = technican,
        //       companyQ = company,
        //       priorityQ = priority
        //    });
            

        //}
        internal static void MessageBoxShowObject( string choose=null, string SearchText=null)
        {
            if(choose != null&& SearchText!=null)
            {
                if(choose=="Id")
                {
                    mySqlQuery = $"select id,title, description, location, _user, status, date_of_sla, company_name, telephone_number, priorytet, technican, create_date from reports where {choose} ={SearchText};";

                }
                else
                {
                    mySqlQuery = $"select id,title, description, location, _user, status, date_of_sla, company_name, telephone_number, priorytet, technican, create_date from reports where upper({choose})  like upper('%{SearchText}%');";

                }

            }
            else
            {
                mySqlQuery = $"select id,title, description, location, _user, status, date_of_sla, company_name, telephone_number, priorytet, technican, create_date from reports;";
            }


            ReturnRequestsListObject();
        }
        internal static List<Task> ReturnRequestsListObject()
        {
            bool isQueryNull=true;
            List<Task> Requestors = new List<Task>();
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3308;
            conn_string.UserID = "root";
            conn_string.Password = "2137";
            conn_string.Database = "servicedeskv2";
            

            using (MySqlConnection con = new MySqlConnection(conn_string.ToString()))
            {
                con.Open();

                using (MySqlCommand command = new MySqlCommand(mySqlQuery, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Requestors.Add(new Task {
                                Id = $"{reader["id"].ToString()}",
                                Title = $"{reader["title"].ToString()}",
                                Description = $"{reader["description"].ToString()}",
                                Location = $"{reader["location"].ToString()}",
                                User = $"{reader["_user"].ToString()}",
                                Status = $"{reader["status"].ToString()}",
                                SLA = $"{reader["date_of_sla"].ToString()}",
                                Company = $"{reader["company_name"].ToString()}",
                                TelNumber = $"{reader["telephone_number"].ToString()}",
                                Priorytet = $"{reader["priorytet"].ToString()}",
                                Technican = $"{reader["technican"].ToString()}",
                                CreateDate = $"{reader["create_date"].ToString()}"

                            });

                        }
                        con.Close();
                    }
                }
            }

            return Requestors;
        }
    }
}
