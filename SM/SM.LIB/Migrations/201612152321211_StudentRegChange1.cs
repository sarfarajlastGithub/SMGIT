namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentRegChange1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentRegs", "StudentProfileId", c => c.String(nullable: false));
            DropColumn("dbo.StudentRegs", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentRegs", "StudentId", c => c.String(nullable: false));
            DropColumn("dbo.StudentRegs", "StudentProfileId");
        }
    }
}
