namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addsubscribedbool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "IsSubbedNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "IsSubbedNewsletter");
        }
    }
}
