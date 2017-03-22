using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Data.DataModel;
using Swan.Models;
using Swan.Providers;


namespace Swan.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
      private SwanDbEntities _db = new SwanDbEntities();

        public ActionResult Login()
        {
            return View(new LogOnModel());          
        }

        [HttpPost]
        public ActionResult Login(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipUser membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(model.Email, model.Password);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при регистрации");
                }
            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult ShowAllUsers()
        {
          return View(_db.Users.Where(c=>true));
        }

        protected override void Dispose(bool disposing)
        {
          if (disposing)
          {
            _db.Dispose();
          }
          base.Dispose(disposing);
        }
    }
}