namespace MVC_Course_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbirthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
