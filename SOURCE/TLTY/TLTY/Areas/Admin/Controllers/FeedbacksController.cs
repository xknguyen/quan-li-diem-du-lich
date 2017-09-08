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
    public class FeedbacksController : BaseController
    {
        private TLTYDBContext db = new TLTYDBContext();

        [HasCredential(PathID = "VIEW_FEEDBACK")]
        // GET: /Admin/Feedbacks/
        public ActionResult Index()
        {
            return View(db.Feedbacks.ToList());
        }

        [HasCredential(PathID = "DETAILS_FEEDBACK")]
        // GET: /Admin/Feedbacks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            feedback.Status = true;
            db.SaveChanges();
            return View(feedback);
        }

        [HasCredential(PathID = "DELETE_FEEDBACK")]
        // GET: /Admin/Feedbacks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        [HasCredential(PathID = "DELETE_FEEDBACK")]
        // POST: /Admin/Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
            db.SaveChanges();
            if (feedback.ID > 0)
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HasCredential(PathID = "EDIT_FEEDBACK")]
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var feedback = db.Feedbacks.Find(id);
            feedback.Status = !feedback.Status;
            db.SaveChanges();
            return Json(new
            {
                status = feedback.Status
            });
        }
    }
}
