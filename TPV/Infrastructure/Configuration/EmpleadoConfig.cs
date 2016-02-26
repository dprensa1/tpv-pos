using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TPV.Models;

namespace TPV.Infrastructure.Configuration
{
    public class EmpleadoConfig : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoConfig()
        {
            ToTable("Empleados");

            HasKey(e => e.EmpleadoId);

            Property(e => e.EmpleadoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(c => c.Nombre)
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();

            Property(c => c.Apellido)
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();

            Property(c => c.Sexo)
                .HasColumnType("nvarchar")
                .HasMaxLength(1)
                .IsRequired();

            Property(c => c.FechaNacimiento)
                .HasColumnType("date")
                .IsRequired();

            Property(c => c.Cedula)
                .HasColumnType("nvarchar")
                .HasMaxLength(11)
                .IsRequired();

            Property(c => c.Telefono)
                .HasColumnType("nvarchar")
                .HasMaxLength(11)
                .IsRequired();

            Property(c => c.Salario)
                .HasColumnType("nvarchar")
                .HasPrecision(18, 2)
                .IsRequired();

            HasRequired(a => a.Puesto)
                .WithMany(b => b.Empleados)
                .HasForeignKey(c => c.EmpleadoId);

            Property(c => c.FechaEntrada)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}