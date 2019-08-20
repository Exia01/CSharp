﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Vidly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() //when the application is started, this method will be called
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);//registering routes
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
