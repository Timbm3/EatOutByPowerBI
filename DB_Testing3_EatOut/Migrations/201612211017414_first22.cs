namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookeds",
                c => new
                    {
                        BookedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookedId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        BookingTimeId = c.Int(nullable: false),
                        BookedId = c.Int(nullable: false),
                        NrOfPeople = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.BookingTimes",
                c => new
                    {
                        BookingTimeId = c.Int(nullable: false, identity: true),
                        Time = c.String(nullable: false),
                        Date = c.String(),
                        DateAndTime = c.DateTime(nullable: false),
                        AvailableSeats = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        BookedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingTimeId)
                .ForeignKey("dbo.Bookeds", t => t.BookedId, cascadeDelete: true)
                .Index(t => t.BookedId);
            
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
                "dbo.EmployeeForms",
                c => new
                    {
                        EmployeeFormID = c.Int(nullable: false, identity: true),
                        EmployeeFormName = c.String(nullable: false, maxLength: 30),
                        EmployeeFormOrderRow = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeFormID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 100),
                        EmployeeFormID = c.Int(nullable: false),
                        EmployeeTypeID = c.Int(nullable: false),
                        Factor1 = c.Int(nullable: false),
                        Factor2 = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.EmployeeForms", t => t.EmployeeFormID, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeTypes", t => t.EmployeeTypeID, cascadeDelete: true)
                .Index(t => t.EmployeeFormID)
                .Index(t => t.EmployeeTypeID);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        EmployeeTypeID = c.Int(nullable: false, identity: true),
                        EmployeeTypeName = c.String(nullable: false, maxLength: 30),
                        EmployeeTypeOrderRow = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeTypeID);
            
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
                        PaymentMethodType = c.String(),
                        Factor1 = c.Int(nullable: false),
                        Factor2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        ProductGroupID = c.Int(nullable: false, identity: true),
                        ProductGroupName = c.String(nullable: false, maxLength: 100),
                        ProductGroupOrderRow = c.Int(nullable: false),
                        ProductTypeID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductGroupID)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeID, cascadeDelete: true)
                .Index(t => t.ProductTypeID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeID = c.Int(nullable: false, identity: true),
                        ProductTypeName = c.String(nullable: false, maxLength: 100),
                        ProductTypeOrderRow = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductTypeID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        ProductGroupID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Unit = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Factor1 = c.Int(nullable: false),
                        Factor2 = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupID, cascadeDelete: true)
                .Index(t => t.ProductGroupID);
            
            CreateTable(
                "dbo.SalesOrderItems",
                c => new
                    {
                        SalesOrderItemId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SalesOrderId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Factor1 = c.Int(nullable: false),
                        Factor2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesOrderItemId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SalesOrders", t => t.SalesOrderId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SalesOrderId);
            
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        SalesOrderId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        SeatId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Factor1 = c.Int(nullable: false),
                        Factor2 = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesOrderId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.SeatId, cascadeDelete: true)
                .Index(t => t.SeatId)
                .Index(t => t.EmployeeId)
                .Index(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        SeatPlace = c.String(nullable: false, maxLength: 30),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Factor1 = c.Int(nullable: false),
                        Factor2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeatId);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        TimeTableID = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        YearWeekNumber = c.Int(nullable: false),
                        MonthName = c.String(nullable: false, maxLength: 30),
                        MonthDay = c.Int(nullable: false),
                        WeekDay = c.String(nullable: false, maxLength: 30),
                        TimeStamp = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Factor1 = c.Int(nullable: false),
                        Factor2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TimeTableID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesOrders", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.SalesOrders", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.SalesOrderItems", "SalesOrderId", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesOrders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SalesOrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductGroupID", "dbo.ProductGroups");
            DropForeignKey("dbo.ProductGroups", "ProductTypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes");
            DropForeignKey("dbo.Employees", "EmployeeTypeID", "dbo.EmployeeTypes");
            DropForeignKey("dbo.Employees", "EmployeeFormID", "dbo.EmployeeForms");
            DropForeignKey("dbo.EmployeeEvents", "EmployeeEventTypeId", "dbo.EmployeeEventTypes");
            DropForeignKey("dbo.BookingTimes", "BookedId", "dbo.Bookeds");
            DropIndex("dbo.SalesOrders", new[] { "PaymentMethodId" });
            DropIndex("dbo.SalesOrders", new[] { "EmployeeId" });
            DropIndex("dbo.SalesOrders", new[] { "SeatId" });
            DropIndex("dbo.SalesOrderItems", new[] { "SalesOrderId" });
            DropIndex("dbo.SalesOrderItems", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ProductGroupID" });
            DropIndex("dbo.ProductGroups", new[] { "ProductTypeID" });
            DropIndex("dbo.Events", new[] { "EventTypeId" });
            DropIndex("dbo.Employees", new[] { "EmployeeTypeID" });
            DropIndex("dbo.Employees", new[] { "EmployeeFormID" });
            DropIndex("dbo.EmployeeEvents", new[] { "EmployeeEventTypeId" });
            DropIndex("dbo.BookingTimes", new[] { "BookedId" });
            DropTable("dbo.TimeTables");
            DropTable("dbo.Seats");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.SalesOrderItems");
            DropTable("dbo.Products");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeForms");
            DropTable("dbo.EmployeeEventTypes");
            DropTable("dbo.EmployeeEvents");
            DropTable("dbo.BookingTimes");
            DropTable("dbo.Bookings");
            DropTable("dbo.Bookeds");
        }
    }
}
