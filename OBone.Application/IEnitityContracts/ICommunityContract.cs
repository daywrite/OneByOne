using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OBone.Core;
using OBone.Core.Models;
using OBone.Utility.Data;

namespace OBone.Application
{
    public interface ICommunityContract : IDependency
    {
        /// <summary>
        /// 获取查询数据集
        /// </summary>
        IQueryable<Community> Communities { get; }
        Task<Community> GetByKeyAsync(int id);

        /// <summary>
        /// 异步添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResult> AddCommunityAsync(Community dto);
    }
}

