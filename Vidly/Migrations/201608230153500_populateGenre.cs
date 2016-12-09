namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES(1,'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(2,'Action')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(3,'Family')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(4,'Romance')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(5,'Fiction')");
        }
        
        public override void Down()
        {
        }
    }
}
