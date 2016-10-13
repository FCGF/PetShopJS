using PetShopJS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class ParcelasController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Parcelas
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            IEnumerable<Parcela> parcelas = db.Parcelas.ToList();

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                decimal dec = 0;
                decimal.TryParse(search, out dec);

                parcelas = parcelas.Where("Id == @0 OR Quantidade == @1 OR Juros == @1", integer, dec);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedParcelas = parcelas.OrderBy(a => a.Quantidade).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedParcelas.ToList());
        }

        // GET: Parcelas/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parcela parcela = db.Parcelas.Find(id);
            if (parcela == null) {
                return HttpNotFound();
            }
            return PartialView(parcela);
        }

        // GET: Parcelas/Create
        public ActionResult Create() {
            return PartialView();
        }

        // POST: Parcelas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,Quantidade,Juros")] Parcela parcela) {
            if (ModelState.IsValid) {
                db.Parcelas.Add(parcela);
                db.SaveChanges();
                return Json(new { result = true, message = "Parcelas criadas com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Parcelas/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parcela parcela = db.Parcelas.Find(id);
            if (parcela == null) {
                return HttpNotFound();
            }
            return PartialView(parcela);
        }

        // POST: Parcelas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "Id,Quantidade,Juros")] Parcela parcela) {
            if (ModelState.IsValid) {
                db.Entry(parcela).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = true, message = "Parcelas editadas com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Parcelas/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parcela parcela = db.Parcelas.Find(id);
            if (parcela == null) {
                return HttpNotFound();
            }
            return PartialView(parcela);
        }

        // POST: Parcelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id) {
            Parcela parcela = db.Parcelas.Find(id);
            db.Parcelas.Remove(parcela);
            db.SaveChanges();
            return Json(new { result = true, message = "Parcelas deletadas com sucesso" });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
