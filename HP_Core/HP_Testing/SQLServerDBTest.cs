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
            DataAccessLayer dal = new DataAccessLayer(connectionString);
            var conn = dal.CreateConnection();
            IsValid = dal.OpenConnection(conn);
            var cmd = conn.CreateCommand();
            var close = dal.CloseConnection(conn);
            Assert.IsTrue(close);
        }


        // Connecting to the Stored procedure.
        [Test]
        public void CallExecuteNonQueryFor_SP_InsertTest()
        {
            bool IsValid = true;
            DataAccessLayer dal = new DataAccessLayer(connectionString);
            var conn = dal.CreateConnection();
            IsValid =  dal.OpenConnection(conn);
             var cmd = dal.CreateCommand("SP_InsertTest", conn);
            var para1 = new SqlParameter("para1",  SqlDbType.NVarChar);
            SqlParameter[] sqlParas =
            {
                para1
            };
            dal.ExecuteNonQuery(cmd, sqlParas);
        }

        // Connecting to the Stored procedure.
        [Test]
        public void CallExecuteNonQueryFor_SP_DeleteTest()
        {
            bool IsValid = true;
            DataAccessLayer dal = new DataAccessLayer(connectionString);
            var conn = dal.CreateConnection();
            IsValid = dal.OpenConnection(conn);
            var cmd = dal.CreateCommand("SP_DeleteTest", conn);
            var para1 = new SqlParameter("para1", SqlDbType.NVarChar);
            var para2 = new SqlParameter("para2", SqlDbType.NVarChar);
            SqlParameter[] sqlParas ={para1,para2};
            dal.ExecuteNonQuery(cmd, sqlParas);
        }

        [Test]
        public void CallFunctionTesting()
        {
        }

        [Test]
        public void TestingCallTableData()
        {
            bool IsValid = true;
            DataAccessLayer dal = new DataAccessLayer(connectionString);
            var conn = dal.CreateConnection();
            IsValid = dal.OpenConnection(conn);
            var cmd = conn.CreateCommand();
            cmd.CommandTimeout = 30;
            var adapter=dal.CreateAdapter(cmd);


            var close = dal.CloseConnection(conn);
            Assert.IsTrue(close);
        }

    }
}
