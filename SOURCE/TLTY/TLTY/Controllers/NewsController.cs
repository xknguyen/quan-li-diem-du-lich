using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityModel.EF;

namespace TLTY.Controllers
{
    public class NewsController : Controller
    {
        TLTYDBContext _db = new TLTYDBContext();
        // GET: News
        public ActionResult Index()
        {
            var news = _db.Contents.Where(x => x.Status&& x.Category).OrderByDescending(x=>x.CreateDate).ToList();
            return View(news);
        }

		// GET: Admin/AccountGroups/Details/5
		public ActionResult Details(long? id)
		{
			return View();
		}
    }
}