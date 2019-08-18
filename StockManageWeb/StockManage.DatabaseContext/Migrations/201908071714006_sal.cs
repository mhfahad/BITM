namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Image", c => c.Binary(nullable: false));
        }
    }
}
