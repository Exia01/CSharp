namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateReleasedToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DateReleased", c => c.DateTime(nullable: false));
            //year month date on convert
            Sql("UPDATE movies SET movies.datereleased =Convert(DateTime,'20190512',112) WHERE Id % 2 = 0");
            Sql("UPDATE movies SET movies.datereleased =Convert(DateTime,'20180226',112) WHERE Id % 2 = 1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DateReleased");
        }
    }
}
