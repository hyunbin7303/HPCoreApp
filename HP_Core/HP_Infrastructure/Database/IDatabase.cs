using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HP_Infrastructure.Database
{
    public interface IDatabase
    {
        IDbConnection CreateConnection();
        bool CloseConnection(IDbConnection conn);
        IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection conn);
        IDataAdapter CreateAdapter(IDbCommand cmd);
        IDbDataParameter CreateParameter(IDbCommand cmd);
    }
}
