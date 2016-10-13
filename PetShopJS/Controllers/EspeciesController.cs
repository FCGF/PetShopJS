using PetShopJS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class EspeciesController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Especies
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            IEnumerable<Especie> especies = db.Especies.ToList();

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                especies = especies.Where("Id == @0 OR Nome.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedEspecies = especies.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedEspecies.ToList());
        }

        // GET: Especies/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = db.Especies.Find(id);
            if (especie == null) {
                return HttpNotFound();
            }
            return PartialView(especie);
        }

        // GET: Especies/Create
        public ActionResult Create() {
            return PartialView();
        }

        // POST: Especies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,Nome")] Especie especie) {
            if (ModelState.IsValid) {
                db.Especies.Add(especie);
                db.SaveChanges();
                return Json(new { result = true, message = "Especie criada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Especies/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = db.Especies.Find(id);
            if (especie == null) {
                return HttpNotFound();
            }
            return PartialView(especie);
        }

        // POST: Especies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "Id,Nome")] Especie especie) {
            if (ModelState.IsValid) {
                db.Entry(especie).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = true, message = "Especie editada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Especies/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especie especie = db.Especies.Find(id);
            if (especie == null) {
                return HttpNotFound();
            }
            return PartialView(especie);
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id) {
            Especie especie = db.Especies.Find(id);
            db.Especies.Remove(especie);
            db.SaveChanges();
            return Json(new { result = true, message = "Especie deletada com sucesso" });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
