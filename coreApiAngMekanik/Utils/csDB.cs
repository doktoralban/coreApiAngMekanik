using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreApiAngMekanik.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
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

        public static async Task<User> GetUser(string userName)
        {
            string sql = "SELECT TOP 1 * FROM TBLUSERS WHERE USERNAME=@USERNAME ";
            User _user;
            try
            {
                using (var connection = new SqlConnection(cnnString()))
                {
                   _user = await  connection.QueryFirstOrDefaultAsync<User>(sql, 
                       new { USERNAME = userName });
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return _user;
        }
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



        public static async  Task<ActionResult<string>> AddUser(User _user)
        {
            string sql = $@"INSERT INTO  [TBLUSERS] (USERNAME, PASSWORD, ISACTIVE, PHOTOPATH) 
                            VALUES (@USERNAME ,@PASSWORD ,@ISACTIVE ,@PHOTOPATH ) ";

            int affectedRows = 0;
            string result = "";
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
                result = ex.Message;
            }
            if (affectedRows<1)
            {
                result = " Problem! \r\n" + result;
            }
            return new JsonResult( result);
        }

        public static async Task<ActionResult<string>> PutUser(User _user,string userName)
        {
            string sql = $@"UPDATE TBLUSERS SET PASSWORD=@PASSWORD,ISACTIVE=@ISACTIVE,PHOTOPATH=@PHOTOPATH 
                            WHERE USERNAME=@USERNAME ";

            int affectedRows = 0;
            string result = "";
            try
            {
                using (var connection = new SqlConnection(cnnString()))
                { 
                    affectedRows = await connection.ExecuteAsync(sql,
                        new
                        { 
                            USERNAME = userName,
                            PASSWORD = _user.PASSWORD,
                            ISACTIVE = _user.ISACTIVE ,
                            PHOTOPATH = _user.PHOTOPATH
                        });
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            if (affectedRows < 1)
            {
                result = " Problem! \r\n" + result   ;
            }
            return new JsonResult(result);
        }


            #endregion




        }
}
