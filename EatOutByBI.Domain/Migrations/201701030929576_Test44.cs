namespace EatOutByBI.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Test44 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeEvents",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    CreatedId = c.String(nullable: false),
                    DateTime = c.DateTime(nullable: false),
                    NameOfEvent = c.String(nullable: false, maxLength: 255),
                    EmployeeEventTypeId = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeEventTypes", t => t.EmployeeEventTypeId, cascadeDelete: true)
                .Index(t => t.EmployeeEventTypeId);

            CreateTable(
                "dbo.EmployeeEventTypes",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
               "dbo.Events",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Description = c.String(),
                   Image = c.Binary(),
                   CreatedId = c.String(nullable: false),
                   DateTime = c.DateTime(nullable: false),
                   NameOfEvent = c.String(nullable: false, maxLength: 255),
                   EventTypeId = c.Byte(nullable: false),
               })
               .PrimaryKey(t => t.Id)
               .ForeignKey("dbo.EventTypes", t => t.EventTypeId, cascadeDelete: true)
               .Index(t => t.EventTypeId);

            CreateTable(
                "dbo.EventTypes",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes");
            DropForeignKey("dbo.EmployeeEvents", "EmployeeEventTypeId", "dbo.EmployeeEventTypes");

            DropIndex("dbo.Events", new[] { "EventTypeId" });
            DropIndex("dbo.EmployeeEvents", new[] { "EmployeeEventTypeId" });

            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");

            DropTable("dbo.EmployeeEventTypes");
            DropTable("dbo.EmployeeEvents");

        }
    }
}
