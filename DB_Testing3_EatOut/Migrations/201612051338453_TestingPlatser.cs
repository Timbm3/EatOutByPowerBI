namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingPlatser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingTimes", "AntalPlatser", c => c.Int(nullable: false));
            AddColumn("dbo.BookingTimes", "AntalPersoner", c => c.Int(nullable: false));
            AddColumn("dbo.BookingTimes", "IsAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingTimes", "IsAvailable");
            DropColumn("dbo.BookingTimes", "AntalPersoner");
            DropColumn("dbo.BookingTimes", "AntalPlatser");
        }
    }
}
