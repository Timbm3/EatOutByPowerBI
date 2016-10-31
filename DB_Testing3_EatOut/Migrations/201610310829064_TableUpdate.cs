namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "SeatPlace", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.EmployeeForms", "EmployeeFormName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.EmployeeTypes", "EmployeeTypeName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.TimeTables", "MonthName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.TimeTables", "WeekDay", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ProductGroups", "ProductGroupName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ProductTypes", "ProductTypeName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Seats", "TableNr");
            DropColumn("dbo.Seats", "Bar");
            DropColumn("dbo.Seats", "Outside");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "Outside", c => c.Boolean(nullable: false));
            AddColumn("dbo.Seats", "Bar", c => c.Boolean(nullable: false));
            AddColumn("dbo.Seats", "TableNr", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductTypes", "ProductTypeName", c => c.String());
            AlterColumn("dbo.ProductGroups", "ProductGroupName", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.TimeTables", "WeekDay", c => c.String());
            AlterColumn("dbo.TimeTables", "MonthName", c => c.String());
            AlterColumn("dbo.EmployeeTypes", "EmployeeTypeName", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.EmployeeForms", "EmployeeFormName", c => c.String());
            DropColumn("dbo.Seats", "SeatPlace");
        }
    }
}
