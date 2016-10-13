using PetShopJS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class AnimaisController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Animais
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var animais = db.Animals.Include(a => a.Cliente).Include(a => a.Raca);

            if (!String.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                DateTime date = DateTime.Now;
                DateTime.TryParse(search, out date);

                animais = animais.Where("Id == @0 OR IdDono == @0 OR IdRaca == @0 OR DataNascimento.Equals(@1) OR Nome.Contains(@2) OR Cor.Contains(@2) OR Sexo.Contains(@2) OR Observacoes.Contains(@2)", integer, date, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedAnimais = animais.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedAnimais.ToList());
        }

        // GET: Animais/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null) {
                return HttpNotFound();
            }
            return PartialView(animal);
        }

        // GET: Animais/Create
        public ActionResult Create() {
            ViewBag.IdDono = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.IdRaca = new SelectList(db.Racas, "Id", "Nome");
            return PartialView();
        }

        // POST: Animais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,IdDono,Nome,IdRaca,DataNascimento,Cor,Sexo,Observacoes")] Animal animal) {
            if (ModelState.IsValid) {
                db.Animals.Add(animal);
                db.SaveChanges();
                return Json(new { result = true, message = "Animal cadastrado com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Animais/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null) {
                return HttpNotFound();
            }
            ViewBag.IdDono = new SelectList(db.Clientes, "Id", "Nome", animal.IdDono);
            ViewBag.IdRaca = new SelectList(db.Racas, "Id", "Nome", animal.IdRaca);
            return PartialView(animal);
        }

        // POST: Animais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdDono,Nome,IdRaca,DataNascimento,Cor,Sexo,Observacoes")] Animal animal) {
            if (ModelState.IsValid) {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDono = new SelectList(db.Clientes, "Id", "Nome", animal.IdDono);
            ViewBag.IdRaca = new SelectList(db.Racas, "Id", "Nome", animal.IdRaca);
            return View(animal);
        }

        // GET: Animais/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null) {
                return HttpNotFound();
            }
            return PartialView(animal);
        }

        // POST: Animais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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
