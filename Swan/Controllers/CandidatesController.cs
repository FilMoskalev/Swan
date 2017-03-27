using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.DataModel;

namespace Swan.Controllers
{
    [Authorize]
    public class CandidatesController : Controller
    {
        private SwanDbEntities _db = new SwanDbEntities();

        // GET: Candidates
        public ActionResult Index()
        {
            return View(_db.Candidate.ToList());
        }

        public FileContentResult GetPhotoCandidates(int candidateId)
        {
          Candidate candidate = _db.Candidate
              .FirstOrDefault(g => g.CandidateId == candidateId);

          if (candidate != null)
          {
            return File(candidate.Photo, candidate.PhotoMimeType);
          }
          else
          {
            return null;
          }
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = _db.Candidate.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            ViewBag.Vacancy = new SelectList(_db.Vacancies, "Id", "Position");
            return View("Edit", new Candidate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Candidate candidate, HttpPostedFileBase image=null, HttpPostedFileBase file = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    candidate.PhotoMimeType = image.ContentType;
                    candidate.Photo = new byte[image.ContentLength];
                    image.InputStream.Read(candidate.Photo, 0, image.ContentLength);
                }

                if (file != null)
                {
                    candidate.AttachmentsMimeType = file.ContentType;
                    candidate.Attachments = new byte[file.ContentLength];
                    file.InputStream.Read(candidate.Attachments, 0, file.ContentLength);
                }
                
                if (candidate.CandidateId == 0)
                {
                    _db.Candidate.Add(candidate);
                }
                else
                {
                    var entry = _db.Entry(candidate);
                    entry.State = EntityState.Modified;
                    if (image == null)
                    {
                        entry.Property(e => e.Photo).IsModified = false;
                        entry.Property(e => e.PhotoMimeType).IsModified = false;
                    }
                    if (file == null)
                    {
                        entry.Property(e => e.Attachments).IsModified = false;
                        entry.Property(e => e.AttachmentsMimeType).IsModified = false;
                    }
                    
                }
                candidate.WhoIntroduced = _db.Users.First(u => u.Email == HttpContext.User.Identity.Name).Id;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vacancy = new SelectList(_db.Vacancies, "Id", "Position", candidate.Vacancy);
            return View("Edit", candidate);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = _db.Candidate.Find(id);
            ViewBag.Vacancy = new SelectList(_db.Vacancies, "Id", "Position", candidate.Vacancy);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = _db.Candidate.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = _db.Candidate.Find(id);
            _db.Candidate.Remove(candidate);
            _db.SaveChanges();
            return RedirectToAction("Index");
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
