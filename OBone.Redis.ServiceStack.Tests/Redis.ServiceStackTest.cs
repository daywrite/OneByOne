using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OBone.Core.Data.Entity;
using OBone.Core.Models;
using ServiceStack.Redis;

namespace OBone.Redis.ServiceStack.Tests
{
    [TestClass]
    public class ServiceStackTest
    {
        OBoneDbContext context = new OBoneDbContext();

        public RedisClient Client = null;

        public ServiceStackTest()
        {
            Client = new RedisClient("127.0.0.1", 6379);
            
        }

        [TestMethod]
        public void TestMethod1()
        {
            string key = "test";
            string value = "OBone.Redis";

            string str = Client.Get<string>(key);

            Assert.AreEqual(value, str);
        }

        [TestMethod]
        public void TestList()
        {
            Client.FlushAll();
            var rCommunities = Client.As<Community>();

            List<Community> Entities = context.Set<Community>().ToList();

            rCommunities.StoreAll(Entities.ToList());
        }

        [TestMethod]
        public void GetList()
        {
            var rCommunities = Client.As<Community>();

            var result = rCommunities.GetAll();
        }
    }
}
