using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityModel.EFModel;

namespace DiemDuLich.Areas.Administrator.Controllers
{
    public class ContentsController : Controller
    {
        private DiemDuLichDBContext db = new DiemDuLichDBContext();

        // GET: Administrator/Contents
        public ActionResult Index()
        {
            var contents = db.Contents.Include(c => c.AlbumImage).Include(c => c.Category).Include(c => c.User);
            return View(contents.ToList());
        }

        // GET: Administrator/Contents/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: Administrator/Contents/Create
        public ActionResult Create()
        {
            ViewBag.AlbumImageID = new SelectList(db.AlbumImages, "ID", "Name");
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: Administrator/Contents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,Description,Images,CategoryID,Detail,AlbumImageID,CreateDate,UserID,ModifiedDate,ModifiedBy,Status,TopHot,ViewCount,Tags")] Content content)
        {
            if (ModelState.IsValid)
            {
                db.Contents.Add(content);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumImageID = new SelectList(db.AlbumImages, "ID", "Name", content.AlbumImageID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", content.CategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", content.UserID);
            return View(content);
        }

        // GET: Administrator/Contents/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumImageID = new SelectList(db.AlbumImages, "ID", "Name", content.AlbumImageID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", content.CategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", content.UserID);
            return View(content);
        }

        // POST: Administrator/Contents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MetaTitle,Description,Images,CategoryID,Detail,AlbumImageID,CreateDate,UserID,ModifiedDate,ModifiedBy,Status,TopHot,ViewCount,Tags")] Content content)
        {
            if (ModelState.IsValid)
            {
                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumImageID = new SelectList(db.AlbumImages, "ID", "Name", content.AlbumImageID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", content.CategoryID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", content.UserID);
            return View(content);
        }

        // GET: Administrator/Contents/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Administrator/Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Content content = db.Contents.Find(id);
            db.Contents.Remove(content);
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
