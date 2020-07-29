namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'178cda8a-5b4a-484f-bd39-0be200660b40', N'admin@vidly.com', 0, N'ABR4GHcm//N8MZrDcJ14cVKvYA4XXsbYjkzWxfZ3psSGs1bnSYuKW4vLMEGwl2msUg==', N'7bb1041a-22a4-404d-8a6b-f4a30092d5c0', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'afbbbf55-be76-41fa-9111-54eb5b3ebd7b', N'testuser@test.com', 0, N'ADoPqCMtW7e0rBndrOylPtLLVKduf4DTvaBqU3/mAwuK5mGxhOl1vX2CL2XiQ7O4fQ==', N'64cad1b2-97c5-4d23-8f8b-7942c1a32fe1', NULL, 0, 0, NULL, 1, 0, N'testuser@test.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'17676549-c835-4bbd-8e34-7f9d849480a0', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'178cda8a-5b4a-484f-bd39-0be200660b40', N'17676549-c835-4bbd-8e34-7f9d849480a0')
            ");

        }

        public override void Down()
        {
        }
    }
}
