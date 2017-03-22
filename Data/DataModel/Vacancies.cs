using System.ComponentModel.DataAnnotations;

namespace Data.DataModel
{
    public class Vacancies
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string Position { get; set; }

        public string NumberOfPersons { get; set; }
        public string Team { get; set; }

        public string Head { get; set; }
        public string TypeOfPayment { get; set; }
        public string Amount { get; set; }
        public string CurrencyType { get; set; }
        public string PaymentComments { get; set; }
        public string EmploymentType { get; set; }
        public string CauseOfOccurrence { get; set; }
        public string Duties { get; set; }
        public string GoalsAndObjectives { get; set; }
        public string Gender { get; set; }
        public string YearsOld { get; set; }
        public string FamilyStatus { get; set; }
        public string Location { get; set; }
        public string Education { get; set; }
        public string WorkExperience { get; set; }
        public string ProfessionalKnowledge { get; set; }
        public string PersonalQualities { get; set; }
        public string AdditionalRequirements { get; set; }
        public string TechnicalInterviewsAreConducted { get; set; }
        public string TheFinalDecision { get; set; }
        public string ExpectedDateOfEmployment { get; set; }

    }
}
