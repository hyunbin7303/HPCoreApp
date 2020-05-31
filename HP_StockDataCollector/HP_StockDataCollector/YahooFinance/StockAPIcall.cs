using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.YahooFinance
{
    public static class StockAPIcall
    {
        public static void GetStatistic()
        {
            var client = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com/stock/v2/get-statistics?region=US&symbol=AMRN");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620");
            IRestResponse response = client.Execute(request);
            var check = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(check.ToString()); 
        }
    }
}
