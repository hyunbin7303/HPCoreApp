
using HP_StockDataCollector.Domain;
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
        public MarketAPIcall(){
            _category = "market";
            _endPointTitle = EndpointTitle.Market;
        }
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
        public async Task<List<QuoteData>> GetQuotesAsync(string symbolValue, string selectToken)
        {

            _categoryOption = "get-quotes";
            var urldic = new Dictionary<string, string>();
            urldic.Add("region", "US");
            urldic.Add("lang", "en");
            urldic.Add("symbols", symbolValue);
            RequestHeader(urldic);
            var checkStr = await getRestResponseAsync(selectToken);
            var quoteList = JsonConvert.DeserializeObject<List<QuoteData>>(checkStr);
            return quoteList;
        }
        //https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-movers?region=US&lang=en
        public async Task<bool> GetMoverAPI(string? start, string? count)
        {
            _categoryOption = "get-movers";
            var urldic = new Dictionary<string, string>();
            urldic.Add("region", "US");
            urldic.Add("lang", "en");
            //if(start.IsN)
            urldic.Add("start", start);
            urldic.Add("count", count);
            RequestHeader(urldic);
            //await getRestResponseAsync(selectToken);
            return true;
        }
        public async Task<string> GetChartAsync(string symbol, string interval, string range, string comparisons)
        {
            _categoryOption = "get-charts";
            var urldic = new Dictionary<string, string>();
            urldic.Add("region", "US");
            urldic.Add("lang", "en");
            urldic.Add("symbol", symbol);
            urldic.Add("interval", interval);
            urldic.Add("range", range);
            RequestHeader(urldic);
            await getRestResponseAsync("");
            return "";
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

// Worker - Set up to save data in sql server.
// Need to create SQL server ...
//https://www.youtube.com/watch?v=c5ZDbDGySc0
