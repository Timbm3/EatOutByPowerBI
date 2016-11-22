namespace EatOutByBI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Date");
        }
    }
}
