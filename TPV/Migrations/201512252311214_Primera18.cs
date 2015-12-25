namespace TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera18 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empleados", "Cedula", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empleados", "Cedula", c => c.String(unicode: false));
        }
    }
}
