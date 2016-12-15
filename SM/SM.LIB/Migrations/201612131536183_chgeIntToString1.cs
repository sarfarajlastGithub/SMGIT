namespace SM.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chgeIntToString1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SchoolProfiles", "TotalStudent", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SchoolProfiles", "TotalStudent", c => c.Int(nullable: false));
        }
    }
}
