using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HP_Redis
{





    public class RedisStore : IRedisCache
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisStore()
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { "localhost" } // Default Database.
                //EndPoints = { ConfigurationManager.AppSettings["redis.connection"] }
            };

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();

        public Task<RedisValue> GetValue(string key)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetValues(IList<string> keys)
        {
            throw new NotImplementedException();
        }

        public RedisValue GetValueSync(string key)
        {
            throw new NotImplementedException();
        }

        public void setValue(string key, string value)
        {
            throw new NotImplementedException();
        }
    }


    // using ConnectionMultiplexer
    // access a redis db.
    // make use of the pub/sub features of redis
    // access an individual server for maintainance / monitoring purposes.

    public class RedisConnection
    {
        private static ConnectionMultiplexer redis = null;
        public static void OpenConnection(string url)
        {
            redis = ConnectionMultiplexer.Connect(url);
        }
        public static bool OpenConnection(string url, string setup)
        {

            redis = ConnectionMultiplexer.Connect(url);
            return true;
        }


        public static void CloseConnection()
        {
            redis.Close();
        }
        public static ConnectionMultiplexer Redis
        {
            get
            {
                return redis;
            }
        }
        public static IDatabase GetDatabase()
        {
            return redis.GetDatabase();
        }

        public static void AccessServer(int portNum)
        {
            IServer server = redis.GetServer("localhost", portNum);
            EndPoint[] endPoints = redis.GetEndPoints();
            DateTime lastSave = server.LastSave();
            ClientInfo[] clients = server.ClientList();
        }
    }

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
        public static T GetFormat<T>(IDatabase cache, string key)
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
        public static T Get<T>(IDatabase cache, string key)
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
