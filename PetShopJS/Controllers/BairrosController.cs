using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class BairrosController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Bairros
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var bairros = db.Bairroes.Include(b => b.Cidade);

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                bairros = bairros.Where("Id == @0 OR IdCidade == @0 OR Nome.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedBairros = bairros.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedBairros.ToList());
        }

        // GET: Bairros/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.Bairroes.Find(id);
            if (bairro == null) {
                return HttpNotFound();
            }
            return PartialView(bairro);
        }

        // GET: Bairros/Create
        public ActionResult Create() {
            ViewBag.IdCidade = new SelectList(db.Cidades, "Id", "Nome");
            return PartialView();
        }

        // POST: Bairros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCidade,Nome")] Bairro bairro) {
            if (ModelState.IsValid) {
                db.Bairroes.Add(bairro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCidade = new SelectList(db.Cidades, "Id", "Nome", bairro.IdCidade);
            return View(bairro);
        }

        // GET: Bairros/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.Bairroes.Find(id);
            if (bairro == null) {
                return HttpNotFound();
            }
            ViewBag.IdCidade = new SelectList(db.Cidades, "Id", "Nome", bairro.IdCidade);
            return PartialView(bairro);
        }

        // POST: Bairros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCidade,Nome")] Bairro bairro) {
            if (ModelState.IsValid) {
                db.Entry(bairro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCidade = new SelectList(db.Cidades, "Id", "Nome", bairro.IdCidade);
            return View(bairro);
        }

        // GET: Bairros/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.Bairroes.Find(id);
            if (bairro == null) {
                return HttpNotFound();
            }
            return PartialView(bairro);
        }

        // POST: Bairros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Bairro bairro = db.Bairroes.Find(id);
            db.Bairroes.Remove(bairro);
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
