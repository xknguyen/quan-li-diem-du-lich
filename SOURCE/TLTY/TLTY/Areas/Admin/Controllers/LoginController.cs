using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityModel.EF;
using TLTY.Areas.Admin.Models;

namespace TLTY.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
		TLTYDBContext _db = new TLTYDBContext();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

	    [HttpPost]
	    public ActionResult Login(LoginModel model)
	    {
			if (ModelState.IsValid)
			{
				var result = DangNhap(model.UserName, Common.MD5Hash(model.UserName + model.Password));
				if (result == 1)
				{
					//var account = dao.GetByID(model.accountName);
					var account = _db.Accounts.SingleOrDefault(x => x.UserName == model.UserName);
					if (account != null)
					{
						Session["AccountID"] = account.ID;
						Session["UserName"] = account.UserName;
						Session["FristName"] = account.FirstName;
						Session["LastName"] = account.LastName;
						Session["Phone"] = account.Phone;
						Session["Email"] = account.Email;
						Session["Address"] = account.Address;
						Session["Avatar"] = account.Avatar;
					}

					return RedirectToAction("Index", "Home");
				}
				else if (result == 0)
				{
					ViewBag.Error = "Tài khoản không tồn tại!";
					//ModelState.AddModelError("", "Tài khoản không tồn tại hoặc bạn không có quyên vào đây!");
				}
				else if (result == -1)
				{
					ViewBag.Error = "Tài khoản đang bị khóa!";
					//ModelState.AddModelError("", "Tài khoản đang bị khóa!");
				}
				else if (result == -2)
				{
					ViewBag.Error = "Sai mật khẩu.";
					//ModelState.AddModelError("", "Sai mật khẩu.");
				}
			}
			else
			{
				ViewBag.Error = "Vui lòng nhập đầy đủ thông tin!";
			}
			return View("Index");
	    }

		public int DangNhap(string userName, string pasword)
		{
			var result = _db.Accounts.SingleOrDefault(x => x.UserName == userName);
			if (result == null)
			{
				return 0;
			}
			else
			{
				if (result.Status == false)
				{
					return -1;
				}
				else
				{
					if (result.Password == pasword)
					{
						return 1;
					}
					else
						return -2;
				}

			}
		}

		public ActionResult Logout()
		{
			Session["AccountID"] = null;
			Session["UserName"] = null;
			Session["FristName"] = null;
			Session["LastName"] = null;
			Session["Phone"] = null;
			Session["Email"] = null;
			Session["Address"] = null;
			Session["Avatar"] = null;
			return RedirectToAction("Index", "Home");
		}
    }
}