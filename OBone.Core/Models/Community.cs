using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBone.Core.Models
{
    /// <summary>
    /// 小区实体类信息
    /// </summary>
    [Description("小区信息")]
    public class Community : EntityBase<int>
    {
        public Community() { }

        /// <summary>
        /// 小区名称
        /// </summary>
        [Required, StringLength(50)]
        public string CommunityName { get; set; }

        /// <summary>
        /// 获取或设置 楼宇信息集合
        /// </summary>
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
