using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TPV.Models;

namespace TPV.Infrastructure
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            ToTable("Clientes");

            HasKey(c => c.ClienteID);

            Property(c => c.ClienteID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(c => c.Nombre)
                .HasMaxLength(64)
                .IsRequired();

            Property(c => c.Apellido)
                .HasMaxLength(32);

            Property(c => c.Identificacion)
                .HasMaxLength(16)
                .IsRequired();

            Property(c => c.Telefono)
                .HasMaxLength(10);

            Property(c => c.Direccion)
                .HasMaxLength(64);

            Property(c => c.Contacto)
                .HasColumnName("Nombre_Contacto")
                .HasMaxLength(32)
                .IsRequired();

            Property(c => c.Telefono_Contacto)
                .HasColumnName("Telefono_Contacto")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}