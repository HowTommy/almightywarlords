namespace AW.DependencyResolution
{
    using AW.DataAccess;
    using AW.DataAccess.DataContext;
    using SimpleInjector;
    using AW.DataAccess.Interfaces;

    public static class DefaultPackage
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IDbContext, AWContext>();

            container.Register<IUserDataAccess, UserDataAccess>();
        }
    }
}
