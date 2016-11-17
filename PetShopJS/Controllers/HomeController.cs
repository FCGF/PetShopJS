using PetShopJS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace PetShopJS.Controllers {

    [AllowAnonymous]
    public class HomeController : Controller {
        private PetShopEntities db = new PetShopEntities();

        public ActionResult Index() {

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/images/slider/"));

            IList<string> files = new List<string>();
            foreach (string filePath in filePaths) {
                string fileName = Path.GetFileName(filePath);
                files.Add("../images/slider/" + fileName);
            }

            ViewBag.Files = files;

            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "PetShopJS";

            return View();
        }

        public async Task<ActionResult> Contact() {
            ViewBag.Message = "PetShopJS";

            try {
                const double latitude = -26.4933104;
                const double longitude = -49.0763121;

                var weather = await WeatherMapProxy.GetWeather(latitude, longitude);

                ViewBag.Location = weather.name;
                ViewBag.Temperature = ((int)weather.main.temp).ToString();
                ViewBag.WeatherDescription = weather.weather[0].description;
            } catch {
                ViewBag.Location = "";
                ViewBag.Temperature = "";
                ViewBag.WeatherDescription = "Unable to get weather at this time.";
            }

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

        [HttpPost]
        public ActionResult SendEmail() {
            return View();
        }
    }
}