namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollBack : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookeds", "BookingTimesIds");
            DropColumn("dbo.Bookeds", "IsDateAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookeds", "IsDateAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bookeds", "BookingTimesIds", c => c.String());
        }
    }
}
