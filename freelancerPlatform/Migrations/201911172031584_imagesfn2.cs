namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagesfn2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Image", c => c.String(nullable: false));
        }
    }
}
