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
    public class SlidersController : BaseController
    {
        private TLTYDBContext _db = new TLTYDBContext();

        [HasCredential(PathID = "VIEW_SLIDER")]
        // GET: Admin/Sliders
        public ActionResult Index()
        {
            var sliders = _db.Sliders;
            return View(sliders.ToList());
        }

        [HasCredential(PathID = "DETAILS_SLIDER")]
        // GET: Admin/Sliders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = _db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        [HasCredential(PathID = "CREATE_SLIDER")]
        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            ViewBag.ContentID = new SelectList(_db.Contents, "ID", "Name");
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HasCredential(PathID = "CREATE_SLIDER")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DisplayOrder,Link,ContentID,CreateDate,UserName,Status,Description")] Slider slider)
        {
            if (string.IsNullOrEmpty(slider.Name))
            {
                SetAlert("<i class='fa fa-times'></i> Tên trống xin hãy kiểm tra lại!", "error");
            }
			else if (slider.Name.Length > 500)
			{
				SetAlert("<i class='fa fa-times'></i> Tên quá 500 Ký tự xin hãy kiểm tra lại!", "error");
			}
            else if (slider.DisplayOrder < 0)
            {
                SetAlert("<i class='fa fa-times'></i> Thứ tự không được trống và nhỏ hơn 0!", "error");
            }
            else if (slider.ContentID < 0)
            {
                SetAlert("<i class='fa fa-times'></i> Nội dung trống xin hãy kiểm tra lại!", "error");
            }
            else if (string.IsNullOrEmpty(slider.Link))
            {
                SetAlert("<i class='fa fa-times'></i> Đường dẫn trống xin hãy kiểm tra lại!", "error");
            }
			else if (slider.Description.Length > 500)
			{
				SetAlert("<i class='fa fa-times'></i> Mô tả quá 500 Ký tự xin hãy kiểm tra lại!", "error");
			}
            else
            {
				var session = (UserLogin)Session[Constants.USER_SESSION];
                slider.Status = false;
                slider.CreateDate = DateTime.Now.Date;
                slider.UserName = session.UserName;
                _db.Sliders.Add(slider);
                _db.SaveChanges();
                if (slider.ID > 0)
                {
                    SetAlert("<i class='fa fa-check'></i> Thêm trình ảnh thành công!. Hãy kích hoạt trình ảnh vừa tạo.", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("<i class='fa fa-times'></i> Thêm trình ảnh không thành công!", "error");
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ContentID = new SelectList(_db.Contents, "ID", "Name", slider.ContentID);
            return RedirectToAction("Index");
        }

        [HasCredential(PathID = "EDIT_SLIDER")]
        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = _db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContentID = new SelectList(_db.Contents, "ID", "Name", slider.ContentID);
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HasCredential(PathID = "EDIT_SLIDER")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DisplayOrder,Link,ContentID,CreateDate,UserName,Status,Description")] Slider slider)
        {
			if (string.IsNullOrEmpty(slider.Name))
			{
				SetAlert("<i class='fa fa-times'></i> Tên trống xin hãy kiểm tra lại!", "error");
			}
			else if (slider.Name.Length > 500)
			{
				SetAlert("<i class='fa fa-times'></i> Tên quá 500 Ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (slider.DisplayOrder < 0)
			{
				SetAlert("<i class='fa fa-times'></i> Thứ tự không được trống và nhỏ hơn 0!", "error");
			}
			else if (slider.ContentID < 0)
			{
				SetAlert("<i class='fa fa-times'></i> Nội dung trống xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(slider.Link))
			{
				SetAlert("<i class='fa fa-times'></i> Đường dẫn trống xin hãy kiểm tra lại!", "error");
			}
			else if (slider.Description.Length > 500)
			{
				SetAlert("<i class='fa fa-times'></i> Mô tả quá 500 Ký tự xin hãy kiểm tra lại!", "error");
			}
			else
			{
                if (string.IsNullOrEmpty(slider.Link))
                {
                    slider.Link = "/DATA/images/Slider/1.jpg";
                }
                _db.Entry(slider).State = EntityState.Modified;
                _db.SaveChanges();
                if (slider.ID > 0)
                {
                    SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Sửa trình ảnh thành công!", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Sửa trình ảnh không thành công!", "error");
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HasCredential(PathID = "DELETE_SLIDER")]
        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = _db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        [HasCredential(PathID = "DELETE_SLIDER")]
        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Slider slider = _db.Sliders.Find(id);
            _db.Sliders.Remove(slider);
            _db.SaveChanges();
            if (slider.ID > 0)
            {
                SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Xóa trình ảnh thành công!", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Xóa trình ảnh không thành công!", "error");
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

        [HasCredential(PathID = "EDIT_SLIDER")]
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var slider = _db.Sliders.Find(id);
            slider.Status = !slider.Status;
            _db.SaveChanges();
            return Json(new
            {
                status = slider.Status
            });
        }

        [HasCredential(PathID = "EDIT_SLIDER")]
        public string ChangeImage(int id, string picture)
        {
            if (id < 0)
            {
                return " Không tìm thấy tài khoản!";
            }
            else
            {
                Slider p = _db.Sliders.Find(id);
                if (p == null)
                {
                    return " Không tìm thấy tài khoản!";
                }
                else
                {
                    p.Link = picture;
                    _db.SaveChanges();
                    return "";
                }
            }
        }
    }
}
