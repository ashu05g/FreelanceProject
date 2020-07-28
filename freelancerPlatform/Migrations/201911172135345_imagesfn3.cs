namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagesfn3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Freelancers", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Freelancers", "Phone", c => c.String(nullable: false));
        }
    }
}
