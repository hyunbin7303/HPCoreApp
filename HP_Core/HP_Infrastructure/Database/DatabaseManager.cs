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
    // Databse Helper
    public class MsSQLHelper
    {
        public ProviderManager pManager { get; set; }
        private string ConnString { get; set; }
        public MsSQLHelper()
        {
            ConnString = ConfigurationSetting.ConnectionString;
            pManager = new ProviderManager();
        }
        public MsSQLHelper(string connStr)
        {
            ConnString = connStr;
            pManager = new ProviderManager(ConfigurationSetting.GetProviderName(ConnString));
        }
        public DbConnection GetConn()
        {
            try
            {
                var conn = pManager.Factory.CreateConnection();
                conn.ConnectionString = ConnString;
                conn.Open();
                return conn;
            }
            catch (Exception)
            {
                throw new Exception("Error occured duing connection setup. ");
            }
        }
        public bool CloseConn(IDbConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                var getConn = conn;
                getConn.Close();
                getConn.Dispose();
                Console.WriteLine(conn.ToString() + "Closed and Disposed");
                return true;
            }
            else
            {
                Console.WriteLine("Connection was already closed before");
                return false;
            }
        }
        public IDbCommand GetCommand(string cmdText, IDbConnection conn, CommandType cmdType)
        {
            try
            {
                IDbCommand cmd = pManager.Factory.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.Connection = conn;
                cmd.CommandType = cmdType;
                return cmd;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid parameter 'CommandText'." + ex.Message);
            }
        }
        public DbDataAdapter GetDataAdapter(IDbCommand cmd)
        {
            DbDataAdapter adapter = pManager.Factory.CreateDataAdapter();
            adapter.SelectCommand = (DbCommand)cmd;
            adapter.InsertCommand = (DbCommand)cmd;
            adapter.UpdateCommand = (DbCommand)cmd;
            adapter.DeleteCommand = (DbCommand)cmd;
            return adapter;
        }
        public DbParameter GetParameter(string name, object value, DbType dbType)
        {
            try
            {
                DbParameter dbParam = pManager.Factory.CreateParameter();
                dbParam.ParameterName = name;
                dbParam.Value = value;
                dbParam.Direction = ParameterDirection.Input;
                dbParam.DbType = dbType;
                return dbParam;
            } catch (Exception ex)
            {
                throw new Exception("Invalid parameter or type." + ex.Message);
            }
        }
        public DbParameter GetParameter(string name, object value, DbType dbType, ParameterDirection paraDirection)
        {
            try
            {
                DbParameter dbParam = pManager.Factory.CreateParameter();
                dbParam.ParameterName = name;
                dbParam.Value = value;
                dbParam.Direction = paraDirection;
                dbParam.DbType = dbType;
                return dbParam;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid parameter or type." + ex.Message);
            }
        }
        public DbParameter GetParameter(string name, object value, int size, DbType dbType, ParameterDirection paraDirection)
        {
            try
            {
                DbParameter dbParam = pManager.Factory.CreateParameter();
                dbParam.ParameterName = name;
                dbParam.Value = value;
                dbParam.Direction = paraDirection;
                dbParam.DbType = dbType;
                dbParam.Size = size;
                return dbParam;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid parameter or type." + ex.Message);
            }
        }
    }
    public class DatabaseManager : IDatabase, IDisposable
    {
        //public  SqlConnection _sqlConn = null;
        private MsSQLHelper database;
        private string ConnString { get; set; }
        public DatabaseManager(){
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