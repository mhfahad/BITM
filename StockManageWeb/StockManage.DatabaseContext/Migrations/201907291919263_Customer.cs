namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Contact", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Code", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Contuct");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Contuct", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Code", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "Contact");
        }
    }
}
