using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OBone.Core.Models;

namespace OBone.Core.Data.Entity.ModelConfigurations
{
    public class CommunityConfiguration : EntityConfigurationBase<Community, int>
    {
        public CommunityConfiguration()
        {
            //主键
            HasKey(p => p.Id);
        }
    }
}
