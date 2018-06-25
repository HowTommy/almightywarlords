using System.ComponentModel.DataAnnotations.Schema;

namespace AW.DataAccess.DataContext.Configuration
{
    using System.Data.Entity.ModelConfiguration;
    using AW.Models;

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Pseudo).HasMaxLength(50).IsRequired();
            Property(p => p.Email).HasMaxLength(255).IsRequired();
            Property(p => p.Password).HasMaxLength(1024).IsRequired();
            Property(p => p.Salt).HasMaxLength(1024).IsRequired();
            Property(p => p.PictureUrl).HasMaxLength(2048).IsRequired();
            Property(p => p.Language).HasMaxLength(10).IsRequired();
            Property(p => p.IsActivated).IsRequired();
            Property(p => p.CguVersion).HasMaxLength(10).IsRequired();
            Property(p => p.RemovalDate).IsOptional();
            Property(p => p.LastConnectionDate).IsRequired();
            Property(p => p.CreationDate).IsRequired();
            Property(p => p.ModificationDate).IsRequired();

            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("User");
            });
        }
    }
}
