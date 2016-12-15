namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hideFeeAcound : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentRegs", "FeeAccountId", "dbo.FeeAccounts");
            DropIndex("dbo.StudentRegs", new[] { "FeeAccountId" });
            DropColumn("dbo.StudentRegs", "FeeAccountId");
            DropTable("dbo.FeeAccounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FeeAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeePerMonth = c.Int(nullable: false),
                        FeeDiscount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentRegs", "FeeAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentRegs", "FeeAccountId");
            AddForeignKey("dbo.StudentRegs", "FeeAccountId", "dbo.FeeAccounts", "Id", cascadeDelete: true);
        }
    }
}
