namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addspecialisation3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Freelancers", "About", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Freelancers", "About");
        }
    }
}
