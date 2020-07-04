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
            var check1 = stockAPIcall.GetSummaryAsync("US", "AMRN", "defaultKeyStatistics");
        }

        [TestMethod]
        public void Call_StockAPI_GetHistoricalData()
        {
            StockAPIcall stockAPIcall = new StockAPIcall();
            var check1 = stockAPIcall.GetHistoricalDataAsync("MSFT", "");
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
        public void Call_StockAPI_GetBalanceSheet()
        {

        }
        [TestMethod]
        public void Call_StockAPI_GetFinancials()
        {

        }
        #endregion
    }
}
