using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HP_StockDataCollector
{
    public abstract class BaseWebClient
    {
        private const string url = "apidojo-yahoo-finance-v1.p.rapidapi.com/";
        private const string apiKey = "7c660e7db2msh6dba68fb0305bc6p1d982cjsn55312d329620";
        protected RestClient _client;
        protected RestRequest _request;
        protected string _category;
        protected string _categoryOption;
        public void RequestHeader(Dictionary<string,string> urlpara)
        {
            string totalurl = "https://" + url + _category + "/v2/" + _categoryOption + "?";
            foreach(var check in urlpara)
            {
                totalurl += check.Key + "=" + check.Value + "&";
            }
            _client = new RestClient(totalurl);
            _request = new RestRequest(Method.GET);
            _request.AddHeader("x-rapidapi-host", url);
            _request.AddHeader("x-rapidapi-key", apiKey);
        }
        protected async Task<bool> getRestResponseAsync(string selectToken)
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
