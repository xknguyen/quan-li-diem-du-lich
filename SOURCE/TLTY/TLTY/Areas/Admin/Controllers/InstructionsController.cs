using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using EntityModel.EF;

namespace TLTY.Areas.Admin.Controllers
{
    public class InstructionsController : Controller
    {
        private TLTYDBContext db = new TLTYDBContext();

        // GET: Admin/Instructions
        public ActionResult Index()
        {
            var instructions = db.Instructions.Include(i => i.Account);
            return View(instructions.ToList());
        }

        // GET: Admin/Instructions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instruction instruction = db.Instructions.Find(id);
            if (instruction == null)
            {
                return HttpNotFound();
            }
            return View(instruction);
        }

        // GET: Admin/Instructions/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName");
            return View();
        }

        // POST: Admin/Instructions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CreateDate,AccountID,Status,Detail,Images,MoreImages")] Instruction instruction)
        {
            if (ModelState.IsValid)
            {
                db.Instructions.Add(instruction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName", instruction.AccountID);
            return View(instruction);
        }

        // GET: Admin/Instructions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instruction instruction = db.Instructions.Find(id);
            if (instruction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName", instruction.AccountID);
            return View(instruction);
        }

        // POST: Admin/Instructions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CreateDate,AccountID,Status,Detail,Images,MoreImages")] Instruction instruction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instruction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "UserName", instruction.AccountID);
            return View(instruction);
        }

        // GET: Admin/Instructions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instruction instruction = db.Instructions.Find(id);
            if (instruction == null)
            {
                return HttpNotFound();
            }
            return View(instruction);
        }

        // POST: Admin/Instructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Instruction instruction = db.Instructions.Find(id);
            db.Instructions.Remove(instruction);
            db.SaveChanges();
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

		public string ChangeImage(int id, string picture)
		{
			if (id < 0)
			{
				return "Mã không tồn tại";
			}
			else
			{
				Instruction p = db.Instructions.Find(id);
				if (p == null)
				{
					return "Mã sai";
				}
				else
				{
					p.Images = picture;
					db.SaveChanges();
					return "";
				}
			}
		}

		[HttpPost]
		public JsonResult ChangeStatus(long id)
		{
			var instruct = db.Instructions.Find(id);
			instruct.Status = !instruct.Status;
			db.SaveChanges();
			return Json(new
			{

				status = instruct.Status
			});
		}

		public JsonResult LoadImages(long id)
		{
			var instruct = db.Instructions.Find(id);
			var images = instruct.MoreImages;
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


		public void UpdateImages(long productId, string images)
		{
			var product = db.Instructions.Find(productId);
			product.MoreImages = images;
			db.SaveChanges();
		}


    }
}
