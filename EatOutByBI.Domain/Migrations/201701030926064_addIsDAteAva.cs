namespace EatOutByBI.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsDAteAva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookeds", "IsDateAvailable", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Bookeds", "IsDateAvailable");
        }
    }
}
