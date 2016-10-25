namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "TimeTableID", "dbo.TimeTables");
            DropIndex("dbo.Orders", new[] { "TimeTableID" });
            DropColumn("dbo.Orders", "TimeTableID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TimeTableID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "TimeTableID");
            AddForeignKey("dbo.Orders", "TimeTableID", "dbo.TimeTables", "TimeTableID", cascadeDelete: true);
        }
    }
}
