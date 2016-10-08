using System.Web.Mvc;

namespace PetShopJS.Models {
    public class JsonHandlerAttribute : ActionFilterAttribute {
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            var jsonResult = filterContext.Result as JsonResult;

            if (jsonResult != null) {
                filterContext.Result = new JsonNetResult {
                    ContentEncoding = jsonResult.ContentEncoding,
                    ContentType = jsonResult.ContentType,
                    Data = jsonResult.Data,
                    JsonRequestBehavior = jsonResult.JsonRequestBehavior
                };
            }

            base.OnActionExecuted(filterContext);
        }
    }
}