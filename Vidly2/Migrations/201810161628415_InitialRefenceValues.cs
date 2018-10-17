namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialRefenceValues : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20)");


            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Romance')");

        }

        public override void Down()
        {
        }
    }
}
