using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector
{

    public abstract class BaseWebClient
    {
        private const string url = "https://apidojo-yahoo-finance-v1.p.rapidapi.com/";
        private const string restApiAddress = "";
        public void RequestHeaderSetup(string category, string getfield,string company, out RestClient client, out RestRequest request)
        {
            client = new RestClient(url + category +"/v2/" + getfield + "?symbol=" + company);
            request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620");
        }


    }
}
