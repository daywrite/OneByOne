using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBone.Application.Caching;
using OBone.Core.Models;

namespace OBone.Application
{
     public class CacheApplication
    {
        public static void Init()
        {
            new RedisCacheCore<Community,int>().Init();
        }
    }
}
