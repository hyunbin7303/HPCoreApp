using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HP_Infrastructure.Database
{
    public interface IDatabase
    {
        IDbConnection CreateConnection();

        void OpenConnection();
        bool OpenConnection(IDbConnection conn);
        bool CloseConnection();
        bool CloseConnection(IDbConnection conn);
        IDbCommand CreateCommand(string cmdText, IDbConnection conn);
        IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection conn);
        IDataAdapter CreateAdapter(IDbCommand cmd);
        IDataReader GetDataReader(string cmdText, CommandType cmdType,IDbDataParameter[] paras, out IDbConnection conn);

        DataTable GetDataTable(string cmdText, CommandType cmdType, IDbDataParameter[] paras = null);
        DataSet GetDataSet(string cmdText, CommandType cmdType, IDbDataAdapter[] paras = null);
    }
}
