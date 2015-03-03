using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using OBone.Application;
using OBone.Core.Data.Entity;

namespace OBone.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //关闭XML返回格式
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //序列化与反序列化，不是特别优秀的解决循环引用的一种方式
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            
            //数据库生成初始入口           
            DatabaseInitializer.Initialize();

            //CacheApplication.Init();
        }
    }
}
