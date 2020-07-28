namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3tables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Specialisations", "FId", "dbo.Freelancers");
            DropForeignKey("dbo.Specialisations", "SerId", "dbo.Services");
            DropIndex("dbo.Specialisations", new[] { "SerId" });
            DropIndex("dbo.Specialisations", new[] { "FId" });
            CreateTable(
                "dbo.ServiceFreelancers",
                c => new
                    {
                        Service_SerId = c.Int(nullable: false),
                        Freelancer_FId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_SerId, t.Freelancer_FId })
                .ForeignKey("dbo.Services", t => t.Service_SerId, cascadeDelete: true)
                .ForeignKey("dbo.Freelancers", t => t.Freelancer_FId, cascadeDelete: true)
                .Index(t => t.Service_SerId)
                .Index(t => t.Freelancer_FId);
            
            DropTable("dbo.Specialisations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Specialisations",
                c => new
                    {
                        SerId = c.Int(nullable: false),
                        FId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SerId, t.FId });
            
            DropForeignKey("dbo.ServiceFreelancers", "Freelancer_FId", "dbo.Freelancers");
            DropForeignKey("dbo.ServiceFreelancers", "Service_SerId", "dbo.Services");
            DropIndex("dbo.ServiceFreelancers", new[] { "Freelancer_FId" });
            DropIndex("dbo.ServiceFreelancers", new[] { "Service_SerId" });
            DropTable("dbo.ServiceFreelancers");
            CreateIndex("dbo.Specialisations", "FId");
            CreateIndex("dbo.Specialisations", "SerId");
            AddForeignKey("dbo.Specialisations", "SerId", "dbo.Services", "SerId", cascadeDelete: true);
            AddForeignKey("dbo.Specialisations", "FId", "dbo.Freelancers", "FId", cascadeDelete: true);
        }
    }
}
