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
    public class EspecificacoesController : Controller
    {
        private PetShopEntities db = new PetShopEntities();

        // GET: Especificacoes
        public ActionResult Index()
        {
            var especificacaos = db.Especificacaos.Include(e => e.Produto);
            return View(especificacaos.ToList());
        }

        // GET: Especificacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especificacao especificacao = db.Especificacaos.Find(id);
            if (especificacao == null)
            {
                return HttpNotFound();
            }
            return View(especificacao);
        }

        // GET: Especificacoes/Create
        public ActionResult Create()
        {
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome");
            return View();
        }

        // POST: Especificacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdProduto,Nome,Valor")] Especificacao especificacao)
        {
            if (ModelState.IsValid)
            {
                db.Especificacaos.Add(especificacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome", especificacao.IdProduto);
            return View(especificacao);
        }

        // GET: Especificacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especificacao especificacao = db.Especificacaos.Find(id);
            if (especificacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome", especificacao.IdProduto);
            return View(especificacao);
        }

        // POST: Especificacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdProduto,Nome,Valor")] Especificacao especificacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especificacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProduto = new SelectList(db.Produtoes, "Id", "Nome", especificacao.IdProduto);
            return View(especificacao);
        }

        // GET: Especificacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especificacao especificacao = db.Especificacaos.Find(id);
            if (especificacao == null)
            {
                return HttpNotFound();
            }
            return View(especificacao);
        }

        // POST: Especificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especificacao especificacao = db.Especificacaos.Find(id);
            db.Especificacaos.Remove(especificacao);
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
