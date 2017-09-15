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
					var account = _db.Accounts.FirstOrDefault(x => x.UserName == model.UserName);
					if (account != null)
					{
						var userSession = new UserLogin();
						userSession .AccountID= account.ID;
						userSession.UserName = account.UserName;
						userSession.FristName = account.FirstName;
						userSession.LastName = account.LastName;
						userSession.Phone = account.Phone;
						userSession.Email = account.Email;
						userSession.Address = account.Address;
						userSession.Avatar = account.Avatar;
						userSession.AccountGroupID = account.AccountGroupID;

						var listCredentials = GetListCredential(model.UserName);

						Session.Add(Constants.SESSION_CREDENTIALS,listCredentials);
						Session.Add(Constants.USER_SESSION, userSession);
					}

					return RedirectToAction("Index","Home");
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
					ViewBag.Error = "Sai mật khẩu!";
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

		public List<string> GetListCredential(string userName)
		{
			var user = _db.Accounts.Single(x => x.UserName == userName);
			var data = (from a in _db.GroupPaths
						join b in _db.AccountGroups on a.AccountGroupID equals b.ID
						join c in _db.Paths on a.PathID equals c.ID
						where b.ID == user.AccountGroupID
						select new
						{
							PathID = a.PathID,
							AccountGroupID = a.AccountGroupID
						}).AsEnumerable().Select(x => new GroupPath()
						{
							PathID = x.PathID,
							AccountGroupID = x.AccountGroupID
						});
			return data.Select(x => x.PathID).ToList();
		}

		public ActionResult Logout()
		{
			Session.RemoveAll();
			return RedirectToAction("Index", "Home");
		}
    }
}