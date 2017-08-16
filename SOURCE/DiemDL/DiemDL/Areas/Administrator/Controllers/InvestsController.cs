using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;

namespace DiemDL.Areas.Administrator.Controllers
{
    public class InvestsController : Controller
    {
        private DiemDLDBContext db = new DiemDLDBContext();

        // GET: Administrator/Invests
        public ActionResult Index()
        {
            var invests = db.Invests.Include(i => i.Account);
            return View(invests.ToList());
        }

        // GET: Administrator/Invests/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invest invest = db.Invests.Find(id);
            if (invest == null)
            {
                return HttpNotFound();
            }
            return View(invest);
        }

        // GET: Administrator/Invests/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName");
            return View();
        }

        // POST: Administrator/Invests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CreateDate,AccountID,Status,Description")] Invest invest)
        {
            if (ModelState.IsValid)
            {
                db.Invests.Add(invest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName", invest.AccountID);
            return View(invest);
        }

        // GET: Administrator/Invests/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invest invest = db.Invests.Find(id);
            if (invest == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName", invest.AccountID);
            return View(invest);
        }

        // POST: Administrator/Invests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CreateDate,AccountID,Status,Description")] Invest invest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName", invest.AccountID);
            return View(invest);
        }

        // GET: Administrator/Invests/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invest invest = db.Invests.Find(id);
            if (invest == null)
            {
                return HttpNotFound();
            }
            return View(invest);
        }

        // POST: Administrator/Invests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Invest invest = db.Invests.Find(id);
            db.Invests.Remove(invest);
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
