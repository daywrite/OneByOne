using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

using OBone.Core.Data.Entity;

namespace OBone.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //数据库生成初始入口           
            DatabaseInitializer.Initialize();  
        }
    }
}
