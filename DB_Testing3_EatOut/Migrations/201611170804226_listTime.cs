namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listTime : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "BookingTimeId", "dbo.BookingTimes");
            DropIndex("dbo.Bookings", new[] { "BookingTimeId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Bookings", "BookingTimeId");
            AddForeignKey("dbo.Bookings", "BookingTimeId", "dbo.BookingTimes", "BookingTimeId", cascadeDelete: true);
        }
    }
}
