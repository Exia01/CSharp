namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "DurationInMoths");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "DurationInMoths", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "DurationInMonths");
        }
    }
}
