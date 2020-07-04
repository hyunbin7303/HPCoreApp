using HP_StockDataCollector.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            _endPointTitle = EndpointTitle.Stock;
        }
        public async Task<object> GetStatisticAllAsync(string company, string selectToken)
        {
            _categoryOption = "get-statistics";
            var urldic = new Dictionary<string, string>();
            urldic.Add("region", "US");
            urldic.Add("symbol", "AMRN");
            RequestHeader(urldic);
            var statisticObj = await getRestResponseDynamicObjAsnyc(selectToken);
            return statisticObj;
        }
        public async Task<Statistics> GetStatisticAsync(string company, string selectToken)
        {
            _categoryOption = "get-statistics";
            var urldic = new Dictionary<string, string>();
            urldic.Add("region", company);
            urldic.Add("symbol", "AMRN");
            RequestHeader(urldic);
            var checkStr = await getRestResponseAsync(selectToken);
            try
            {
                var statistic = JsonConvert.DeserializeObject<Statistics>(checkStr);
                return statistic;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<BalanceSheet> GetBalanceSheetAsync(string company, string selectToken)
        {
            _categoryOption = "get-balance-sheet";
            var urldic = new Dictionary<string, string>();
            urldic.Add("symbol", company);
            RequestHeader(urldic);
            await getRestResponseAsync(selectToken);
            return true;
        }
        public async Task<IList<StockSummary>> GetSummaryAsync(string company, string selectToken)
        {
            if(company == null)
            {
                Console.WriteLine("Company is empty, Please type company name");
                return null;
            }

            _categoryOption = "get-summary";
            var urldic = new Dictionary<string, string>();
            urldic.Add("region", "US");
            urldic.Add("symbol", company);
            RequestHeader(urldic);
            var checkStr = await getRestResponseAsync(selectToken);
            var summary = JsonConvert.DeserializeObject<List<StockSummary>>(checkStr);
            return summary;
        }


        // HOw to use Cancellation token in here?...

        public async Task<bool> GetHistoricalDataAsync(string symbol, string period1, string period2, string selectToken,string frequency = null, string filter = null)
        {
            _categoryOption = "get-historical-data";
            var urldic = new Dictionary<string, string>();
            urldic.Add("period1", period1);
            urldic.Add("period2", period2);
            urldic.Add("symbol", symbol);
            if (frequency != null)
                urldic.Add("frequency", frequency);
            if (filter != null)
                urldic.Add("filter", filter);

            RequestHeader(urldic);
            var checkStr = await getRestResponseAsync(selectToken);
            return true;
        }
        
        
        
        // Need to check how this method is runnign
        //public static async Task<IReadOnlyList<Candle>> GetHistoricalAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, Period period = Period.Daily, CancellationToken token = default)
        //{
        //    await GetTicksAsync(symbol, startTime, endTime, period, ShowOption.History, RowExtension.ToCandle, token).ConfigureAwait(false);
        //    // How the Get Ticks Async is working?
        //}
    }
}
