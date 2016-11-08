namespace EatOutByBI.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFactorTest5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Factor1", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Factor2", c => c.Int(nullable: false));
            AddColumn("dbo.OrderRows", "Factor1", c => c.Int(nullable: false));
            AddColumn("dbo.OrderRows", "Factor2", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Factor1", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Factor2", c => c.Int(nullable: false));
            AddColumn("dbo.Seats", "Factor1", c => c.Int(nullable: false));
            AddColumn("dbo.Seats", "Factor2", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTables", "Factor1", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTables", "Factor2", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Factor1", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Factor2", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Products", "Factor2");
            DropColumn("dbo.Products", "Factor1");
            DropColumn("dbo.TimeTables", "Factor2");
            DropColumn("dbo.TimeTables", "Factor1");
            DropColumn("dbo.Seats", "Factor2");
            DropColumn("dbo.Seats", "Factor1");
            DropColumn("dbo.Orders", "Factor2");
            DropColumn("dbo.Orders", "Factor1");
            DropColumn("dbo.OrderRows", "Factor2");
            DropColumn("dbo.OrderRows", "Factor1");
            DropColumn("dbo.Employees", "Factor2");
            DropColumn("dbo.Employees", "Factor1");
        }
    }
}
