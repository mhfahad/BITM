namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Perchase18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Purchase_ID", "dbo.Purchases");
            DropIndex("dbo.Products", new[] { "Purchase_ID" });
            AddColumn("dbo.Products", "Product_ID", c => c.Int());
            CreateIndex("dbo.Products", "Product_ID");
            AddForeignKey("dbo.Products", "Product_ID", "dbo.Products", "ID");
            DropColumn("dbo.Products", "Purchase_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Purchase_ID", c => c.Int());
            DropForeignKey("dbo.Products", "Product_ID", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Product_ID" });
            DropColumn("dbo.Products", "Product_ID");
            CreateIndex("dbo.Products", "Purchase_ID");
            AddForeignKey("dbo.Products", "Purchase_ID", "dbo.Purchases", "ID");
        }
    }
}
