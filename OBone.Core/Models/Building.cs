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
    /// 楼栋实体类信息
    /// </summary>
    [Description("楼栋信息")]
    public class Building : EntityBase<int>
    {
        public Building() { }

        /// <summary>
        /// 小区名称
        /// </summary>
        [Required, StringLength(20)]
        public string BuildingName { get; set; }

        public int CommunityID { get; set; }
        public virtual Community Community { get; set; }
    }
}
