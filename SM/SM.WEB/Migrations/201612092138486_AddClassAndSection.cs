namespace SM.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassAndSection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassAndSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolId = c.String(),
                        SClass = c.Int(nullable: false),
                        SSection = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassAndSections");
        }
    }
}
