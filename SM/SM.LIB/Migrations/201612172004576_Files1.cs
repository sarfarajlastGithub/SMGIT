namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentVMs", "smfile_FileId", c => c.Int());
            CreateIndex("dbo.StudentVMs", "smfile_FileId");
            AddForeignKey("dbo.StudentVMs", "smfile_FileId", "dbo.SMFiles", "FileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentVMs", "smfile_FileId", "dbo.SMFiles");
            DropIndex("dbo.StudentVMs", new[] { "smfile_FileId" });
            DropColumn("dbo.StudentVMs", "smfile_FileId");
        }
    }
}
