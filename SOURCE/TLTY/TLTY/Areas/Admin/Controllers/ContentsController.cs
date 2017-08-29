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
    public class ContentsController : BaseController
    {
        private TLTYDBContext _db = new TLTYDBContext();

        // GET: Admin/Contents
        public ActionResult Index()
        {
            return View(_db.Contents.ToList());
        }

        // GET: Admin/Contents/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = _db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: Admin/Contents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,CreateDate,UserName,Status,ViewCount,Detail,Description,Images,MoreImages,Category")] Content content)
        {
            if (string.IsNullOrEmpty(content.Name))
            {
                SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tiêu đề trống xin hãy kiểm tra lại!", "error");
            }
            else if (string.IsNullOrEmpty(content.Description))
            {
                SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Mô tả trống xin hãy kiểm tra lại!", "error");
            }
            else if (string.IsNullOrEmpty(content.Detail))
            {
                SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Nội dung trống xin hãy kiểm tra lại!", "error");
            }
            else
            {
                var checkcontent = _db.Contents.SingleOrDefault(x => x.Name == content.Name);
                if (checkcontent == null)
                {
                    content.Status = false;
                    content.CreateDate = DateTime.Now.Date;
                    content.UserName = Session["UserName"].ToString();
                    if (string.IsNullOrEmpty(content.Images))
                    {
                        content.Images = "/DATA/images/Content/1.jpg";
                    }
                    _db.Contents.Add(content);
                    _db.SaveChanges();
                    if (content.ID > 0)
                    {
                        SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Thêm nội dung thành công!. Hãy kích hoạt nội dung vừa tạo.", "success");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Thêm nội dung không thành công!", "error");
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Nội dung đã tồn tại!", "error");
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Contents/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = _db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Admin/Contents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,MetaTitle,CreateDate,UserName,Status,ViewCount,Detail,Description,Images,MoreImages,Category")] Content content)
        {
            if (string.IsNullOrEmpty(content.Name))
            {
                SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tiêu đề trống xin hãy kiểm tra lại!", "error");
            }
            else if (string.IsNullOrEmpty(content.Description))
            {
                SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Mô tả trống xin hãy kiểm tra lại!", "error");
            }
            else if (string.IsNullOrEmpty(content.Detail))
            {
                SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Nội dung trống xin hãy kiểm tra lại!", "error");
            }
            else
            {
                if (string.IsNullOrEmpty(content.Images))
                {
                    content.Images = "/DATA/images/Content/1.jpg";
                }
                _db.Entry(content).State = EntityState.Modified;
                _db.SaveChanges();
                if (content.ID > 0)
                {
                    SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Sửa nội dung thành công!. Hãy kích hoạt nội dung vừa tạo.", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Sửa nội dung không thành công!", "error");
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Contents/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = _db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Admin/Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Content content =_db.Contents.Find(id);
            _db.Contents.Remove(content);
            _db.SaveChanges();
            if (content.ID > 0)
            {
                SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Xóa nội dung thành công!", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Xóa nội dung không thành công!", "error");
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
    }
}
