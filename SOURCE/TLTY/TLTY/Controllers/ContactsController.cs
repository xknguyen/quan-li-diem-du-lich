using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityModel.EF;

namespace TLTY.Controllers
{
    public class ContactsController : Controller
    {
		TLTYDBContext _db = new TLTYDBContext();

        // GET: Contacts
        public ActionResult Index()
        {
			var model = _db.Contacts.Where(x => x.Status == true).OrderByDescending(x=>x.CreateDate).Take(1).ToList();
			return View(model);
        }

        [HttpPost]
        public JsonResult Feedback(string name, string phone, string email, string detail)
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
                        var feedback = new Feedback();
                        feedback.Name = name;
                        feedback.Email = email;
                        feedback.Phone = phone;
                        feedback.Description = detail;
                        feedback.Status = false;
                        feedback.CreateDate = DateTime.Now.Date;
                        _db.Feedbacks.Add(feedback);
                        _db.SaveChanges();
                        if (feedback.ID > 0)
                        {
                            return Json(new
                            {
                                msg = " Gửi yêu cầu thành công, chúng tôi sẽ liên lạc sớm nhất!.",
                                status = true
                            });
                            //Send mail
                        }
                        else
                        {
                            return Json(new
                            {
                                msg = " Gửi yêu cầu không thành công!.",
                                status = false
                            });
                        }
                    }
                }
            }
        }
    }
}