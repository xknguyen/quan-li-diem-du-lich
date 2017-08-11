using System.Web.Mvc;

namespace DiemDuLich.Areas.Clienttheme
{
    public class ClientthemeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Clienttheme";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Clienttheme_default",
                "Clienttheme/{controller}/{action}/{id}",
				new { action = "Index", controller = "Home", id = UrlParameter.Optional },
				new string[] { "DiemDuLich.Areas.Clienttheme.Controllers"}
            );
        }
    }
}