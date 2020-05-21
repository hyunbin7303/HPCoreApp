using HP_Redis;
using NUnit.Framework;

namespace HP_Testing
{
    public class TestsRedis
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void RedisOpenTest()
        {
        }

        [Test]
        public void Test1()
        {
            Patient p1 = new Patient();
            p1.Fname = "Kevin";
            p1.Lname = "Park";
            p1.PID = System.Guid.NewGuid();

            //RedisConnection.OpenConnection("localhost");
            //RedisHelper.Set(RedisConnection.GetDatabase(), "KEVIN3", p1, System.TimeSpan.MaxValue);
            //RedisPubSub.OpenSub(RedisConnection.Redis);
            //RedisHelper.Get<Patient>(RedisConnection.GetDatabase(), "KEVIN");
            //RedisConnection.CloseConnection();
        }

        [Test]
        public void RedisConnectionTest()
        {
            Patient p1 = new Patient();
            p1.Fname = "Kevin";
            p1.Lname = "Park";
            p1.PID = System.Guid.NewGuid();

            //RedisConnection.OpenConnection("localhost");
            //RedisHelper.Set(RedisConnection.GetDatabase(), "KEVIN3", p1, System.TimeSpan.MaxValue);
            //RedisPubSub.OpenSub(RedisConnection.Redis);
            //RedisHelper.Get<Patient>(RedisConnection.GetDatabase(), "KEVIN");
            //RedisConnection.CloseConnection();
        }
    }
}