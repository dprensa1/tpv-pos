using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TPV.Models;

namespace TPV.Infrastructure
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

            HasMany(u => u.Usuarios)
                .WithMany(r => r.Rols)
                .Map(m =>
                {
                    m.MapLeftKey("UsuarioRefId");
                    m.MapRightKey("RolRefId");
                    m.ToTable("UsuarioRoles");
                });
        }
    }
}