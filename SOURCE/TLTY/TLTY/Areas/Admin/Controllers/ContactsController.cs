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
    public class ContactsController : BaseController
    {
        private TLTYDBContext db = new TLTYDBContext();

        [HasCredential(PathID = "VIEW_CONTACT")]
        // GET: /Admin/Contacts/
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        [HasCredential(PathID = "DETAILS_CONTACT")]
        // GET: /Admin/Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HasCredential(PathID = "CREATE_CONTACT")]
        // GET: /Admin/Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HasCredential(PathID = "CREATE_CONTACT")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,CreateDate,UserName,Status,Address,Phone,Email")] Contact contact)
        {
            if (string.IsNullOrEmpty(contact.Address))
            {
                SetAlert("<i class='fa fa-times'></i> Địa chỉ trống xin hãy kiểm tra lại!", "error");
            }
			else if (contact.Address.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Địa chỉ quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
            else if (string.IsNullOrEmpty(contact.Phone))
            {
                SetAlert("<i class='fa fa-times'></i> Số điện thoại trống xin hãy kiểm tra lại!", "error");
			}
			else if (contact.Phone.Length > 50)
			{
				SetAlert("<i class='fa fa-times'></i> Số điện thoái quá 50 ký tự xin hãy kiểm tra lại!", "error");
			}
            else if (string.IsNullOrEmpty(contact.Email))
            {
                SetAlert("<i class='fa fa-times'></i> Email trống xin hãy kiểm tra lại!", "error");
            }
			else if (contact.Email.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Email quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
            else
            {
				var session = (UserLogin)Session[Constants.USER_SESSION];
                    contact.Status = false;
                    contact.CreateDate = DateTime.Now.Date;
                    contact.UserName = session.UserName;
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    if (contact.ID > 0)
                    {
                        SetAlert("<i class='fa fa-check'></i> Thêm liên hệ thành công!. Hãy kích hoạt liên hệ vừa tạo.", "success");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        SetAlert("<i class='fa fa-times'></i> Thêm liên hệ không thành công!", "error");
                        return RedirectToAction("Index");
                    }
                }
            return RedirectToAction("Index");
        }

        [HasCredential(PathID = "EDIT_CONTACT")]
        // GET: /Admin/Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: /Admin/Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HasCredential(PathID = "EDIT_CONTACT")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,CreateDate,UserName,Status,Address,Phone,Email")] Contact contact)
        {
			if (string.IsNullOrEmpty(contact.Address))
			{
				SetAlert("<i class='fa fa-times'></i> Địa chỉ trống xin hãy kiểm tra lại!", "error");
			}
			else if (contact.Address.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Địa chỉ quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(contact.Phone))
			{
				SetAlert("<i class='fa fa-times'></i> Số điện thoại trống xin hãy kiểm tra lại!", "error");
			}
			else if (contact.Phone.Length > 50)
			{
				SetAlert("<i class='fa fa-times'></i> Số điện thoái quá 50 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(contact.Email))
			{
				SetAlert("<i class='fa fa-times'></i> Email trống xin hãy kiểm tra lại!", "error");
			}
			else if (contact.Email.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Email quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
			else
			{
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                if (contact.ID > 0)
                {
                    SetAlert("<i class='fa fa-check'></i> Sửa liên hệ thành công!", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("<i class='fa fa-times'></i> Sửa liên hệ không thành công!", "error");
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HasCredential(PathID = "DELETE_CONTACT")]
        // GET: /Admin/Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HasCredential(PathID = "DELETE_CONTACT")]
        // POST: /Admin/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            if (contact.ID > 0)
            {
                SetAlert("<i class='fa fa-check'></i> Xóa liên hệ thành công!", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("<i class='fa fa-times'></i> Xóa liên hệ không thành công!", "error");
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

        [HasCredential(PathID = "EDIT_CONTACT")]
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var user = db.Contacts.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return Json(new
            {
                status = user.Status
            });
        }
    }
}
