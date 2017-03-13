using System;
using System.ComponentModel.DataAnnotations;

namespace Data.DataModel
{
  public class Candidate
  {
    public Candidate()
    {
      DateOfBirth = DateTime.Now;
    }
    public int CandidateId { get; set; }
    public byte[] Photo { get; set; }
    public string PhotoMimeType { get; set; }
    [Required(ErrorMessage = "Field is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Field is required")]
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }

    //[StringLength(450)]
    //[Index(IsUnique = true)]
    //[Required(ErrorMessage = "Field is required")]
    public string ContactPhone { get; set; }

    //[StringLength(450)]
    //[Index(IsUnique = true)]
    //[Required(ErrorMessage = "Field is required")]
    public string ContactEmail { get; set; }

    public string ContactSkype { get; set; }
    public string ContactLinkedIn { get; set; }
    public string ContactFacebook { get; set; }
    public string ContactGoogle { get; set; }
    public string ContactGit { get; set; }
    public string ContactHomePage { get; set; }
    [Required(ErrorMessage = "Field is required")]
    public string EnglishLevels { get; set; }
    [Required(ErrorMessage = "Field is required")]
    public string Source { get; set; }
    public string Vacancy { get; set; }
    public byte[] Attachments { get; set; }
    public string AttachmentsMimeType { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }
    public string Education { get; set; }
    public string CurrentCompany { get; set; }
    public string CurrentPosition { get; set; }
    [Required(ErrorMessage = "Field is required")]
    public string Status { get; set; }
    public int WhoIntroduced { get; set; }
  }
}
