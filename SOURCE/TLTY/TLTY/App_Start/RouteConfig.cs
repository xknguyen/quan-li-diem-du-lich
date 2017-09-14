using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TLTY
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
			name: "Liên hệ",
			url: "lien-he",
			defaults: new { controller = "Contacts", action = "Index", id = UrlParameter.Optional },
			namespaces: new[] { "TLTY.Controllers" }
		  );

			routes.MapRoute(
			name: "Bảng giá",
			url: "bang-gia",
			defaults: new { controller = "Tickers", action = "Index", id = UrlParameter.Optional },
			namespaces: new[] { "TLTY.Controllers" }
		  );

            routes.MapRoute(
            name: "Chi tiết tin tức",
            url: "tin-tuc/chi-tiet/{metatitle}-{id}",
            defaults: new { controller = "News", action = "Details", id = UrlParameter.Optional },
            namespaces: new[] { "TLTY.Controllers" }
          );

			routes.MapRoute(
			name: "Tin tức",
			url: "tin-tuc",
			defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional },
			namespaces: new[] { "TLTY.Controllers" }
		  );

			routes.MapRoute(
			name: "Chi tiết Dịch vụ",
			url: "dich-vu/chi-tiet/{metatitle}-{id}",
			defaults: new { controller = "Express", action = "Details", id = UrlParameter.Optional },
			namespaces: new[] { "TLTY.Controllers" }
		  );

			routes.MapRoute(
			name: "Dịch vụ",
			url: "dich-vu",
			defaults: new { controller = "Express", action = "Index", id = UrlParameter.Optional },
			namespaces: new[] { "TLTY.Controllers" }
		  );

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				namespaces: new[] { "TLTY.Controllers" }
			);
		}
	}
}
