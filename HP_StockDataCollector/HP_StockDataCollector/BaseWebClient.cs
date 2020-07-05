using HP_StockDataCollector.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        protected string _field;
        protected string _category;
        protected string _categoryOption;
        protected EndpointTitle _endPointTitle;
        public void RequestHeader(Dictionary<string,object> urlpara)
        {
            string totalUrl = string.Empty;
            if(_endPointTitle== EndpointTitle.Stock)
            {
                totalUrl = "https://" + url + _category + "/v2/" + _categoryOption + "?";
                foreach (var check in urlpara)
                {
                    totalUrl += check.Key + "=" + check.Value + "&";
                }
            }
            else if(_endPointTitle == EndpointTitle.Market)
            {
                //totalUrl = "https://apidojo-yahoo-finance-v1.p.rapidapi.com/market/get-quotes?region=US&lang=en&symbols=BAC";
                totalUrl = "https://" + url + _category + "/" + _categoryOption + "?";
                foreach (var check in urlpara)
                {
                    totalUrl += check.Key + "=" + check.Value + "&";
                }
            }
            _client = new RestClient(totalUrl);
            _request = new RestRequest(Method.GET);
            _request.AddHeader("x-rapidapi-host", url);
            _request.AddHeader("x-rapidapi-key", apiKey);
        }
        protected async Task<string> getRestResponseAsync(string selectToken)
        {
            IRestResponse response = null;
            try
            {
                response = await _client.ExecuteAsync(_request);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Status code : Not found "); // Logging require, not console WriteLine.
                    return "ERROR";
                }
                JObject jobj = (JObject)JsonConvert.DeserializeObject(response.Content);
                var result = jobj.SelectToken(selectToken).ToString();
                return result;
            }
            catch(JsonException je)
            {
                Console.WriteLine(je.Message);
                return "Json Exception";
            }
        }

        protected async Task<object> getRestResponseDynamicObjAsnyc(string selectToken)
        {
            IRestResponse response = await _client.ExecuteAsync(_request);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("Status code : Not found "); // Logging require, not console WriteLine.
                return "ERROR";
            }
            try
            {
                JObject jobj = (JObject)JsonConvert.DeserializeObject(response.Content);
                return jobj;
            }
            catch(JsonException je)
            {
                Console.WriteLine(je.Message);
                return "Json Exception";
            }
        }
        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
    }
}
