namespace TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesos",
                c => new
                    {
                        AccesoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                        Rutas = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
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
                        AccesoID = c.Int(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RolID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        EmpleadoID = c.Int(),
                        User = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        Clave = c.String(nullable: false, maxLength: 16, storeType: "nvarchar"),
                        RolID = c.Int(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoID)
                .Index(t => t.EmpleadoID)
                .Index(t => t.User, unique: true, name: "UserIDX");
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        EmpleadoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Apellido = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        FechaNacimiento = c.DateTime(nullable: false, precision: 0),
                        Cedula = c.String(nullable: false, maxLength: 11, storeType: "nvarchar"),
                        Telefono = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PuestoID = c.Int(nullable: false),
                        Codigo = c.Int(),
                        FechaEntrada = c.DateTime(nullable: false, precision: 0),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoID)
                .ForeignKey("dbo.Puestos", t => t.PuestoID, cascadeDelete: true)
                .Index(t => t.PuestoID)
                .Index(t => t.Codigo, unique: true, name: "CodigoIDX");
            
            CreateTable(
                "dbo.Puestos",
                c => new
                    {
                        PuestoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                        Descripcion = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Funciones = c.String(nullable: false, unicode: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PuestoID);
            
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
                        Codigo = c.Int(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.RolAcceso",
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
                "dbo.UsuarioRol",
                c => new
                    {
                        Usuario_UsuarioID = c.Int(nullable: false),
                        Rol_RolID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_UsuarioID, t.Rol_RolID })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Rol_RolID, cascadeDelete: true)
                .Index(t => t.Usuario_UsuarioID)
                .Index(t => t.Rol_RolID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioRol", "Rol_RolID", "dbo.Roles");
            DropForeignKey("dbo.UsuarioRol", "Usuario_UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "EmpleadoID", "dbo.Empleados");
            DropForeignKey("dbo.Empleados", "PuestoID", "dbo.Puestos");
            DropForeignKey("dbo.RolAcceso", "Acceso_AccesoID", "dbo.Accesos");
            DropForeignKey("dbo.RolAcceso", "Rol_RolID", "dbo.Roles");
            DropIndex("dbo.UsuarioRol", new[] { "Rol_RolID" });
            DropIndex("dbo.UsuarioRol", new[] { "Usuario_UsuarioID" });
            DropIndex("dbo.RolAcceso", new[] { "Acceso_AccesoID" });
            DropIndex("dbo.RolAcceso", new[] { "Rol_RolID" });
            DropIndex("dbo.Empleados", "CodigoIDX");
            DropIndex("dbo.Empleados", new[] { "PuestoID" });
            DropIndex("dbo.Usuarios", "UserIDX");
            DropIndex("dbo.Usuarios", new[] { "EmpleadoID" });
            DropTable("dbo.UsuarioRol");
            DropTable("dbo.RolAcceso");
            DropTable("dbo.Clientes");
            DropTable("dbo.Puestos");
            DropTable("dbo.Empleados");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Roles");
            DropTable("dbo.Accesos");
        }
    }
}
