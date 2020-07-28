namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagesfn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Image", c => c.String());
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Image");
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.Customers", "Image");
        }
    }
}
