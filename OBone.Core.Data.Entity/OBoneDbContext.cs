using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OBone.Core.Data.Entity
{
    /// <summary>
    /// EntityFramework-CodeFirst数据上下文
    /// </summary>
    public class OBoneDbContext : DbContext
    {
        public OBoneDbContext()
            : base(ConfigurationManager.AppSettings["ConnectionStringName"])
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //注册实体配置信息
            ICollection<IEntityMapper> entityMappers = DatabaseInitializer.EntityMappers;
            foreach (IEntityMapper mapper in entityMappers)
            {
                mapper.RegistTo(modelBuilder.Configurations);
            }
        }
    }
}
