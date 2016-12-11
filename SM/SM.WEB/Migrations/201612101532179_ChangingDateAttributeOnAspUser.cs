namespace SM.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingDateAttributeOnAspUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RegistarDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "RegistarDate");
        }
    }
}
