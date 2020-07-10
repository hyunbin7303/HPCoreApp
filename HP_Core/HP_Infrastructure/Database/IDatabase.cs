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
        bool CreateConnection();

        void OpenConnection();
        bool OpenConnection(IDbConnection conn);
        bool CloseConnection();
        bool CloseConnection(IDbConnection conn);
        IDbCommand CreateCommand(string cmdText, IDbConnection conn);
        IDataAdapter CreateAdapter(IDbCommand cmd);
        IDataReader GetDataReader(string cmdText, IDbDataParameter[] paras, out IDbConnection conn);


    }
}
