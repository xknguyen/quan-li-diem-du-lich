using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityModel.EF;

namespace TLTY.Controllers
{
    public class TickersController : Controller
    {
		TLTYDBContext _db = new TLTYDBContext();
        // GET: Tickers
        public ActionResult Index()
        {
	        var ticker = _db.Tickers.Where(x => x.Status).OrderBy(x => x.CreateDate).ToList();
			return View(ticker);
        }
    }
}