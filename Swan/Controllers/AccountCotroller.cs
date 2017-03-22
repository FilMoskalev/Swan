using System.Data.Entity;
using System.Linq;
using System.Net;
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
          return View(_db.Users.Where(c=> true).ToList());
        }


        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
          if (id == null)
          {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          }
          User user = _db.Users.Find(id);
          if (user == null)
          {
            return HttpNotFound();
          }
          ViewBag.RoleId = new SelectList(_db.Roles, "Id", "Name", user.RoleId);
          return View(user);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,CreationDate,RoleId")] User user)
        {
          if (ModelState.IsValid)
          {
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("ShowAllUsers", "Account");
          }
          ViewBag.RoleId = new SelectList(_db.Roles, "Id", "Name", user.RoleId);
          return View(user);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
          if (id == null)
          {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          }
          User user = _db.Users.Find(id);
          if (user == null)
          {
            return HttpNotFound();
          }
          return View(user);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          User user = _db.Users.Find(id);
          _db.Users.Remove(user);
          _db.SaveChanges();
          return RedirectToAction("ShowAllUsers", "Account");
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