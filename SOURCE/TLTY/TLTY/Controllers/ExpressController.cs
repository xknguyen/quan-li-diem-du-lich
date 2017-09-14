using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityModel.EF;

namespace TLTY.Controllers
{
	public class ExpressController : Controller
	{
		TLTYDBContext _db = new TLTYDBContext();
		// GET: Express
		public ActionResult Index()
		{
			var express =
				_db.Contents.Where(x => x.Category == false && x.Status).OrderByDescending(x => x.CreateDate).ToList();
			return View(express);
		}

		// GET: Admin/AccountGroups/Details/5
		public ActionResult Details(long id)
		{
			var express = _db.Contents.Find(id);
			express.ViewCount++;
			_db.SaveChanges();
			ViewBag.Request = _db.Requests.Where(x => x.ContentID == id && x.Status == true).OrderByDescending(x => x.CreateDate).ToList();
			return View(express);
		}

		[HttpPost]
		public JsonResult Request(string name, string phone, string email, string detail, long contentId)
		{
			string msg = "";
			if (string.IsNullOrEmpty(name))
			{
				return Json(new
				{
					msg=" Tên trống.",
					status = false
				});
			}
			else
			{
				if (string.IsNullOrEmpty(email))
				{
					return Json(new
					{
						msg = " Email trống.",
						status = false
					});
				}
				else
				{
					if (string.IsNullOrEmpty(detail))
					{
						return Json(new
						{
							msg = " Yêu cầu trống.",
							status = false
						});
					}
					else
					{
						var request = new Request();
						request.Name = name;
						request.Email = email;
						request.Phone = phone;
						request.Detail = detail;
						request.ContentID = contentId;
						request.Status = false;
						request.CreateDate = DateTime.Now.Date;
						_db.Requests.Add(request);
						_db.SaveChanges();
						if (request.ID > 0)
						{
							return Json(new
							{
								msg = " Gửi phản hồi thành công, sau khi chúng tôi xác nhận, phản hồi sẽ được đăng công khai.",
								status = true
							});
							//send mail

						}
						else
						{
							return Json(new
							{
								msg = " Gửi phản hồi không thành công.",
								status = false
							});
						}
					}
				}

			}
		}
	}
}