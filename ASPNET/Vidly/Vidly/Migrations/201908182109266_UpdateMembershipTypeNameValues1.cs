namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeNameValues1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE id % 2 = 0");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE id % 2 = 1");
        }
        
        public override void Down()
        {
        }
    }
}
