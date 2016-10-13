using System.Collections.Generic;
using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class ProdutosController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Produtos
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var produtos = db.Produtoes.Include(p => p.Animal).Include(p => p.Categoria).Include(p => p.Fabricante);

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                produtos = produtos.Where("Id == @0 OR IdCategoria == @0 OR IdFabricante == @0 OR IdAnimal == @0 OR Nome.Contains(@1) OR Descricao.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedProdutos = produtos.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedProdutos.ToList());
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
        public JsonResult Create([Bind(Include = "Id,IdCategoria,IdFabricante,Nome,Descricao,IdAnimal")] Produto produto) {
            if (ModelState.IsValid) {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return Json(new { result = true, message = "Produto criado com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
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
        public JsonResult Edit([Bind(Include = "Id,IdCategoria,IdFabricante,Nome,Descricao,IdAnimal")] Produto produto) {
            if (ModelState.IsValid) {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = true, message = "Produto editado com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
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
        public JsonResult DeleteConfirmed(int id) {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
            db.SaveChanges();
            return Json(new { result = true, message = "Produto deletado com sucesso" });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
