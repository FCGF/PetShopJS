using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetShopJS.Models;

namespace PetShopJS.Controllers
{
    public class AnimaisController : Controller
    {
        private PetShopEntities db = new PetShopEntities();

        // GET: Animais
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.Cliente).Include(a => a.Raca);
            return View(animals.ToList());
        }

        // GET: Animais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animais/Create
        public ActionResult Create()
        {
            ViewBag.IdDono = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.IdRaca = new SelectList(db.Racas, "Id", "Nome");
            return View();
        }

        // POST: Animais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdDono,Nome,IdRaca,DataNascimento,Cor,Sexo,Observacoes")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDono = new SelectList(db.Clientes, "Id", "Nome", animal.IdDono);
            ViewBag.IdRaca = new SelectList(db.Racas, "Id", "Nome", animal.IdRaca);
            return View(animal);
        }

        // GET: Animais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDono = new SelectList(db.Clientes, "Id", "Nome", animal.IdDono);
            ViewBag.IdRaca = new SelectList(db.Racas, "Id", "Nome", animal.IdRaca);
            return View(animal);
        }

        // POST: Animais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdDono,Nome,IdRaca,DataNascimento,Cor,Sexo,Observacoes")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDono = new SelectList(db.Clientes, "Id", "Nome", animal.IdDono);
            ViewBag.IdRaca = new SelectList(db.Racas, "Id", "Nome", animal.IdRaca);
            return View(animal);
        }

        // GET: Animais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
