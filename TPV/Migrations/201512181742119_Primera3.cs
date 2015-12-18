namespace TPV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Usuarios", "User", unique: true, name: "UserIDX");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuarios", "UserIDX");
        }
    }
}
