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

            Assert.IsNotNull(getSummary);
            Assert.Equals(getSummary[0].ShortName, "S&P 500");
        }


        [TestMethod]
        public void DisplayData_MarketSummary()
        {
        }

        #endregion
    }
}
