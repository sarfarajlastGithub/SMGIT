namespace SM.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FewChanges1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassAndSections", "SchoolProfiles_Id", "dbo.SchoolProfiles");
            DropIndex("dbo.ClassAndSections", new[] { "SchoolProfiles_Id" });
            DropColumn("dbo.ClassAndSections", "SchoolProfiles_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.ClassAndSections", "SchoolProfiles_Id", c => c.Int());
            CreateIndex("dbo.ClassAndSections", "SchoolProfiles_Id");
            AddForeignKey("dbo.ClassAndSections", "SchoolProfiles_Id", "dbo.SchoolProfiles", "Id");
        }
    }
}
