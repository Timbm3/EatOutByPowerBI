namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Merge : DbMigration
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
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodId = c.Int(nullable: false, identity: true),
                        PaymentMethods = c.String(),
                        Factor1 = c.Int(nullable: false),
                        Factor2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
            AddColumn("dbo.Orders", "PaymentMethodId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Orders", "PaymentMethodId");
            AddForeignKey("dbo.Orders", "PaymentMethodId", "dbo.PaymentMethods", "PaymentMethodId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes");
            DropForeignKey("dbo.EmployeeEvents", "EmployeeEventTypeId", "dbo.EmployeeEventTypes");
            DropIndex("dbo.Orders", new[] { "PaymentMethodId" });
            DropIndex("dbo.Events", new[] { "EventTypeId" });
            DropIndex("dbo.EmployeeEvents", new[] { "EmployeeEventTypeId" });
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Orders", "PaymentMethodId");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
            DropTable("dbo.EmployeeEventTypes");
            DropTable("dbo.EmployeeEvents");
        }
    }
}
