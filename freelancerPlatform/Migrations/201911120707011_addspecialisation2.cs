namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addspecialisation2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Freelancers", "Image", c => c.String());
            AddColumn("dbo.Specialisations", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Specialisations", "Description");
            DropColumn("dbo.Freelancers", "Image");
        }
    }
}
