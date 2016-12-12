namespace SM.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUserTableAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SchoolProfiles", "LastUpdatedDate", c => c.DateTime());
            AlterColumn("dbo.SchoolProfiles", "AnnulDateOfExam", c => c.DateTime());
            AlterColumn("dbo.SchoolProfiles", "EstablishedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SchoolProfiles", "EstablishedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SchoolProfiles", "AnnulDateOfExam", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SchoolProfiles", "LastUpdatedDate", c => c.DateTime(nullable: false));
        }
    }
}
