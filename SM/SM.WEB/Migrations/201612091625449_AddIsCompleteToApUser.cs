namespace SM.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCompleteToApUser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "sAddressId" });
            AddColumn("dbo.AspNetUsers", "IsComplete", c => c.Boolean(nullable: false));
            CreateIndex("dbo.AspNetUsers", "SAddressId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "SAddressId" });
            DropColumn("dbo.AspNetUsers", "IsComplete");
            CreateIndex("dbo.AspNetUsers", "sAddressId");
        }
    }
}
