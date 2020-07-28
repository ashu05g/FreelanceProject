namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addspecialisation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Specialisations", "Days", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Specialisations", "Days");
        }
    }
}
