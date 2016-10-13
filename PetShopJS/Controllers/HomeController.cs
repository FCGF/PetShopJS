using PetShopJS.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace PetShopJS.Controllers {
    public class HomeController : Controller {
        private PetShopEntities db = new PetShopEntities();
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chart1() {
            var compras = db.Compras.Include(c => c.Cliente).Include(c => c.Condicao).Include(c => c.Forma_Pagamento).Include(c => c.Parcela);

            var now = DateTime.Now.AddMonths(-1);

            var datas = compras.Where(c => c.Data.CompareTo(now) >= 0).Select(c => c.Data);

            var contas = datas.GroupBy(i => i)
                .Select(grp => grp.Count());

            var datasUnicas = datas.GroupBy(i => i).Select(i => i.FirstOrDefault());

            ViewBag.Datas = datasUnicas;
            ViewBag.Quantidade = contas;
            return View();
        }
    }
}