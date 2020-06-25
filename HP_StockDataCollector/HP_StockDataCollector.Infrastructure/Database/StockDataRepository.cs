using HP_Infrastructure.Database;
using HP_StockDataCollector.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HP_StockDataCollector.Infrastructure.Database
{
    public class StockDataRepository : IRepository<StockData>
    {
        DataAccessLayer dal = null;
        private static SqlConnection _conn;
        public StockDataRepository(string connStr)
        {
            dal = new DataAccessLayer(connStr);
        }

        public void Delete(StockData entityToDelete)
        {
            _conn = (SqlConnection)dal.CreateConnection();


            dal.CloseConnection(_conn);
        }

        public void Delete(object id)
        {
            _conn = (SqlConnection)dal.CreateConnection();


            dal.CloseConnection(_conn);
        }

        public IEnumerable<StockData> Get(Expression<Func<StockData, bool>> filter = null, Func<IQueryable<StockData>, IOrderedQueryable<StockData>> orderBy = null, string includeProperties = "")
        {

            throw new NotImplementedException();
        }

        public StockData GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockData> GetWithRawSql(string query, params object[] paras)
        {
            throw new NotImplementedException();
        }

        public void Insert(StockData entity)
        {
            using (_conn = (SqlConnection)dal.CreateConnection())
            {
                _conn.Open();
                using

            }



            dal.CloseConnection(_conn);
        }

        public void Update(StockData entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
