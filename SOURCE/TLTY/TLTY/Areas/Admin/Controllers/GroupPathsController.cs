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
    public class GroupPathsController : Controller
    {
        private TLTYDBContext db = new TLTYDBContext();

        // GET: Admin/GroupPaths
        public ActionResult Index()
        {
            return View(db.GroupPaths.ToList());
        }

        // GET: Admin/GroupPaths/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPath groupPath = db.GroupPaths.Find(id);
            if (groupPath == null)
            {
                return HttpNotFound();
            }
            return View(groupPath);
        }

        // GET: Admin/GroupPaths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GroupPaths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountGroupID,PathID")] GroupPath groupPath)
        {
            if (ModelState.IsValid)
            {
                db.GroupPaths.Add(groupPath);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupPath);
        }

        // GET: Admin/GroupPaths/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPath groupPath = db.GroupPaths.Find(id);
            if (groupPath == null)
            {
                return HttpNotFound();
            }
            return View(groupPath);
        }

        // POST: Admin/GroupPaths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountGroupID,PathID")] GroupPath groupPath)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupPath).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupPath);
        }

        // GET: Admin/GroupPaths/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPath groupPath = db.GroupPaths.Find(id);
            if (groupPath == null)
            {
                return HttpNotFound();
            }
            return View(groupPath);
        }

        // POST: Admin/GroupPaths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GroupPath groupPath = db.GroupPaths.Find(id);
            db.GroupPaths.Remove(groupPath);
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
