namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRequirements : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Candidates", new[] { "ContactPhone" });
            DropIndex("dbo.Candidates", new[] { "ContactEmail" });
            AlterColumn("dbo.Candidates", "ContactPhone", c => c.String());
            AlterColumn("dbo.Candidates", "ContactEmail", c => c.String());
            AlterColumn("dbo.Candidates", "EnglishLevels", c => c.String(nullable: false));
            AlterColumn("dbo.Candidates", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Candidates", "Status", c => c.String());
            AlterColumn("dbo.Candidates", "EnglishLevels", c => c.String());
            AlterColumn("dbo.Candidates", "ContactEmail", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Candidates", "ContactPhone", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.Candidates", "ContactEmail", unique: true);
            CreateIndex("dbo.Candidates", "ContactPhone", unique: true);
        }
    }
}
