namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        ProductID = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        MRP = c.Int(nullable: false),
                        TotalMRP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "ProductID" });
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropTable("dbo.Sales");
        }
    }
}
