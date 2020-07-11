using HP_Infrastructure.Database;
using HP_StockDataCollector.YahooFinance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HP_StockDataCollector.Test
{
    public class SQL_MarketDataTest
    {
        #region NormalTest_Market
        [TestMethod]
        public async Task InsertDataIn_MarketSummary()
        {
            MarketAPIcall market = new MarketAPIcall();
            var getSummary = await market.GetSummaryAsync();

            // Call stored procedure 
            DataAccessLayer dal = new DataAccessLayer();
            dal.GetConnectionString("");
            var check = dal.CreateConnection();
            //dal.OpenConnection(check);
            //dal.CloseConnection(check);

            Assert.IsNotNull(getSummary);
            Assert.Equals(getSummary[0].ShortName, "S&P 500");
        }


        [TestMethod]
        public void DisplayData_MarketSummary()
        {
            using(DataAccessLayer dal = new DataAccessLayer())
            {
                if(dal.CreateConnection())
                {
                }
            }
        }

        #endregion
    }
}
