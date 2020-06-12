using HP_StockDataCollector.YahooFinance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace HP_StockDataCollector.Test
{
    [TestClass]
    public class YahooFiananceMarketAPITest
    {
        [TestMethod]
        public async Task GetSummaryTestAsync()
        {
            MarketAPIcall market = new MarketAPIcall();
            await market.GetSummaryAsync();
        }

        [TestMethod]
        public async Task GetQuotesTestAsync()
        {
            MarketAPIcall market = new MarketAPIcall();
            //What is this symbol value? 
            await market.GetQuotesAsync("BAC,KC=F,002210.KS,IWM,AMECX", "quoteResponse");
        }
    }
}
