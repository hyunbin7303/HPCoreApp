
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
        public async Task<IList<MarketSummary>> GetSummaryAsync()
        {
            _categoryOption = "get-summary";
            var urldic = new Dictionary<string, object>();
            urldic.Add("region", "US");
            urldic.Add("lang", "en");
            RequestHeader(urldic);
            var checkStr = await getRestResponseAsync("marketSummaryResponse.result");
            var summary = JsonConvert.DeserializeObject<List<MarketSummary>>(checkStr);
            return summary;
        }
        public async Task<IList<QuoteData>> GetQuotesAsync(string symbolValue, string selectToken)
        {
            _categoryOption = "get-quotes";
            var urldic = new Dictionary<string, object>();
            urldic.Add("region", "US");
            urldic.Add("lang", "en");
            urldic.Add("symbols", symbolValue);
            RequestHeader(urldic);
            var checkStr = await getRestResponseAsync(selectToken);
            var quoteList = JsonConvert.DeserializeObject<List<QuoteData>>(checkStr);
            return quoteList;
        }
        public async Task<IList<Mover>> GetMoverAPIAsync(string start = null, string count = null)
        {
            _categoryOption = "get-movers";
            var urldic = new Dictionary<string, object>();
            urldic.Add("region", "US");
            urldic.Add("lang", "en");
            if(start != null || count != null)
            {
                urldic.Add("start", start);
                urldic.Add("count", count);
            }
            RequestHeader(urldic);
            var checkStr = await getRestResponseAsync("result");
            var moveList = JsonConvert.DeserializeObject<List<Mover>>(checkStr);
            return moveList;
        }
        public async Task<string> GetAutoCompleteAsync(string query)
        {
            _categoryOption = "auto-complete";
            var urldic = new Dictionary<string, object>();
            urldic.Add("region", "US");
            urldic.Add("lang", "en");
            urldic.Add("query", query);
            RequestHeader(urldic);
            var checkStr = await getRestResponseAsync("ResultSet");
            return checkStr;

        }


        public async Task<string> GetChartAsync(string symbol, string interval, string range, string comparisons)
        {
            _categoryOption = "get-charts";
            var urldic = new Dictionary<string, object>();
            urldic.Add("region", "US");
            urldic.Add("lang", "en");
            urldic.Add("symbol", symbol);
            urldic.Add("interval", interval);
            urldic.Add("range", range);
            RequestHeader(urldic);
            await getRestResponseAsync("");
            return "";
        }
 
    }
}

// Worker - Set up to save data in sql server.
// Need to create SQL server ...
//https://www.youtube.com/watch?v=c5ZDbDGySc0
