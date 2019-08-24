namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Data", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Data");
        }
    }
}
