namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FewChangesAddedInStudentTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentRegs", "AdmissioinDate", c => c.DateTime());
            AddColumn("dbo.StudentProfiles", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.StudentProfiles", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.StudentProfiles", "GuardialEmail", c => c.String());
            AddColumn("dbo.StudentProfiles", "AsddressId", c => c.Int(nullable: false));
            AddColumn("dbo.StudentProfiles", "Saddress_Id", c => c.Int());
            CreateIndex("dbo.StudentProfiles", "Saddress_Id");
            AddForeignKey("dbo.StudentProfiles", "Saddress_Id", "dbo.SAddresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentProfiles", "Saddress_Id", "dbo.SAddresses");
            DropIndex("dbo.StudentProfiles", new[] { "Saddress_Id" });
            DropColumn("dbo.StudentProfiles", "Saddress_Id");
            DropColumn("dbo.StudentProfiles", "AsddressId");
            DropColumn("dbo.StudentProfiles", "GuardialEmail");
            DropColumn("dbo.StudentProfiles", "DateOfBirth");
            DropColumn("dbo.StudentProfiles", "Age");
            DropColumn("dbo.StudentRegs", "AdmissioinDate");
        }
    }
}
