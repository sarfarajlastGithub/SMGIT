namespace SM.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchoolPropertyAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddL1 = c.String(),
                        AddL2 = c.String(),
                        Pin = c.Int(nullable: false),
                        City = c.Int(nullable: false),
                        state = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "CPName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CPPhone", c => c.String());
            AddColumn("dbo.AspNetUsers", "schoolFType", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "schoolGType", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "sClass", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "sAddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "sAddressId");
            AddForeignKey("dbo.AspNetUsers", "sAddressId", "dbo.SAddresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "sAddressId", "dbo.SAddresses");
            DropIndex("dbo.AspNetUsers", new[] { "sAddressId" });
            DropColumn("dbo.AspNetUsers", "sAddressId");
            DropColumn("dbo.AspNetUsers", "sClass");
            DropColumn("dbo.AspNetUsers", "schoolGType");
            DropColumn("dbo.AspNetUsers", "schoolFType");
            DropColumn("dbo.AspNetUsers", "CPPhone");
            DropColumn("dbo.AspNetUsers", "CPName");
            DropTable("dbo.SAddresses");
        }
    }
}
