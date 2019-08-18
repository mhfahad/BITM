namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sale : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Image", c => c.Binary(nullable: false));
        }
    }
}
