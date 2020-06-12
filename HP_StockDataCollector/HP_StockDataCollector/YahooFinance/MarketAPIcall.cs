
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HP_StockDataCollector.YahooFinance
{
    public class MarketAPIcall : BaseWebClient
    {
        public MarketAPIcall(){ _category = "market";}
        public async Task<bool> GetSummaryAsync()
        {
            _categoryOption = "get-summary";
            var urldic = new Dictionary<string, string>();
            urldic.Add("region", "US");
            urldic.Add("lang", "en");
            RequestHeader(urldic);
            await getRestResponseAsync("");
            return true;
        }
        // https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-quotes?region=US&lang=en&symbols=BAC%252CKC%253DF%252C002210.KS%252CIWM%252CAMECX
        public async Task<bool> GetQuotesAsync(string symbolValue, string selectToken)
        {
            _categoryOption = "get-quotes";
            var urldic = new Dictionary<string, string>();
            urldic.Add("region", "US");
            urldic.Add("lang", "en");
            urldic.Add("symbols", "");
            RequestHeader(urldic);
            await getRestResponseAsync(selectToken);
            return true;
        }
        public static void GetMoverAPI()
        {
            var client = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-movers?region=US&lang=en");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620");
            IRestResponse response = client.Execute(request);
            JObject check = (JObject)JsonConvert.DeserializeObject(response.Content);
            var result = check.SelectToken("marketSummaryResponse.result").ToString();
            System.Console.WriteLine(result);
        }
        public static void GetChartAPI()
        {
            var client = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-charts?comparisons=%255EGDAXI%252C%255EFCHI&region=US&lang=en&symbol=HYDR.ME&interval=5m&range=1d");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620");
            IRestResponse response = client.Execute(request);
        }
        public static void GetAutoCompleteAPI()
        {
            var client = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/auto-complete?lang=en&region=US&query=nbe");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620");
            IRestResponse response = client.Execute(request);
        }



    }
}
