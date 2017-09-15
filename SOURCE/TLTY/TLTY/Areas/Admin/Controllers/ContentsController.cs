using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using EntityModel.EF;
using TLTY.Areas.Admin.Models;

namespace TLTY.Areas.Admin.Controllers
{
	public class ContentsController : BaseController
	{
		private TLTYDBContext _db = new TLTYDBContext();

		[HasCredential(PathID = "VIEW_CONTENT")]
		// GET: Admin/Contents
		public ActionResult Index()
		{
			return View(_db.Contents.ToList());
		}

		[HasCredential(PathID = "DETAILS_CONTENT")]
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

		[HasCredential(PathID = "CREATE_CONTENT")]
		// GET: Admin/Contents/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/Contents/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HasCredential(PathID = "CREATE_CONTENT")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,CreateDate,UserName,Status,ViewCount,Detail,Description,Images,MoreImages,Category")] Content content)
		{
			if (string.IsNullOrEmpty(content.Name))
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề trống xin hãy kiểm tra lại!", "error");
			}
			else if (content.Name.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(content.Description))
			{
				SetAlert("<i class='fa fa-times'></i> Mô tả trống xin hãy kiểm tra lại!", "error");
			}
			else if (content.Description.Length > 500)
			{
				SetAlert("<i class='fa fa-times'></i> Mô tả quá 500 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(content.Detail))
			{
				SetAlert("<i class='fa fa-times'></i> Nội dung trống xin hãy kiểm tra lại!", "error");
			}
			else
			{
				var checkcontent = _db.Contents.SingleOrDefault(x => x.Name == content.Name);
				if (checkcontent == null)
				{
					var session = (UserLogin)Session[Constants.USER_SESSION];
					content.Status = false;
					content.ViewCount = 0;
					content.CreateDate = DateTime.Now.Date;
					content.UserName = session.UserName;
					//Xử lý alias
					if (string.IsNullOrEmpty(content.MetaTitle))//Nếu metatitle k được nhập thì sẽ xử lý
					{
						content.MetaTitle = StringHelper.ToUnsignString(content.Name);
					}
					if (string.IsNullOrEmpty(content.Images))
					{
						content.Images = "/DATA/images/Instruction/1.png";
					}
					_db.Contents.Add(content);
					_db.SaveChanges();
					if (content.ID > 0)
					{
						SetAlert("<i class='fa fa-check'></i> Thêm nội dung thành công!. Hãy kích hoạt nội dung vừa tạo.", "success");
						return RedirectToAction("Index");
					}
					else
					{
						SetAlert("<i class='fa fa-times'></i> Thêm nội dung không thành công!", "error");
						return RedirectToAction("Index");
					}
				}
				else
				{
					SetAlert("<i class='fa fa-times'></i> Nội dung đã tồn tại!", "error");
				}
			}
			return RedirectToAction("Index");
		}

		[HasCredential(PathID = "EDIT_CONTENT")]
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
		[HasCredential(PathID = "EDIT_CONTENT")]
		[HttpPost, ValidateInput(false)]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,Name,MetaTitle,CreateDate,UserName,Status,ViewCount,Detail,Description,Images,MoreImages,Category")] Content content)
		{
			if (string.IsNullOrEmpty(content.Name))
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề trống xin hãy kiểm tra lại!", "error");
			}
			else if (content.Name.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(content.Description))
			{
				SetAlert("<i class='fa fa-times'></i> Mô tả trống xin hãy kiểm tra lại!", "error");
			}
			else if (content.Description.Length > 500)
			{
				SetAlert("<i class='fa fa-times'></i> Mô tả quá 500 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(content.Detail))
			{
				SetAlert("<i class='fa fa-times'></i> Nội dung trống xin hãy kiểm tra lại!", "error");
			}
			else
			{
				if (string.IsNullOrEmpty(content.Images))
				{
					content.Images = "/DATA/images/Instruction/1.png";
				}
				_db.Entry(content).State = EntityState.Modified;
				_db.SaveChanges();
				if (content.ID > 0)
				{
					SetAlert("<i class='fa fa-check'></i> Sửa nội dung thành công!", "success");
					return RedirectToAction("Index");
				}
				else
				{
					SetAlert("<i class='fa fa-times'></i> Sửa nội dung không thành công!", "error");
					return RedirectToAction("Index");
				}
			}
			return RedirectToAction("Index");
		}

		[HasCredential(PathID = "DELETE_CONTENT")]
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

		[HasCredential(PathID = "DELETE_CONTENT")]
		// POST: Admin/Contents/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(long id)
		{
			Content content = _db.Contents.Find(id);
			_db.Contents.Remove(content);
			_db.SaveChanges();
			if (content.ID > 0)
			{
				SetAlert("<i class='fa fa-check'></i> Xóa nội dung thành công!", "success");
				return RedirectToAction("Index");
			}
			else
			{
				SetAlert("<i class='fa fa-times'></i> Xóa nội dung không thành công!", "error");
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

		[HasCredential(PathID = "EDIT_CONTENT")]
		[HttpPost]
		public JsonResult ChangeStatus(long id)
		{
			var content = _db.Contents.Find(id);
			content.Status = !content.Status;
			_db.SaveChanges();
			return Json(new
			{
				status = content.Status
			});
		}

		[HasCredential(PathID = "EDIT_CONTENT")]
		public string ChangeImage(int id, string picture)
		{
			if (id < 0)
			{
				return "Mã tài khoản không tồn tại";
			}
			else
			{
				Content p = _db.Contents.Find(id);
				if (p == null)
				{
					return "Mã tài khoản không được tìm thấy";
				}
				else
				{
					p.Images = picture;
					_db.SaveChanges();
					SetAlert("<i class='fa fa-times'></i> Tài khoản không tồn tại", "error");
					return "";
				}
			}
		}

		[HasCredential(PathID = "EDIT_CONTENT")]
		public JsonResult LoadImages(long id)
		{
			var content = _db.Contents.Find(id);
			var images = content.MoreImages;
			XElement xImages = XElement.Parse(images);
			List<string> listImageReturn = new List<string>();

			foreach (XElement item in xImages.Elements())
			{
				listImageReturn.Add(item.Value);
			}

			return Json(new
			{
				data = listImageReturn
			}, JsonRequestBehavior.AllowGet);

		}

		[HasCredential(PathID = "EDIT_CONTENT")]
		[HttpPost]
		public JsonResult SaveImages(long id, string images)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			var listImages = serializer.Deserialize<List<string>>(images);
			XElement xElement = new XElement("Images");
			foreach (var item in listImages)
			{
				var subStringItem = item.Substring(22);
				xElement.Add(new XElement("Image", subStringItem));
			}

			try
			{
				UpdateImages(id, xElement.ToString());
				return Json(new
				{
					status = true
				});
			}
			catch (Exception)
			{
				return Json(new
				{
					status = false
				});
			}
		}

		public void UpdateImages(long contentId, string images)
		{
			var content = _db.Contents.Find(contentId);
			content.MoreImages = images;
			_db.SaveChanges();
		}
	}
}

