namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDoB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "DoB", c => c.DateTime());
            DropColumn("dbo.CustomerModels", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerModels", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerModels", "DoB");
        }
    }
}
