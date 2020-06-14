using System;
using Newtonsoft.Json;

namespace HP_StockDataCollector.Domain
{
    public class QuoteData
    {
        public string Symbol { get; set; }
        public string Exchange { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public long Volume { get; set; }

        [JsonProperty("quoteType")]

        public string QuoteType { get; set; }

        [JsonProperty("bid")]
        public double Bid { get; set; }
        [JsonProperty("ask")]
        public double Ask { get; set; }
        public DateTime Timestamp { get; set; } = new DateTime();
    }
}
