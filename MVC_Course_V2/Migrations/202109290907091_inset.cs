namespace MVC_Course_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inset : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(ID,Name) VALUES(1,'Comedy')");
            Sql("INSERT INTO Genres(ID,Name) VALUES(2,'Action')");
            Sql("INSERT INTO Genres(ID,Name) VALUES(3,'Family')");
            Sql("INSERT INTO Genres(ID,Name) VALUES(4,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
