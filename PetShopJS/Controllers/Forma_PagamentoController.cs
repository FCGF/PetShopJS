using PetShopJS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class Forma_PagamentoController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Forma_Pagamento
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            IEnumerable<Forma_Pagamento> formasPagamento = db.Forma_Pagamento.ToList();

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                formasPagamento = formasPagamento.Where("Id == @0 OR Nome.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedFabricantes = formasPagamento.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedFabricantes.ToList());
        }

        // GET: Forma_Pagamento/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forma_Pagamento forma_Pagamento = db.Forma_Pagamento.Find(id);
            if (forma_Pagamento == null) {
                return HttpNotFound();
            }
            return PartialView(forma_Pagamento);
        }

        // GET: Forma_Pagamento/Create
        public ActionResult Create() {
            return PartialView();
        }

        // POST: Forma_Pagamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Forma_Pagamento forma_Pagamento) {
            if (ModelState.IsValid) {
                db.Forma_Pagamento.Add(forma_Pagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forma_Pagamento);
        }

        // GET: Forma_Pagamento/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forma_Pagamento forma_Pagamento = db.Forma_Pagamento.Find(id);
            if (forma_Pagamento == null) {
                return HttpNotFound();
            }
            return PartialView(forma_Pagamento);
        }

        // POST: Forma_Pagamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Forma_Pagamento forma_Pagamento) {
            if (ModelState.IsValid) {
                db.Entry(forma_Pagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forma_Pagamento);
        }

        // GET: Forma_Pagamento/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forma_Pagamento forma_Pagamento = db.Forma_Pagamento.Find(id);
            if (forma_Pagamento == null) {
                return HttpNotFound();
            }
            return PartialView(forma_Pagamento);
        }

        // POST: Forma_Pagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Forma_Pagamento forma_Pagamento = db.Forma_Pagamento.Find(id);
            db.Forma_Pagamento.Remove(forma_Pagamento);
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
