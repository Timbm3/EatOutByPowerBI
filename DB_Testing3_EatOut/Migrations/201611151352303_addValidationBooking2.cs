namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addValidationBooking2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookingTimes", "Time", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookingTimes", "Time", c => c.DateTime(nullable: false));
        }
    }
}
