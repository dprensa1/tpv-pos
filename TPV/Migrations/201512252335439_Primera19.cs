namespace TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empleados", "Cedula", c => c.String(nullable: false, maxLength: 11, storeType: "nvarchar"));
            AlterColumn("dbo.Empleados", "Telefono", c => c.String(nullable: false, maxLength: 10, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empleados", "Telefono", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Empleados", "Cedula", c => c.String(nullable: false, unicode: false));
        }
    }
}
