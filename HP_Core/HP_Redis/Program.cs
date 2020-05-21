using StackExchange.Redis;
using System;

namespace HP_Redis
{
    public class Patient
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        private string _Mname;
        public string Mname
        {
            get { return _Mname ?? string.Empty; }
            set { _Mname = value; }
        }
        public Guid PID { get; set; }
    }
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Redis Test Application.");
            Patient p1 = new Patient();
            p1.Fname = "Kevin";
            p1.Lname = "Park";
            p1.PID = Guid.NewGuid();
            RedisConnection.OpenConnection("localhost");
            RedisHelper.Set(RedisConnection.GetDatabase(), "KEVIN3", p1, TimeSpan.MaxValue);
            RedisPubSub.OpenSub(RedisConnection.Redis);
            RedisHelper.Get<Patient>(RedisConnection.GetDatabase(), "KEVIN");
            RedisConnection.CloseConnection();
        }



        static void testing1()
        {
            var redis = RedisStore.RedisCache;
            //if (redis.StringGet("testKey", CommandFlags.DemandSlave))
            //{

            //}
        }
    }

}
