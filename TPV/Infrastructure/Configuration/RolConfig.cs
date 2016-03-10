using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TPV.Models;

namespace TPV.Infrastructure.Configuration
{
    public class RolConfig : EntityTypeConfiguration<Rol>
    {
        public RolConfig()
        {
            ToTable("Roles");

            HasKey(a => a.RolId);

            Property(a => a.RolId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(c => c.Nombre)
                .HasColumnType("nvarchar")
                .HasMaxLength(16)
                .IsRequired();

            Property(r => r.Descripcion)
                .HasColumnType("nvarchar")
                .HasMaxLength(128);

            HasMany(r => r.Accesos)
                .WithMany(u => u.Rols)
                .Map(ur =>
                {
                    ur.MapLeftKey("RolId");
                    ur.MapRightKey("AccesoId");
                    ur.ToTable("RolesAccesos");
                });
        }
    }
}