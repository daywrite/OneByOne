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
      
        /// <summary>
        /// 获取 
        /// </summary>
        public IQueryable<Community> Communities
        {
            get { return _communityRepository.Entities; }
        }

        public async Task<Community> GetByKeyAsync(int id)
        {
            //id.CheckGreaterThan("id", 0);
            return await _communityRepository.GetByKeyAsync(id);
        }

    }
}
