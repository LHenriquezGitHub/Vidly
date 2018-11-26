namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'43e5eedc-082a-448c-9b51-54bce026ece1', N'guest@vidly2.com', 0, N'AJQ+Toia8vYKpmSAi5t1BCUUmTaumjQEp+qptte4OaBwUucWEZpFKoM5nurPOVLCKg==', N'f2271ddc-7857-46ae-9048-66878a094110', NULL, 0, 0, NULL, 1, 0, N'guest@vidly2.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5b20a0c4-ecf3-477b-890c-71272103d957', N'leonel.henriquez@hotmail.com', 0, N'AIirC3sWuNQczhUWAHf+XJwSfZBbe87GoSBNihGVQDa70SRlwAcC/zt0HnXUL/u5oA==', N'46e789ca-0b92-4b83-ad0c-2b5a9b3f6edb', NULL, 0, 0, NULL, 1, 0, N'leonel.henriquez@hotmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'67f7beb9-c5cd-4060-bb6a-7c6b4a1741ec', N'admin@vidly2.com', 0, N'APA3V8RSOE+zCpVLNiDKKwnTYx8a031l/Fe8fQXjgSwrBYyRvRJ1cuhfozhfV8T8gA==', N'cf56fe7f-c274-4836-808c-d221394a7ada', NULL, 0, 0, NULL, 1, 0, N'admin@vidly2.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'08f5113f-e370-46e9-8df1-675629735797', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'67f7beb9-c5cd-4060-bb6a-7c6b4a1741ec', N'08f5113f-e370-46e9-8df1-675629735797')");
        }
        
        public override void Down()
        {
        }
    }
}
