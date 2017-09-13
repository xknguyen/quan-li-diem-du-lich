using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityModel.EF;

namespace TLTY.Controllers
{
    public class ExpressController : Controller
    {
        TLTYDBContext _db = new TLTYDBContext();
        // GET: Express
        public ActionResult Index()
        {
            var express =
                _db.Contents.Where(x => x.Category == false && x.Status).OrderByDescending(x => x.CreateDate).ToList();
            return View(express);
        }

		// GET: Admin/AccountGroups/Details/5
		public ActionResult Details(long? id)
		{
			return View();
		}
    }
}