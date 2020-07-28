namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addspecialisation4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Image");
        }
    }
}
