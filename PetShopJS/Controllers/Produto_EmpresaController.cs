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
    public class Produto_EmpresaController : Controller
    {
        private PetShopEntities db = new PetShopEntities();

        // GET: Produto_Empresa
        public ActionResult Index()
        {
            var produto_Empresa = db.Produto_Empresa.Include(p => p.Empresa).Include(p => p.Produto);
            return View(produto_Empresa.ToList());
        }

        // GET: Produto_Empresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto_Empresa produto_Empresa = db.Produto_Empresa.Find(id);
            if (produto_Empresa == null)
            {
                return HttpNotFound();
            }
            return View(produto_Empresa);
        }

        // GET: Produto_Empresa/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.Empresas, "Id", "Nome");
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome");
            return View();
        }

        // POST: Produto_Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpresa,IdProduto,Valor,Estoque,Ativo")] Produto_Empresa produto_Empresa)
        {
            if (ModelState.IsValid)
            {
                db.Produto_Empresa.Add(produto_Empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.Empresas, "Id", "Nome", produto_Empresa.IdEmpresa);
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome", produto_Empresa.IdProduto);
            return View(produto_Empresa);
        }

        // GET: Produto_Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto_Empresa produto_Empresa = db.Produto_Empresa.Find(id);
            if (produto_Empresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresas, "Id", "Nome", produto_Empresa.IdEmpresa);
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome", produto_Empresa.IdProduto);
            return View(produto_Empresa);
        }

        // POST: Produto_Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpresa,IdProduto,Valor,Estoque,Ativo")] Produto_Empresa produto_Empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto_Empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresas, "Id", "Nome", produto_Empresa.IdEmpresa);
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome", produto_Empresa.IdProduto);
            return View(produto_Empresa);
        }

        // GET: Produto_Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto_Empresa produto_Empresa = db.Produto_Empresa.Find(id);
            if (produto_Empresa == null)
            {
                return HttpNotFound();
            }
            return View(produto_Empresa);
        }

        // POST: Produto_Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto_Empresa produto_Empresa = db.Produto_Empresa.Find(id);
            db.Produto_Empresa.Remove(produto_Empresa);
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
