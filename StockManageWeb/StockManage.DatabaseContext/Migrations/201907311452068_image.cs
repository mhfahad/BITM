namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Image", c => c.Binary(nullable: false));
            AddColumn("dbo.Products", "Image", c => c.Binary(nullable: false));
            AddColumn("dbo.Suppliers", "Image", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "Image");
            DropColumn("dbo.Products", "Image");
            DropColumn("dbo.Customers", "Image");
        }
    }
}
