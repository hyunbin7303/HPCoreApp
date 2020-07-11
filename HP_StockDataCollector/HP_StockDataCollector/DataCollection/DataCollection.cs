using HP_Infrastructure.Database;
using HP_StockDataCollector.Domain;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HP_StockDataCollector.DataCollection
{
    public class DataCollection
    {
        public List<StockData> stockList { get; set; } = new List<StockData>();
        public List<QuoteData> quoteList { get; set; } = new List<QuoteData>();
        public List<StockSummary> stockSummaries { get; set; } = new List<StockSummary>();
        public List<MarketSummary> marketSummaries { get; set; } = new List<MarketSummary>();
        public DataCollection()
        {
        }

        public void CalculateStockDataBetweenTime()
        {
            //stockList = Task.Run(async () => await StockDataHelper.GetYookStock("SPY", DateTime.Parse("1/1/2019"), DateTime.Parse("5/1/2019"))).Result;
        }


        private static string connectionString = $"Server= VHW-R90RDFTG\\SQLEXPRESS; Database= HPdatabase; Integrated Security = SSPI;";

        public IEnumerable<StockSummary> StoreMarketSumamry()
        {
            using (DataAccessLayer dal = new DataAccessLayer())
            {

            }
            // Call Stored Procedure for insertion?.
            // use Using... --> provides a convenient syntax that ensures the c orrect use of IDisposable objects.
            // Beginning in C# 8.0, the using statement ensures the correct use of IAsyncDisposable objets.

            return null;
        }


    }


    //https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/communication-in-microservice-architecture

}
