using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
// source from : http://csharpdocs.com/generic-data-access-layer-in-c-using-dbproviderfactories/

namespace HP_Infrastructure.Database
{

    public class DatabaseManager : IDatabase, IDisposable
    {
        //public  SqlConnection _sqlConn = null;
        private MsSQLHelper database;
        public DatabaseManager(){
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            database = new MsSQLHelper();
        }
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public bool CloseConnection(IDbConnection conn)
        {
            return database.CloseConn(conn);
        }
        public void OpenConnection(IDbConnection conn)
        {
            bool isOpen = conn.State == ConnectionState.Open ? true : false;
            if (!isOpen)
            {
                conn.Open();
            }
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
        public IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection conn) 
        {
            return new SqlCommand{CommandText = cmdText,Connection = (SqlConnection)conn,CommandType = cmdType};
        }
        // Retrieving data from database.
        public IDataReader GetDataReader(string cmdText,CommandType cmdType,IDbDataParameter[] paras, out IDbConnection conn)
        {
            IDataReader reader = null;
            conn = database.GetConn();
            var cmd = database.GetCommand(cmdText, conn, cmdType);
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
           //TODO change later! CloseConnection();
        }
        public DataTable GetDataTable(string cmdText, CommandType cmdType, IDbDataParameter[] paras = null)
        {
            using (var conn =database.GetConn())
            {
                using(var cmd = database.GetCommand(cmdText, conn, cmdType))
                {
                    if(paras != null)
                    {
                        foreach(var para in paras)
                        {
                            cmd.Parameters.Add(para);
                        }
                    }
                    var dataset = new DataSet();
                    var dataAdapter = database.GetDataAdapter(cmd);
                    dataAdapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
        public DataSet GetDataSet(string cmdText, CommandType cmdType, IDbDataAdapter[] paras = null)
        {
            using (var conn = database.GetConn())
            {
                using (var cmd = database.GetCommand(cmdText, conn, cmdType))
                {
                    if(paras != null)
                    {
                        foreach(var para in paras)
                        {
                            cmd.Parameters.Add(para);
                        }
                    }
                    var dataSet = new DataSet();
                    var dataAdapter = database.GetDataAdapter(cmd);
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }
        public void Delete(string cmdText, CommandType cmdType, IDbDataParameter[] paras = null)
        {
            using(var conn = database.GetConn())
            {
                using(var cmd = database.GetCommand(cmdText, conn,cmdType))
                {
                    if(paras != null)
                    {
                        foreach(var para in paras)
                        {
                            cmd.Parameters.Add(para);
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public void Insert(string cmdText, CommandType cmdType, IDbDataParameter[] paras)
        {
            using (var conn = database.GetConn())
            {
                using(var cmd = database.GetCommand(cmdText, conn, cmdType))
                {
                    if(paras != null)
                    {
                        foreach(var para in paras)
                        {
                            cmd.Parameters.Add(para);
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IDbDataParameter CreateParameter(string name, object value, DbType dbType)
        {
            return database.GetParameter(name, value, dbType, ParameterDirection.Input);
        }
        public IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType)
        {
            return database.GetParameter(name, value, size, dbType, ParameterDirection.Input);
        }
        public IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return database.GetParameter(name, value, size, dbType, direction);
        }

    }
}
/* ExecuteReader used for getting the query results as a DataReader object. It is readonly forward only retrieval of records and it usees select command to read through the table from the first to the last.
 * ExecuteNonQuery used for executing queries that does not return any data. It is used to execute the sql statements like update insert, delete etc.
 * Execute nonquery executes the command and returns the number of rows affected.
 */