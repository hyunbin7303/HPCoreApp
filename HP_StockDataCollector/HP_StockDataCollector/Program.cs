using HP_StockDataCollector.YahooFinance;
using RestSharp;
using System;
namespace HP_StockDataCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            MarketAPIcall.GetSummary();
            //StockAPIcall.GetStatistic();
        }


    }
}
