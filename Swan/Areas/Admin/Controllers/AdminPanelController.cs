using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Swan.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminPanelController : Controller
    {
        // GET: Admin/AdminPanel
        
        public ActionResult Index()
        {
            
            return View();
        }
    }
}