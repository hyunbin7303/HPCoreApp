using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.Domain
{


    public class Statistics
    {
        [JsonProperty("shortName")]
        public string ShortName { get; set; }
        [JsonProperty("exchange")]
        public string Exchange { get; set; }
        public RegularMarket regularMarketTime { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("quoteType")]
        public string QuoteType { get; set; }
        [JsonProperty("fiftyTwoWeekLowChangePercent")]
        public RegularMarket FiftyTwoWeekLowChangePercent { get; set; }


    }
}
