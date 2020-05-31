using HP_StockDataCollector.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HP_StockDataCollector.DataCollection
{
    public class DataCollection
    {
        public List<StockData> stockList { get; set; } = new List<StockData>();
        public DataCollection()
        {
        }

        public void CalculateStockDataBetweenTime()
        {
            //stockList = Task.Run(async () => await StockDataHelper.GetYookStock("SPY", DateTime.Parse("1/1/2019"), DateTime.Parse("5/1/2019"))).Result;
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
