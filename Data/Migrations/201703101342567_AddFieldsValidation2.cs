namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsValidation2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidates", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Candidates", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Candidates", "ContactPhone", c => c.String(maxLength: 450));
            AlterColumn("dbo.Candidates", "ContactEmail", c => c.String(maxLength: 450));
            CreateIndex("dbo.Candidates", "ContactPhone", unique: true);
            CreateIndex("dbo.Candidates", "ContactEmail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Candidates", new[] { "ContactEmail" });
            DropIndex("dbo.Candidates", new[] { "ContactPhone" });
            AlterColumn("dbo.Candidates", "ContactEmail", c => c.String());
            AlterColumn("dbo.Candidates", "ContactPhone", c => c.String());
            AlterColumn("dbo.Candidates", "Gender", c => c.String());
            AlterColumn("dbo.Candidates", "Name", c => c.String());
        }
    }
}
