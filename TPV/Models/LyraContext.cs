using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TPV.Infrastructure.Configuration;

namespace TPV.Models
{
    //public class LyraContext : DbContext
    public class LyraContext : IdentityDbContext<Usuario>
    {
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Rol> Roles { get; set; }

        public LyraContext() : base("Lyra")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<LyraContext>());

            //Database.SetInitializer<LyraContext>(new CreateDatabaseIfNotExists<LyraContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LyraContext>());
        }

        public static LyraContext Create()
        {
            return new LyraContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Configurations.Add(new AccesoConfig());
            modelBuilder.Configurations.Add(new RolConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new EmpleadoConfig());
            modelBuilder.Configurations.Add(new PuestoConfig());
            modelBuilder.Configurations.Add(new ClienteConfig());
        }
    }
}