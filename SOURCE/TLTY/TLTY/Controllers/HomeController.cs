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
		public ActionResult Index()
		{
			ViewBag.Title = ConfigurationManager.AppSettings["HomeTitle"];
			ViewBag.Keywords = ConfigurationManager.AppSettings["HomeKeyword"];
			ViewBag.Descriptions = ConfigurationManager.AppSettings["HomeDescription"];
			var intruction = _db.Instructions.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(8).ToList();
			return View(intruction);
		}


	}
}