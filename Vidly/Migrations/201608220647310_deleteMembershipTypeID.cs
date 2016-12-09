namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteMembershipTypeID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "isSubscribedTNewsLetter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "isSubscribedToNewsLetter");
            DropColumn("dbo.Customers", "MemberShipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MemberShipTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "isSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "isSubscribedTNewsLetter");
        }
    }
}
