namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentRegs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolProfileId = c.Int(nullable: false),
                        StudentProfileId = c.Int(nullable: false),
                        StudentName = c.String(),
                        ClassAndSectionId = c.Int(nullable: false),
                        TenureTimeId = c.Int(nullable: false),
                        FeeAccountId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeeAccounts", t => t.FeeAccountId, cascadeDelete: true)
                .ForeignKey("dbo.SchoolProfiles", t => t.SchoolProfileId, cascadeDelete: true)
                .ForeignKey("dbo.ClassAndSections", t => t.ClassAndSectionId, cascadeDelete: true)
                .ForeignKey("dbo.StudentProfiles", t => t.StudentProfileId, cascadeDelete: true)
                .ForeignKey("dbo.TenureTimes", t => t.TenureTimeId, cascadeDelete: true)
                .Index(t => t.SchoolProfileId)
                .Index(t => t.StudentProfileId)
                .Index(t => t.ClassAndSectionId)
                .Index(t => t.TenureTimeId)
                .Index(t => t.FeeAccountId);
            
            CreateTable(
                "dbo.FeeAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeePerMonth = c.Int(nullable: false),
                        FeeDiscount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        PhotoLocation = c.String(),
                        PreEduInfo = c.String(),
                        GuardianName = c.String(),
                        GuardianMobile = c.Int(nullable: false),
                        GuardianQualification = c.Int(nullable: false),
                        GuardianOcupation = c.String(),
                        RelationWithGuardian = c.Int(nullable: false),
                        MotherName = c.String(),
                        MotherQualification = c.String(),
                        MotherOcupation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TenureTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolProfileId = c.Int(nullable: false),
                        TenureYearName = c.Int(nullable: false),
                        TenureStartDate = c.DateTime(),
                        TenureEndDate = c.DateTime(),
                        IsSet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentRegs", "TenureTimeId", "dbo.TenureTimes");
            DropForeignKey("dbo.StudentRegs", "StudentProfileId", "dbo.StudentProfiles");
            DropForeignKey("dbo.StudentRegs", "ClassAndSectionId", "dbo.ClassAndSections");
            DropForeignKey("dbo.StudentRegs", "SchoolProfileId", "dbo.SchoolProfiles");
            DropForeignKey("dbo.StudentRegs", "FeeAccountId", "dbo.FeeAccounts");
            DropIndex("dbo.StudentRegs", new[] { "FeeAccountId" });
            DropIndex("dbo.StudentRegs", new[] { "TenureTimeId" });
            DropIndex("dbo.StudentRegs", new[] { "ClassAndSectionId" });
            DropIndex("dbo.StudentRegs", new[] { "StudentProfileId" });
            DropIndex("dbo.StudentRegs", new[] { "SchoolProfileId" });
            DropTable("dbo.TenureTimes");
            DropTable("dbo.StudentProfiles");
            DropTable("dbo.FeeAccounts");
            DropTable("dbo.StudentRegs");
        }
    }
}
