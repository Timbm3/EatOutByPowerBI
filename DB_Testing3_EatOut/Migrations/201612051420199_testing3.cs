namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Pers", c => c.Int(nullable: false));
            AddColumn("dbo.BookingTimes", "Pers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingTimes", "Pers");
            DropColumn("dbo.Bookings", "Pers");
        }
    }
}
