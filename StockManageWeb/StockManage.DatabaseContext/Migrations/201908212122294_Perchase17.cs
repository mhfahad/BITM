namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Perchase17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Purchase_ID", c => c.Int());
            CreateIndex("dbo.Products", "Purchase_ID");
            AddForeignKey("dbo.Products", "Purchase_ID", "dbo.Purchases", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Purchase_ID", "dbo.Purchases");
            DropIndex("dbo.Products", new[] { "Purchase_ID" });
            DropColumn("dbo.Products", "Purchase_ID");
        }
    }
}
