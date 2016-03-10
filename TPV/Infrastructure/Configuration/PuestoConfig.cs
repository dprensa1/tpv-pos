using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TPV.Models;

namespace TPV.Infrastructure.Configuration
{
    public class PuestoConfig : EntityTypeConfiguration<Puesto>
    {
        public PuestoConfig()
        {
            ToTable("Puestos");

            HasKey(p => p.PuestoId);

            Property(p => p.PuestoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.Nombre)
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();

            Property(p => p.Descripcion)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            Property(p => p.Funciones)
                .HasColumnType("nvarchar")
                .IsRequired();
        }
    }
}