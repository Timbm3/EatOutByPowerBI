namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testBtIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookeds", "BookingTimeIds", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookeds", "BookingTimeIds");
        }
    }
}
