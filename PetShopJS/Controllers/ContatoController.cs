using System.Web.Mvc;

namespace PetShopJS.Controllers {
    public class ContatoController : Controller {
        // GET: Index view  
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail() {
            //call SendEmailView view to invoke webmail  
            return View();
        }
    }
}