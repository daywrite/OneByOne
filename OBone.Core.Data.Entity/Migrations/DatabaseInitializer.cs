using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using System.Data.Entity;

namespace OBone.Core.Data.Entity
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public class DatabaseInitializer
    {
        private static readonly ICollection<Assembly> MapperAssemblies = new List<Assembly>();

        /// <summary>
        /// 获取 数据实体映射配置信息集合
        /// </summary>
        public static ICollection<IEntityMapper> EntityMappers { get { return GetAllEntityMapper(); } }

        /// <summary>
        /// 设置数据库初始化，策略为自动迁移到最新版本
        /// </summary>
        public static void Initialize()
        {
            OBoneDbContext context = new OBoneDbContext();
            IDatabaseInitializer<OBoneDbContext> initializer;
            if (!context.Database.Exists())
            {
                initializer = new CreateDatabaseIfNotExistsWithSeed();
            }
            else
            {
                initializer = new MigrateDatabaseToLatestVersion<OBoneDbContext, MigrationsConfiguration>();
            }
            Database.SetInitializer(initializer);

            //增加字段可以立马展示出来--有好--有坏
            //增加的整数不能为null，就得等增加的时候才能加上，看情况
            //目前先加上
            context.Database.Initialize(false);
        }

        /// <summary>
        /// 添加需要搜索实体映射的程序集到检索集合中
        /// </summary>
        public static void AddMapperAssembly(Assembly assembly)
        {
            //assembly.CheckNotNull("assembly");
            if (MapperAssemblies.Any(m => m == assembly))
            {
                return;
            }
            MapperAssemblies.Add(assembly);
        }

        private static ICollection<IEntityMapper> GetAllEntityMapper()
        {
            Type baseType = typeof(IEntityMapper);
            //增加DLL映射
            AddMapperAssembly(Assembly.GetExecutingAssembly());

            Type[] mapperTypes = MapperAssemblies.SelectMany(assembly => assembly.GetTypes())
                .Where(type => baseType.IsAssignableFrom(type) && type != baseType && !type.IsAbstract).ToArray();
            ICollection<IEntityMapper> result = mapperTypes.Select(type => Activator.CreateInstance(type) as IEntityMapper).ToList();
            return result;
        }
    }
}