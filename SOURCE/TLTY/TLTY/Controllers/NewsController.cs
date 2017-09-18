using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityModel.EF;

namespace TLTY.Controllers
{
	public class NewsController : Controller
	{
		TLTYDBContext _db = new TLTYDBContext();
		// GET: News
		public ActionResult Index(int page = 1, int pageSize = 9)
		{
			int totalRecord = 0;
			var news = ListContent(ref totalRecord, page, pageSize);
			ViewBag.Total = totalRecord;
			ViewBag.Page = page;

			int maxPage = 10;
			int totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));

			ViewBag.TotalPage = totalPage + 1;//
			ViewBag.MaxPage = maxPage;
			ViewBag.First = 1;
			ViewBag.Last = totalPage + 1;//
			ViewBag.Next = page + 1;
			ViewBag.Prev = page - 1;
			ViewBag.SliderNews = _db.Contents.Where(x => x.Status && x.Category&&x.ViewCount > 20).OrderByDescending(x=>x.ViewCount).ToList();
			return View(news);
		}

		public List<Content> ListContent(ref int totalRecord, int pageIndex = 1, int pageSize = 2)
		{
			totalRecord = _db.Contents.Where(x => x.Status && x.Category).Count();
			var model = (from a in _db.Contents
						 where a.Status && a.Category
						 select new
						 {
							 a.MetaTitle,
							 a.ID,
							 a.Images,
							 a.MoreImages,
							 a.Name,
							 a.Status,
							 a.UserName,
							 a.ViewCount,
							 a.Category,
							 a.CreateDate,
							 a.Description,
							 a.Detail
						 }).AsEnumerable().Select(x => new Content()
						 {
							 MetaTitle = x.MetaTitle,
							 ID = x.ID,
							 Images = x.Images,
							 MoreImages = x.MoreImages,
							 Name = x.Name,
							 Status = x.Status,
							 UserName = x.UserName,
							 ViewCount = x.ViewCount,
							 Category = x.Category,
							 CreateDate = x.CreateDate,
							 Description = x.Description,
							 Detail = x.Detail
						 });

			return model.OrderByDescending(x => x.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
		}

		// GET: Admin/AccountGroups/Details/5
		public ActionResult Details(long id)
		{
			var news = _db.Contents.Find(id);
			news.ViewCount++;
			_db.SaveChanges();
			ViewBag.Request = _db.Requests.Where(x => x.ContentID == id && x.Status == true).OrderByDescending(x => x.CreateDate).ToList();
			ViewBag.Seen = _db.Contents.Where(x => x.Status && x.Category).ToList();
			return View(news);
		}

		[HttpPost]
		public JsonResult Requests(string name, string phone, string email, string detail, long contentId)
		{
			if (string.IsNullOrEmpty(name))
			{
				return Json(new
				{
					msg = " Tên trống.",
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
								msg = " Gửi phản hồi thành công, sau khi chúng tôi xác nhận, phản hồi sẽ được đăng công khai!.",
								status = true
							});
							//Send mail
						}
						else
						{
							return Json(new
							{
								msg = " Gửi phản hồi không thành công!.",
								status = false
							});
						}
					}
				}
			}
		}
	}
}