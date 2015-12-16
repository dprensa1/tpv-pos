using System.Data.Entity;

namespace TPV.Models
{
    public class Lyra : DbContext
    {
        public DbSet<Puesto> Puesto { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public Lyra() : base()
        {
            Database.SetInitializer<Lyra>(new DropCreateDatabaseAlways<Lyra>());
            
            //Database.SetInitializer<Lyra>(new CreateDatabaseIfNotExists<Lyra>());
            //Database.SetInitializer<Lyra>(new DropCreateDatabaseIfModelChanges<Lyra>());
            //Database.SetInitializer<Lyra>(new DropCreateDatabaseAlways<Lyra>());
            //Database.SetInitializer<Lyra>(new SchoolDBInitializer());
        }
    }
}