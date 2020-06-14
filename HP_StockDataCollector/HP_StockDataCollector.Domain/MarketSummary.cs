using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.Domain
{
    public class MarketSummary
    {
        [JsonProperty("fullExchangeName")]
        public string FullExchangeName { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("quoteType")]
        public string QuoteType { get; set; }
        [JsonProperty("shortName")]
        public string ShortName { get; set; }
        [JsonProperty("regularMarketPreviousClose")]
        public regularMarketPreviousClose RegularMarketPrevClose { get; set; }

    }
    public class regularMarketPreviousClose
    {
        public double raw { get; set; }
        public double fmt { get; set; }
    }
}
