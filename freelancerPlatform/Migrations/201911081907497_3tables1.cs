namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3tables1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ServiceFreelancers", newName: "Freelancers_Services");
            RenameColumn(table: "dbo.Freelancers_Services", name: "Service_SerId", newName: "SerId");
            RenameColumn(table: "dbo.Freelancers_Services", name: "Freelancer_FId", newName: "FId");
            RenameIndex(table: "dbo.Freelancers_Services", name: "IX_Freelancer_FId", newName: "IX_FId");
            RenameIndex(table: "dbo.Freelancers_Services", name: "IX_Service_SerId", newName: "IX_SerId");
            DropPrimaryKey("dbo.Freelancers_Services");
            AddPrimaryKey("dbo.Freelancers_Services", new[] { "FId", "SerId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Freelancers_Services");
            AddPrimaryKey("dbo.Freelancers_Services", new[] { "Service_SerId", "Freelancer_FId" });
            RenameIndex(table: "dbo.Freelancers_Services", name: "IX_SerId", newName: "IX_Service_SerId");
            RenameIndex(table: "dbo.Freelancers_Services", name: "IX_FId", newName: "IX_Freelancer_FId");
            RenameColumn(table: "dbo.Freelancers_Services", name: "FId", newName: "Freelancer_FId");
            RenameColumn(table: "dbo.Freelancers_Services", name: "SerId", newName: "Service_SerId");
            RenameTable(name: "dbo.Freelancers_Services", newName: "ServiceFreelancers");
        }
    }
}
