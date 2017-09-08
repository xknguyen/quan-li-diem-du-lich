using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EntityModel.EF;
using TLTY.Areas.Admin.Models;

namespace TLTY
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			BundleTable.EnableOptimizations = true;
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new AdminDatabaseInitializer());

		}
	}
}
