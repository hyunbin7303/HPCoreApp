using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.Domain
{
    public class Mover
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("canonicalName")]
        public string CanonicalName { get; set; }
        [JsonProperty("start")]
        public int Start { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("quotes")]
        public List<QuoteData> Quotes { get; set; }
    }
}
