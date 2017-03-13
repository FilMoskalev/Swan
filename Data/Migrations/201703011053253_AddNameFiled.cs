namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameFiled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "Name");
        }
    }
}
