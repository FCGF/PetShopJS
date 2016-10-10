using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class RacasController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Racas
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var racas = db.Racas.Include(r => r.Especie);

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                racas = racas.Where("Id == @0 OR IdEspecie == @0 OR Nome.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedRacas = racas.OrderBy(a => a.IdEspecie).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedRacas.ToList());
        }

        // GET: Racas/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raca raca = db.Racas.Find(id);
            if (raca == null) {
                return HttpNotFound();
            }
            return PartialView(raca);
        }

        // GET: Racas/Create
        public ActionResult Create() {
            ViewBag.IdEspecie = new SelectList(db.Especies, "Id", "Nome");
            return PartialView();
        }

        // POST: Racas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,IdEspecie")] Raca raca) {
            if (ModelState.IsValid) {
                db.Racas.Add(raca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEspecie = new SelectList(db.Especies, "Id", "Nome", raca.IdEspecie);
            return View(raca);
        }

        // GET: Racas/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raca raca = db.Racas.Find(id);
            if (raca == null) {
                return HttpNotFound();
            }
            ViewBag.IdEspecie = new SelectList(db.Especies, "Id", "Nome", raca.IdEspecie);
            return PartialView(raca);
        }

        // POST: Racas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IdEspecie")] Raca raca) {
            if (ModelState.IsValid) {
                db.Entry(raca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEspecie = new SelectList(db.Especies, "Id", "Nome", raca.IdEspecie);
            return View(raca);
        }

        // GET: Racas/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raca raca = db.Racas.Find(id);
            if (raca == null) {
                return HttpNotFound();
            }
            return PartialView(raca);
        }

        // POST: Racas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Raca raca = db.Racas.Find(id);
            db.Racas.Remove(raca);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
