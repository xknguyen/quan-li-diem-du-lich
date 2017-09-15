using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Services;
using EntityModel.EF;

namespace TLTY.Areas.Admin.Controllers
{
	public class HomeController : BaseController
	{
		TLTYDBContext _db = new TLTYDBContext();

		// GET: Admin/Home
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult NotificationAuthorize()
		{
			return View();
		}

		public JsonResult FeedbackMe()
		{
			var feedback = _db.Feedbacks.Where(x => x.Status == false).OrderByDescending(x => x.CreateDate).ToList();
			return Json(new
			{
				count =feedback.Count,
				data = feedback
			}, JsonRequestBehavior.AllowGet);
		}

		public JsonResult RequestMe()
		{
			var request = _db.Requests.Where(x => x.Status == false).OrderByDescending(x => x.CreateDate).ToList();
			return Json(new
			{
				count = request.Count,
				data = request
			}, JsonRequestBehavior.AllowGet);
		}
	}
}