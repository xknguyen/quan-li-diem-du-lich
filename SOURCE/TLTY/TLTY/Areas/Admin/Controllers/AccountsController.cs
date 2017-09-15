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
	public class AccountsController : BaseController
	{
		private TLTYDBContext _db = new TLTYDBContext();

		[HasCredential(PathID = "VIEW_ACCOUNT")]
		// GET: Admin/Accounts
		public ActionResult Index()
		{
			var accounts = _db.Accounts.Include(a => a.AccountGroup);
			return View(accounts.ToList());
		}

		[HasCredential(PathID = "DETAILS_ACCOUNT")]
		// GET: Admin/Accounts/Details/5
		public ActionResult Details(long? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Account account = _db.Accounts.Find(id);
			if (account == null)
			{
				return HttpNotFound();
			}
			return View(account);
		}

		[HasCredential(PathID = "CREATE_ACCOUNT")]
		// GET: Admin/Accounts/Create
		public ActionResult Create()
		{
			ViewBag.AccountGroupID = new SelectList(_db.AccountGroups, "ID", "Name");
			return View();
		}

		// POST: Admin/Accounts/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HasCredential(PathID = "CREATE_ACCOUNT")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,UserName,Password,AccountGroupID,FirstName,LastName,Birthday,Email,Phone,Avatar,Address,CreateDate,Status")] Account account)
		{
			if (string.IsNullOrEmpty(account.UserName))
			{
				SetAlert("<i class='fa fa-times'></i> Tài khoản trống xin hãy kiểm tra lại!", "error");
			}
			else if (account.UserName.Length > 250 || account.UserName.Length < 4)
			{
				SetAlert("<i class='fa fa-times'></i> Tài khoản quá 250 ký tự hoặc thấp hơn 4 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(account.FirstName))
			{
				SetAlert("<i class='fa fa-times'></i> Tên trống xin hãy kiểm tra lại!", "error");
			}
			else if (account.FirstName.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Tên quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (account.LastName.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Họ quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(account.Email))
			{
				SetAlert("<i class='fa fa-times'></i> Email trống xin hãy kiểm tra lại!", "error");
			}
			else if (account.Email.Length > 250 || account.Email.Length < 4)
			{
				SetAlert("<i class='fa fa-times'></i> Email quá 250 ký tự hoặc thấp hơn 4 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (account.Phone.Length > 15 || account.UserName.Length < 10)
			{
				SetAlert("<i class='fa fa-times'></i> Số điện thoại quá 15 ký tự hoặc thấp hơn 10 ký tự xin hãy kiểm tra lại!", "error");
			}
			else
			{
				var checkuser = _db.Accounts.SingleOrDefault(x => x.UserName == account.UserName);
				if (checkuser == null)
				{
					if (account.Birthday > DateTime.Parse("1/1/2017") || account.Birthday < DateTime.Parse("1/1/1950"))
					{
						SetAlert("<i class='fa fa-times'></i> Ngày sinh không phù hợp, Xin hãy thử lại!", "error");
					}
					else
					{
						const string password = "123456";
						var entryptedMd5Pas = Common.MD5Hash(account.UserName + password);
						account.Password = entryptedMd5Pas;
						account.Status = false;
						account.CreateDate = DateTime.Now.Date;
						if (string.IsNullOrEmpty(account.Avatar))
						{
							account.Avatar = "/DATA/images/Avatar/10l.jpg";
						}
						_db.Accounts.Add(account);
						_db.SaveChanges();
						if (account.ID > 0)
						{
							SetAlert("<i class='fa fa-check'></i> Thêm tài khoản thành công! Mật khẩu mặc định là <strong>" + password + "</strong>. Hãy kích hoạt tài khoản vừa tạo để đăng nhập.", "success");
							return RedirectToAction("Index");
						}
						else
						{
							SetAlert("<i class='fa fa-times'></i> Thêm tài khoản không thành công!", "error");
							return RedirectToAction("Index");
						}
					}
				}
				else
				{
					SetAlert("<i class='fa fa-times'></i> Tài khoản đã tồn tại!", "error");
				}
			}

			ViewBag.AccountGroupID = new SelectList(_db.AccountGroups, "ID", "Name", account.AccountGroupID);
			return RedirectToAction("Index");
		}

		[HasCredential(PathID = "EDIT_ACCOUNT")]
		// GET: Admin/Accounts/Edit/5
		public ActionResult Edit(long? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Account account = _db.Accounts.Find(id);
			if (account == null)
			{
				return HttpNotFound();
			}
			ViewBag.AccountGroupID = new SelectList(_db.AccountGroups, "ID", "Name", account.AccountGroupID);
			return View(account);
		}

		// POST: Admin/Accounts/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HasCredential(PathID = "EDIT_ACCOUNT")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,UserName,Password,AccountGroupID,FirstName,LastName,Birthday,Email,Phone,Avatar,Address,CreateDate,Status")] Account account)
		{
			var session = (UserLogin)Session[Constants.USER_SESSION];
			if (session.AccountID != 1 && account.ID == 1)
			{
				SetAlert("<i class='fa fa-times'></i> Bạn không thể sửa tài khoản quyền cao nhất!", "error");
				return RedirectToAction("Index");
			}
			else
			{
				if (string.IsNullOrEmpty(account.UserName))
				{
					SetAlert("<i class='fa fa-times'></i> Tài khoản trống xin hãy kiểm tra lại!", "error");
				}
				else if (account.UserName.Length > 250 || account.UserName.Length < 4)
				{
					SetAlert("<i class='fa fa-times'></i> Tài khoản quá 250 ký tự hoặc thấp hơn 4 ký tự xin hãy kiểm tra lại!", "error");
				}
				else if (string.IsNullOrEmpty(account.FirstName))
				{
					SetAlert("<i class='fa fa-times'></i> Tên trống xin hãy kiểm tra lại!", "error");
				}
				else if (account.FirstName.Length > 250)
				{
					SetAlert("<i class='fa fa-times'></i> Tên quá 250 ký tự xin hãy kiểm tra lại!", "error");
				}
				else if (account.LastName.Length > 250)
				{
					SetAlert("<i class='fa fa-times'></i> Họ quá 250 ký tự xin hãy kiểm tra lại!", "error");
				}
				else if (string.IsNullOrEmpty(account.Email))
				{
					SetAlert("<i class='fa fa-times'></i> Email trống xin hãy kiểm tra lại!", "error");
				}
				else if (account.Email.Length > 250 || account.Email.Length < 4)
				{
					SetAlert("<i class='fa fa-times'></i> Email quá 250 ký tự hoặc thấp hơn 4 ký tự xin hãy kiểm tra lại!", "error");
				}
				else if (account.Phone.Length > 15 || account.UserName.Length < 10)
				{
					SetAlert("<i class='fa fa-times'></i> Số điện thoại quá 15 ký tự hoặc thấp hơn 10 ký tự xin hãy kiểm tra lại!", "error");
				}
				else if (account.Birthday > DateTime.Parse("1/1/2017") || account.Birthday < DateTime.Parse("1/1/1950"))
				{
					SetAlert("<i class='fa fa-times'></i> Ngày sinh không phù hợp, Xin hãy thử lại!", "error");
				}
				else
				{
					_db.Entry(account).State = EntityState.Modified;
					_db.SaveChanges();
					if (account.ID > 0)
					{
						SetAlert("<i class='fa fa-check'></i> Sửa tài khoản thành công!", "success");
						return RedirectToAction("Index");
					}
					else
					{
						SetAlert("<i class='fa fa-times'></i> Sửa tài khoản không thành công!", "error");
						return RedirectToAction("Index");
					}
				}
			}

			ViewBag.AccountGroupID = new SelectList(_db.AccountGroups, "ID", "Name", account.AccountGroupID);
			return RedirectToAction("Index");
		}

		[HasCredential(PathID = "DELETE_ACCOUNT")]
		// GET: Admin/Accounts/Delete/5
		public ActionResult Delete(long? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Account account = _db.Accounts.Find(id);
			if (account == null)
			{
				return HttpNotFound();
			}
			return View(account);
		}

		[HasCredential(PathID = "DELETE_ACCOUNT")]
		// POST: Admin/Accounts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(long id)
		{
			Account account = _db.Accounts.Find(id);
			if (account.ID == 1 || account.UserName == "admin")
			{
				SetAlert("<i class='fa fa-times'></i> Đây là tài khoản admin quyền cao nhất, bạn không thể xóa!", "error");
				return RedirectToAction("Index");
			}
			else
			{
				var session = (UserLogin)Session[Constants.USER_SESSION];
				if (account.ID == session.AccountID)
				{
					SetAlert("<i class='fa fa-times'></i> Bạn không thể xóa tài khoản đang đăng nhập!", "error");
					return RedirectToAction("Index");
				}
				else
				{
					_db.Accounts.Remove(account);
					_db.SaveChanges();
					if (account.ID > 0)
					{
						SetAlert("<i class='fa fa-check'></i> Xóa tài khoản thành công!", "success");
						return RedirectToAction("Index");
					}
					else
					{
						SetAlert("<i class='fa fa-times'></i> Xóa tài khoản không thành công!", "error");
						return RedirectToAction("Index");
					}
				}
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

		[HasCredential(PathID = "CHANGE_ACCOUNT")]
		//Change password
		public ActionResult ChangPassword(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Account account = _db.Accounts.Find(id);
			if (account == null)
			{
				return HttpNotFound();
			}
			return View(account);
		}

		[HasCredential(PathID = "CHANGE_ACCOUNT")]
		[HttpPost]
		public ActionResult ChangPassword(string oldPass, string newPass1, string newPass2)
		{
			if (ModelState.IsValid)
			{
				if (!string.IsNullOrEmpty(oldPass))
				{
					var session = (UserLogin)Session[Constants.USER_SESSION];
					string username = session.UserName;
					long userid = session.AccountID;
					var entryptedMd5Pas = Common.MD5Hash(username + oldPass);
					oldPass = entryptedMd5Pas;

					var result = _db.Accounts.SingleOrDefault(x => x.UserName == username);
					if (result == null)
					{
						SetAlert("<i class='fa fa-times'></i> Tài khoản không tồn tại", "error");
					}
					else if (newPass1.Length > 250 || newPass1.Length < 6 || newPass2.Length > 250 || newPass2.Length < 6)
					{
						SetAlert("<i class='fa fa-times'></i> Mật khẩu quá 250 ký tự hoặc thấp hơn 6 ký tự xin hãy kiểm tra lại!", "error");
					}
					else
					{
						if (result.Password == oldPass)
						{
							var user = _db.Accounts.Find(userid);
							if (!string.IsNullOrEmpty(newPass1) && !string.IsNullOrEmpty(newPass2) && newPass1 == newPass2)
							{
								var entryptedMd5Pasnew = Common.MD5Hash(username + newPass1);
								newPass1 = entryptedMd5Pasnew;
								user.Password = newPass1;
								_db.SaveChanges();
								if (user.ID > 0)
								{
									SetAlert("<i class='fa fa-check'></i> Thay đổi mật khẩu thành công!", "success");
									return RedirectToAction("Index");
								}
								else
								{
									SetAlert("<i class='fa fa-times'></i> Thay đổi mật khẩu không thành công!", "error");
									return RedirectToAction("Index");
								}
							}
							else
							{
								SetAlert("<i class='fa fa-times'></i> Mật khẩu mới trống hoặc không khớp với xác nhận mật khẩu.", "error");
							}
						}
						else
						{
							SetAlert("<i class='fa fa-times'></i> Mật khẩu không chính xác.", "error");
						}
					}
				}
				else
				{
					SetAlert("<i class='fa fa-times'></i> Tài khoản không tồn tại.", "error");
				}
			}
			return RedirectToAction("Index");
		}

		[HasCredential(PathID = "EDIT_ACCOUNT")]
		[HttpPost]
		public JsonResult ChangeStatus(long id)
		{
			var user = _db.Accounts.Find(id);
			user.Status = !user.Status;
			_db.SaveChanges();
			return Json(new
			{
				status = user.Status
			});
		}

		[HasCredential(PathID = "EDIT_ACCOUNT")]
		public string ChangeImage(int id, string picture)
		{
			if (id < 0)
			{
				return " Không tin thấy tài khoản!";
			}
			else
			{
				Account p = _db.Accounts.Find(id);
				if (p == null)
				{
					return " Không tin thấy tài khoản!";
				}
				else
				{
					p.Avatar = picture;
					_db.SaveChanges();
					return "";
				}
			}
		}
	}
}
