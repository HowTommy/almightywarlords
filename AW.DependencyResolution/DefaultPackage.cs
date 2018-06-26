namespace AW.DependencyResolution
{
    using SimpleInjector;

    using AW.DataAccess;
    using AW.DataAccess.DataContext;
    using AW.DataAccess.Interfaces;
    using AW.Logic;
    using AW.Logic.Interfaces;

    public static class DefaultPackage
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IDbContext, AWContext>();

            container.Register<IUserDataAccess, UserDataAccess>();

            container.Register<IUserLogic, UserLogic>();
        }
    }
}
