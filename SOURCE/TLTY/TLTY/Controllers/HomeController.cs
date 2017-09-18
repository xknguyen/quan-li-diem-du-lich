using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using EntityModel.EF;
using System.Configuration;

namespace TLTY.Controllers
{
	public class HomeController : Controller
	{
		TLTYDBContext _db = new TLTYDBContext();
		public ActionResult Index(string nameThemes)
		{
			ViewBag.Title = ConfigurationManager.AppSettings["HomeTitle"];
			ViewBag.Keywords = ConfigurationManager.AppSettings["HomeKeyword"];
			ViewBag.Descriptions = ConfigurationManager.AppSettings["HomeDescription"];

            HttpCookie themePage = new HttpCookie("themePage", nameThemes);
            themePage.Expires = DateTime.Now.AddMonths(1);
            int response = 1;
            if (themePage != null)
            {
                if (themePage.Value == "Den")
                {
                    response = 2;
                }
                else
                {
                    response = 1;
                }
            }
            ViewBag.Views = response;

            var intruction = _db.Instructions.Where(x => x.Status == true).ToList();
			return View(intruction);
		}

        public JsonResult ChangeTheme(string nameThemes)
        {
            HttpCookie themePage = new HttpCookie("themePage", nameThemes);
            themePage.Expires = DateTime.Now.AddMonths(1);
            int response = 1;
            if (themePage != null)
            {
                if (themePage.Value == "Den")
                {
                    response = 2;
                }
                else
                {
                    response = 1;
                }
            }
            return Json(response);
        }

		public PartialViewResult Slider()
		{
			var slider = _db.Sliders.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
			ViewBag.Content = _db.Contents.Where(x => x.Status == true).ToList();
			return PartialView(slider);
		}

		public PartialViewResult Footer()
		{
			var footer = _db.Contacts.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(1).ToList();
			return PartialView(footer);
		}
    }
}