using System.Collections.Generic;
using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class CidadesController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Cidades
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var cidades = db.Cidades.Include(c => c.Estado);

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                cidades = cidades.Where("Id == @0 OR IdEstado == @0 OR Nome.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedCidades = cidades.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedCidades.ToList());
        }

        // GET: Cidades/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidades.Find(id);
            if (cidade == null) {
                return HttpNotFound();
            }
            return PartialView(cidade);
        }

        // GET: Cidades/Create
        public ActionResult Create() {
            ViewBag.IdEstado = new SelectList(db.Estadoes, "Id", "Nome");
            return PartialView();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,Nome,IdEstado")] Cidade cidade) {
            if (ModelState.IsValid) {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return Json(new { result = true, message = "Cidade criada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Cidades/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidades.Find(id);
            if (cidade == null) {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.Estadoes, "Id", "Nome", cidade.IdEstado);
            return PartialView(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "Id,Nome,IdEstado")] Cidade cidade) {
            if (ModelState.IsValid) {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = true, message = "Cidade editada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Cidades/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidades.Find(id);
            if (cidade == null) {
                return HttpNotFound();
            }
            return PartialView(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Cidade cidade = db.Cidades.Find(id);
            db.Cidades.Remove(cidade);
            db.SaveChanges();
            return Json(new { result = true, message = "Cidade deletada com sucesso" });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
