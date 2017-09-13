using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityModel.EF;

namespace TLTY.Controllers
{
    public class ContactsController : Controller
    {
		TLTYDBContext _db = new TLTYDBContext();
        // GET: Contacts
        public ActionResult Index()
        {
			var model = _db.Contacts.Where(x => x.Status == true);
			ViewBag.Contact = _db.Contacts.Where(x => x.Status == true).ToList();
			return View(model.ToList());
        }
    }
}