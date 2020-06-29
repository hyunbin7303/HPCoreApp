using HP_Infrastructure.Database;
using HP_StockDataCollector.Domain;
using System;
using System.Collections.Generic;
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

        public IEnumerable<StockSummary> GetAllMarketSumamry()
        {
            DataAccessLayer dal = new DataAccessLayer(connectionString);
            var conn = dal.CreateConnection();
            dal.OpenConnection(conn);

            // Call Stored Procedure for insertion?.

            dal.CloseConnection(conn);

        }


    }



    //https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/communication-in-microservice-architecture
    //public interface IEventBus
    //{
    //    void Publish(IntegrationEvent @event);

    //    void Subscribe<T, TH>()
    //        where T : IntegrationEvent
    //        where TH : IIntegrationEventHandler<T>;

    //    void SubscribeDynamic<TH>(string eventName)
    //        where TH : IDynamicIntegrationEventHandler;
    //    void UnsubscribeDynamic<TH>(string eventName)
    //        where TH : IDynamicIntegrationEventHandler;
    //    void Unsubscribe<T, TH>()
    //        where TH : IIntegrationEventHandler<T>
    //        where T : IntegrationEvent;
    //}
}
