using System.Collections.Generic;
using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class EnderecosController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Enderecos
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var enderecos = db.Enderecoes.Include(e => e.Bairro);

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                enderecos = enderecos.Where("Id == @0 OR IdBairro == @0 OR CEP.Contains(@1) OR Endereco1.Contains(@1) OR Endereco2.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedCondicoes = enderecos.OrderBy(a => a.IdBairro).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedCondicoes.ToList());
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
                return Json(new { result = true, message = "Endereço criado com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
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
        public JsonResult Edit([Bind(Include = "Id,IdBairro,Endereco1,Endereco2,CEP")] Endereco endereco) {
            if (ModelState.IsValid) {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = true, message = "Endereço editado com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
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
        public JsonResult DeleteConfirmed(int id) {
            Endereco endereco = db.Enderecoes.Find(id);
            db.Enderecoes.Remove(endereco);
            db.SaveChanges();
            return Json(new { result = true, message = "Endereço deletado com sucesso" });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
