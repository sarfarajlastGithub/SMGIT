namespace SM.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewDataChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastUpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "SchoolPhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "AnnulDateOfExam", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Medium", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "EstablishedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SAddresses", "AddL1", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.SAddresses", "AddL2", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SAddresses", "AddL2", c => c.String());
            AlterColumn("dbo.SAddresses", "AddL1", c => c.String());
            DropColumn("dbo.AspNetUsers", "EstablishedDate");
            DropColumn("dbo.AspNetUsers", "Medium");
            DropColumn("dbo.AspNetUsers", "AnnulDateOfExam");
            DropColumn("dbo.AspNetUsers", "SchoolPhoneNumber");
            DropColumn("dbo.AspNetUsers", "LastUpdatedDate");
        }
    }
}
