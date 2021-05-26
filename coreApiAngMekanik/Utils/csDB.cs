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



        public static async Task<bool> AddUser(User _user)
        {
            string sql = $@"INSERT INTO [dbo].[TBLUSERS] (USERNAME, PASSWORD, ISACTIVE, PHOTOPATH) 
                            VALUES (@USERNAME ,@PASSWORD ,@ISACTIVE ,@PHOTOPATH ) ";

            int affectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(cnnString()))
                {
                      affectedRows = await connection.ExecuteAsync(sql, 
                          new { USERNAME =  _user.USERNAME,
                              PASSWORD = _user.PASSWORD,
                              ISACTIVE = _user.ISACTIVE,
                              PHOTOPATH = _user.PHOTOPATH
                          });
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return affectedRows > 0;
        }
        #endregion




    }
}
