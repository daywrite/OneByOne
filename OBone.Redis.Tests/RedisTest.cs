using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;

namespace OBone.Redis.Tests
{
    [TestClass]
    public class RedisTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            var client = RedisSingleton.GetInstance.Client = new Client.RedisClient();
            client.Connect("127.0.0.1",6379);

            string key = "test";
            string value = "OBone.Redis";

            client.Set(key, value);

            Assert.AreEqual(value, client.Get(key));
        }
    }
}
