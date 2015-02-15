using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OBone.Core;
using OBone.Core.Models;

namespace OBone.Application.Caching
{
    public interface ICommunityCore : IDependency
    {
        /// <summary>
        /// 获取查询数据集
        /// </summary>
        IQueryable<Community> Communities { get; }
        Task<Community> GetByKeyAsync(int id);
    }
}

