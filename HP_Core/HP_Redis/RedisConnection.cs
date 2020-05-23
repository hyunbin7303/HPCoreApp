using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HP_Redis
{

    // using ConnectionMultiplexer
    // access a redis db.
    // make use of the pub/sub features of redis
    // access an individual server for maintainance / monitoring purposes.
    public class RedisHelper
    {
        public static void Set(IDatabase cache, string key, object value, TimeSpan experation)
        {
            cache.StringSet(key, JsonConvert.SerializeObject(value), experation);
        }
        public static void SetFormat(IDatabase cache, string key, object value, TimeSpan experation)
        {
            string serializedStr = JsonConvert.SerializeObject(value
                , Formatting.Indented
                , new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.All
                });
            cache.StringSet(key, serializedStr, experation);
        }




    }
}
