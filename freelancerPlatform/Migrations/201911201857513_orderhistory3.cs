namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderhistory3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
        }
    }
}
