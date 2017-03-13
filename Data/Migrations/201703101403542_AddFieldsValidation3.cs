namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsValidation3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidates", "Source", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Candidates", "Source", c => c.String());
        }
    }
}
