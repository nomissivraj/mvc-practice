namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "Genre");
        }
    }
}
