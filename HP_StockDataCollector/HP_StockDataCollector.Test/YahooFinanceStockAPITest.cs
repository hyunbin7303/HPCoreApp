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
            //var check2 = stockAPIcall.GetHistoricalDataAsync("MSFT", 1593891928, 1593805528, "firstTradeDate", Frequency.Daily, Filter.HistoricalPrices);
           // Assert.IsNotNull(check1);
            //Assert.IsNotNull(check2);
            await stockAPIcall.TestingAsync();
            Console.WriteLine("CHECK");
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
