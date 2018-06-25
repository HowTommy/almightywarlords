using AW.DependencyResolution;

namespace AW.Web
{
    using System.Reflection;
    using System.Web.Mvc;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;

    using SimpleInjector;

    public class IocConfig
    {
        public static void Register()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            DefaultPackage.RegisterServices(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}