using PetShopJS.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class CondicoesController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Condicoes
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            IEnumerable<Condicao> condicao = db.Condicaos.ToList();

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                condicao = condicao.Where("Id == @0 OR Nome.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedCondicoes = condicao.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedCondicoes.ToList());
        }

        // GET: Condicoes/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicao condicao = db.Condicaos.Find(id);
            if (condicao == null) {
                return HttpNotFound();
            }
            return PartialView(condicao);
        }

        // GET: Condicoes/Create
        public ActionResult Create() {
            return PartialView();
        }

        // POST: Condicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,Nome")] Condicao condicao) {
            if (ModelState.IsValid) {
                db.Condicaos.Add(condicao);
                db.SaveChanges();
                return Json(new { result = true, message = "Condição criada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Condicoes/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicao condicao = db.Condicaos.Find(id);
            if (condicao == null) {
                return HttpNotFound();
            }
            return PartialView(condicao);
        }

        // POST: Condicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "Id,Nome")] Condicao condicao) {
            if (ModelState.IsValid) {
                db.Entry(condicao).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = true, message = "Condição editada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Condicoes/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicao condicao = db.Condicaos.Find(id);
            if (condicao == null) {
                return HttpNotFound();
            }
            return PartialView(condicao);
        }

        // POST: Condicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id) {
            Condicao condicao = db.Condicaos.Find(id);
            db.Condicaos.Remove(condicao);
            db.SaveChanges();
            return Json(new { result = true, message = "Condição deletada com sucesso" });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
