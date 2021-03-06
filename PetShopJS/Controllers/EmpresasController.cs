﻿using System.Collections.Generic;
using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class EmpresasController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Empresas
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var empresas = db.Empresas.Include(e => e.Endereco);

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                empresas = empresas.Where("Id == @0 OR IdEndereco == @0 OR Nome.Contains(@1) OR Email.Contains(@1) OR Telefone.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedCondicoes = empresas.OrderBy(a => a.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedCondicoes.ToList());
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null) {
                return HttpNotFound();
            }
            return PartialView(empresa);
        }

        // GET: Empresas/Create
        public ActionResult Create() {
            ViewBag.IdEndereco = new SelectList(db.Enderecoes, "Id", "Endereco1");
            return PartialView();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,Nome,Email,Telefone,IdEndereco")] Empresa empresa) {
            if (ModelState.IsValid) {
                db.Empresas.Add(empresa);
                db.SaveChanges();
                return Json(new { result = true, message = "Empresa criada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null) {
                return HttpNotFound();
            }
            ViewBag.IdEndereco = new SelectList(db.Enderecoes, "Id", "Endereco1", empresa.IdEndereco);
            return PartialView(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Telefone,IdEndereco")] Empresa empresa) {
            if (ModelState.IsValid) {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = true, message = "Empresa editada com sucesso" });
            } else {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(i => i.Errors);

                return Json(new { result = false, message = errors });
            }
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null) {
                return HttpNotFound();
            }
            return PartialView(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id) {
            Empresa empresa = db.Empresas.Find(id);
            db.Empresas.Remove(empresa);
            db.SaveChanges();
            return Json(new { result = true, message = "Empresa deletada com sucesso" });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
