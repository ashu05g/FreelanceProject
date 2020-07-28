namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderhistory2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "SId" });
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "SId", c => c.Int());
            AlterColumn("dbo.Orders", "OId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "OId");
            CreateIndex("dbo.Orders", "SId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "SId" });
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "OId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "SId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Orders", "SId");
            CreateIndex("dbo.Orders", "SId");
        }
    }
}
