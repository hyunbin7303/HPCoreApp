using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HP_StockDataCollector.YahooFinance
{
    // Stock API call method.
    public class StockAPIcall : BaseWebClient
    {
        // A stock symbol is a unique series of leters assigned to a security for trading purposes.
        /*
        * A tick represents the standard upon which the price of a security may fluctuate.
        * The tick provides a specific price increment, reflected in the local currency associated with the market in which the security trades,
        * by which the overall price of the security can change.
        */
        public StockAPIcall()
        {
            _category = "stock";
        }
        public void GetStatistic(string company)
        {
            IRestResponse response = _client.Execute(_request);
            JObject check = (JObject)JsonConvert.DeserializeObject(response.Content);
            var result = check.SelectToken("marketSummaryResponse.result").ToString();
            System.Console.WriteLine(result);
        }
        public async Task<bool> GetHolderAsync(string company, string selectToken)
        {
            _categoryOption = "get-holders";
            var urldic = new Dictionary<string, string>();
            urldic.Add("symbol", company);
            RequestHeader(urldic);
            await getRestResponseAsync(selectToken);
            return true;
        }
        public async Task<bool> GetBalanceSheetAsync(string company, string selectToken)
        {
            _categoryOption = "get-balance-sheet";
            var urldic = new Dictionary<string, string>();
            urldic.Add("symbol", company);
            RequestHeader(urldic);
            await getRestResponseAsync(selectToken);
            return true;
        }
        public async Task<bool> GetSummaryAsync(string region, string company, string selectToken)
        {
            _categoryOption = "get-summary";
            var urldic = new Dictionary<string, string>();
            urldic.Add("region", region);
            urldic.Add("symbol", company);
            RequestHeader(urldic);
            await getRestResponseAsync(selectToken);
            return true;
        }
        public async Task<bool> GetHistoricalDataAsync(string symbol, string period1, string period2, string selectToken, DateTime? statTime = null, DateTime? endTime = null)
        {
            _categoryOption = "get-historical-data";
            var urldic = new Dictionary<string, string>();
            urldic.Add("period1", period1);
            urldic.Add("period2", period2);
            urldic.Add("symbol", symbol);
            RequestHeader(urldic);
            await getRestResponseAsync(selectToken);
            return true;
        }
        //public static async Task<IReadOnlyList<Candle>> GetHistoricalAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, Period period = Period.Daily, CancellationToken token = default)
        //{
        //    await GetTicksAsync(symbol, startTime, endTime, period, ShowOption.History, RowExtension.ToCandle, token).ConfigureAwait(false);
        //    // How the Get Ticks Async is working?
        //}
        private async Task<bool> getRestResponseAsync(string selectToken)
        {
            IRestResponse response = await _client.ExecuteAsync(_request);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("Status code : Not found "); // Logging require, not console WriteLine.
                return false;
            }
            JObject check = (JObject)JsonConvert.DeserializeObject(response.Content);
            var result = check.SelectToken(selectToken).ToString();
            Console.WriteLine(result);
            return true;
        }

    }
}
