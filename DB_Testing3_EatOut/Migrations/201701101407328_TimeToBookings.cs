namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeToBookings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Time", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Time");
        }
    }
}
