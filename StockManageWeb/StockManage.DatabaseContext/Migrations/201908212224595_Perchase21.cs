namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Perchase21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "ProductID", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "ProductID" });
            AddColumn("dbo.Sales", "PurchaseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "PurchaseID");
            AddForeignKey("dbo.Sales", "PurchaseID", "dbo.Purchases", "ID", cascadeDelete: true);
            DropColumn("dbo.Sales", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "ProductID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sales", "PurchaseID", "dbo.Purchases");
            DropIndex("dbo.Sales", new[] { "PurchaseID" });
            DropColumn("dbo.Sales", "PurchaseID");
            CreateIndex("dbo.Sales", "ProductID");
            AddForeignKey("dbo.Sales", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
