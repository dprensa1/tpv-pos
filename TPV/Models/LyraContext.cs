using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TPV.Models
{
    public class LyraContext : DbContext
    //public class LyraContext : IdentityDbContext<Usuario>
    {
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public LyraContext() : base("Lyra")
        {
            //Database.SetInitializer<Lyra>(new DropCreateDatabaseAlways<Lyra>());
            
            //Database.SetInitializer<LyraContext>(new CreateDatabaseIfNotExists<LyraContext>());
            
            Database.SetInitializer<LyraContext>(new DropCreateDatabaseIfModelChanges<LyraContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            /*
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Usuarios");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Usuarios");
            
            */
        }
    }
}