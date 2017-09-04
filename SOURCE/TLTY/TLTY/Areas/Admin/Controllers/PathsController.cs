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
    public class PathsController : Controller
    {
        private TLTYDBContext db = new TLTYDBContext();

        // GET: Admin/Paths
        public ActionResult Index()
        {
            return View(db.Paths.ToList());
        }

        // GET: Admin/Paths/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = db.Paths.Find(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // GET: Admin/Paths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Paths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,status")] Path path)
        {
            if (ModelState.IsValid)
            {
                db.Paths.Add(path);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(path);
        }

        // GET: Admin/Paths/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = db.Paths.Find(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // POST: Admin/Paths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,status")] Path path)
        {
            if (ModelState.IsValid)
            {
                db.Entry(path).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(path);
        }

        // GET: Admin/Paths/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = db.Paths.Find(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // POST: Admin/Paths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Path path = db.Paths.Find(id);
            db.Paths.Remove(path);
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
