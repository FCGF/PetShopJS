using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class ParcelasController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Parcelas
        public ActionResult Index() {
            return View(db.Parcelas.ToList());
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
        public ActionResult Create([Bind(Include = "Id,Quantidade,Juros")] Parcela parcela) {
            if (ModelState.IsValid) {
                db.Parcelas.Add(parcela);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parcela);
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
        public ActionResult Edit([Bind(Include = "Id,Quantidade,Juros")] Parcela parcela) {
            if (ModelState.IsValid) {
                db.Entry(parcela).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parcela);
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
        public ActionResult DeleteConfirmed(int id) {
            Parcela parcela = db.Parcelas.Find(id);
            db.Parcelas.Remove(parcela);
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
