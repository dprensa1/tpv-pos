using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TPV.Models;

namespace TPV.Infrastructure
{
    public class AccesoConfig : EntityTypeConfiguration<Acceso>
    {
        public AccesoConfig()
        {
            ToTable("Accesos");

            HasKey(a => a.AccesoId);

            Property(a => a.AccesoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(a => a.Nombre)
                .HasMaxLength(16)
                .IsRequired();

            Property(a => a.Descripcion)
                .HasMaxLength(128)
                .IsRequired();

            Property(a => a.Rutas)
                .IsRequired();

            HasMany(a => a.Roles)
                .WithMany(b => b.Accesos)
                .Map(m =>
                {
                    m.ToTable("RolesAccesos");
                    m.MapRightKey("RolId");
                    m.MapLeftKey("AccesoId");
                });
        }
    }
}