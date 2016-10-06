using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class ProdutosController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Produtos
        public ActionResult Index() {
            var produtoes = db.Produtoes.Include(p => p.Animal).Include(p => p.Categoria).Include(p => p.Fabricante);
            return View(produtoes.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null) {
                return HttpNotFound();
            }
            return PartialView(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create() {
            ViewBag.IdAnimal = new SelectList(db.Animals, "Id", "Nome");
            ViewBag.IdCategoria = new SelectList(db.Categorias, "Id", "Nome");
            ViewBag.IdFabricante = new SelectList(db.Fabricantes, "Id", "Nome");
            return PartialView();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCategoria,IdFabricante,Nome,Descricao,IdAnimal")] Produto produto) {
            if (ModelState.IsValid) {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAnimal = new SelectList(db.Animals, "Id", "Nome", produto.IdAnimal);
            ViewBag.IdCategoria = new SelectList(db.Categorias, "Id", "Nome", produto.IdCategoria);
            ViewBag.IdFabricante = new SelectList(db.Fabricantes, "Id", "Nome", produto.IdFabricante);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null) {
                return HttpNotFound();
            }
            ViewBag.IdAnimal = new SelectList(db.Animals, "Id", "Nome", produto.IdAnimal);
            ViewBag.IdCategoria = new SelectList(db.Categorias, "Id", "Nome", produto.IdCategoria);
            ViewBag.IdFabricante = new SelectList(db.Fabricantes, "Id", "Nome", produto.IdFabricante);
            return PartialView(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCategoria,IdFabricante,Nome,Descricao,IdAnimal")] Produto produto) {
            if (ModelState.IsValid) {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAnimal = new SelectList(db.Animals, "Id", "Nome", produto.IdAnimal);
            ViewBag.IdCategoria = new SelectList(db.Categorias, "Id", "Nome", produto.IdCategoria);
            ViewBag.IdFabricante = new SelectList(db.Fabricantes, "Id", "Nome", produto.IdFabricante);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null) {
                return HttpNotFound();
            }
            return PartialView(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
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
