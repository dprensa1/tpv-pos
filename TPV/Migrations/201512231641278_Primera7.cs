namespace TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Puestos", "Funciones", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Puestos", "Funciones", c => c.String(unicode: false));
        }
    }
}
