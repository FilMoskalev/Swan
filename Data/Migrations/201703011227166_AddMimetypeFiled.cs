namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMimetypeFiled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "AttachmentsMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "AttachmentsMimeType");
        }
    }
}
