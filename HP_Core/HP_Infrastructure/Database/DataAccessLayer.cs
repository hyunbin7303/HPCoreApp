using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HP_Infrastructure.Database
{
    public class DataAccessLayer : IDatabase
    {
        private string ConnString { get; set; }
        public DataAccessLayer(){        }
        public DataAccessLayer(string _conn){
            ConnString = _conn;
        }
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnString);
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
        public bool OpenConnection(IDbConnection conn)
        {
            if(conn.State == ConnectionState.Open)
            {
                return false;
            }
            conn.Open();
            return true;
        }



        //WHERE I SHOULD USE CREATE ADAPTER?
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
        public IDataReader GetDataReader(string cmd,IDbDataParameter[] paras, out IDbConnection conn)
        {
            throw new NotImplementedException();
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


    }
}
