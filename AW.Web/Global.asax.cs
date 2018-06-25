namespace AW.Web
{
    using AW.DataAccess.DatabaseInitialization;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ApplicationDatabaseInitializer.InitializeDatabase();

            // ViewEngine Performance issue addressed:
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            // Registers
            IocConfig.Register();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Configure Auto-mappers
            //todo AutoMapperBootstrapper.ConfigureAutoMapper();
        }
    }
}
