using System.Web.Mvc;

namespace DiemDL.Areas.Administrator
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
                new { action = "Index", Controller = "Home", id = UrlParameter.Optional },
				new string[] { "DiemDL.Areas.Administrator.Controllers"}
            );
        }
    }
}