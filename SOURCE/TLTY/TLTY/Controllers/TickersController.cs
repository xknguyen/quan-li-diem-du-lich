using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TLTY.Controllers
{
    public class TickersController : Controller
    {
        // GET: Tickers
        public ActionResult Index()
        {
            return View();
        }
    }
}