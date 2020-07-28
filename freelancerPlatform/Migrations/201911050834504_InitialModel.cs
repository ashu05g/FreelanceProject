namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 255),
                        City = c.String(),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Order_CId = c.Int(),
                        Order_FId = c.Int(),
                    })
                .PrimaryKey(t => t.CId)
                .ForeignKey("dbo.Orders", t => new { t.Order_CId, t.Order_FId })
                .Index(t => new { t.Order_CId, t.Order_FId });
            
            CreateTable(
                "dbo.Freelancers",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 255),
                        City = c.String(),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Order_CId = c.Int(),
                        Order_FId = c.Int(),
                        Specialisation_SerId = c.Int(),
                        Specialisation_FId = c.Int(),
                    })
                .PrimaryKey(t => t.FId)
                .ForeignKey("dbo.Orders", t => new { t.Order_CId, t.Order_FId })
                .ForeignKey("dbo.Specialisations", t => new { t.Specialisation_SerId, t.Specialisation_FId })
                .Index(t => new { t.Order_CId, t.Order_FId })
                .Index(t => new { t.Specialisation_SerId, t.Specialisation_FId });
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        SerId = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false, maxLength: 255),
                        Specialisation_SerId = c.Int(),
                        Specialisation_FId = c.Int(),
                    })
                .PrimaryKey(t => t.SerId)
                .ForeignKey("dbo.Specialisations", t => new { t.Specialisation_SerId, t.Specialisation_FId })
                .Index(t => new { t.Specialisation_SerId, t.Specialisation_FId });
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        CId = c.Int(nullable: false),
                        FId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        FinalPrice = c.Int(nullable: false),
                        Period = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CId, t.FId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Specialisations",
                c => new
                    {
                        SerId = c.Int(nullable: false),
                        FId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SerId, t.FId });
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FreelancerCustomers",
                c => new
                    {
                        Freelancer_FId = c.Int(nullable: false),
                        Customer_CId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Freelancer_FId, t.Customer_CId })
                .ForeignKey("dbo.Freelancers", t => t.Freelancer_FId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CId, cascadeDelete: true)
                .Index(t => t.Freelancer_FId)
                .Index(t => t.Customer_CId);
            
            CreateTable(
                "dbo.ServiceFreelancers",
                c => new
                    {
                        Service_SerId = c.Int(nullable: false),
                        Freelancer_FId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_SerId, t.Freelancer_FId })
                .ForeignKey("dbo.Services", t => t.Service_SerId, cascadeDelete: true)
                .ForeignKey("dbo.Freelancers", t => t.Freelancer_FId, cascadeDelete: true)
                .Index(t => t.Service_SerId)
                .Index(t => t.Freelancer_FId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Services", new[] { "Specialisation_SerId", "Specialisation_FId" }, "dbo.Specialisations");
            DropForeignKey("dbo.Freelancers", new[] { "Specialisation_SerId", "Specialisation_FId" }, "dbo.Specialisations");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Freelancers", new[] { "Order_CId", "Order_FId" }, "dbo.Orders");
            DropForeignKey("dbo.Customers", new[] { "Order_CId", "Order_FId" }, "dbo.Orders");
            DropForeignKey("dbo.ServiceFreelancers", "Freelancer_FId", "dbo.Freelancers");
            DropForeignKey("dbo.ServiceFreelancers", "Service_SerId", "dbo.Services");
            DropForeignKey("dbo.FreelancerCustomers", "Customer_CId", "dbo.Customers");
            DropForeignKey("dbo.FreelancerCustomers", "Freelancer_FId", "dbo.Freelancers");
            DropIndex("dbo.ServiceFreelancers", new[] { "Freelancer_FId" });
            DropIndex("dbo.ServiceFreelancers", new[] { "Service_SerId" });
            DropIndex("dbo.FreelancerCustomers", new[] { "Customer_CId" });
            DropIndex("dbo.FreelancerCustomers", new[] { "Freelancer_FId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Services", new[] { "Specialisation_SerId", "Specialisation_FId" });
            DropIndex("dbo.Freelancers", new[] { "Specialisation_SerId", "Specialisation_FId" });
            DropIndex("dbo.Freelancers", new[] { "Order_CId", "Order_FId" });
            DropIndex("dbo.Customers", new[] { "Order_CId", "Order_FId" });
            DropTable("dbo.ServiceFreelancers");
            DropTable("dbo.FreelancerCustomers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Specialisations");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Orders");
            DropTable("dbo.Services");
            DropTable("dbo.Freelancers");
            DropTable("dbo.Customers");
        }
    }
}
