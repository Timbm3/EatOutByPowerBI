namespace EatOutByBI.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addValidationBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "DateAndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bookings", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Bookings", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Bookings", "Date", c => c.String(nullable: false));
            DropColumn("dbo.Bookings", "TimeStamp");
        }

        public override void Down()
        {
            AddColumn("dbo.Bookings", "TimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bookings", "Date", c => c.String());
            AlterColumn("dbo.Bookings", "Email", c => c.String());
            AlterColumn("dbo.Bookings", "Name", c => c.String());
            DropColumn("dbo.Bookings", "DateAndTime");
        }
    }
}
