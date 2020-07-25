using HP_Infrastructure.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Text;

namespace HP_Testing
{
    public class SQLServerDBTest
    {
        private static string connectionString = $"Server= VHW-R90RDFTG\\SQLEXPRESS; Database= HPdatabase; Integrated Security = SSPI;";
        [Test]
        public void TestingConnection()
        {
            DatabaseManager dal = new DatabaseManager();
        }
        [Test]
        public void TestingUsingConnection()
        {
            using (DatabaseManager dal = new DatabaseManager())
            {

            }
        }

        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Account { get; set; }
        }

        [Test]
        public void SPInsertUser()
        {
            var kObj = new User { FirstName = "Kevin", LastName = "Park", Id = 50, Account ="Kevin12345" };
            DatabaseManager dbManager = new DatabaseManager();
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Account", "Kevin1", DbType.String));
            parameters.Add(dbManager.CreateParameter("@FirstName", "hyunbin", DbType.String));
            parameters.Add(dbManager.CreateParameter("@LastName", "Park", DbType.String));

            //using (DatabaseManager dbManager = new DatabaseManager())
            //{
            //    //dbManager.CreateCommand("SP_InsertUser", CommandType.StoredProcedure, conn);

            //    var parameters = new List<IDbDataParameter>();
            //    parameters.Add(dbManager.CreateParameter("@Account", "Kevin1", DbType.String));
            //    parameters.Add(dbManager.CreateParameter("@FirstName", "hyunbin", DbType.String));
            //    parameters.Add(dbManager.CreateParameter("@LastName", "Park", DbType.String));
            //    dbManager.Insert("SP_InsertUser", CommandType.StoredProcedure, parameters.ToArray());
            //}
        }


        // Connecting to the Stored procedure.
        [Test]
        public void CallExecuteNonQueryFor_SP_InsertTest()
        {
            DatabaseManager dal = new DatabaseManager();
            //var conn = dal.CreateConnection();
            //IsValid =  dal.OpenConnection(conn);
            // var cmd = dal.CreateCommand("SP_InsertTest", conn);
            var para1 = new SqlParameter("para1",  SqlDbType.NVarChar);
            SqlParameter[] sqlParas =
            {
                para1
            };
            //dal.ExecuteNonQuery(cmd, sqlParas);
        }

        // Connecting to the Stored procedure.
        [Test]
        public void CallExecuteNonQueryFor_SP_DeleteTest()
        {
            //DatabaseManager dal = new DatabaseManager(connectionString);
            //var conn = dal.();
            //dal.OpenConnection();
            //var cmd = dal.CreateCommand("SP_DeleteTest", dal._sqlConn);
            //var para1 = new SqlParameter("para1", SqlDbType.NVarChar);
            //var para2 = new SqlParameter("para2", SqlDbType.NVarChar);
            //SqlParameter[] sqlParas ={para1,para2};
            //dal.ExecuteNonQuery(cmd, sqlParas);
        }

        [Test]
        public void CallFunctionTesting()
        {
            //using (DatabaseManager dal = new DatabaseManager(connectionString))
            //{
            //    var conn = dal.CreateConnection();
            //    dal.OpenConnection();
            //    var para1 = new SqlParameter("para1", SqlDbType.NVarChar);
            //    var para2 = new SqlParameter("para2", SqlDbType.NVarChar);
            //    SqlParameter[] sqlParas ={para1,para2};
            //    var checking = dal.GetDataReader("SP_SPname", CommandType.StoredProcedure, sqlParas, out conn);
            //}

        }

        [Test]
        public void TestingCallTableData()
        {
            DatabaseManager dal = new DatabaseManager();
            //var conn = dal.CreateConnection();
            //IsValid = dal.OpenConnection(conn);
            ////var cmd = conn.CreateCommand();
            //cmd.CommandTimeout = 30;
            //var adapter=dal.CreateAdapter(cmd);


            //var close = dal.CloseConnection(conn);
            //Assert.IsTrue(close);
        }

    }
}
