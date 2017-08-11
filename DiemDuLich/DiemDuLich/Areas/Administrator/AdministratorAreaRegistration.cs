using System.Web.Mvc;

namespace DiemDuLich.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrator_default",
                "Administrator/{controller}/{action}/{id}",
				new { action = "Index", controller = "Home", id = UrlParameter.Optional },
				new string[] { "DiemDuLich.Areas.Administrator.Controllers" }
            );
        }
    }
}