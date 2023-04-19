using Checo.Repository.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checo.Repository
{
    public class MsSQLRepository : IMsSQLRepository
    {
        public string connectString = "";

        public int InsertDapper(string queryInsert,object obj)
        {
            using (var connection = new SqlConnection(connectString))
            {
                connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        result = connection.Execute(queryInsert, obj);
                        trans.Commit();
                        return result;
                    }
                    catch (System.Exception ex)
                    {
                        trans.Rollback();
                        return -1;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
