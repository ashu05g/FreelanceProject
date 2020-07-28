namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addspeci : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Specialisations", name: "Freelancer_FId", newName: "FId");
            RenameIndex(table: "dbo.Specialisations", name: "IX_Freelancer_FId", newName: "IX_FId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Specialisations", name: "IX_FId", newName: "IX_Freelancer_FId");
            RenameColumn(table: "dbo.Specialisations", name: "FId", newName: "Freelancer_FId");
        }
    }
}
