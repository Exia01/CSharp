namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMovie_v2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies ( Name, DateAdded, NumberInStock,Genre_id) VALUES ( 'Gone the wind has',Convert(DateTime,'19920626',112),8,2)");
            Sql("INSERT INTO Movies ( Name, DateAdded, NumberInStock,Genre_id) VALUES ( 'Wind, Fire And Ice',Convert(DateTime,'19990626',112),5,1)");
            Sql("INSERT INTO Movies ( Name, DateAdded, NumberInStock,Genre_id) VALUES ( 'Power of the Wind',Convert(DateTime,'20010626',112),6,3)");
            Sql("INSERT INTO Movies ( Name, DateAdded, NumberInStock,Genre_id) VALUES ('Lorem Ipsum has',Convert(DateTime,'19820626',112),6,4)");
            Sql("INSERT INTO Movies ( Name, DateAdded, NumberInStock,Genre_id) VALUES ( 'Gone the wind has',Convert(DateTime,'19820626',112),8,5)");
        }
        
        public override void Down()
        {
        }
    }
}
