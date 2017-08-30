using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Services;

namespace TLTY.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[WebMethod]
		public static void ChangeTheme(string nameThemes)
		{
			HttpCookie themePage = new HttpCookie("themePage", nameThemes);
			themePage.Expires = DateTime.Now.AddMonths(1);
			//var response = HttpContext.Current.Response;
			//response.Cookies.Add(themePage);
		}

	}
}