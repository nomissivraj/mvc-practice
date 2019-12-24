namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) " +
                "Values" +
                "('Action')," +
                "('Comedy')," +
                "('Romance')," +
                "('Thriller')," +
                "('Horror')," +
                "('Animated')," +
                "('Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
