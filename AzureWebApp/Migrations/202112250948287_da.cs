namespace AzureWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class da : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RetailStores", "ProductName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RetailStores", "ProductName", c => c.String());
        }
    }
}
