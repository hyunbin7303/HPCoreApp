
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
namespace HP_StockDataCollector.YahooFinance
{
    public static class MarketAPIcall
    {

        public static void GetSummary()
        {
            var client = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-summary?region=US&lang=en");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620");
            IRestResponse response = client.Execute(request);
            JObject check = (JObject)JsonConvert.DeserializeObject(response.Content);
            var result = check.SelectToken("marketSummaryResponse.result").ToString();
            System.Console.WriteLine(result);
            //DynamicJsonDeserializer dynamicJsonDeserializer = new DynamicJsonDeserializer();
            //var t = dynamicJsonDeserializer.Deserialize<A>((RestResponse)response);

        }
        public static void GetMoverAPI()
        {
            var client = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-movers?region=US&lang=en");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620");
            IRestResponse response = client.Execute(request);
        }
        public static void GetQuotesAPI()
        {
            var client = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-quotes?region=US&lang=en&symbols=BAC%252CKC%253DF%252C002210.KS%252CIWM%252CAMECX");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620");
            IRestResponse response = client.Execute(request);
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
