namespace Vidly_Movie_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres2 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id, Name) Values (1, 'Comedy')");
            Sql("Insert into Genres (Id, Name) Values (2, 'Action')");
            Sql("Insert into Genres (Id, Name) Values (3, 'Family')");
            Sql("Insert into Genres (Id, Name) Values (4, 'Romance')");
            Sql("Insert into Genres (Id, Name) Values (5, 'Mystery')");
            Sql("Insert into Genres (Id, Name) Values (6, 'Horror')");
            Sql("Insert into Genres (Id, Name) Values (7, 'Adventure')");
            Sql("Insert into Genres (Id, Name) Values (8, 'Drama')");
            Sql("Insert into Genres (Id, Name) Values (9, 'Fantasy')");
            Sql("Insert into Genres (Id, Name) Values (10, 'Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
