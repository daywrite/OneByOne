using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace OBone.Core
{
    /// <summary>
    /// 可持久化到数据库的数据模型基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class EntityBase<TKey>
    {
        protected EntityBase()
        {
            IsDeleted = false;
            CreatedTime = DateTime.Now;
        }

        #region 属性

        /// <summary>
        /// 获取或设置 实体唯一标识，主键
        /// </summary>
        [Key]
        public TKey Id { get; set; }

        /// <summary>
        /// 获取或设置 是否删除，逻辑上的删除，非物品删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        #endregion
    }
}
