namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureClasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductTypeID" });
            AddColumn("dbo.Orders", "TimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Unit", c => c.String());
            AddColumn("dbo.ProductGroups", "ProductTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductGroups", "ProductTypeID");
            AddForeignKey("dbo.ProductGroups", "ProductTypeID", "dbo.ProductTypes", "ProductTypeID", cascadeDelete: true);
            DropColumn("dbo.Products", "OrderRowID");
            DropColumn("dbo.Products", "ProductTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "OrderRowID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductGroups", "ProductTypeID", "dbo.ProductTypes");
            DropIndex("dbo.ProductGroups", new[] { "ProductTypeID" });
            DropColumn("dbo.ProductGroups", "ProductTypeID");
            DropColumn("dbo.Products", "Unit");
            DropColumn("dbo.Products", "Amount");
            DropColumn("dbo.Orders", "TimeStamp");
            CreateIndex("dbo.Products", "ProductTypeID");
            AddForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes", "ProductTypeID", cascadeDelete: true);
        }
    }
}
