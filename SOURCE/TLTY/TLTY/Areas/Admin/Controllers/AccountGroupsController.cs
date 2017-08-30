using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EntityModel.EF;

namespace TLTY.Areas.Admin.Controllers
{
	public class AccountGroupsController : BaseController
	{
		private TLTYDBContext _db = new TLTYDBContext();

		// GET: Admin/AccountGroups
		public ActionResult Index()
		{
			var accountGroups = _db.AccountGroups.Include(a => a.Account);
			return View(accountGroups.ToList());
		}

		// GET: Admin/AccountGroups/Details/5
		public ActionResult Details(long? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			AccountGroup accountGroup = _db.AccountGroups.Find(id);
			if (accountGroup == null)
			{
				return HttpNotFound();
			}
			return View(accountGroup);
		}

		// GET: Admin/AccountGroups/Create
		public ActionResult Create()
		{
			ViewBag.AccountID = new SelectList(_db.Accounts, "ID", "UserName");
			ViewBag.GroupPathID = new SelectList(_db.GroupPaths, "ID", "Name");
			return View();
		}

		// POST: Admin/AccountGroups/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,GroupPathID,AccountID,Description,status")] AccountGroup accountGroup)
		{
			if (accountGroup.AccountID < 0)
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tài khoản trống!", "error");
			}
			if (accountGroup.GroupPathID < 0)
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Nhóm quyền trống!", "error");
			}
			else
			{
				accountGroup.status = false;
				_db.AccountGroups.Add(accountGroup);
				_db.SaveChanges();

				if (accountGroup.ID > 0)
				{
					SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Phân quyền cho tài khoản thành công.", "success");
					return RedirectToAction("Index");
				}
				else
				{
					SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Phân quyền cho tài khoản không thành công!", "error");
					return RedirectToAction("Index");
				}
			}
			ViewBag.AccountID = new SelectList(_db.Accounts, "ID", "UserName", accountGroup.AccountID);
			ViewBag.GroupPathID = new SelectList(_db.GroupPaths, "ID", "Name", accountGroup.GroupPathID);
			return RedirectToAction("Index");
		}

		// GET: Admin/AccountGroups/Edit/5
		public ActionResult Edit(long? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			AccountGroup accountGroup = _db.AccountGroups.Find(id);
			if (accountGroup == null)
			{
				return HttpNotFound();
			}
			ViewBag.AccountID = new SelectList(_db.Accounts, "ID", "UserName", accountGroup.AccountID);
			ViewBag.GroupPathID = new SelectList(_db.GroupPaths, "ID", "Name", accountGroup.GroupPathID);
			return View(accountGroup);
		}

		// POST: Admin/AccountGroups/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,GroupPathID,AccountID,Description,status")] AccountGroup accountGroup)
		{
			if (accountGroup.AccountID < 0)
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Tài khoản trống!", "error");
			}
			if (accountGroup.GroupPathID < 0)
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Nhóm quyền trống!", "error");
			}
			else
			{
				_db.Entry(accountGroup).State = EntityState.Modified;
				_db.SaveChanges();
				if (accountGroup.ID > 0)
				{
					SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Sửa phân quyền cho tài khoản thành công.", "success");
					return RedirectToAction("Index");
				}
				else
				{
					SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Sửa phân quyền cho tài khoản không thành công!", "error");
					return RedirectToAction("Index");
				}
			}
			ViewBag.AccountID = new SelectList(_db.Accounts, "ID", "UserName", accountGroup.AccountID);
			ViewBag.GroupPathID = new SelectList(_db.GroupPaths, "ID", "Name", accountGroup.GroupPathID);
			return View(accountGroup);
		}

		// GET: Admin/AccountGroups/Delete/5
		public ActionResult Delete(long? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			AccountGroup accountGroup = _db.AccountGroups.Find(id);
			if (accountGroup == null)
			{
				return HttpNotFound();
			}
			return View(accountGroup);
		}

		// POST: Admin/AccountGroups/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(long id)
		{
			AccountGroup accountGroup = _db.AccountGroups.Find(id);
			_db.AccountGroups.Remove(accountGroup);
			_db.SaveChanges();
			if (accountGroup.ID > 0)
			{
				SetAlert("<img src='/Data/images/ChucNang/ok.png' /> Xóa phân quyền cho tài khoản thành công.", "success");
				return RedirectToAction("Index");
			}
			else
			{
				SetAlert("<img src='/Data/images/ChucNang/del.png' height='20' width='20' /> Xóa phân quyền cho tài khoản không thành công!", "error");
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
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

			var user = _db.AccountGroups.Find(id);
			user.status = !user.status;
			_db.SaveChanges();
			return Json(new
			{
				status = user.status
			});
		}
	}
}
