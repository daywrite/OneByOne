using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBone.Core;
using OBone.Core.Data;
using OBone.Core.Data.Entity;
using OBone.Core.Data.Entity.Monitors;
using OBone.Core.Models;
using OBone.Redis;
using OBone.Utility.Data;

namespace OBone.Application.Caching
{
    public class RedisCacheCore
    {

        public static void Init()
        {
            RedisSingleton.GetInstance.Client = new OBone.Redis.Client.RedisClient();
            //todo 读取配置连接Redis
            RedisSingleton.GetInstance.Client.Connect("127.0.0.1", 6379);

            //todo 读取数据库加载Redis缓存监视器
            var monitor = new RedisCacheMonitor() { TableName = "Communities", Fields = new string[] { "Id", "CommunityName" } };

            MonitorWrapper.Init(monitor);

            //todo 启动时自动加载所有缓存
            LoadUserCache<OBone.Core.Models.Community>(monitor.Fields);
        }

        public static async void LoadUserCache<T>(params string[] propertyNames) where T : class,new()
        {
            //List<T> lst = null;
            var lst = new List<Community>() { 
            new Community(){Id=1,CommunityName="111", IsDeleted=false, CreatedTime=DateTime.Now},
            new Community(){Id=2,CommunityName="222", IsDeleted=false, CreatedTime=DateTime.Now},
            new Community(){Id=3,CommunityName="333", IsDeleted=false, CreatedTime=DateTime.Now},
            new Community(){Id=4,CommunityName="444", IsDeleted=false, CreatedTime=DateTime.Now}
            };
            //using (var ef = new DataWrapper<T>())
            //{
            //    lst = await ef.FindAllAsync();
            //}

            var type = typeof(T);
            
            foreach (var user in lst)
            {
                foreach (var propertyName in propertyNames)
                {
                    RedisSingleton.GetInstance.Client.HSet(
                        type.Name,
                        string.Format("{0}:{1}", propertyName, type.GetProperty(propertyName).GetValue(user) as string),
                        JsonHelper.SerializeToJson(user));
                }
            }
        }
    }
}

