using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OBone.Core;
using OBone.Core.Data;
using OBone.Core.Data.Entity.Monitors;
using OBone.Core.Models;
using OBone.Redis;
using OBone.Utility.Data;

namespace OBone.Application.Caching
{
    public class CommunityCore : ServiceBase, ICommunityCore
    {
        private readonly IRepository<Community, int> _communityRepository;

        public CommunityCore(IRepository<Community, int> communityRepository)
            : base(communityRepository.UnitOfWork)
        {
            _communityRepository = communityRepository;
        }

        private List<Community> GetCommunityCacheByCommunityName(string communityName)
        {
            return JsonHelper.FromJson<List<Community>>(RedisSingleton.GetInstance.Client.Get("Community"));
        }

        /// <summary>
        /// 获取 
        /// </summary>
        public IQueryable<Community> Communities
        {
            get
            {
                return _communityRepository.Entities;
            }
        }

        public async Task<Community> GetByKeyAsync(int id)
        {
            List<Community> c = GetCommunityCacheByCommunityName("111");
            //id.CheckGreaterThan("id", 0);
            return await _communityRepository.GetByKeyAsync(id);
        }

    }
}
