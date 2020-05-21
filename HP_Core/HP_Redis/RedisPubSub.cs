using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Redis
{
    public class RedisPubSub
    {
        private static ISubscriber sub = null;

        public static void OpenSub(ConnectionMultiplexer redis)
        {
            sub = redis.GetSubscriber();
            sub.Subscribe("messages", (channel, message) => { Console.WriteLine((string)message); });
        }

    }
}
