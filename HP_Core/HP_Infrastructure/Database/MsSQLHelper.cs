using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HP_Infrastructure.Database
{
    public class MsSQLHelper
    {
        public ProviderManager pManager { get; set; }
        private string ConnString { get; set; }
        public MsSQLHelper()
        {
            ConnString = ConfigurationSetting.ConnectionString;
            pManager = new ProviderManager();
        }

        //public static void testing()
        //{
        //    try
        //    {
        //        DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
        //        //for Connection
        //        var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        //        DbConnection connection = factory.CreateConnection();


        //        DbProviderFactory f = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");
        //        using (DbConnection con = f.CreateConnection())
        //        {
        //            con.ConnectionString = "<your connection string>";
        //            con.Open();
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //}
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
            }
            catch (Exception ex)
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
}
