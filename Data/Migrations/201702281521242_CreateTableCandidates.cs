namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCandidates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        Photo = c.Binary(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        ContactPhone = c.String(),
                        ContactEmail = c.String(),
                        ContactSkype = c.String(),
                        ContactLinkedIn = c.String(),
                        ContactFacebook = c.String(),
                        ContactGoogle = c.String(),
                        ContactGit = c.String(),
                        ContactHomePage = c.String(),
                        EnglishLevels = c.String(),
                        Source = c.String(),
                        Vacancy = c.String(),
                        Attachments = c.Binary(),
                        Description = c.String(),
                        Notes = c.String(),
                        Education = c.String(),
                        CurrentCompany = c.String(),
                        CurrentPosition = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.CandidateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Candidates");
        }
    }
}
