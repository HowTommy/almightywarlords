namespace AW.DataAccess.DataContext
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using AW.DataAccess.Interfaces;
    using AW.Models;

    public class AWContext : DbContext, IDbContext
    {
        public AWContext() : base("AWContext")
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}