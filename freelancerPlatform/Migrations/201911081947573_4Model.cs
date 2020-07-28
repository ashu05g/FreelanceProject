namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Freelancers_Services1",
                c => new
                    {
                        SerId = c.Int(nullable: false),
                        FId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SerId, t.FId })
                .ForeignKey("dbo.Freelancers", t => t.FId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.SerId, cascadeDelete: true)
                .Index(t => t.SerId)
                .Index(t => t.FId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Freelancers_Services1", "SerId", "dbo.Services");
            DropForeignKey("dbo.Freelancers_Services1", "FId", "dbo.Freelancers");
            DropIndex("dbo.Freelancers_Services1", new[] { "FId" });
            DropIndex("dbo.Freelancers_Services1", new[] { "SerId" });
            DropTable("dbo.Freelancers_Services1");
        }
    }
}
