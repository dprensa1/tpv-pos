namespace TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesos",
                c => new
                    {
                        AccesoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Rutas = c.String(unicode: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccesoID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RolID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Descripcion = c.String(unicode: false),
                        AccesoID = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RolID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Apellido = c.String(unicode: false),
                        Identificacion = c.String(unicode: false),
                        Telefono = c.String(unicode: false),
                        Contacto = c.String(unicode: false),
                        Telefono_Contacto = c.String(unicode: false),
                        Extension_Telefono_Contacto = c.String(unicode: false),
                        Codigo = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        EmpleadoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Apellido = c.String(unicode: false),
                        FechaNacimiento = c.DateTime(nullable: false, precision: 0),
                        Cedula = c.String(unicode: false),
                        Telefono = c.String(unicode: false),
                        Salario = c.Double(nullable: false),
                        PuestoID = c.Int(nullable: false),
                        Codigo = c.Int(nullable: false),
                        FechaEntrada = c.DateTime(nullable: false, precision: 0),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoID);
            
            CreateTable(
                "dbo.Puestos",
                c => new
                    {
                        PuestoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Descripcion = c.String(unicode: false),
                        Funciones = c.String(unicode: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PuestoID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        EmpleadoID = c.Int(nullable: false),
                        User = c.String(unicode: false),
                        Clave = c.String(unicode: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoID, cascadeDelete: true)
                .Index(t => t.EmpleadoID);
            
            CreateTable(
                "dbo.RolAccesoes",
                c => new
                    {
                        Rol_RolID = c.Int(nullable: false),
                        Acceso_AccesoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rol_RolID, t.Acceso_AccesoID })
                .ForeignKey("dbo.Roles", t => t.Rol_RolID, cascadeDelete: true)
                .ForeignKey("dbo.Accesos", t => t.Acceso_AccesoID, cascadeDelete: true)
                .Index(t => t.Rol_RolID)
                .Index(t => t.Acceso_AccesoID);
            
            CreateTable(
                "dbo.PuestoEmpleadoes",
                c => new
                    {
                        Puesto_PuestoID = c.Int(nullable: false),
                        Empleado_EmpleadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Puesto_PuestoID, t.Empleado_EmpleadoID })
                .ForeignKey("dbo.Puestos", t => t.Puesto_PuestoID, cascadeDelete: true)
                .ForeignKey("dbo.Empleados", t => t.Empleado_EmpleadoID, cascadeDelete: true)
                .Index(t => t.Puesto_PuestoID)
                .Index(t => t.Empleado_EmpleadoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "EmpleadoID", "dbo.Empleados");
            DropForeignKey("dbo.PuestoEmpleadoes", "Empleado_EmpleadoID", "dbo.Empleados");
            DropForeignKey("dbo.PuestoEmpleadoes", "Puesto_PuestoID", "dbo.Puestos");
            DropForeignKey("dbo.RolAccesoes", "Acceso_AccesoID", "dbo.Accesos");
            DropForeignKey("dbo.RolAccesoes", "Rol_RolID", "dbo.Roles");
            DropIndex("dbo.PuestoEmpleadoes", new[] { "Empleado_EmpleadoID" });
            DropIndex("dbo.PuestoEmpleadoes", new[] { "Puesto_PuestoID" });
            DropIndex("dbo.RolAccesoes", new[] { "Acceso_AccesoID" });
            DropIndex("dbo.RolAccesoes", new[] { "Rol_RolID" });
            DropIndex("dbo.Usuarios", new[] { "EmpleadoID" });
            DropTable("dbo.PuestoEmpleadoes");
            DropTable("dbo.RolAccesoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Puestos");
            DropTable("dbo.Empleados");
            DropTable("dbo.Clientes");
            DropTable("dbo.Roles");
            DropTable("dbo.Accesos");
        }
    }
}
