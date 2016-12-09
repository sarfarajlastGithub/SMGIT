namespace SM.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "dateTime", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "dateTime");
        }
    }
}
