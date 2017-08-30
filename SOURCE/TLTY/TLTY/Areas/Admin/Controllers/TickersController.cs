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
    public class TickersController : BaseController
    {
        private TLTYDBContext db = new TLTYDBContext();

        // GET: /Admin/Tickers/
        public ActionResult Index()
        {
            return View(db.Tickers.ToList());
        }

        // GET: /Admin/Tickers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticker ticker = db.Tickers.Find(id);
            if (ticker == null)
            {
                return HttpNotFound();
            }
            return View(ticker);
        }

        // GET: /Admin/Tickers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Tickers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,CreateDate,UserName,Status,Type,Quantity,Price,Description")] Ticker ticker)
        {
           if (ModelState.IsValid)
			{
				ticker.Status = false;
                ticker.CreateDate = DateTime.Now.Date;
				db.Tickers.Add(ticker);
				db.SaveChanges();
				if (ticker.ID > 0)
				{
					SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Thêm bảng giá thành công!", "success");
					
					return RedirectToAction("Index");
				}
				else
				{
					SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Thêm bảng giá không thành công!", "error");
					return RedirectToAction("Index");
				}
			}
			else
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Vui lòng nhập đầy đủ thông tin!", "error");
			}

			return View(ticker);
        }

        // GET: /Admin/Tickers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticker ticker = db.Tickers.Find(id);
            if (ticker == null)
            {
                return HttpNotFound();
            }
            return View(ticker);
        }

        // POST: /Admin/Tickers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,CreateDate,UserName,Status,Type,Quantity,Price,Description")] Ticker ticker)
        {
            if (ModelState.IsValid)
            {
                ticker.Status = true;
                db.Entry(ticker).State = EntityState.Modified;
                db.SaveChanges();
                if(ticker.ID>0)
                {
                    SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Sửa bảng giá thành công!", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Sửa bảng giá không thành công!", "error");
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(ticker);
        }

        // GET: /Admin/Tickers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticker ticker = db.Tickers.Find(id);
            if (ticker == null)
            {
                return HttpNotFound();
            }
            return View(ticker);
        }

        // POST: /Admin/Tickers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Ticker ticker = db.Tickers.Find(id);
            db.Tickers.Remove(ticker);
            db.SaveChanges();
            if (ticker.ID > 0)
            {
                SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Xóa bảng giá thành công!", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Xóa bảng giá không thành công!", "error");
                return RedirectToAction("Index");
            }
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

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {

            var user = db.Tickers.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return Json(new
            {
                status = user.Status
            });
        }
    }
}
