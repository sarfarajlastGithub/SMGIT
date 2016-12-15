namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAddressTblFroStudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentProfiles", "Saddress_Id", "dbo.SAddresses");
            DropIndex("dbo.StudentProfiles", new[] { "Saddress_Id" });
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddL1 = c.String(nullable: false, maxLength: 300),
                        AddL2 = c.String(maxLength: 300),
                        Pin = c.Int(nullable: false),
                        City = c.Int(nullable: false),
                        state = c.Int(nullable: false),
                        StudentProfileId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentProfiles", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentProfiles", "AddressId");
            AddForeignKey("dbo.StudentProfiles", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            DropColumn("dbo.StudentProfiles", "Age");
            DropColumn("dbo.StudentProfiles", "AsddressId");
            DropColumn("dbo.StudentProfiles", "Saddress_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentProfiles", "Saddress_Id", c => c.Int());
            AddColumn("dbo.StudentProfiles", "AsddressId", c => c.Int(nullable: false));
            AddColumn("dbo.StudentProfiles", "Age", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentProfiles", "AddressId", "dbo.Addresses");
            DropIndex("dbo.StudentProfiles", new[] { "AddressId" });
            DropColumn("dbo.StudentProfiles", "AddressId");
            DropTable("dbo.Addresses");
            CreateIndex("dbo.StudentProfiles", "Saddress_Id");
            AddForeignKey("dbo.StudentProfiles", "Saddress_Id", "dbo.SAddresses", "Id");
        }
    }
}
