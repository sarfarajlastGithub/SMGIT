namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guardianMobileAttChangeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentProfiles", "GuardianMobile", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentProfiles", "GuardianMobile", c => c.Int(nullable: false));
        }
    }
}
