namespace Vidly_Movie_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingLicenceToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicence", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicence");
        }
    }
}
