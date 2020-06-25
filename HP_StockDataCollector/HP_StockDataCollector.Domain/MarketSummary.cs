using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HP_StockDataCollector.Domain
{
    public class MarketSummary
    {
        [JsonProperty("fullExchangeName")]
        public string FullExchangeName { get; set; }

        [JsonProperty("exchangeTimezoneShortName")]
        public string ExchangeTimezoneShortName { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("quoteType")]
        public string QuoteType { get; set; }
        [JsonProperty("shortName")]
        public string ShortName { get; set; }
        [JsonProperty("regularMarketPreviousClose")]
        public RegularMarket RegularMarketPrevClose { get; set; }

        [JsonProperty("regularMarketPrice")]
        public RegularMarket RegularMarketPrice { get; set; }
    }
    public class RegularMarket
    {
        public double raw { get; set; }
        public double fmt { get; set; }
    }
}
