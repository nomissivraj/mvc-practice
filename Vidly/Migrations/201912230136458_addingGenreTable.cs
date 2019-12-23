namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingGenreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.MovieModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MovieModels", "Genre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieModels", "Genre", c => c.String());
            AlterColumn("dbo.MovieModels", "Name", c => c.String());
            DropTable("dbo.Genres");
        }
    }
}
