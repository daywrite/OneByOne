using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            //var rCommunities = Client.As<Community>();

            List<Community> Entities = context.Set<Community>().ToList();
            Task.Run(() => {
                RedisClient _Client = new RedisClient("127.0.0.1", 6379);
                var rCommunities = _Client.As<Community>();
                List<Community> Entities10 = Entities.Take(1000).ToList();
                rCommunities.StoreAll(Entities10);
            });
            //Task.Run(() =>
            //{
            //    List<Community> Entities20 = Entities.Skip(1000).Take(1000).ToList();
            //    rCommunities.StoreAll(Entities20);
            //});
            //Task.Run(() =>
            //{
            //    List<Community> Entities30 = Entities.Skip(2000).Take(1000).ToList();
            //    rCommunities.StoreAll(Entities30);
            //});
            //Task.Run(() =>
            //{
            //    List<Community> Entities40 = Entities.Skip(3000).Take(1000).ToList();
            //    rCommunities.StoreAll(Entities40);
            //});
            //Task.Run(() =>
            //{
            //    List<Community> Entities50 = Entities.Skip(4000).Take(1000).ToList();
            //    rCommunities.StoreAll(Entities50);
            //});         
            //rCommunities.StoreAll(Entities1020);
        }
        public static PooledRedisClientManager CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
        {
            //支持读写分离，均衡负载
            return new PooledRedisClientManager(readWriteHosts, readOnlyHosts, new RedisClientManagerConfig
            {
                MaxWritePoolSize = 5,//“写”链接池链接数
                MaxReadPoolSize = 5,//“写”链接池链接数
                AutoStart = true,
            });
        }
        [TestMethod]
        public void GetList()
        {
            var rCommunities = Client.As<Community>();

            var result = rCommunities.GetAll();
        }
    }
}
