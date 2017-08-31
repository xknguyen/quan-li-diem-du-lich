using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EntityModel.EF;

namespace TLTY.Areas.Admin.Controllers
{
    public class PathsController : BaseController
    {
        private TLTYDBContext _db = new TLTYDBContext();

        // GET: Admin/Paths
        public ActionResult Index()
        {
            return View(_db.Paths.ToList());
        }

        // GET: Admin/Paths/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = _db.Paths.Find(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // GET: Admin/Paths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Paths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PathName,Description,Link,status")] Path path)
        {
			if (string.IsNullOrEmpty(path.PathName))
			{
				SetAlert("<i class='fa fa-times'></i> Tên đường dẫn trống!", "error");
			}
			else if (string.IsNullOrEmpty(path.Link))
			{
				SetAlert("<i class='fa fa-times'></i> Địa chỉ đường dẫn trống!", "error");
			}
			else
			{
				path.status = false;
				_db.Paths.Add(path);
				_db.SaveChanges();
				if (path.ID > 0)
				{
					SetAlert("<i class='fa fa-check'></i> Thêm đường dẫn thành công!", "success");
					return RedirectToAction("Index");
				}
				else
				{
					SetAlert("<i class='fa fa-times'></i> Thêm đường dẫn không thành công!", "error");
					return RedirectToAction("Index");
				}
			}

			return RedirectToAction("Index");
        }

        // GET: Admin/Paths/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = _db.Paths.Find(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // POST: Admin/Paths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PathName,Description,Link,status")] Path path)
        {
			if (string.IsNullOrEmpty(path.PathName))
			{
				SetAlert("<i class='fa fa-times'></i> Tên đường dẫn trống!", "error");
			}
			else if (string.IsNullOrEmpty(path.Link))
			{
				SetAlert("<i class='fa fa-times'></i> Địa chỉ đường dẫn trống!", "error");
			}
			else
			{
				_db.Entry(path).State = EntityState.Modified;
				_db.SaveChanges();
				if (path.ID > 0)
				{
					SetAlert("<i class='fa fa-check'></i> Sửa đường dẫn thành công!", "success");
					return RedirectToAction("Index");
				}
				else
				{
					SetAlert("<i class='fa fa-times'></i> Sửa đường dẫn không thành công!", "error");
					return RedirectToAction("Index");
				}
			}

			return RedirectToAction("Index");
        }

        // GET: Admin/Paths/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = _db.Paths.Find(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // POST: Admin/Paths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Path path = _db.Paths.Find(id);
            _db.Paths.Remove(path);
            _db.SaveChanges();
			if (path.ID > 0)
			{
				SetAlert("<i class='fa fa-check'></i> Xóa đường dẫn thành công!", "success");
				return RedirectToAction("Index");
			}
			else
			{
				SetAlert("<i class='fa fa-times'></i> Xóa đường dẫn không thành công!", "error");
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

		[HttpPost]
		public JsonResult ChangeStatus(long id)
		{
			var path = _db.Paths.Find(id);
			path.status = !path.status;
			_db.SaveChanges();
			return Json(new
			{
				status = path.status
			});
		}
    }
}
