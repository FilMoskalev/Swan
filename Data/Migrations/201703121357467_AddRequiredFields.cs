namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredFields : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Candidates", new[] { "ContactPhone" });
            DropIndex("dbo.Candidates", new[] { "ContactEmail" });
            AlterColumn("dbo.Candidates", "ContactPhone", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Candidates", "ContactEmail", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.Candidates", "ContactPhone", unique: true);
            CreateIndex("dbo.Candidates", "ContactEmail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Candidates", new[] { "ContactEmail" });
            DropIndex("dbo.Candidates", new[] { "ContactPhone" });
            AlterColumn("dbo.Candidates", "ContactEmail", c => c.String(maxLength: 450));
            AlterColumn("dbo.Candidates", "ContactPhone", c => c.String(maxLength: 450));
            CreateIndex("dbo.Candidates", "ContactEmail", unique: true);
            CreateIndex("dbo.Candidates", "ContactPhone", unique: true);
        }
    }
}
