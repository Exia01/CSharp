namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedMoviesPT2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"

            INSERT INTO [dbo].[Movies] ([Name], [GenreId], [DateAdded], [NumberInStock], [ReleaseDate]) VALUES (N'Gone the wind has', 2, N'1992-06-26 00:00:00', 8, N'2018-02-26 00:00:00')
            INSERT INTO [dbo].[Movies] ([Name], [GenreId], [DateAdded], [NumberInStock], [ReleaseDate]) VALUES (N'Wind, Fire And Ice', 1, N'1999-06-26 00:00:00', 19, N'2019-05-12 00:00:00')
            INSERT INTO [dbo].[Movies] ([Name], [GenreId], [DateAdded], [NumberInStock], [ReleaseDate]) VALUES (N'Power of the Wind', 3, N'2001-06-26 00:00:00', 4, N'2018-02-26 00:00:00')
            INSERT INTO [dbo].[Movies] ([Name], [GenreId], [DateAdded], [NumberInStock], [ReleaseDate]) VALUES (N'Lorem Ipsum has', 4, N'1982-06-26 00:00:00', 6, N'2019-05-12 00:00:00')
            INSERT INTO [dbo].[Movies] ([Name], [GenreId], [DateAdded], [NumberInStock], [ReleaseDate]) VALUES (N'Gone the wind has PT - Rewinded', 5, N'1982-06-26 00:00:00', 4, N'2018-04-26 00:00:00')
            INSERT INTO [dbo].[Movies] ([Name], [GenreId], [DateAdded], [NumberInStock], [ReleaseDate]) VALUES (N'IT Winds pt1', 2, N'2019-08-23 17:43:30', 6, N'2015-12-05 00:00:00')
            INSERT INTO [dbo].[Movies] ([Name], [GenreId], [DateAdded], [NumberInStock], [ReleaseDate]) VALUES (N'The Kinder of the Fair', 4, N'2019-08-25 19:15:10', 2, N'2018-12-09 00:00:00')
            INSERT INTO [dbo].[Movies] ([Name], [GenreId], [DateAdded], [NumberInStock], [ReleaseDate]) VALUES (N'Wind Redu Redux', 1, N'2019-09-25 15:38:19', 12, N'2015-12-09 00:00:00')

            ");
        }

        public override void Down()
        {
        }
    }
}
