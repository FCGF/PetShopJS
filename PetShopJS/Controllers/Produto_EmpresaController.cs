using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class Produto_EmpresaController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Produto_Empresa
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var produtos = db.Produto_Empresa.Include(p => p.Empresa).Include(p => p.Produto);

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                decimal dec = 0;
                decimal.TryParse(search, out dec);

                produtos = produtos.Where("Id == @0 OR IdEmpresa == @0 OR IdProduto == @0 OR Valor == @1 OR Estoque == @1", integer, dec);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedProdutos = produtos.OrderBy(a => a.IdProduto).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedProdutos.ToList());
        }

        // GET: Produto_Empresa/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto_Empresa produto_Empresa = db.Produto_Empresa.Find(id);
            if (produto_Empresa == null) {
                return HttpNotFound();
            }
            return PartialView(produto_Empresa);
        }

        // GET: Produto_Empresa/Create
        public ActionResult Create() {
            ViewBag.IdEmpresa = new SelectList(db.Empresas, "Id", "Nome");
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome");
            return PartialView();
        }

        // POST: Produto_Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpresa,IdProduto,Valor,Estoque,Ativo")] Produto_Empresa produto_Empresa) {
            if (ModelState.IsValid) {
                db.Produto_Empresa.Add(produto_Empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.Empresas, "Id", "Nome", produto_Empresa.IdEmpresa);
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome", produto_Empresa.IdProduto);
            return View(produto_Empresa);
        }

        // GET: Produto_Empresa/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto_Empresa produto_Empresa = db.Produto_Empresa.Find(id);
            if (produto_Empresa == null) {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresas, "Id", "Nome", produto_Empresa.IdEmpresa);
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome", produto_Empresa.IdProduto);
            return PartialView(produto_Empresa);
        }

        // POST: Produto_Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpresa,IdProduto,Valor,Estoque,Ativo")] Produto_Empresa produto_Empresa) {
            if (ModelState.IsValid) {
                db.Entry(produto_Empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresas, "Id", "Nome", produto_Empresa.IdEmpresa);
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome", produto_Empresa.IdProduto);
            return View(produto_Empresa);
        }

        // GET: Produto_Empresa/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto_Empresa produto_Empresa = db.Produto_Empresa.Find(id);
            if (produto_Empresa == null) {
                return HttpNotFound();
            }
            return PartialView(produto_Empresa);
        }

        // POST: Produto_Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Produto_Empresa produto_Empresa = db.Produto_Empresa.Find(id);
            db.Produto_Empresa.Remove(produto_Empresa);
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
