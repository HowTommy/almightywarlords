namespace AW.DataAccess.DataContext
{
    using System.Configuration;
    using AW.Core;
    using AW.DataAccess.DataContext.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using AW.DataAccess.Interfaces;
    using AW.Models;

    public class AWContext : DbContext, IDbContext
    {
        public AWContext() : base(ConfigurationManager
            .ConnectionStrings[ApplicationSettings.ApplicationConnectionString].ConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}