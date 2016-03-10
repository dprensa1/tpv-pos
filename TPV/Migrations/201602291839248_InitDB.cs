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
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 16, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 128),
                        Rutas = c.String(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        CreadoEn = c.String(),
                        CreadoPor = c.String(),
                        ModificadoEn = c.String(),
                        ModificadoPor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 16),
                        Descripcion = c.String(maxLength: 128),
                        Estado = c.Boolean(nullable: false),
                        CreadoEn = c.String(),
                        CreadoPor = c.String(),
                        ModificadoEn = c.String(),
                        ModificadoPor = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpleadoId = c.Int(nullable: false),
                        User = c.String(nullable: false, maxLength: 10),
                        Clave = c.String(nullable: false, maxLength: 32),
                        Estado = c.Boolean(nullable: false),
                        CreadoEn = c.String(),
                        CreadoPor = c.String(),
                        ModificadoEn = c.String(),
                        ModificadoPor = c.String(),
                        Empleado_EmpleadoId = c.Int(),
                        Empleado_Cedula = c.String(maxLength: 11),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleados", t => new { t.Empleado_EmpleadoId, t.Empleado_Cedula })
                .Index(t => new { t.Empleado_EmpleadoId, t.Empleado_Cedula });
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false, maxLength: 11),
                        Nombre = c.String(nullable: false, maxLength: 32),
                        Apellido = c.String(nullable: false, maxLength: 32),
                        Sexo = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                        FechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PuestoId = c.Int(nullable: false),
                        Codigo = c.Int(nullable: false),
                        FechaEntrada = c.DateTime(nullable: false, storeType: "date"),
                        Estado = c.Boolean(nullable: false),
                        CreadoEn = c.String(),
                        CreadoPor = c.String(),
                        ModificadoEn = c.String(),
                        ModificadoPor = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.Cedula })
                .ForeignKey("dbo.Puestos", t => t.PuestoId, cascadeDelete: true)
                .Index(t => t.PuestoId);
            
            CreateTable(
                "dbo.Puestos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 32),
                        Descripcion = c.String(nullable: false, maxLength: 128),
                        Funciones = c.String(nullable: false, maxLength: 4000),
                        Estado = c.Boolean(nullable: false),
                        CreadoEn = c.String(),
                        CreadoPor = c.String(),
                        ModificadoEn = c.String(),
                        ModificadoPor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identificacion = c.String(nullable: false, maxLength: 16),
                        Nombre = c.String(nullable: false, maxLength: 64),
                        Apellido = c.String(maxLength: 32),
                        Telefono = c.String(maxLength: 10),
                        Direccion = c.String(maxLength: 64),
                        Nombre_Contacto = c.String(nullable: false, maxLength: 32),
                        Telefono_Contacto = c.String(nullable: false, maxLength: 10),
                        Codigo = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        CreadoEn = c.String(),
                        CreadoPor = c.String(),
                        ModificadoEn = c.String(),
                        ModificadoPor = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Identificacion });
            
            CreateTable(
                "dbo.RolesAccesos",
                c => new
                    {
                        RolId = c.Int(nullable: false),
                        AccesoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RolId, t.AccesoId })
                .ForeignKey("dbo.Roles", t => t.RolId, cascadeDelete: true)
                .ForeignKey("dbo.Accesos", t => t.AccesoId, cascadeDelete: true)
                .Index(t => t.RolId)
                .Index(t => t.AccesoId);
            
            CreateTable(
                "dbo.UsuariosRoles",
                c => new
                    {
                        UsuarioIdFk = c.Int(nullable: false),
                        RolIdFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UsuarioIdFk, t.RolIdFk })
                .ForeignKey("dbo.Usuarios", t => t.UsuarioIdFk, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RolIdFk, cascadeDelete: true)
                .Index(t => t.UsuarioIdFk)
                .Index(t => t.RolIdFk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuariosRoles", "RolIdFk", "dbo.Roles");
            DropForeignKey("dbo.UsuariosRoles", "UsuarioIdFk", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", new[] { "Empleado_EmpleadoId", "Empleado_Cedula" }, "dbo.Empleados");
            DropForeignKey("dbo.Empleados", "PuestoId", "dbo.Puestos");
            DropForeignKey("dbo.RolesAccesos", "AccesoId", "dbo.Accesos");
            DropForeignKey("dbo.RolesAccesos", "RolId", "dbo.Roles");
            DropIndex("dbo.UsuariosRoles", new[] { "RolIdFk" });
            DropIndex("dbo.UsuariosRoles", new[] { "UsuarioIdFk" });
            DropIndex("dbo.RolesAccesos", new[] { "AccesoId" });
            DropIndex("dbo.RolesAccesos", new[] { "RolId" });
            DropIndex("dbo.Empleados", new[] { "PuestoId" });
            DropIndex("dbo.Usuarios", new[] { "Empleado_EmpleadoId", "Empleado_Cedula" });
            DropTable("dbo.UsuariosRoles");
            DropTable("dbo.RolesAccesos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Puestos");
            DropTable("dbo.Empleados");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Roles");
            DropTable("dbo.Accesos");
        }
    }
}
