using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityModel.EF;
using TLTY.Areas.Admin.Models;

namespace TLTY.Areas.Admin.Controllers
{
    public class RequestsController : BaseController
    {
        private TLTYDBContext _db = new TLTYDBContext();

        [HasCredential(PathID = "VIEW_REQUEST")]
        // GET: Admin/Requests
        public ActionResult Index()
        {
            var requests = _db.Requests;
            return View(requests.ToList());
        }

        [HasCredential(PathID = "DETAILS_REQUEST")]
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
            request.Status = true;
            _db.SaveChanges();
            return View(request);
        }

        [HasCredential(PathID = "DELETE_REQUEST")]
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

        [HasCredential(PathID = "DELETE_REQUEST")]
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
                SetAlert("<i class='fa fa-check'></i> Xóa phản hồi thành công!", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("<i class='fa fa-times'></i> Xóa phản hồi không thành công!", "error");
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

        [HasCredential(PathID = "EDIT_REQUEST")]
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
