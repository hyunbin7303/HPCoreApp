using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HP_StockDataCollector.Infrastructure.Database
{
    public abstract class CustomRepository<T> where T : class
    {
        private static SqlConnection _conn;
        private static string _connStr = null;
        public CustomRepository(string connStr)
        {
            _connStr = connStr;
            _conn = new SqlConnection(_connStr);
        }
    }
}
