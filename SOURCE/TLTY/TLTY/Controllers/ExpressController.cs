using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TLTY.Controllers
{
    public class ExpressController : Controller
    {
        // GET: Express
        public ActionResult Index()
        {
            return View();
        }

		// GET: Admin/AccountGroups/Details/5
		public ActionResult Details(long? id)
		{
			return View();
		}
    }
}