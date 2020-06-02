using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.YahooFinance
{
    public static class StockAPIcall
    {
        public static void GetStatistic(string company)
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

        // AMRN = Amarin Corporations.
        // Biopharmaceutical company founded in 1993 ...for the treatment of cardiovascular disease.

        public static void GetHolder(string company)
        {
            RestClient client;
            RestRequest request;
            RequestHeaderSetup(company, out client, out request);
            IRestResponse response = client.Execute(request);
            JObject check = (JObject)JsonConvert.DeserializeObject(response.Content);
            var result = check.SelectToken("marketSummaryResponse.result").ToString();
            System.Console.WriteLine(result);
        }


    }
}
