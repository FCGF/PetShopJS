using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class CategoriasController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Categorias
        public ActionResult Index() {
            var categorias = db.Categorias.Include(c => c.Categoria2);
            return View(categorias.ToList());
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
        public ActionResult Create([Bind(Include = "Id,Nome,IdCategoriaPai")] Categoria categoria) {
            if (ModelState.IsValid) {
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoriaPai = new SelectList(db.Categorias, "Id", "Nome", categoria.IdCategoriaPai);
            return View(categoria);
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
        public ActionResult Edit([Bind(Include = "Id,Nome,IdCategoriaPai")] Categoria categoria) {
            if (ModelState.IsValid) {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoriaPai = new SelectList(db.Categorias, "Id", "Nome", categoria.IdCategoriaPai);
            return View(categoria);
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
        public ActionResult DeleteConfirmed(int id) {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
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
