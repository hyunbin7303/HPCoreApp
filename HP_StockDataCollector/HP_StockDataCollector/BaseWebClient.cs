using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector
{

    public static class BaseWebClient
    {
        private const string restApiAddress = "";
        private static void RequestHeaderSetup(out RestClient client, out RestRequest request, string? company)
        {
            client = new RestClient("https://apidojo-yahoo-finance-v1.p.rapidapi.com/stock/v2/get-holders?symbol=" + company);
            request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620");
        }


    }
}
