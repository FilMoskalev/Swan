using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Swan.Models.FieldChoises
{
  public class CandidatesOptions
  {

    public static List<SelectListItem> Gender()
    {
      return new List<SelectListItem>
      {
        new SelectListItem {Value = "Male", Text = "Male"},
        new SelectListItem {Value = "Female", Text = "Female"},
      };
    }

    public static List<SelectListItem> EnglishLevels()
    {
      var list = new List<string>
      {
        "Unknown", "Elementary","Pre-Intermediate","Intermediate","Upper intermediate","Advanced","Proficient","Native"
      };
      return list.Select(cases => new SelectListItem { Value = cases, Text = cases }).ToList();
    }

    public static List<SelectListItem> SourceChoises()
    {
      var list = new List<string>
      {
        "Work ua", "Rabota ua","HH ua","HR chat","Referral","Social networks","Professional networks","Skype chat",
        "Sales school", "Sales event","career karazin","rabota.kharkov.ua","Lardi-Tranc"
      };
      return list.Select(cases => new SelectListItem { Value = cases, Text = cases }).ToList();
    }

    public static List<SelectListItem> StatusCandidate()
    {
      var list = new List<string>
      {
        "Active","Not interested","Passive search","Hired","Freelancer","Our employee"
      };
      return list.Select(cases => new SelectListItem { Value = cases, Text = cases }).ToList();
    }
  }
}