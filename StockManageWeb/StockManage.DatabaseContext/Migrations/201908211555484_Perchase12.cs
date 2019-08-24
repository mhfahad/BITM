namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Perchase12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchases", "invoiceNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "invoiceNo");
            DropColumn("dbo.Purchases", "Date");
        }
    }
}
