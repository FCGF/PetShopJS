using System.Collections.Generic;
using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class EspecificacoesController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Especificacoes
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var especificacoes = db.Especificacaos.Include(e => e.Produto);

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                especificacoes = especificacoes.Where("Id == @0 OR IdProduto == @0 OR Nome.Contains(@1) OR Valor.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedEspecificacoes = especificacoes.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedEspecificacoes.ToList());
        }

        // GET: Especificacoes/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especificacao especificacao = db.Especificacaos.Find(id);
            if (especificacao == null) {
                return HttpNotFound();
            }
            return PartialView(especificacao);
        }

        // GET: Especificacoes/Create
        public ActionResult Create() {
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome");
            return PartialView();
        }

        // POST: Especificacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,IdProduto,Nome,Valor")] Especificacao especificacao) {
            if (ModelState.IsValid) {
                db.Especificacaos.Add(especificacao);
                db.SaveChanges();
                return Json(new { result = true, message = "Especificação criada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Especificacoes/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especificacao especificacao = db.Especificacaos.Find(id);
            if (especificacao == null) {
                return HttpNotFound();
            }
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome", especificacao.IdProduto);
            return PartialView(especificacao);
        }

        // POST: Especificacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "Id,IdProduto,Nome,Valor")] Especificacao especificacao) {
            if (ModelState.IsValid) {
                db.Entry(especificacao).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = true, message = "Especificação editada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Especificacoes/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especificacao especificacao = db.Especificacaos.Find(id);
            if (especificacao == null) {
                return HttpNotFound();
            }
            return PartialView(especificacao);
        }

        // POST: Especificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id) {
            Especificacao especificacao = db.Especificacaos.Find(id);
            db.Especificacaos.Remove(especificacao);
            db.SaveChanges();
            return Json(new { result = true, message = "Especificação deletada com sucesso" });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
