using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.DataModel;

namespace Swan.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";
      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    public PartialViewResult Navigation(string category = null)
    {
      var categories = new Dictionary<string, Dictionary<string, string>>();
      // key = url , value = text

      /*categories["Messages"] = new Dictionary<string, string>
        {
          {"MessagesLPs", "LandingPages"},
          {"MessagesPPs", "Portals"},
          {"SeoMetas", "SeoMetas"},
        };*/
      var selectedCategory = categories
          .Where(x => x.Value.Keys.Contains(category))
          .Select(x => x.Key).ToList().FirstOrDefault();

      ViewBag.SelectedCategory = string.IsNullOrEmpty(selectedCategory) ? category : selectedCategory;
      return PartialView("Menu", categories);
    }
  }
}