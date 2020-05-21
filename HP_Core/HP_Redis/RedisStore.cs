using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

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

            var check = RedisStore.RedisCache;

            throw new NotImplementedException();
        }

        public RedisValue GetValueSync(string key)
        {
            throw new NotImplementedException();
        }

        public void setValue(string key, string value)
        {
            var rdb = _conn.GetDatabase();
            rdb.StringSetAsync(key, JsonConvert.SerializeObject(value)).Wait();
        }
        Task<RedisValue> IRedisCache.GetValue(string key)
        {
            throw new NotImplementedException();
        }

        RedisValue IRedisCache.GetValueSync(string key)
        {
            throw new NotImplementedException();
        }
    }


}
