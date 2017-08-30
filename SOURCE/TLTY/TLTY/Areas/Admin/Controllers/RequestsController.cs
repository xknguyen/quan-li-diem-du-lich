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
    public class RequestsController : BaseController
    {
        private TLTYDBContext _db = new TLTYDBContext();

        // GET: Admin/Requests
        public ActionResult Index()
        {
            var requests = _db.Requests.Include(r => r.Content);
            return View(requests.ToList());
        }

        // GET: Admin/Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = _db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Admin/Requests/Create
        public ActionResult Create()
        {
            ViewBag.ContentID = new SelectList(_db.Contents, "ID", "Name");
            return View();
        }

        // POST: Admin/Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Phone,Email,CreateDate,Status,MoreImage,ContentID,Detail")] Request request)
        {
            if (ModelState.IsValid)
            {
                _db.Requests.Add(request);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContentID = new SelectList(_db.Contents, "ID", "Name", request.ContentID);
            return View(request);
        }

        // GET: Admin/Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = _db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContentID = new SelectList(_db.Contents, "ID", "Name", request.ContentID);
            return View(request);
        }

        // POST: Admin/Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Phone,Email,CreateDate,Status,MoreImage,ContentID,Detail")] Request request)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(request).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContentID = new SelectList(_db.Contents, "ID", "Name", request.ContentID);
            return View(request);
        }

        // GET: Admin/Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = _db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Admin/Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = _db.Requests.Find(id);
            _db.Requests.Remove(request);
            _db.SaveChanges();
            if (request.ID > 0)
            {
                SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Xóa phản hồi thành công!", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Xóa phản hồi không thành công!", "error");
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {

            var request = _db.Requests.Find(id);
            request.Status = !request.Status;
            _db.SaveChanges();
            return Json(new
            {
                status = request.Status
            });
        }
    }
}
