namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableCandidates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "PhotoMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "PhotoMimeType");
        }
    }
}
