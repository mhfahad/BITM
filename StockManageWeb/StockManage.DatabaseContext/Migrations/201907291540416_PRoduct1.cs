namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PRoduct1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Category", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Category");
        }
    }
}
