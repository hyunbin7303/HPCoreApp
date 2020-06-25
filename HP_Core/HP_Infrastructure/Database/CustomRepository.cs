using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HP_Infrastructure.Database
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

        //protected IEnumerable<T> GetDatas(SqlCommand cmd)
        //{
        //    List<T> l = new List<T>();
        //    cmd.Connection = _conn;
        //    _conn.Open();
        //    try
        //    {
        //        var reader = cmd.ExecuteReader();
        //        while(reader.Read())
        //        {
        //            l.Add()
        //        }
        //    }

        //}
        //protected IEnumerable<T> ExeStoredProcedure(SqlCommand cmd)
        //{
        //    List<T> l = new List<T>();
        //    cmd.Connection = _conn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    _conn.Open();
        //    try
        //    {

        //    }catch
        //}

    }
}
