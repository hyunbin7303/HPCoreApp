using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Linq;
namespace HP_Redis
{
    public class RedisStore : IRedisCache
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;
        public static ConnectionMultiplexer _conn => LazyConnection.Value;
        public static IDatabase RedisCache => _conn.GetDatabase();
        static RedisStore()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { config["redis.connection"] }
            };
            configurationOptions.SyncTimeout = 5000;
            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }
        public async Task<RedisValue> GetValue(string key)
        {
            var rdb = _conn.GetDatabase();
            return await rdb.StringGetAsync(key);
        }
        public IList<string> GetValues(IList<string> keys)
        {
            var rdb = _conn.GetDatabase();
            RedisValue[] results = rdb.StringGet(keys.Select(x => (RedisKey)x).ToArray());
            return results.Select(value => (string)value).Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

        public RedisValue GetValueSync(string key)
        {
            var rdb = _conn.GetDatabase();
            return rdb.StringGet(key);
        }

        public void setValue(string key, string value)
        {
            var rdb = _conn.GetDatabase();
            rdb.StringSetAsync(key, JsonConvert.SerializeObject(value)).Wait();
        }


        // Make a test case for these two methods. 
        public T GetFormat<T>(IDatabase cache, string key)
        {
            var value = cache.StringGet(key);
            if (!value.IsNull)
            {
                var deserializedStr = JsonConvert.SerializeObject(value
                    , Formatting.Indented
                    , new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        TypeNameHandling = TypeNameHandling.All
                    });
                return JsonConvert.DeserializeObject<T>(deserializedStr);
            }
            else
            {
                return default(T);
            }
        }
        public T Get<T>(IDatabase cache, string key)
        {
            var value = cache.StringGet(key);
            if (!value.IsNull)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            else
            {
                return default(T);
            }
        }
    }


}
