namespace TPV.Migrations
{
    using System;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<Lyra>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            // Register mysql code generator
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Lyra db)
        {
         /*   if (!db.Database.Exists())
            {
                // if database did not exist before - create it
                db.Database.Create();
            }

            db.Puesto.AddOrUpdate(
                   new Puesto
                   {
                       Nombre = "Gerente",
                       Descripcion = "Ser Gerente",
                       Funciones = "Funcion",
                       Estado = true
                   });

            db.Empleados.AddOrUpdate(
                new Empleado
                {
                    Nombre = "Emilia",
                    Apellido = "Marte",
                    Cedula = "12345678901",
                    Sexo = 'F',
                    FechaNacimiento = new DateTime(1975, 1, 18),
                    Telefono = "8095900000",
                    Salario = 30.000,
                    FechaEntrada = DateTime.Today,
                    Estado = true
                });

            db.SaveChanges();*/

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