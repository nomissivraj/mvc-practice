namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CustomerModels (Name, Age, Hobby, IsSubbedNewsLetter, MembershipTypeId) VALUES ('John Smith', 24, 'Football', 0, 1)");
            Sql("INSERT INTO CustomerModels (Name, Age, Hobby, IsSubbedNewsLetter, MembershipTypeId) VALUES ('Mary Wallis', 22, 'Netball', 1, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
