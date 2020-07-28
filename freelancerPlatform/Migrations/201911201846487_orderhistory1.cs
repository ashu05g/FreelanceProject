namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderhistory1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "Id", newName: "SId");
            RenameIndex(table: "dbo.Orders", name: "IX_Id", newName: "IX_SId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_SId", newName: "IX_Id");
            RenameColumn(table: "dbo.Orders", name: "SId", newName: "Id");
        }
    }
}
