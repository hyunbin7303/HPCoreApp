using System;

namespace HP_StockDataCollector.Domain
{
    public class StockData
    {
        public string Ticker { get; set; }
        public DateTime Date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public float CloseAdj { get; set; }
        public float Volume { get; set; }
    }
}
