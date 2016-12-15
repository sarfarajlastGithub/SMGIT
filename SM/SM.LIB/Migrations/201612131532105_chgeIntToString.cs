namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chgeIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SchoolProfiles", "SchoolPhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SchoolProfiles", "SchoolPhoneNumber", c => c.Int(nullable: false));
        }
    }
}
