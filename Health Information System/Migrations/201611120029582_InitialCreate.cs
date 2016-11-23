namespace Health_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AgeMin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AgeMax = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryDetails",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryHeaderID = c.Int(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.CategoryHeaders", t => t.CategoryHeaderID, cascadeDelete: true)
                .Index(t => t.CategoryHeaderID);
            
            CreateTable(
                "dbo.CategoryHeaders",
                c => new
                    {
                        CategoryHeaderID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Description2 = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryHeaderID);
            
            CreateTable(
                "dbo.MemberCategories",
                c => new
                    {
                        MemberID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.CategoryDetails", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberID)
                .Index(t => t.MemberID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SegregatedFundID = c.Int(nullable: false),
                        MemberStatusID = c.Int(nullable: false),
                        MemberNo = c.String(),
                        Suffix = c.Int(nullable: false),
                        Title = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        Initials = c.String(),
                        Surname = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        Race = c.Int(nullable: false),
                        DateOfJoining = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(),
                        EmailAddress = c.String(),
                        Occupation = c.String(),
                        BillingGroupID = c.Int(nullable: false),
                        NationalIDNo = c.Int(nullable: false),
                        Photo = c.Binary(),
                        NationalityID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                        IsDependant = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BillingGroups", t => t.BillingGroupID, cascadeDelete: true)
                .ForeignKey("dbo.Nationalities", t => t.NationalityID, cascadeDelete: true)
                .ForeignKey("dbo.SegregatedFunds", t => t.SegregatedFundID, cascadeDelete: true)
                .Index(t => t.SegregatedFundID)
                .Index(t => t.BillingGroupID)
                .Index(t => t.NationalityID);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SegregatedFunds",
                c => new
                    {
                        SegregatedFundID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SegregatedFundID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "SegregatedFundID", "dbo.SegregatedFunds");
            DropForeignKey("dbo.Members", "NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.MemberCategories", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Members", "BillingGroupID", "dbo.BillingGroups");
            DropForeignKey("dbo.MemberCategories", "CategoryID", "dbo.CategoryDetails");
            DropForeignKey("dbo.CategoryDetails", "CategoryHeaderID", "dbo.CategoryHeaders");
            DropIndex("dbo.Members", new[] { "NationalityID" });
            DropIndex("dbo.Members", new[] { "BillingGroupID" });
            DropIndex("dbo.Members", new[] { "SegregatedFundID" });
            DropIndex("dbo.MemberCategories", new[] { "CategoryID" });
            DropIndex("dbo.MemberCategories", new[] { "MemberID" });
            DropIndex("dbo.CategoryDetails", new[] { "CategoryHeaderID" });
            DropTable("dbo.SegregatedFunds");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Members");
            DropTable("dbo.MemberCategories");
            DropTable("dbo.CategoryHeaders");
            DropTable("dbo.CategoryDetails");
            DropTable("dbo.BillingGroups");
        }
    }
}
