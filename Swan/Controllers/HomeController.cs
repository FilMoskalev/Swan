﻿using System.Web.Mvc;

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
      ViewBag.SelectedCategory = category;
      return PartialView("Menu");
    }
  }
}