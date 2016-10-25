namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nymigrationn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderRowID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderRowID");
        }
    }
}
