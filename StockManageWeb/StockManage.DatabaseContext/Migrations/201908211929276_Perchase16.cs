namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Perchase16 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Suppliers", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "Image", c => c.Binary(nullable: false));
        }
    }
}
