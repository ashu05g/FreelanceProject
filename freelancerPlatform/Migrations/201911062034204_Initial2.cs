namespace freelancerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FreelancerCustomers", "Freelancer_FId", "dbo.Freelancers");
            DropForeignKey("dbo.FreelancerCustomers", "Customer_CId", "dbo.Customers");
            DropForeignKey("dbo.ServiceFreelancers", "Service_SerId", "dbo.Services");
            DropForeignKey("dbo.ServiceFreelancers", "Freelancer_FId", "dbo.Freelancers");
            DropForeignKey("dbo.Customers", new[] { "Order_CId", "Order_FId" }, "dbo.Orders");
            DropForeignKey("dbo.Freelancers", new[] { "Order_CId", "Order_FId" }, "dbo.Orders");
            DropForeignKey("dbo.Freelancers", new[] { "Specialisation_SerId", "Specialisation_FId" }, "dbo.Specialisations");
            DropForeignKey("dbo.Services", new[] { "Specialisation_SerId", "Specialisation_FId" }, "dbo.Specialisations");
            DropIndex("dbo.Customers", new[] { "Order_CId", "Order_FId" });
            DropIndex("dbo.Freelancers", new[] { "Order_CId", "Order_FId" });
            DropIndex("dbo.Freelancers", new[] { "Specialisation_SerId", "Specialisation_FId" });
            DropIndex("dbo.Services", new[] { "Specialisation_SerId", "Specialisation_FId" });
            DropIndex("dbo.FreelancerCustomers", new[] { "Freelancer_FId" });
            DropIndex("dbo.FreelancerCustomers", new[] { "Customer_CId" });
            DropIndex("dbo.ServiceFreelancers", new[] { "Service_SerId" });
            DropIndex("dbo.ServiceFreelancers", new[] { "Freelancer_FId" });
            AddColumn("dbo.Services", "Price", c => c.Int(nullable: false));
            CreateIndex("dbo.Specialisations", "SerId");
            CreateIndex("dbo.Specialisations", "FId");
            AddForeignKey("dbo.Specialisations", "FId", "dbo.Freelancers", "FId", cascadeDelete: true);
            AddForeignKey("dbo.Specialisations", "SerId", "dbo.Services", "SerId", cascadeDelete: true);
            DropColumn("dbo.Customers", "Order_CId");
            DropColumn("dbo.Customers", "Order_FId");
            DropColumn("dbo.Freelancers", "Order_CId");
            DropColumn("dbo.Freelancers", "Order_FId");
            DropColumn("dbo.Freelancers", "Specialisation_SerId");
            DropColumn("dbo.Freelancers", "Specialisation_FId");
            DropColumn("dbo.Services", "Specialisation_SerId");
            DropColumn("dbo.Services", "Specialisation_FId");
            DropColumn("dbo.Specialisations", "Price");
            DropTable("dbo.Orders");
            DropTable("dbo.FreelancerCustomers");
            DropTable("dbo.ServiceFreelancers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceFreelancers",
                c => new
                    {
                        Service_SerId = c.Int(nullable: false),
                        Freelancer_FId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_SerId, t.Freelancer_FId });
            
            CreateTable(
                "dbo.FreelancerCustomers",
                c => new
                    {
                        Freelancer_FId = c.Int(nullable: false),
                        Customer_CId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Freelancer_FId, t.Customer_CId });
            
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
            
            AddColumn("dbo.Specialisations", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "Specialisation_FId", c => c.Int());
            AddColumn("dbo.Services", "Specialisation_SerId", c => c.Int());
            AddColumn("dbo.Freelancers", "Specialisation_FId", c => c.Int());
            AddColumn("dbo.Freelancers", "Specialisation_SerId", c => c.Int());
            AddColumn("dbo.Freelancers", "Order_FId", c => c.Int());
            AddColumn("dbo.Freelancers", "Order_CId", c => c.Int());
            AddColumn("dbo.Customers", "Order_FId", c => c.Int());
            AddColumn("dbo.Customers", "Order_CId", c => c.Int());
            DropForeignKey("dbo.Specialisations", "SerId", "dbo.Services");
            DropForeignKey("dbo.Specialisations", "FId", "dbo.Freelancers");
            DropIndex("dbo.Specialisations", new[] { "FId" });
            DropIndex("dbo.Specialisations", new[] { "SerId" });
            DropColumn("dbo.Services", "Price");
            CreateIndex("dbo.ServiceFreelancers", "Freelancer_FId");
            CreateIndex("dbo.ServiceFreelancers", "Service_SerId");
            CreateIndex("dbo.FreelancerCustomers", "Customer_CId");
            CreateIndex("dbo.FreelancerCustomers", "Freelancer_FId");
            CreateIndex("dbo.Services", new[] { "Specialisation_SerId", "Specialisation_FId" });
            CreateIndex("dbo.Freelancers", new[] { "Specialisation_SerId", "Specialisation_FId" });
            CreateIndex("dbo.Freelancers", new[] { "Order_CId", "Order_FId" });
            CreateIndex("dbo.Customers", new[] { "Order_CId", "Order_FId" });
            AddForeignKey("dbo.Services", new[] { "Specialisation_SerId", "Specialisation_FId" }, "dbo.Specialisations", new[] { "SerId", "FId" });
            AddForeignKey("dbo.Freelancers", new[] { "Specialisation_SerId", "Specialisation_FId" }, "dbo.Specialisations", new[] { "SerId", "FId" });
            AddForeignKey("dbo.Freelancers", new[] { "Order_CId", "Order_FId" }, "dbo.Orders", new[] { "CId", "FId" });
            AddForeignKey("dbo.Customers", new[] { "Order_CId", "Order_FId" }, "dbo.Orders", new[] { "CId", "FId" });
            AddForeignKey("dbo.ServiceFreelancers", "Freelancer_FId", "dbo.Freelancers", "FId", cascadeDelete: true);
            AddForeignKey("dbo.ServiceFreelancers", "Service_SerId", "dbo.Services", "SerId", cascadeDelete: true);
            AddForeignKey("dbo.FreelancerCustomers", "Customer_CId", "dbo.Customers", "CId", cascadeDelete: true);
            AddForeignKey("dbo.FreelancerCustomers", "Freelancer_FId", "dbo.Freelancers", "FId", cascadeDelete: true);
        }
    }
}
