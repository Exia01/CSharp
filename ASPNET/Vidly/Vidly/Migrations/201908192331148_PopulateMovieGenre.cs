namespace Vidly.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenre : DbMigration
    {
        public override void Up()
        {
            var random = new Random();
            var genreList = new List<string> { "Suspense", "Novela", "Drama", "New-Age" };

            int index = random.Next(genreList.Count); //somehow this didn't work lol
            Sql($"UPDATE Movies SET Genre =  '{genreList[index]}' WHERE id = 1");
            Sql($"UPDATE Movies SET Genre =  '{genreList[index]}' WHERE id = 2");
            Sql($"UPDATE Movies SET Genre =  '{genreList[index]}' WHERE id = 3");
            Sql($"UPDATE Movies SET Genre =  '{genreList[index]}' WHERE id = 4");

        }
        
        public override void Down()
        {
        }
    }
}
