using PetShopJS.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class ClientesController : Controller {
        private PetShopEntities db = new PetShopEntities();

        // GET: Clientes
        public ActionResult Index() {
            return View();
        }

        // GET: Clientes
        public ActionResult IndexOriginal() {
            var clientes = db.Clientes.Include(c => c.Endereco);
            return View(clientes.ToList());
        }

        public PartialViewResult List(string search, int page = 1, int size = 10) {
            var clientes = db.Clientes.Include(c => c.Endereco);

            if (!string.IsNullOrWhiteSpace(search)) {
                int integer = 0;
                int.TryParse(search, out integer);

                clientes = clientes.Where("Id == @0 OR IdEndereco == @0 OR Nome.Contains(@1) OR Email.Contains(@1) OR Telefone.Contains(@1)", integer, search);
            }
            if (page < 1) page = 1;
            if (size < 1) size = 1;
            var orderedClientes = clientes.OrderBy(c => c.Nome).Skip((page - 1) * size).Take(size);
            return PartialView("_List", orderedClientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null) {
                return HttpNotFound();
            }
            return PartialView(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create() {
            ViewBag.IdEndereco = new SelectList(db.Enderecoes, "Id", "Endereco1");
            return PartialView();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,IdEndereco,Cep,Email,Senha,Telefone")] Cliente cliente) {
            if (ModelState.IsValid) {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEndereco = new SelectList(db.Enderecoes, "Id", "Endereco1", cliente.IdEndereco);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null) {
                return HttpNotFound();
            }
            ViewBag.IdEndereco = new SelectList(db.Enderecoes, "Id", "Endereco1", cliente.IdEndereco);
            return PartialView(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IdEndereco,Cep,Email,Senha,Telefone")] Cliente cliente) {
            if (ModelState.IsValid) {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEndereco = new SelectList(db.Enderecoes, "Id", "Endereco1", cliente.IdEndereco);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null) {
                return HttpNotFound();
            }
            return PartialView(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
