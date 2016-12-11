namespace SM.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FewChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassAndSections", "SchoolProfileId", "dbo.SchoolProfiles");
            DropIndex("dbo.ClassAndSections", new[] { "SchoolProfileId" });
            AddColumn("dbo.ClassAndSections", "SchoolProfiles_Id", c => c.Int());
            AddColumn("dbo.SchoolProfiles", "UserId", c => c.String());
            AddColumn("dbo.SAddresses", "SchoolProfileId", c => c.String());
            AlterColumn("dbo.ClassAndSections", "SchoolProfileId", c => c.String(nullable: false));
            CreateIndex("dbo.ClassAndSections", "SchoolProfiles_Id");
            AddForeignKey("dbo.ClassAndSections", "SchoolProfiles_Id", "dbo.SchoolProfiles", "Id");
            DropColumn("dbo.SAddresses", "SchoolUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SAddresses", "SchoolUserName", c => c.String());
            DropForeignKey("dbo.ClassAndSections", "SchoolProfiles_Id", "dbo.SchoolProfiles");
            DropIndex("dbo.ClassAndSections", new[] { "SchoolProfiles_Id" });
            AlterColumn("dbo.ClassAndSections", "SchoolProfileId", c => c.Int(nullable: false));
            DropColumn("dbo.SAddresses", "SchoolProfileId");
            DropColumn("dbo.SchoolProfiles", "UserId");
            DropColumn("dbo.ClassAndSections", "SchoolProfiles_Id");
            CreateIndex("dbo.ClassAndSections", "SchoolProfileId");
            AddForeignKey("dbo.ClassAndSections", "SchoolProfileId", "dbo.SchoolProfiles", "Id", cascadeDelete: true);
        }
    }
}
