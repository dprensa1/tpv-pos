using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TPV.Models
{
    public class LyraContext : DbContext
    //public class LyraContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Acceso> Acceso { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Puesto> Puesto { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public LyraContext() : base()
        {
            //Database.SetInitializer<Lyra>(new DropCreateDatabaseAlways<Lyra>());
            
            Database.SetInitializer<LyraContext>(new CreateDatabaseIfNotExists<LyraContext>());
            
            //Database.SetInitializer<Lyra>(new DropCreateDatabaseIfModelChanges<Lyra>());
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