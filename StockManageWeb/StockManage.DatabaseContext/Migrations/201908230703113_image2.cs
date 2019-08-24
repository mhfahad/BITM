namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Data", c => c.Binary(nullable: false));
            AddColumn("dbo.Suppliers", "Data", c => c.Binary(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Data", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Data", c => c.Binary());
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Suppliers", "Data");
            DropColumn("dbo.Products", "Data");
        }
    }
}
