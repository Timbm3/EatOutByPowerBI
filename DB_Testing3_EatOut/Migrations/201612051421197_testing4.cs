namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingTimes", "Plats", c => c.Int(nullable: false));
            DropColumn("dbo.BookingTimes", "Pers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingTimes", "Pers", c => c.Int(nullable: false));
            DropColumn("dbo.BookingTimes", "Plats");
        }
    }
}
