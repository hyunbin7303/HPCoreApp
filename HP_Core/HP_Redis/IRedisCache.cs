using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HP_Redis
{
    public interface IRedisCache
    {
        Task<RedisValue> GetValue(string key);
        IList<string> GetValues(IList<string> keys);
        RedisValue GetValueSync(string key);
        void setValue(string key, string value);
    }
}
