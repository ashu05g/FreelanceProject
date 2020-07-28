namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderhistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        OId = c.Int(nullable: false),
                        CId = c.Int(),
                        FId = c.Int(),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CId)
                .ForeignKey("dbo.Freelancers", t => t.FId)
                .ForeignKey("dbo.Specialisations", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.CId)
                .Index(t => t.FId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Id", "dbo.Specialisations");
            DropForeignKey("dbo.Orders", "FId", "dbo.Freelancers");
            DropForeignKey("dbo.Orders", "CId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "FId" });
            DropIndex("dbo.Orders", new[] { "CId" });
            DropIndex("dbo.Orders", new[] { "Id" });
            DropTable("dbo.Orders");
        }
    }
}
