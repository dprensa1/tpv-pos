using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TPV.Infrastructure;

namespace TPV.Models
{
    public class LyraContext : DbContext
    //public class LyraContext : IdentityDbContext<Usuario>
    {
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public LyraContext() : base("Lyra")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<LyraContext>());
            
            //Database.SetInitializer<LyraContext>(new CreateDatabaseIfNotExists<LyraContext>());
            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LyraContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Configurations.Add(new AccesoConfig());
            //modelBuilder.Configurations.Add(new ClienteConfig());
            //modelBuilder.Configurations.Add(new EmpleadoConfig());
        }
    }
}