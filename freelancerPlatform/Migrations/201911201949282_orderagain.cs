namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderagain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "FId", "dbo.Freelancers");
            DropForeignKey("dbo.Orders", "SId", "dbo.Specialisations");
            DropIndex("dbo.Orders", new[] { "CId" });
            DropIndex("dbo.Orders", new[] { "FId" });
            DropIndex("dbo.Orders", new[] { "SId" });
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OId = c.Int(nullable: false, identity: true),
                        CId = c.Int(),
                        FId = c.Int(),
                        SId = c.Int(),
                        Description = c.String(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.OId);
            
            CreateIndex("dbo.Orders", "SId");
            CreateIndex("dbo.Orders", "FId");
            CreateIndex("dbo.Orders", "CId");
            AddForeignKey("dbo.Orders", "SId", "dbo.Specialisations", "Id");
            AddForeignKey("dbo.Orders", "FId", "dbo.Freelancers", "FId");
            AddForeignKey("dbo.Orders", "CId", "dbo.Customers", "CId");
        }
    }
}
