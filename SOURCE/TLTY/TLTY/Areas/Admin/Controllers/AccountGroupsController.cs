using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityModel.EF;

namespace TLTY.Areas.Admin.Controllers
{
    public class AccountGroupsController : Controller
    {
        private TLTYDBContext db = new TLTYDBContext();

        // GET: Admin/AccountGroups
        public ActionResult Index()
        {
            return View(db.AccountGroups.ToList());
        }

        // GET: Admin/AccountGroups/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // GET: Admin/AccountGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AccountGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,status")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.AccountGroups.Add(accountGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountGroup);
        }

        // GET: Admin/AccountGroups/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // POST: Admin/AccountGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,status")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountGroup);
        }

        // GET: Admin/AccountGroups/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // POST: Admin/AccountGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            db.AccountGroups.Remove(accountGroup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
