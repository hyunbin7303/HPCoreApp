using HP_StockDataCollector.YahooFinance;
using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HP_StockDataCollector
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // MarketAPIcall.GetSummary();
            //StockAPIcall.GetStatistic();
            StockAPIcall stockApp = new StockAPIcall();
            await stockApp.GetHolderAsync("AMRN", "price.quoteSourceName");
            await stockApp.GetBalanceSheetAsync("IBM", "cashflowStatementHistory");
        }

        //public static async Task ExecuteTaskWithTimeoutAsync(TimeSpan timeSpan)
        //{
        //    Console.WriteLine(nameof(ExecuteTaskWithTimeoutAsync));
        //    using(var cancellationTokenSource = new CancellationTokenSource)
        //}

    }
}
