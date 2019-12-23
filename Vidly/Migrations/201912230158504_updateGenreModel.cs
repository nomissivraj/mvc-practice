namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGenreModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "GenreId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "GenreId");
        }
    }
}
