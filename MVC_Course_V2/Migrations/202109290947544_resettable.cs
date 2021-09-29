namespace MVC_Course_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resettable : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT(Movies,RESEED,0)");
        }
        
        public override void Down()
        {
        }
    }
}
