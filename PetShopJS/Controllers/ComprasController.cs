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
    public class ComprasController : Controller
    {
        private PetShopEntities db = new PetShopEntities();

        // GET: Compras
        public ActionResult Index()
        {
            var compras = db.Compras.Include(c => c.Cliente).Include(c => c.Condicao).Include(c => c.Forma_Pagamento).Include(c => c.Parcela);
            return View(compras.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.IdCondicao = new SelectList(db.Condicaos, "Id", "Nome");
            ViewBag.IdFormaPagamento = new SelectList(db.Forma_Pagamento, "Id", "Nome");
            ViewBag.IdParcela = new SelectList(db.Parcelas, "Id", "Id");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCliente,IdCondicao,Codigo,Desconto,IdFormaPagamento,IdParcela,Total")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compras.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "Id", "Nome", compra.IdCliente);
            ViewBag.IdCondicao = new SelectList(db.Condicaos, "Id", "Nome", compra.IdCondicao);
            ViewBag.IdFormaPagamento = new SelectList(db.Forma_Pagamento, "Id", "Nome", compra.IdFormaPagamento);
            ViewBag.IdParcela = new SelectList(db.Parcelas, "Id", "Id", compra.IdParcela);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "Id", "Nome", compra.IdCliente);
            ViewBag.IdCondicao = new SelectList(db.Condicaos, "Id", "Nome", compra.IdCondicao);
            ViewBag.IdFormaPagamento = new SelectList(db.Forma_Pagamento, "Id", "Nome", compra.IdFormaPagamento);
            ViewBag.IdParcela = new SelectList(db.Parcelas, "Id", "Id", compra.IdParcela);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCliente,IdCondicao,Codigo,Desconto,IdFormaPagamento,IdParcela,Total")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "Id", "Nome", compra.IdCliente);
            ViewBag.IdCondicao = new SelectList(db.Condicaos, "Id", "Nome", compra.IdCondicao);
            ViewBag.IdFormaPagamento = new SelectList(db.Forma_Pagamento, "Id", "Nome", compra.IdFormaPagamento);
            ViewBag.IdParcela = new SelectList(db.Parcelas, "Id", "Id", compra.IdParcela);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compras.Find(id);
            db.Compras.Remove(compra);
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
