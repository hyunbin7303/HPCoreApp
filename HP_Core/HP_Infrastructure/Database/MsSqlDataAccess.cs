using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace HP_Infrastructure.Database
{
    public class MsSqlDataAccess : IDatabase, IDisposable
    {
        public  SqlConnection _sqlConn = null;
        private IDatabase database;
        private string ConnString { get; set; }
        public MsSqlDataAccess(){        }
        public MsSqlDataAccess(string _conn){
            ConnString = _conn;

        }
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public IDbConnection CreateConnection()
        {
            try
            {
                _sqlConn = new SqlConnection(ConnString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return _sqlConn;
        }
        public bool CloseConnection()
        {
            if (_sqlConn.State == ConnectionState.Open)
            {
                var getConn = _sqlConn;
                getConn.Close();
                getConn.Dispose();
                Console.WriteLine(_sqlConn.ToString() + "Closed and Disposed");
                return true;
            }
            return false;
        }
        public bool CloseConnection(IDbConnection conn)
        {
            if(conn.State == ConnectionState.Open)
            {
                var getConn = conn;
                getConn.Close();
                getConn.Dispose();
                return true;
            }
            return false;
        }
        public void OpenConnection()
        {
            bool isOpen= _sqlConn.State == ConnectionState.Open ? true : false;
            if (!isOpen) _sqlConn.Open();
        }
        public bool OpenConnection(IDbConnection conn)
        {
            if(conn.State == ConnectionState.Open)
            {
                return false;
            }
            conn.Open();
            return true;
        }
        public IDataAdapter CreateAdapter(IDbCommand cmd)
        {
            return new SqlDataAdapter((SqlCommand)cmd);
        }
        public IDbCommand CreateCommand(string cmdText,IDbConnection conn)
        {
            return new SqlCommand
            {
                CommandText = cmdText, // name of the stored procedure.
                Connection = (SqlConnection)conn,
                CommandType = CommandType.StoredProcedure
            };
        }
        public IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection conn) {return new SqlCommand{CommandText = cmdText,Connection = (SqlConnection)conn,
                CommandType = cmdType};
        }
        // Retrieving data from database.
        public IDataReader GetDataReader(string cmdText,CommandType cmdType,IDbDataParameter[] paras, out IDbConnection conn)
        {
            IDataReader reader = null;
            conn = database.CreateConnection();
            conn.Open();
            var cmd = database.CreateCommand(cmdText, cmdType, conn);
            if(paras != null)
            {
                foreach(var para in paras)
                {
                    cmd.Parameters.Add(para);
                }
            }
            reader = cmd.ExecuteReader();
            return reader;
        }
        // Used for Insertion, Deleting, Update?
        public bool ExecuteNonQuery(IDbCommand cmd, IDbDataParameter[] paras = null)
        {
            try
            {
                SqlCommand sqlCmd = (SqlCommand)cmd;
                if (paras != null)
                {
                    sqlCmd.Parameters.Add(paras);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        public void Dispose()
        {
            Console.WriteLine("Disposed called");
            CloseConnection();
        }

        public DataTable GetDataTable(string cmdText, CommandType cmdType, IDbDataParameter[] paras = null)
        {
            throw new NotImplementedException();
        }

        public DataSet GetDataSet(string cmdText, CommandType cmdType, IDbDataAdapter[] paras = null)
        {
            throw new NotImplementedException();
        }


    }
}


/* ExecuteReader used for getting the query results as a DataReader object. It is readonly forward only retrieval of records and it usees select command to read through the table from the first to the last.
 * ExecuteNonQuery used for executing queries that does not return any data. It is used to execute the sql statements like update insert, delete etc.
 * Execute nonquery executes the command and returns the number of rows affected.
 */