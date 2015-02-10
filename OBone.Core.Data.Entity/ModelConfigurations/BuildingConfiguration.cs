using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OBone.Core.Models;

namespace OBone.Core.Data.Entity.ModelConfigurations
{
    public class BuildingConfiguration : EntityConfigurationBase<Building, int>
    {
        public BuildingConfiguration()
        {
            //主键
            HasKey(p => p.Id);
            //外键
            HasRequired(p => p.Community).WithMany(c => c.Buildings).HasForeignKey(p => p.CommunityID).WillCascadeOnDelete(false);
        }
    }
}
