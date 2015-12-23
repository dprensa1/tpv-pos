namespace TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Puestos", "Nombre", c => c.String(nullable: false, maxLength: 32, storeType: "nvarchar"));
            AlterColumn("dbo.Puestos", "Descripcion", c => c.String(nullable: false, maxLength: 128, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Puestos", "Descripcion", c => c.String(unicode: false));
            AlterColumn("dbo.Puestos", "Nombre", c => c.String(unicode: false));
        }
    }
}
