using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SharedWeekends.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "SharedWeekends.MVC.Controllers"}
            );

            routes.MapRoute(
                name: "Static",
                url: "{action}",
                defaults: new { controller = "Home" },
                namespaces: new[] { "SharedWeekends.MVC.Controllers" }
            );
        }
    }
}
