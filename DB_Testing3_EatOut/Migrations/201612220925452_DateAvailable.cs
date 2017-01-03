namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookeds", "IsDateAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookeds", "IsDateAvailable");
        }
    }
}
