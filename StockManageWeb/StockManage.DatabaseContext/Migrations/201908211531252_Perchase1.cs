namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Perchase1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SupplierID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        manufactureDate = c.DateTime(nullable: false),
                        expireDate = c.DateTime(nullable: false),
                        remarks = c.String(nullable: false),
                        quantity = c.Int(nullable: false),
                        unitPrice = c.Int(nullable: false),
                        newMRP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Purchases", "ProductID", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "ProductID" });
            DropIndex("dbo.Purchases", new[] { "SupplierID" });
            DropTable("dbo.Purchases");
        }
    }
}
