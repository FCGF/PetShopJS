using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class EstadosController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Estados
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var estados = db.Estadoes.Include(e => e.Pais);

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                estados = estados.Where("Id == @0 OR IdPais == @0 OR Nome.Contains(@1) OR Abreviacao.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedEspecificacoes = estados.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedEspecificacoes.ToList());
        }

        // GET: Estados/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estadoes.Find(id);
            if (estado == null) {
                return HttpNotFound();
            }
            return PartialView(estado);
        }

        // GET: Estados/Create
        public ActionResult Create() {
            ViewBag.IdPais = new SelectList(db.Pais1, "Id", "Nome");
            return PartialView();
        }

        // POST: Estados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Abreviacao,IdPais")] Estado estado) {
            if (ModelState.IsValid) {
                db.Estadoes.Add(estado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPais = new SelectList(db.Pais1, "Id", "Nome", estado.IdPais);
            return View(estado);
        }

        // GET: Estados/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estadoes.Find(id);
            if (estado == null) {
                return HttpNotFound();
            }
            ViewBag.IdPais = new SelectList(db.Pais1, "Id", "Nome", estado.IdPais);
            return PartialView(estado);
        }

        // POST: Estados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Abreviacao,IdPais")] Estado estado) {
            if (ModelState.IsValid) {
                db.Entry(estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPais = new SelectList(db.Pais1, "Id", "Nome", estado.IdPais);
            return View(estado);
        }

        // GET: Estados/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estadoes.Find(id);
            if (estado == null) {
                return HttpNotFound();
            }
            return PartialView(estado);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Estado estado = db.Estadoes.Find(id);
            db.Estadoes.Remove(estado);
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
