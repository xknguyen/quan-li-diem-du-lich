using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EntityModel.EF;
using System;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Collections.Generic;
using TLTY.Areas.Admin.Models;

namespace TLTY.Areas.Admin.Controllers
{
	public class InstructionsController : BaseController
	{
		private TLTYDBContext _db = new TLTYDBContext();

		[HasCredential(PathID = "VIEW_INSTRUCTION")]
		// GET: Admin/Instructions
		public ActionResult Index()
		{
			return View(_db.Instructions.ToList());
		}

		[HasCredential(PathID = "DETAILS_INSTRUCTION")]
		// GET: Admin/Instructions/Details/5
		public ActionResult Details(long? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Instruction instruction = _db.Instructions.Find(id);
			if (instruction == null)
			{
				return HttpNotFound();
			}
			return View(instruction);
		}

		[HasCredential(PathID = "CREATE_INSTRUCTION")]
		// GET: Admin/Instructions/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Admin/Instructions/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HasCredential(PathID = "CREATE_INSTRUCTION")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,Name,CreateDate,UserName,Status,Detail,Images,MoreImages")] Instruction instruction)
		{
			if (string.IsNullOrEmpty(instruction.Name))
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề trống xin hãy kiểm tra lại!", "error");
			}
			else if (instruction.Name.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(instruction.Detail))
			{
				SetAlert("<i class='fa fa-times'></i> Nội dung trống xin hãy kiểm tra lại!", "error");
			}
			else
			{
				var checkcontent = _db.Contents.SingleOrDefault(x => x.Name == instruction.Name);
				if (checkcontent == null)
				{
					var session = (UserLogin)Session[Constants.USER_SESSION];
					instruction.Status = false;
					instruction.CreateDate = DateTime.Now.Date;
					instruction.UserName = session.UserName;

					if (string.IsNullOrEmpty(instruction.Images))
					{
						instruction.Images = "/DATA/images/Instruction/1.png";
					}
					_db.Instructions.Add(instruction);
					_db.SaveChanges();
					if (instruction.ID > 0)
					{
						SetAlert("<i class='fa fa-check'></i> Thêm giới thiệu thành công!. Hãy kích hoạt giới thiệu vừa tạo.", "success");
						return RedirectToAction("Index");
					}
					else
					{
						SetAlert("<i class='fa fa-times'></i> Thêm giới thiệu không thành công!", "error");
						return RedirectToAction("Index");
					}
				}
				else
				{
					SetAlert("<i class='fa fa-times'></i> Giới thiệu đã tồn tại!", "error");
				}
			}
			return RedirectToAction("Index");
		}

		[HasCredential(PathID = "EDIT_INSTRUCTION")]
		// GET: Admin/Instructions/Edit/5
		public ActionResult Edit(long? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Instruction instruction = _db.Instructions.Find(id);
			if (instruction == null)
			{
				return HttpNotFound();
			}
			return View(instruction);
		}

		// POST: Admin/Instructions/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HasCredential(PathID = "EDIT_INSTRUCTION")]
		[HttpPost, ValidateInput(false)]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,Name,CreateDate,UserName,Status,Detail,Images,MoreImages")] Instruction instruction)
		{
			if (string.IsNullOrEmpty(instruction.Name))
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề trống xin hãy kiểm tra lại!", "error");
			}
			else if (instruction.Name.Length > 250)
			{
				SetAlert("<i class='fa fa-times'></i> Tiêu đề quá 250 ký tự xin hãy kiểm tra lại!", "error");
			}
			else if (string.IsNullOrEmpty(instruction.Detail))
			{
				SetAlert("<i class='fa fa-times'></i> Nội dung trống xin hãy kiểm tra lại!", "error");
			}
			else
			{
				var checkcontent = _db.Contents.SingleOrDefault(x => x.Name == instruction.Name);
				if (checkcontent == null)
				{
					if (string.IsNullOrEmpty(instruction.Images))
					{
						instruction.Images = "/DATA/images/Instruction/1.png";
					}
					_db.Entry(instruction).State = EntityState.Modified;
					_db.SaveChanges();
					if (instruction.ID > 0)
					{
						SetAlert("<i class='fa fa-check'></i> Sửa giới thiệu thành công!", "success");
						return RedirectToAction("Index");
					}
					else
					{
						SetAlert("<i class='fa fa-times'></i> Sửa giới thiệu không thành công!", "error");
						return RedirectToAction("Index");
					}
				}
				else
				{
					SetAlert("<i class='fa fa-times'></i> Giới thiệu đã tồn tại!", "error");
				}
			}
			return RedirectToAction("Index");
		}

		[HasCredential(PathID = "DELETE_INSTRUCTION")]
		// GET: Admin/Instructions/Delete/5
		public ActionResult Delete(long? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Instruction instruction = _db.Instructions.Find(id);
			if (instruction == null)
			{
				return HttpNotFound();
			}
			return View(instruction);
		}

		[HasCredential(PathID = "DELETE_INSTRUCTION")]
		// POST: Admin/Instructions/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(long id)
		{
			Instruction instruction = _db.Instructions.Find(id);
			_db.Instructions.Remove(instruction);
			_db.SaveChanges();
			if (instruction.ID > 0)
			{
				SetAlert("<i class='fa fa-check'></i> Xóa giới thiệu thành công!", "success");
				return RedirectToAction("Index");
			}
			else
			{
				SetAlert("<i class='fa fa-times'></i> Xóa giới thiệu không thành công!", "error");
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

		[HasCredential(PathID = "EDIT_INSTRUCTION")]
		[HttpPost]
		public JsonResult ChangeStatus(long id)
		{
			var instruction = _db.Instructions.Find(id);
			instruction.Status = !instruction.Status;
			_db.SaveChanges();
			return Json(new
			{
				status = instruction.Status
			});
		}

		[HasCredential(PathID = "EDIT_INSTRUCTION")]
		public string ChangeImage(int id, string picture)
		{
			if (id < 0)
			{
				return "Mã tài khoản không tồn tại";
			}
			else
			{
				Instruction p = _db.Instructions.Find(id);
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

		[HasCredential(PathID = "EDIT_INSTRUCTION")]
		public JsonResult LoadImages(long id)
		{
			var instruction = _db.Instructions.Find(id);
			var images = instruction.MoreImages;
			if (images != null)
			{
				XElement xImages = XElement.Parse(images);
				List<string> listImageReturn = new List<string>();

				foreach(XElement item in xImages.Elements())
				{
					listImageReturn.Add(item.Value);
				}

				return Json(new
				{
					data = listImageReturn
				}, JsonRequestBehavior.AllowGet);
			}
			return Json(null, JsonRequestBehavior.AllowGet);
		}

		[HasCredential(PathID = "EDIT_INSTRUCTION")]
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
			var instruction = _db.Instructions.Find(contentId);
			instruction.MoreImages = images;
			_db.SaveChanges();
		}
	}
}
