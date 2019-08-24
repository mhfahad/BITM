namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Perchase14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "totalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "totalPrice");
        }
    }
}
