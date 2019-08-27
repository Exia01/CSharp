namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies ( Name, DateAdded, NumberInStock,Genre_id) VALUES ( 'Gone the wind has', 2/25/2019 ,8,2)");
            Sql("INSERT INTO Movies ( Name, DateAdded, NumberInStock,Genre_id) VALUES ( 'Wind, Fire And Ice', 04/2/2019 ,5,1)");
            Sql("INSERT INTO Movies ( Name, DateAdded, NumberInStock,Genre_id) VALUES ( 'Power of the Wind', 5/15/2019 ,6,3)");
            Sql("INSERT INTO Movies ( Name, DateAdded, NumberInStock,Genre_id) VALUES ('Lorem Ipsum has',02/25/2019 ,6,4)");
            Sql("INSERT INTO Movies ( Name, DateAdded, NumberInStock,Genre_id) VALUES ( 'Gone the wind has', 5/25/2019 ,8,5)");
        }

        public override void Down()
        {
        }
    }
}
