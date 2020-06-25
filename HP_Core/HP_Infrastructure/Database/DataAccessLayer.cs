using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HP_Infrastructure.Database
{
    public class DataAccessLayer : IDatabase
    {
        private string ConnString { get; set; }
        public DataAccessLayer(string _conn){
            ConnString = _conn;
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
        public IDataAdapter CreateAdapter(IDbCommand cmd)
        {
            return new SqlDataAdapter((SqlCommand)cmd);
        }
        public IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection conn)
        {
            return new SqlCommand
            {
                CommandText = cmdText,
                Connection = (SqlConnection)conn,
                CommandType = cmdType
            };
        }
        public IDbDataParameter CreateParameter(IDbCommand cmd)
        {
            SqlCommand sqlCmd = (SqlCommand)cmd;
            return sqlCmd.CreateParameter();
        }
    }
}
