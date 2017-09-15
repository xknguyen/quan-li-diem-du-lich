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
	public class TickersController : BaseController
	{
		private TLTYDBContext db = new TLTYDBContext();

		[HasCredential(PathID = "VIEW_TICKER")]
		// GET: /Admin/Tickers/
		public ActionResult Index()
		{
			return View(db.Tickers.ToList());
		}

		[HasCredential(PathID = "DETAILS_TICKER")]
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

		[HasCredential(PathID = "CREATE_TICKER")]
		// GET: /Admin/Tickers/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: /Admin/Tickers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HasCredential(PathID = "CREATE_TICKER")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,Name,CreateDate,UserName,Status,Type,Quantity,Price,Description")] Ticker ticker)
		{
			if (string.IsNullOrEmpty(ticker.Name))
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề trống xin hãy kiểm tra lại!", "error");
			}
			else if (ticker.Name.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (ticker.Quantity < 0)
			{
				SetAlert("<i class='fa fa-times'></i> Số lượng trống xin hãy kiểm tra lại!", "error");
			}
			else if (ticker.Price < 0)
			{
				SetAlert("<i class='fa fa-times'></i> Giá trống xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(ticker.Description))
			{
				SetAlert("<i class='fa fa-times'></i> Mô tả trống xin hãy kiểm tra lại!", "error");
			}
			else if (ticker.Description.Length > 500)
			{
				SetAlert("<i class='fa fa-times'></i> Mô tả quá 500 ký tự xin hãy kiểm tra lại!", "error");
			}
			else
			{
				ticker.Status = false;
				ticker.CreateDate = DateTime.Now.Date;
				var session = (UserLogin)Session[Constants.USER_SESSION];
				ticker.UserName = session.UserName;
				db.Tickers.Add(ticker);
				db.SaveChanges();
				if (ticker.ID > 0)
				{
					SetAlert("<i class='fa fa-check'></i> Thêm bảng giá thành công!. Hãy kích hoạt bảng giá vừa tạo.", "success");
					return RedirectToAction("Index");
				}
				else
				{
					SetAlert("<i class='fa fa-times'></i> Thêm bảng giá không thành công!", "error");
					return RedirectToAction("Index");
				}
			}
			return RedirectToAction("Index");
		}

		[HasCredential(PathID = "EDIT_TICKER")]
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
		[HasCredential(PathID = "EDIT_TICKER")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,Name,CreateDate,UserName,Status,Type,Quantity,Price,Description")] Ticker ticker)
		{
			if (string.IsNullOrEmpty(ticker.Name))
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề trống xin hãy kiểm tra lại!", "error");
			}
			else if (ticker.Name.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (ticker.Quantity < 0)
			{
				SetAlert("<i class='fa fa-times'></i> Số lượng trống xin hãy kiểm tra lại!", "error");
			}
			else if (ticker.Price < 0)
			{
				SetAlert("<i class='fa fa-times'></i> Giá trống xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(ticker.Description))
			{
				SetAlert("<i class='fa fa-times'></i> Mô tả trống xin hãy kiểm tra lại!", "error");
			}
			else if (ticker.Description.Length > 500)
			{
				SetAlert("<i class='fa fa-times'></i> Mô tả quá 500 ký tự xin hãy kiểm tra lại!", "error");
			}
			else
			{
				db.Entry(ticker).State = EntityState.Modified;
				db.SaveChanges();
				if (ticker.ID > 0)
				{
					SetAlert("<i class='fa fa-check'></i> Sửa bảng giá thành công!", "success");
					return RedirectToAction("Index");
				}
				else
				{
					SetAlert("<i class='fa fa-times'></i> Sửa bảng giá không thành công!", "error");
					return RedirectToAction("Index");
				}
			}
			return RedirectToAction("Index");
		}

		[HasCredential(PathID = "DELETE_TICKER")]
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

		[HasCredential(PathID = "DELETE_TICKER")]
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
				SetAlert("<i class='fa fa-check'></i> Xóa bảng giá thành công!", "success");
				return RedirectToAction("Index");
			}
			else
			{
				SetAlert("<i class='fa fa-times'></i> Xóa bảng giá không thành công!", "error");
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

		[HasCredential(PathID = "EDIT_TICKER")]
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
