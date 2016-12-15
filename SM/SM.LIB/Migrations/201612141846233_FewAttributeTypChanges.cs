namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FewAttributeTypChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentRegs", "ClassAndSectionId", "dbo.ClassAndSections");
            DropForeignKey("dbo.StudentRegs", "TenureTimeId", "dbo.TenureTimes");
            DropForeignKey("dbo.StudentRegs", "SchoolProfileId", "dbo.SchoolProfiles");
            DropForeignKey("dbo.StudentRegs", "StudentProfileId", "dbo.StudentProfiles");
            DropIndex("dbo.StudentRegs", new[] { "SchoolProfileId" });
            DropIndex("dbo.StudentRegs", new[] { "StudentProfileId" });
            DropIndex("dbo.StudentRegs", new[] { "ClassAndSectionId" });
            DropIndex("dbo.StudentRegs", new[] { "TenureTimeId" });
            RenameColumn(table: "dbo.StudentRegs", name: "StudentProfileId", newName: "StudentProfile_Id");
            AddColumn("dbo.ClassAndSections", "NoOfStudentEachSection", c => c.Int(nullable: false));
            AddColumn("dbo.StudentRegs", "StudentId", c => c.String(nullable: false));
            AddColumn("dbo.StudentRegs", "StuClass", c => c.Int(nullable: false));
            AddColumn("dbo.StudentRegs", "StuSection", c => c.Int(nullable: false));
            AddColumn("dbo.StudentRegs", "TenureYear", c => c.Int(nullable: false));
            AddColumn("dbo.StudentRegs", "SchoolProfile_Id", c => c.Int());
            AddColumn("dbo.StudentProfiles", "StudentId", c => c.String());
            AlterColumn("dbo.StudentRegs", "SchoolProfileId", c => c.String(nullable: false));
            AlterColumn("dbo.StudentRegs", "StudentProfile_Id", c => c.Int());
            CreateIndex("dbo.StudentRegs", "SchoolProfile_Id");
            CreateIndex("dbo.StudentRegs", "StudentProfile_Id");
            AddForeignKey("dbo.StudentRegs", "SchoolProfile_Id", "dbo.SchoolProfiles", "Id");
            AddForeignKey("dbo.StudentRegs", "StudentProfile_Id", "dbo.StudentProfiles", "Id");
            DropColumn("dbo.StudentRegs", "ClassAndSectionId");
            DropColumn("dbo.StudentRegs", "TenureTimeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentRegs", "TenureTimeId", c => c.Int(nullable: false));
            AddColumn("dbo.StudentRegs", "ClassAndSectionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentRegs", "StudentProfile_Id", "dbo.StudentProfiles");
            DropForeignKey("dbo.StudentRegs", "SchoolProfile_Id", "dbo.SchoolProfiles");
            DropIndex("dbo.StudentRegs", new[] { "StudentProfile_Id" });
            DropIndex("dbo.StudentRegs", new[] { "SchoolProfile_Id" });
            AlterColumn("dbo.StudentRegs", "StudentProfile_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentRegs", "SchoolProfileId", c => c.Int(nullable: false));
            DropColumn("dbo.StudentProfiles", "StudentId");
            DropColumn("dbo.StudentRegs", "SchoolProfile_Id");
            DropColumn("dbo.StudentRegs", "TenureYear");
            DropColumn("dbo.StudentRegs", "StuSection");
            DropColumn("dbo.StudentRegs", "StuClass");
            DropColumn("dbo.StudentRegs", "StudentId");
            DropColumn("dbo.ClassAndSections", "NoOfStudentEachSection");
            RenameColumn(table: "dbo.StudentRegs", name: "StudentProfile_Id", newName: "StudentProfileId");
            CreateIndex("dbo.StudentRegs", "TenureTimeId");
            CreateIndex("dbo.StudentRegs", "ClassAndSectionId");
            CreateIndex("dbo.StudentRegs", "StudentProfileId");
            CreateIndex("dbo.StudentRegs", "SchoolProfileId");
            AddForeignKey("dbo.StudentRegs", "StudentProfileId", "dbo.StudentProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentRegs", "SchoolProfileId", "dbo.SchoolProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentRegs", "TenureTimeId", "dbo.TenureTimes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentRegs", "ClassAndSectionId", "dbo.ClassAndSections", "Id", cascadeDelete: true);
        }
    }
}
