namespace SharedWeekends.MVC
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using SharedWeekends.MVC.Infrastructure.Mapping;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ViewEnginesConfiguration.RegisterViewEngine(ViewEngines.Engines);
            AutoMapperConfig.Execute();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
