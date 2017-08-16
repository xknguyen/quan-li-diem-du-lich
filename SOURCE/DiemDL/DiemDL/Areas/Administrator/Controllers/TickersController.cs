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
    public class TickersController : Controller
    {
        private DiemDLDBContext db = new DiemDLDBContext();

        // GET: Administrator/Tickers
        public ActionResult Index()
        {
            var tickers = db.Tickers.Include(t => t.Account);
            return View(tickers.ToList());
        }

        // GET: Administrator/Tickers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticker ticker = db.Tickers.Find(id);
            if (ticker == null)
            {
                return HttpNotFound();
            }
            return View(ticker);
        }

        // GET: Administrator/Tickers/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName");
            return View();
        }

        // POST: Administrator/Tickers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,CreateDate,AccountID,Status,Description")] Ticker ticker)
        {
            if (ModelState.IsValid)
            {
                db.Tickers.Add(ticker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName", ticker.AccountID);
            return View(ticker);
        }

        // GET: Administrator/Tickers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticker ticker = db.Tickers.Find(id);
            if (ticker == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName", ticker.AccountID);
            return View(ticker);
        }

        // POST: Administrator/Tickers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,CreateDate,AccountID,Status,Description")] Ticker ticker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName", ticker.AccountID);
            return View(ticker);
        }

        // GET: Administrator/Tickers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticker ticker = db.Tickers.Find(id);
            if (ticker == null)
            {
                return HttpNotFound();
            }
            return View(ticker);
        }

        // POST: Administrator/Tickers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Ticker ticker = db.Tickers.Find(id);
            db.Tickers.Remove(ticker);
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
