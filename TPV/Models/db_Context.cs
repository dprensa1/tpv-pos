using System.Data.Entity;

namespace TPV.Models
{
    public class db_Context : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public db_Context() { }
    }
}