namespace Vidly_Movie_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
