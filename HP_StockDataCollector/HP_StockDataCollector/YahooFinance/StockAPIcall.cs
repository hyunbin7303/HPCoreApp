using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HP_StockDataCollector.YahooFinance
{
    public class StockAPIcall : BaseWebClient
    {

        private static RestClient _client;
        private static RestRequest _request;

        public void GetStatistic(string company)
        {
            var client = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com/stock/v2/get-statistics?region=US&symbol=" + company);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620");
            IRestResponse response = client.Execute(request);
            JObject check = (JObject)JsonConvert.DeserializeObject(response.Content);
            var result = check.SelectToken("marketSummaryResponse.result").ToString();
            System.Console.WriteLine(result);
        }
        public void GetHolder(string company, string selectToken)
        {
            BaseWebClient.RequestHeaderSetup("Stock", "get-holders", company,out _client, out _request);
            IRestResponse response = _client.Execute(_request);
            JObject check = (JObject)JsonConvert.DeserializeObject(response.Content);
            var result = check.SelectToken("marketSummaryResponse.result").ToString();
            System.Console.WriteLine(result);
        }


        // Get Dividend history for a stock


        // Get historical data for a stock
        public void GetHistoricalData()
        {

        }
        public static async Task<IReadOnlyList<Candle>> GetHistoricalAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, Period period = Period.Daily, CancellationToken token = default)
        {
            await GetTicksAsync(symbol,startTime,endTime, period,ShowOption.History,RowExtension.ToCandle,token).ConfigureAwait(false);
            // How the Get Ticks Async is working?

        }

        // Get Stock quotes.

        /*
         * A tick represents the standard upon which the price of a security may fluctuate.
         * The tick provides a specific price increment, reflected in the local currency associated with the market in which the security trades,
         * by which the overall price of the security can change.
         */




    }
}
