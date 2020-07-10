using HP_StockDataCollector.Domain;
using HP_StockDataCollector.YahooFinance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace HP_StockDataCollector.Test
{
    [TestClass]
    public class YahooFinanceStockAPITest
    {
        #region normalTesting
        [TestMethod]
        public void Call_StockAPI_GetSummary()
        {
            StockAPIcall stockAPIcall = new StockAPIcall();
            var check1 = stockAPIcall.GetSummaryAsync("AMRN", "defaultKeyStatistics");
            Assert.IsNotNull(check1);
        }
        [TestMethod]
        public async Task Call_StockAPI_GetHistoricalDataAsync()
        {
            StockAPIcall stockAPIcall = new StockAPIcall();
            var check1 = await stockAPIcall.GetHistoricalDataAsync("MSFT", 1546448400, 1561046800, "prices", Frequency.Daily, Filter.HistoricalPrices);
            Assert.IsNotNull(check1);
        }
        [TestMethod]
        public async Task Call_StockAPI_GetStatisticAsync()
        {
            StockAPIcall stock = new StockAPIcall();
            var test = await stock.GetStatisticAsync("US", "quoteData." + "AMRN");
            Assert.IsNotNull(test);
            Assert.AreEqual("Amarin Corporation plc", test.ShortName);
        }
        [TestMethod]
        public async Task Call_StockAPI_GetStatisticAllObjAsync()
        {
            StockAPIcall stock = new StockAPIcall();
            var test = await stock.GetStatisticAllAsync("US", "quoteData." + "");
        }
        [TestMethod]
        public async Task Call_StockAPI_GetBalanceSheetAsync()
        {
            StockAPIcall stock = new StockAPIcall();
            var test = await stock.GetBalanceSheetAsync("IBM", "price");
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void Call_StockAPI_GetFinancials()
        {

        }
        #endregion

        #region ExceptionTesting


        #endregion
    }
}
