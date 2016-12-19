namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentVMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(),
                        SchoolId = c.String(),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        DateOfBirthString = c.String(),
                        PhotoLocation = c.String(),
                        PreEduInfo = c.String(),
                        GuardianName = c.String(),
                        GuardianMobile = c.String(),
                        GuardialEmail = c.String(),
                        GuardianQualification = c.Int(nullable: false),
                        GuardianOcupation = c.String(),
                        RelationWithGuardian = c.Int(nullable: false),
                        MotherName = c.String(),
                        MotherQualification = c.String(),
                        MotherOcupation = c.String(),
                        TenureYear = c.Int(nullable: false),
                        Stuclass = c.Int(nullable: false),
                        StuSection = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AdmissioinDate = c.DateTime(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentVMs", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.StudentVMs", new[] { "Address_Id" });
            DropTable("dbo.StudentVMs");
        }
    }
}
