namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class isSubscribertoNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "isSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "isSubscribedToNewsLetter");
        }
    }
}
