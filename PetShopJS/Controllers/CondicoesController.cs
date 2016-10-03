﻿using System;
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
    public class CondicoesController : Controller
    {
        private PetShopEntities db = new PetShopEntities();

        // GET: Condicoes
        public ActionResult Index()
        {
            return View(db.Condicaos.ToList());
        }

        // GET: Condicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicao condicao = db.Condicaos.Find(id);
            if (condicao == null)
            {
                return HttpNotFound();
            }
            return View(condicao);
        }

        // GET: Condicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Condicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Condicao condicao)
        {
            if (ModelState.IsValid)
            {
                db.Condicaos.Add(condicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condicao);
        }

        // GET: Condicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicao condicao = db.Condicaos.Find(id);
            if (condicao == null)
            {
                return HttpNotFound();
            }
            return View(condicao);
        }

        // POST: Condicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Condicao condicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicao);
        }

        // GET: Condicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicao condicao = db.Condicaos.Find(id);
            if (condicao == null)
            {
                return HttpNotFound();
            }
            return View(condicao);
        }

        // POST: Condicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Condicao condicao = db.Condicaos.Find(id);
            db.Condicaos.Remove(condicao);
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
