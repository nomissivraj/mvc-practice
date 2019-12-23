namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MovieModels", "Genre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieModels", "Genre", c => c.String());
            AlterColumn("dbo.MovieModels", "Name", c => c.String());
        }
    }
}
