namespace SM.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingDateTimeFormateNulleble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "LastUpdatedDate", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "AnnulDateOfExam", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "EstablishedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "EstablishedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "AnnulDateOfExam", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastUpdatedDate", c => c.DateTime(nullable: false));
        }
    }
}
