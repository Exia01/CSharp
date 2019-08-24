namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTime());
        }
    }
}
