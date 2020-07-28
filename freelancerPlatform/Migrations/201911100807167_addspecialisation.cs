namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addspecialisation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialisations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        About = c.String(),
                        Price = c.Int(nullable: false),
                        Freelancer_FId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Freelancers", t => t.Freelancer_FId)
                .Index(t => t.Freelancer_FId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specialisations", "Freelancer_FId", "dbo.Freelancers");
            DropIndex("dbo.Specialisations", new[] { "Freelancer_FId" });
            DropTable("dbo.Specialisations");
        }
    }
}
