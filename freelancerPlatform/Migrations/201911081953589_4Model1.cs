namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4Model1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Freelancers_Services1", "FId", "dbo.Freelancers");
            DropForeignKey("dbo.Freelancers_Services1", "SerId", "dbo.Services");
            DropIndex("dbo.Freelancers_Services1", new[] { "SerId" });
            DropIndex("dbo.Freelancers_Services1", new[] { "FId" });
            DropTable("dbo.Freelancers_Services1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Freelancers_Services1",
                c => new
                    {
                        SerId = c.Int(nullable: false),
                        FId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SerId, t.FId });
            
            CreateIndex("dbo.Freelancers_Services1", "FId");
            CreateIndex("dbo.Freelancers_Services1", "SerId");
            AddForeignKey("dbo.Freelancers_Services1", "SerId", "dbo.Services", "SerId", cascadeDelete: true);
            AddForeignKey("dbo.Freelancers_Services1", "FId", "dbo.Freelancers", "FId", cascadeDelete: true);
        }
    }
}
