namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extendedVacancies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacancies", "NumberOfPersons", c => c.String());
            AddColumn("dbo.Vacancies", "Team", c => c.String());
            AddColumn("dbo.Vacancies", "Head", c => c.String());
            AddColumn("dbo.Vacancies", "TypeOfPayment", c => c.String());
            AddColumn("dbo.Vacancies", "Amount", c => c.String());
            AddColumn("dbo.Vacancies", "CurrencyType", c => c.String());
            AddColumn("dbo.Vacancies", "PaymentComments", c => c.String());
            AddColumn("dbo.Vacancies", "EmploymentType", c => c.String());
            AddColumn("dbo.Vacancies", "CauseOfOccurrence", c => c.String());
            AddColumn("dbo.Vacancies", "Duties", c => c.String());
            AddColumn("dbo.Vacancies", "GoalsAndObjectives", c => c.String());
            AddColumn("dbo.Vacancies", "Gender", c => c.String());
            AddColumn("dbo.Vacancies", "YearsOld", c => c.String());
            AddColumn("dbo.Vacancies", "FamilyStatus", c => c.String());
            AddColumn("dbo.Vacancies", "Location", c => c.String());
            AddColumn("dbo.Vacancies", "Education", c => c.String());
            AddColumn("dbo.Vacancies", "WorkExperience", c => c.String());
            AddColumn("dbo.Vacancies", "ProfessionalKnowledge", c => c.String());
            AddColumn("dbo.Vacancies", "PersonalQualities", c => c.String());
            AddColumn("dbo.Vacancies", "AdditionalRequirements", c => c.String());
            AddColumn("dbo.Vacancies", "TechnicalInterviewsAreConducted", c => c.String());
            AddColumn("dbo.Vacancies", "TheFinalDecision", c => c.String());
            AddColumn("dbo.Vacancies", "ExpectedDateOfEmployment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vacancies", "ExpectedDateOfEmployment");
            DropColumn("dbo.Vacancies", "TheFinalDecision");
            DropColumn("dbo.Vacancies", "TechnicalInterviewsAreConducted");
            DropColumn("dbo.Vacancies", "AdditionalRequirements");
            DropColumn("dbo.Vacancies", "PersonalQualities");
            DropColumn("dbo.Vacancies", "ProfessionalKnowledge");
            DropColumn("dbo.Vacancies", "WorkExperience");
            DropColumn("dbo.Vacancies", "Education");
            DropColumn("dbo.Vacancies", "Location");
            DropColumn("dbo.Vacancies", "FamilyStatus");
            DropColumn("dbo.Vacancies", "YearsOld");
            DropColumn("dbo.Vacancies", "Gender");
            DropColumn("dbo.Vacancies", "GoalsAndObjectives");
            DropColumn("dbo.Vacancies", "Duties");
            DropColumn("dbo.Vacancies", "CauseOfOccurrence");
            DropColumn("dbo.Vacancies", "EmploymentType");
            DropColumn("dbo.Vacancies", "PaymentComments");
            DropColumn("dbo.Vacancies", "CurrencyType");
            DropColumn("dbo.Vacancies", "Amount");
            DropColumn("dbo.Vacancies", "TypeOfPayment");
            DropColumn("dbo.Vacancies", "Head");
            DropColumn("dbo.Vacancies", "Team");
            DropColumn("dbo.Vacancies", "NumberOfPersons");
        }
    }
}
