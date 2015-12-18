namespace TPV.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Primera2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "RolID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "RolID");
        }
    }
}
