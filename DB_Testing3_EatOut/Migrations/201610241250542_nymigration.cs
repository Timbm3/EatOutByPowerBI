namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nymigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeTables", "MonthNr", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTables", "DayOfYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TimeTables", "DayOfYear");
            DropColumn("dbo.TimeTables", "MonthNr");
        }
    }
}
