namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenreForeignKey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieModels", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.MovieModels", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieModels", "GenreId");
            AddForeignKey("dbo.MovieModels", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.MovieModels", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieModels", "Genre", c => c.String(nullable: false));
            DropForeignKey("dbo.MovieModels", "GenreId", "dbo.Genres");
            DropIndex("dbo.MovieModels", new[] { "GenreId" });
            AlterColumn("dbo.MovieModels", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.MovieModels", "Name", c => c.String(nullable: false));
        }
    }
}
