namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SMFiles",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.String(),
                        StudentProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.StudentProfiles", t => t.StudentProfile_Id)
                .Index(t => t.StudentProfile_Id);
            
            AddColumn("dbo.StudentProfiles", "FileId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SMFiles", "StudentProfile_Id", "dbo.StudentProfiles");
            DropIndex("dbo.SMFiles", new[] { "StudentProfile_Id" });
            DropColumn("dbo.StudentProfiles", "FileId");
            DropTable("dbo.SMFiles");
        }
    }
}
