namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            //SQL method to populate DB, properties and values
            Sql("Insert INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES(1,0,0,0)");
            Sql("Insert INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES(2,30,1,10)");
            Sql("Insert INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES(3,90,3,15)");
            Sql("Insert INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES(4,30,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
