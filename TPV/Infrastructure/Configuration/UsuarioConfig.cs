using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TPV.Models;

namespace TPV.Infrastructure.Configuration
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("Usuarios");

            HasKey(e => e.UsuarioId);
            //HasKey(u => new { u.UsuarioId, u.Roles});

            Property(e => e.UsuarioId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(c => c.User)
                .HasColumnType("nvarchar")
                .HasMaxLength(16)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_UserN", 1) { IsUnique = true }));

            Property(c => c.Clave)
                .HasColumnType("nvarchar")
                .HasMaxLength(16)
                .IsRequired();

            HasMany(r => r.Rols)
                .WithMany(u => u.Usuarios)
                .Map(ur =>
                {
                    ur.MapLeftKey("UsuarioId");
                    ur.MapRightKey("RolId");
                    ur.ToTable("UsuariosRoles");
                });
        }
    }
}