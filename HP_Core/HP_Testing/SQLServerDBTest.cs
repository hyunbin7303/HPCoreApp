using HP_Infrastructure.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HP_Testing
{
    public class SQLServerDBTest
    {
        private static string connectionString = $"Server= VHW-R90RDFTG\\SQLEXPRESS; Database= HPdatabase; Integrated Security = SSPI;";
        [Test]
        public void TestingConnection()
        {
            bool IsValid = true;
            MsSqlDataAccess dal = new MsSqlDataAccess(connectionString);
            var conn = dal.CreateConnection();
            dal.OpenConnection();
            var close = dal.CloseConnection();
            Assert.IsTrue(close);
        }

        [Test]
        public void TestingUsingConnection()
        {
            using (MsSqlDataAccess dal = new MsSqlDataAccess(connectionString))
            {
                dal.CreateConnection();
                dal.OpenConnection();
            }
        }  



        // Connecting to the Stored procedure.
        [Test]
        public void CallExecuteNonQueryFor_SP_InsertTest()
        {
            bool IsValid = true;
            MsSqlDataAccess dal = new MsSqlDataAccess(connectionString);
            var conn = dal.CreateConnection();
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
            bool IsValid = true;
            MsSqlDataAccess dal = new MsSqlDataAccess(connectionString);
            var conn = dal.CreateConnection();
            dal.OpenConnection();
            var cmd = dal.CreateCommand("SP_DeleteTest", dal._sqlConn);
            var para1 = new SqlParameter("para1", SqlDbType.NVarChar);
            var para2 = new SqlParameter("para2", SqlDbType.NVarChar);
            SqlParameter[] sqlParas ={para1,para2};
            dal.ExecuteNonQuery(cmd, sqlParas);
        }

        [Test]
        public void CallFunctionTesting()
        {
            using (MsSqlDataAccess dal = new MsSqlDataAccess(connectionString))
            {
                dal.CreateConnection();
                dal.OpenConnection();
            }

        }

        [Test]
        public void TestingCallTableData()
        {
            bool IsValid = true;
            MsSqlDataAccess dal = new MsSqlDataAccess(connectionString);
            var conn = dal.CreateConnection();
            //IsValid = dal.OpenConnection(conn);
            ////var cmd = conn.CreateCommand();
            //cmd.CommandTimeout = 30;
            //var adapter=dal.CreateAdapter(cmd);


            //var close = dal.CloseConnection(conn);
            //Assert.IsTrue(close);
        }

    }
}
