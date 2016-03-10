namespace TPV.Migrations
{
    using FizzWare.NBuilder;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.LyraContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            //SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
            //SetSqlGenerator("System.Data.Sqlclient", new System.Data.Entity.Migrations.MigrationSqlGenerator());
        }

        protected override void Seed(LyraContext context)
        {
            var Accesos = Builder<Acceso>.CreateListOfSize(25).Build();
            var Roles = Builder<Rol>.CreateListOfSize(25).Build();
            var Usuarios = Builder<Acceso>.CreateListOfSize(25).Build();
            var Empleados = Builder<Acceso>.CreateListOfSize(25).Build();
            var Puestos = Builder<Acceso>.CreateListOfSize(25).Build();
            var Clientes = Builder<Acceso>.CreateListOfSize(25).Build();

            context.Accesos.AddOrUpdate(c => c.AccesoId, Accesos.ToArray());
            context.SaveChanges();
            //context.Clientes.AddOrUpdate(c => c.ClienteId, Clientes.ToArray());

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}