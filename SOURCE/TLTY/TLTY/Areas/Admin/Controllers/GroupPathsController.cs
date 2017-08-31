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
    public class GroupPathsController : BaseController
    {
        private TLTYDBContext _db = new TLTYDBContext();

        // GET: Admin/GroupPaths
        public ActionResult Index()
        {
            var groupPaths = _db.GroupPaths.Include(g => g.AccountGroup).Include(g => g.Path);
            return View(groupPaths.ToList());
        }

        // GET: Admin/GroupPaths/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPath groupPath = _db.GroupPaths.Find(id);
            if (groupPath == null)
            {
                return HttpNotFound();
            }
            return View(groupPath);
        }

        // GET: Admin/GroupPaths/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(_db.AccountGroups, "ID", "Description");
            ViewBag.PathID = new SelectList(_db.Paths, "ID", "PathName");
            return View();
        }

        // POST: Admin/GroupPaths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,GroupID,PathID")] GroupPath groupPath)
        {

            if (string.IsNullOrEmpty(groupPath.Name))
            {
                SetAlert("<i class='fa fa-times'></i> Tên trống xin hãy kiểm tra lại!", "error");
            }
            else if (groupPath.GroupID < 0)
            {
                SetAlert("<i class='fa fa-times'></i> ID nhóm không được trống và nhỏ hơn 0!", "error");
            }
            else if (groupPath.PathID < 0)
            {
                SetAlert("<i class='fa fa-times'></i> ID đường dẫn không được trống và nhỏ hơn 0!", "error");
            }
            else
            {
                _db.GroupPaths.Add(groupPath);
                _db.SaveChanges();
                if (groupPath.ID > 0)
                {
                    SetAlert("<i class='fa fa-check'></i> Thêm nhóm thành công!. Hãy kích hoạt nhóm vừa tạo.", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("<i class='fa fa-times'></i> Thêm nhóm không thành công!", "error");
                    return RedirectToAction("Index");
                }

            }
            //if (ModelState.IsValid)
            //{
            //    _db.GroupPaths.Add(groupPath);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            ViewBag.GroupID = new SelectList(_db.AccountGroups, "ID", "Description", groupPath.GroupID);
            ViewBag.PathID = new SelectList(_db.Paths, "ID", "PathName", groupPath.PathID);
            return View(groupPath);
        }

        // GET: Admin/GroupPaths/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPath groupPath = _db.GroupPaths.Find(id);
            if (groupPath == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(_db.AccountGroups, "ID", "Description", groupPath.GroupID);
            ViewBag.PathID = new SelectList(_db.Paths, "ID", "PathName", groupPath.PathID);
            return View(groupPath);
        }

        // POST: Admin/GroupPaths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,GroupID,PathID")] GroupPath groupPath)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(groupPath).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(_db.AccountGroups, "ID", "Description", groupPath.GroupID);
            ViewBag.PathID = new SelectList(_db.Paths, "ID", "PathName", groupPath.PathID);
            return View(groupPath);
        }

        // GET: Admin/GroupPaths/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPath groupPath = _db.GroupPaths.Find(id);
            if (groupPath == null)
            {
                return HttpNotFound();
            }
            return View(groupPath);
        }

        // POST: Admin/GroupPaths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            GroupPath groupPath = _db.GroupPaths.Find(id);
            _db.GroupPaths.Remove(groupPath);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
