namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            //verbatim string. Breaking down in multiple lines
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b3a6d084-9a4f-41dd-9b72-bd276a87cefc', N'guest@vidly.com', 0, N'AGoROUfF0z8HViVGqXDi9IgtWXU2I23xY+z4Vkgf51CPs9TvoqnYJe9oQgW3k397TA==', N'4e0f31bd-393c-440d-9c52-bd3d360b644d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ffa3fdb3-4fac-43ba-bbc9-303260824c40', N'admin@vidly.com', 0, N'ANWXlElLbj5ecIH/yLhUZurz0wwC18Vm+VOCeFasBuTXG4XzZJTJ7Nlx8vhAnbiJ6w==', N'cee79672-9360-4286-b44c-9fa5448b2630', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'57982158-6e1f-4b54-ae5c-a21060420bc6', N'canManageMovie')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ffa3fdb3-4fac-43ba-bbc9-303260824c40', N'57982158-6e1f-4b54-ae5c-a21060420bc6')


                ");
        }

        public override void Down()
        {
        }
    }
}
