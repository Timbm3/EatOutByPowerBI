namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "AntalPlatser", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "AntalPersoner", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "IsAvailable", c => c.Boolean(nullable: false));
            DropColumn("dbo.BookingTimes", "AntalPlatser");
            DropColumn("dbo.BookingTimes", "AntalPersoner");
            DropColumn("dbo.BookingTimes", "IsAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingTimes", "IsAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.BookingTimes", "AntalPersoner", c => c.Int(nullable: false));
            AddColumn("dbo.BookingTimes", "AntalPlatser", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "IsAvailable");
            DropColumn("dbo.Bookings", "AntalPersoner");
            DropColumn("dbo.Bookings", "AntalPlatser");
        }
    }
}
