using PetShopJS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class FabricantesController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Fabricantes
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            IEnumerable<Fabricante> fabricantes = db.Fabricantes.ToList();

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                fabricantes = fabricantes.Where("Id == @0 OR Nome.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedFabricantes = fabricantes.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedFabricantes.ToList());
        }

        // GET: Fabricantes/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = db.Fabricantes.Find(id);
            if (fabricante == null) {
                return HttpNotFound();
            }
            return PartialView(fabricante);
        }

        // GET: Fabricantes/Create
        public ActionResult Create() {
            return PartialView();
        }

        // POST: Fabricantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Fabricante fabricante) {
            if (ModelState.IsValid) {
                db.Fabricantes.Add(fabricante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabricante);
        }

        // GET: Fabricantes/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = db.Fabricantes.Find(id);
            if (fabricante == null) {
                return HttpNotFound();
            }
            return PartialView(fabricante);
        }

        // POST: Fabricantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Fabricante fabricante) {
            if (ModelState.IsValid) {
                db.Entry(fabricante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = db.Fabricantes.Find(id);
            if (fabricante == null) {
                return HttpNotFound();
            }
            return PartialView(fabricante);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Fabricante fabricante = db.Fabricantes.Find(id);
            db.Fabricantes.Remove(fabricante);
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
