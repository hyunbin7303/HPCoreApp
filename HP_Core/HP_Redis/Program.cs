using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = RedisStore.RedisCache;
            if (redis.StringSet("testKey", "testValue"))
            {
                var val = redis.StringGet("testKey");
            }

            Console.ReadKey();
        }
    }
}
