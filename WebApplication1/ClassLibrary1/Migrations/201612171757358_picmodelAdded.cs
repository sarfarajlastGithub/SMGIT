namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picmodelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtWorks",
                c => new
                    {
                        ArtWorkId = c.Int(nullable: false, identity: true),
                        ImageMimeType = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ArtworkThumbnail = c.Binary(),
                    })
                .PrimaryKey(t => t.ArtWorkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArtWorks");
        }
    }
}
