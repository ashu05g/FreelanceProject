namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderagain1 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.OId)
                .ForeignKey("dbo.Customers", t => t.CId)
                .ForeignKey("dbo.Freelancers", t => t.FId)
                .ForeignKey("dbo.Specialisations", t => t.SId)
                .Index(t => t.CId)
                .Index(t => t.FId)
                .Index(t => t.SId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "SId", "dbo.Specialisations");
            DropForeignKey("dbo.Orders", "FId", "dbo.Freelancers");
            DropForeignKey("dbo.Orders", "CId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "SId" });
            DropIndex("dbo.Orders", new[] { "FId" });
            DropIndex("dbo.Orders", new[] { "CId" });
            DropTable("dbo.Orders");
        }
    }
}
