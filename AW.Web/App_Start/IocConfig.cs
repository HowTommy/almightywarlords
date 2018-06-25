namespace AW.Web
{
    using System.Reflection;
    using System.Web.Mvc;
    using AW.DataAccess.DataContext;
    using AW.DataAccess.Interfaces;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;

    using SimpleInjector;

    public class IocConfig
    {
        public static void Register()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IDbContext, AWContext>(Lifestyle.Scoped);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}