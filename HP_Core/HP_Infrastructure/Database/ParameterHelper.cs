using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HP_Infrastructure.Database
{
    public class ParameterHelper
    {
        public static IDbDataParameter CreateParameter(string providerName, string name, int size,object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter para = null;
            switch(providerName.ToLower())
            {
                case "system.data.sqlclient":
                    return CreateSqlParameter(name, size, value, dbType, direction);
            }
            return para;
        }
        private static IDbDataParameter CreateSqlParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new SqlParameter { DbType = dbType, Size = size, ParameterName = name, Direction = direction, Value = value };
        }
    }
}
