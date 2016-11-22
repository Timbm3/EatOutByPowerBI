namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingSystemV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        BookingTimeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.BookingTimes", t => t.BookingTimeId, cascadeDelete: true)
                .Index(t => t.BookingTimeId);
            
            CreateTable(
                "dbo.BookingTimes",
                c => new
                    {
                        BookingTimeId = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingTimeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "BookingTimeId", "dbo.BookingTimes");
            DropIndex("dbo.Bookings", new[] { "BookingTimeId" });
            DropTable("dbo.BookingTimes");
            DropTable("dbo.Bookings");
        }
    }
}
