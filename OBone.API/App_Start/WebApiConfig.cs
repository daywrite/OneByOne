using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Autofac;
using Autofac.Integration.WebApi;

using System.Reflection;

using OBone.Core;
using OBone.Core.Data.Entity;
using OBone.Core.Data;

using System.IO;
using System.Web;
using OBone.API.Logging;
using OBone.Core.Logging;
using OBone.Utility.Logging;

namespace OBone.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            #region 依赖注入

            var builder = new ContainerBuilder();
            var baseType = typeof(IDependency);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));

            var assemblies = new DirectoryInfo(
                    HttpContext.Current.Server.MapPath("~/bin/"))
              .GetFiles("*.dll")
              .Select(r => Assembly.LoadFrom(r.FullName)).ToArray();

            builder.RegisterAssemblyTypes(assemblies)
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerLifetimeScope();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());

            #endregion

            #region 日志
            LoggingInitialize();
            #endregion
        }

        private static void LoggingInitialize()
        {
            Log4NetLoggerAdapter adapter = new Log4NetLoggerAdapter();
            LogManager.AddLoggerAdapter(adapter);
        }
    }
}
