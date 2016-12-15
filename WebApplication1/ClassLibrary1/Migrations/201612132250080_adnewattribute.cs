namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adnewattribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.scClasses", "FirstName", c => c.String());
            AddColumn("dbo.scClasses", "LastName", c => c.String());
            AddColumn("dbo.scClasses", "Age", c => c.String());
            AddColumn("dbo.scClasses", "Active", c => c.Boolean(nullable: false));
            DropColumn("dbo.scClasses", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.scClasses", "Name", c => c.String());
            DropColumn("dbo.scClasses", "Active");
            DropColumn("dbo.scClasses", "Age");
            DropColumn("dbo.scClasses", "LastName");
            DropColumn("dbo.scClasses", "FirstName");
        }
    }
}
