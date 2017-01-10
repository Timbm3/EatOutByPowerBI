namespace EatOutByBI.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddEventTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "FinnishTime", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Events", "FinnishTime");
        }
    }
}
