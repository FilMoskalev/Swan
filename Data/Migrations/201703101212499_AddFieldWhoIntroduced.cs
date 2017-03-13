namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldWhoIntroduced : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "WhoIntroduced", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "WhoIntroduced");
        }
    }
}
