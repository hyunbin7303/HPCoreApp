using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;


// Source : rdingwall/DynamicJsonDeserializer.cs
// Web : https://gist.github.com/rdingwall/1884642#file-dynamicjsondeserializer-cs
namespace HP_StockDataCollector.YahooFinance
{
    public class DynamicJsonDeserializer 
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public T Deserialize<T>(RestResponse response) where T : new()
        {
            return JsonConvert.DeserializeObject<dynamic>(response.Content);
        }
    }
}
