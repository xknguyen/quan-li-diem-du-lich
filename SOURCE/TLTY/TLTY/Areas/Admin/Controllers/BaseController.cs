using System.Web.Mvc;
using System.Web.Routing;

namespace TLTY.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			//var session = (UserLogin)Session[Common.CommonConstants.USER_SESSION];

			if (Session["AccountID"] == null)
			{
				filterContext.Result = new RedirectToRouteResult(new
					RouteValueDictionary(new { Controller = "Login", action = "Index", Area = "Admin" }));
			}
			base.OnActionExecuting(filterContext);
		}
		protected void SetAlert(string message, string type)
		{
			TempData["AlertMessage"] = message;
			if (type == "success")
			{
				TempData["AlertType"] = "alert-success";
			}
			else if (type == "warning")
			{
				TempData["AlertType"] = "alert-warning";
			}
			else if (type == "error")
			{
				TempData["AlertType"] = "alert-danger";
			}
		}
    }
}