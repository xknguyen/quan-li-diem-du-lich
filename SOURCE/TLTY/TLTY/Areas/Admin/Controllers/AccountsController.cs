using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EntityModel.EF;
using TLTY.Areas.Admin.Models;
using System;

namespace TLTY.Areas.Admin.Controllers
{
	public class AccountsController : BaseController
	{
		private TLTYDBContext _db = new TLTYDBContext();

		// GET: Admin/Accounts
		public ActionResult Index()
		{
			return View(_db.Accounts.ToList());
		}

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

		// GET: Admin/Accounts/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/Accounts/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,UserName,Password,FirstName,LastName,Birthday,Email,Phone,Avatar,Address,CreateDate,Status")] Account account)
		{
			if (string.IsNullOrEmpty(account.UserName))
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tài khoản trống xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(account.FirstName))
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tên trống xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(account.Email))
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Email trống xin hãy kiểm tra lại!", "error");
			}
			else
			{
				var checkuser = _db.Accounts.SingleOrDefault(x => x.UserName == account.UserName);
				if (checkuser == null)
				{
					if (account.Birthday > DateTime.Parse("1/1/2017") || account.Birthday < DateTime.Parse("1/1/1950"))
					{
						SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Ngày sinh không phù hợp, Xin hãy thử lại!", "error");
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
							SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Thêm tài khoản thành công! Mật khẩu mặc định là <strong>" + password + "</strong>. Hãy kích hoạt tài khoản vừa tạo để đăng nhập.", "success");
							return RedirectToAction("Index");
						}
						else
						{
							SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Thêm tài khoản không thành công!", "error");
							return RedirectToAction("Index");
						}
					}
				}
				else
				{
					SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tài khoản đã tồn tại!", "error");
				}
			}
			return RedirectToAction("Index");
		}

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
			return View(account);
		}

		// POST: Admin/Accounts/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,UserName,Password,FirstName,LastName,Birthday,Email,Phone,Avatar,Address,CreateDate,Status")] Account account)
		{
			if (Session["AccountID"].GetHashCode() != 1 && account.ID == 1)
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Bạn không thể sửa tài khoản quyền cao nhất!", "error");
				return RedirectToAction("Index");
			}
			else
			{
				if (string.IsNullOrEmpty(account.UserName))
				{
					SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tài khoản trống xin hãy kiểm tra lại!", "error");
				}
				else if (string.IsNullOrEmpty(account.FirstName))
				{
					SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tên trống xin hãy kiểm tra lại!", "error");
				}
				else if (string.IsNullOrEmpty(account.Email))
				{
					SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Email trống xin hãy kiểm tra lại!", "error");
				}
				else if (account.Birthday > DateTime.Parse("1/1/2017") || account.Birthday < DateTime.Parse("1/1/1950"))
				{
					SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Ngày sinh không phù hợp, Xin hãy thử lại!", "error");
				}
				else
				{
					_db.Entry(account).State = EntityState.Modified;
					_db.SaveChanges();
					if (account.ID > 0)
					{
						SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Sửa tài khoản thành công!", "success");
						return RedirectToAction("Index");
					}
					else
					{
						SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Sửa tài khoản không thành công!", "error");
						return RedirectToAction("Index");
					}
				}
			}
			return RedirectToAction("Index");
		}

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

		// POST: Admin/Accounts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(long id)
		{
			Account account = _db.Accounts.Find(id);
			if (account.ID == 1 || account.UserName == "admin")
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Đây là tài khoản admin quyền cao nhất, bạn không thể xóa!", "error");
				return RedirectToAction("Index");
			}
			else
			{
				if (account.ID == Session["AccountID"].GetHashCode())
				{
					SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Bạn không thể xóa tài khoản đang đăng nhập!", "error");
					return RedirectToAction("Index");
				}
				else
				{
					_db.Accounts.Remove(account);
					_db.SaveChanges();
					if (account.ID > 0)
					{
						SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Xóa tài khoản thành công!", "success");
						return RedirectToAction("Index");
					}
					else
					{
						SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Xóa tài khoản không thành công!", "error");
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

		[HttpPost]
		public ActionResult ChangPassword(string oldPass, string newPass1, string newPass2)
		{
			if (ModelState.IsValid)
			{
				if (!string.IsNullOrEmpty(oldPass))
				{
					string username = Session["UserName"].ToString();
					int userid = Session["AccountID"].GetHashCode();
					var entryptedMd5Pas = Common.MD5Hash(username + oldPass);
					oldPass = entryptedMd5Pas;

					var result = _db.Accounts.SingleOrDefault(x => x.UserName == username);
					if (result == null)
					{
						SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tài khoản không tồn tại", "error");
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
									SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Thay đổi mật khẩu thành công!", "success");
									return RedirectToAction("Index");
								}
								else
								{
									SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Thay đổi mật khẩu không thành công!", "error");
									return RedirectToAction("Index");
								}
							}
							else
							{
								SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Mật khẩu mới trống hoặc không khớp với xác nhận mật khẩu.", "error");
							}
						}
						else
						{
							SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Mật khẩu không chính xác.", "error");
						}
					}
				}
				else
				{
					SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tài khoản không tồn tại.", "error");
				}
			}
			return RedirectToAction("Index");
		}

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
