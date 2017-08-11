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
    public class AlbumImagesController : Controller
    {
        private DiemDuLichDBContext db = new DiemDuLichDBContext();

        // GET: Administrator/AlbumImages
        public ActionResult Index()
        {
            return View(db.AlbumImages.ToList());
        }

        // GET: Administrator/AlbumImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumImage albumImage = db.AlbumImages.Find(id);
            if (albumImage == null)
            {
                return HttpNotFound();
            }
            return View(albumImage);
        }

        // GET: Administrator/AlbumImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/AlbumImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Status")] AlbumImage albumImage)
        {
            if (ModelState.IsValid)
            {
                db.AlbumImages.Add(albumImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(albumImage);
        }

        // GET: Administrator/AlbumImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumImage albumImage = db.AlbumImages.Find(id);
            if (albumImage == null)
            {
                return HttpNotFound();
            }
            return View(albumImage);
        }

        // POST: Administrator/AlbumImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Status")] AlbumImage albumImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albumImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(albumImage);
        }

        // GET: Administrator/AlbumImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumImage albumImage = db.AlbumImages.Find(id);
            if (albumImage == null)
            {
                return HttpNotFound();
            }
            return View(albumImage);
        }

        // POST: Administrator/AlbumImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumImage albumImage = db.AlbumImages.Find(id);
            db.AlbumImages.Remove(albumImage);
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
