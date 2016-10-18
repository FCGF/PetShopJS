using System.Collections.Generic;
using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class CategoriasController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Categorias
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var categorias = db.Categorias.Include(c => c.Categoria2).Where(c => c.Nome != null && c.Nome != "" && c.Nome != " ");

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                categorias = categorias.Where("Id == @0 OR IdCategoriaPai == @0 OR Nome.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedCategorias = categorias.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedCategorias.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null) {
                return HttpNotFound();
            }
            return PartialView(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create() {
            ViewBag.IdCategoriaPai = new SelectList(db.Categorias, "Id", "Nome");
            return PartialView();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,Nome,IdCategoriaPai")] Categoria categoria) {
            if (ModelState.IsValid) {
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return Json(new { result = true, message = "Categoria criada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null) {
                return HttpNotFound();
            }
            ViewBag.IdCategoriaPai = new SelectList(db.Categorias, "Id", "Nome", categoria.IdCategoriaPai);
            return PartialView(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "Id,Nome,IdCategoriaPai")] Categoria categoria) {
            if (ModelState.IsValid) {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = true, message = "Categoria editada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null) {
                return HttpNotFound();
            }
            return PartialView(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id) {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
            db.SaveChanges();
            return Json(new { result = true, message = "Categoria deletada com sucesso" });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
