using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreApiAngMekanik.Models;
using Dapper;
using Microsoft.Data.SqlClient;


namespace DataLayer
{


    public static class csDB
    {
        private static SqlConnection Connection()
        {
             //connection string
            return new SqlConnection(@"Server=LOCALHOST;Database=dbAngMekanikIslem;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
        private static string cnnString()
        {
            return Connection().ConnectionString;
        }

 

        #region" Users "
        public static async Task<IEnumerable<User>> GetUsers()
        {
            string sql ="SELECT * FROM TBLUSERS"  ;
            List<User>  lstUsers = new List<User>();
             try
            {
                using (var connection = new SqlConnection(cnnString()))
                {
                    lstUsers = connection.QueryAsync<User>(sql).Result.ToList(); 
                }
            }
            catch (Exception ex)
            {
                throw;
            } 

            return lstUsers;
        }

        #endregion




    }
}
