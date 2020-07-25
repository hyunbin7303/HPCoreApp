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
        bool CloseConnection(IDbConnection conn);
        IDbCommand CreateCommand(string cmdText, IDbConnection conn);
        IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection conn);
        IDbDataParameter CreateParameter(string name, object value, DbType dbType);
        IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType);
        IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction);
        IDataAdapter CreateAdapter(IDbCommand cmd);
        IDataReader GetDataReader(string cmdText, CommandType cmdType,IDbDataParameter[] paras, out IDbConnection conn);
        DataTable GetDataTable(string cmdText, CommandType cmdType, IDbDataParameter[] paras = null);
        DataSet GetDataSet(string cmdText, CommandType cmdType, IDbDataAdapter[] paras = null);
        void Delete(string cmdText, CommandType cmdType, IDbDataParameter[] paras = null);
        void Insert(string cmdText, CommandType cmdType, IDbDataParameter[] paras);
    }
}
