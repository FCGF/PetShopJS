using PetShopJS.Models;
using System.Web.Mvc;

namespace PetShopJS {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new JsonHandlerAttribute());
        }
    }
}
