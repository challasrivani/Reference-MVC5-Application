namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201608252302450_updateMovieRequiredFields : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "MembershipType_Id1" });
            DropColumn("dbo.Customers", "MembershipType_Id");
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id1", newName: "MembershipType_Id");
            AlterColumn("dbo.Customers", "MembershipType_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "MembershipType_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            AlterColumn("dbo.Customers", "MembershipType_Id", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MembershipType_Id1");
            AddColumn("dbo.Customers", "MembershipType_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipType_Id1");
        }
    }
}
