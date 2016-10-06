using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class Compra_Produto_EmpresaController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Compra_Produto_Empresa
        public ActionResult Index() {
            var compra_Produto_Empresa = db.Compra_Produto_Empresa.Include(c => c.Compra).Include(c => c.Produto_Empresa);
            return View(compra_Produto_Empresa.ToList());
        }

        // GET: Compra_Produto_Empresa/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra_Produto_Empresa compra_Produto_Empresa = db.Compra_Produto_Empresa.Find(id);
            if (compra_Produto_Empresa == null) {
                return HttpNotFound();
            }
            return PartialView(compra_Produto_Empresa);
        }

        // GET: Compra_Produto_Empresa/Create
        public ActionResult Create() {
            ViewBag.IdCompra = new SelectList(db.Compras, "Id", "Codigo");
            ViewBag.IdProdutoEmpresa = new SelectList(db.Produto_Empresa, "Id", "Id");
            return PartialView();
        }

        // POST: Compra_Produto_Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdProdutoEmpresa,IdCompra,Quantidade,ValorUnitario")] Compra_Produto_Empresa compra_Produto_Empresa) {
            if (ModelState.IsValid) {
                db.Compra_Produto_Empresa.Add(compra_Produto_Empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCompra = new SelectList(db.Compras, "Id", "Codigo", compra_Produto_Empresa.IdCompra);
            ViewBag.IdProdutoEmpresa = new SelectList(db.Produto_Empresa, "Id", "Id", compra_Produto_Empresa.IdProdutoEmpresa);
            return View(compra_Produto_Empresa);
        }

        // GET: Compra_Produto_Empresa/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra_Produto_Empresa compra_Produto_Empresa = db.Compra_Produto_Empresa.Find(id);
            if (compra_Produto_Empresa == null) {
                return HttpNotFound();
            }
            ViewBag.IdCompra = new SelectList(db.Compras, "Id", "Codigo", compra_Produto_Empresa.IdCompra);
            ViewBag.IdProdutoEmpresa = new SelectList(db.Produto_Empresa, "Id", "Id", compra_Produto_Empresa.IdProdutoEmpresa);
            return PartialView(compra_Produto_Empresa);
        }

        // POST: Compra_Produto_Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdProdutoEmpresa,IdCompra,Quantidade,ValorUnitario")] Compra_Produto_Empresa compra_Produto_Empresa) {
            if (ModelState.IsValid) {
                db.Entry(compra_Produto_Empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCompra = new SelectList(db.Compras, "Id", "Codigo", compra_Produto_Empresa.IdCompra);
            ViewBag.IdProdutoEmpresa = new SelectList(db.Produto_Empresa, "Id", "Id", compra_Produto_Empresa.IdProdutoEmpresa);
            return View(compra_Produto_Empresa);
        }

        // GET: Compra_Produto_Empresa/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra_Produto_Empresa compra_Produto_Empresa = db.Compra_Produto_Empresa.Find(id);
            if (compra_Produto_Empresa == null) {
                return HttpNotFound();
            }
            return PartialView(compra_Produto_Empresa);
        }

        // POST: Compra_Produto_Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Compra_Produto_Empresa compra_Produto_Empresa = db.Compra_Produto_Empresa.Find(id);
            db.Compra_Produto_Empresa.Remove(compra_Produto_Empresa);
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
