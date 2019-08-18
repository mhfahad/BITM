namespace StockManage.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Supplies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "Contact", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Suppliers", "ContactPerson", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Suppliers", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Suppliers", "Code", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Suppliers", "Address", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Suppliers", "Email", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Suppliers", "Contuct");
            DropColumn("dbo.Suppliers", "ContuctPerson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "ContuctPerson", c => c.String());
            AddColumn("dbo.Suppliers", "Contuct", c => c.String());
            AlterColumn("dbo.Suppliers", "Email", c => c.String());
            AlterColumn("dbo.Suppliers", "Address", c => c.String());
            AlterColumn("dbo.Suppliers", "Code", c => c.Int(nullable: false));
            AlterColumn("dbo.Suppliers", "Name", c => c.String());
            DropColumn("dbo.Suppliers", "ContactPerson");
            DropColumn("dbo.Suppliers", "Contact");
        }
    }
}
