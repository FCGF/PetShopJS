using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class EnderecosController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Enderecos
        public ActionResult Index() {
            var enderecoes = db.Enderecoes.Include(e => e.Bairro);
            return View(enderecoes.ToList());
        }

        // GET: Enderecos/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecoes.Find(id);
            if (endereco == null) {
                return HttpNotFound();
            }
            return PartialView(endereco);
        }

        // GET: Enderecos/Create
        public ActionResult Create() {
            ViewBag.IdBairro = new SelectList(db.Bairroes, "Id", "Nome");
            return PartialView();
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdBairro,Endereco1,Endereco2,CEP")] Endereco endereco) {
            if (ModelState.IsValid) {
                db.Enderecoes.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBairro = new SelectList(db.Bairroes, "Id", "Nome", endereco.IdBairro);
            return View(endereco);
        }

        // GET: Enderecos/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecoes.Find(id);
            if (endereco == null) {
                return HttpNotFound();
            }
            ViewBag.IdBairro = new SelectList(db.Bairroes, "Id", "Nome", endereco.IdBairro);
            return PartialView(endereco);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdBairro,Endereco1,Endereco2,CEP")] Endereco endereco) {
            if (ModelState.IsValid) {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBairro = new SelectList(db.Bairroes, "Id", "Nome", endereco.IdBairro);
            return View(endereco);
        }

        // GET: Enderecos/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecoes.Find(id);
            if (endereco == null) {
                return HttpNotFound();
            }
            return PartialView(endereco);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Endereco endereco = db.Enderecoes.Find(id);
            db.Enderecoes.Remove(endereco);
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
