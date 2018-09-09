using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodWebApplication.App_Start;
using System.Web.Routing;
using System.Web.Optimization;
using System.Data.Entity;
using FastFoodWebApplication.Models.DBContext;

namespace FastFoodWebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<DBContextFile>(new DropCreateDatabaseIfModelChanges<DBContextFile>());
        }
    }
}
