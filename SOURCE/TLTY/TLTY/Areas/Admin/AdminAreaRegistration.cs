using System.Web.Mvc;

namespace TLTY.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
			context.MapRoute(
				"chinh-sua",
				"Admin/xem-thong-tin/{id}",
				new { action = "Details", controller = "Accounts", id = UrlParameter.Optional },
				new string[] { "TLTY.Areas.Admin.Controllers" }
			);
			context.MapRoute(
				"thay-mk",
				"Admin/thay-mat-khau/{user}-{id}",
				new { action = "ChangPassword", controller = "Accounts", id = UrlParameter.Optional },
				new string[] { "TLTY.Areas.Admin.Controllers" }
			);
			context.MapRoute(
				"dangxuat",
				"Admin/dang-xuat",
				new { action = "Logout", controller = "Login", id = UrlParameter.Optional },
				new string[] { "TLTY.Areas.Admin.Controllers" }
			);
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", controller ="Home", id = UrlParameter.Optional },
				new string[] { "TLTY.Areas.Admin.Controllers"}
            );
        }
    }
}