namespace Vidly_Movie_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'004cba41-acbc-4ebe-bde9-1c3a8e0e9c42', N'admin@vidly.com', 0, N'APINFjbzfvRdzjpd3j243eMo7V5fYp+jpsRVCuGxmB3+oeSj8qnfAk1VAPf6ahKvLQ==', N'3aebc119-5b11-41c0-a898-34cbc5744ec0', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'85441f80-944c-444b-85f1-17cc5eaeb9bf', N'guest@vidly.com', 0, N'AITK3oEaB8OkA7QbKEETtXNy4R36GCDjroQNGabF2S1uRdMNPz2dX2ASSsxUZZ4XtA==', N'8dbccbbf-9045-4e58-815e-5f3a8079da24', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c27ae160-5677-46a6-b788-aed0a32006a1', N'CanManageMovies')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'004cba41-acbc-4ebe-bde9-1c3a8e0e9c42', N'c27ae160-5677-46a6-b788-aed0a32006a1')
");
            

        }
        
        public override void Down()
        {
        }
    }
}
