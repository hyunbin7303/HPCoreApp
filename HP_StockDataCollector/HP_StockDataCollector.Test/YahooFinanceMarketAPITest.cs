using HP_StockDataCollector.Domain;
using HP_StockDataCollector.YahooFinance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HP_StockDataCollector.Test
{
    [TestClass]
    public class YahooFinanceMarketAPITest
    {
        #region NormalTest_Market
        [TestMethod]
        public async Task GetSummaryTesting()
        {
            MarketAPIcall market = new MarketAPIcall();
            var getSummary = await market.GetSummaryAsync();
            Assert.IsNotNull(getSummary);
            Assert.Equals(getSummary[0].ShortName, "S&P 500");
        }
        [TestMethod]
        public async Task GetQuotesTestNormalTesting()
        {
            MarketAPIcall market = new MarketAPIcall();
            var quotelist = await market.GetQuotesAsync("BAC", "quoteResponse.result");
            var quotelist2 = await market.GetQuotesAsync("BAC,KC=F", "quoteResponse.result");
            var quotelist3 = await market.GetQuotesAsync("BAC,KC=F,002210.KS", "quoteResponse.result");
            var quotelist4 = await market.GetQuotesAsync("BAC,KC=F,002210.KS,IWM,AMECX", "quoteResponse.result");

            Assert.IsNotNull(quotelist);
            Assert.IsNotNull(quotelist2);
            Assert.IsNotNull(quotelist3);
            Assert.IsNotNull(quotelist4);
        }

        [TestMethod]
        public async Task GetMoversAsyncTesting()
        {
            MarketAPIcall market = new MarketAPIcall();
            var moverTest = await market.GetMoverAPIAsync();
            Assert.IsNotNull(moverTest);
        }
        [TestMethod]
        public async Task GetAutoCompleteTesting()
        {
            MarketAPIcall market = new MarketAPIcall();
            var moverTest = await market.GetAutoCompleteAsync("nbe");
            Assert.IsNotNull(moverTest);
        }
        #endregion

        #region ExceptionTest_Market
        public async Task ExceptionTest()
        {
            var market = new MarketAPIcall();
            var quotelist = await market.GetQuotesAsync("BAC,KC=F", "quoteResponse.result");
            Assert.ThrowsException<System.ArgumentException>(() => quotelist.Count);
        }
        #endregion

        #region NormalTest_Stock
        #endregion




        public async Task GetChartTestAsync()
        {
            MarketAPIcall market = new MarketAPIcall();
            //What is this symbol value? 
            //await market.GetChartAsync();
        }
    }
}
