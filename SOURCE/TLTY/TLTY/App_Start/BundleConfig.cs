using System.Web;
using System.Web.Optimization;

namespace TLTY
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));
				//"~/Content/ClientTheme/js/jquery-2.0.3.min.js"
			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Content/ClientTheme/js/bootstrap.min.js",
						"~/Scripts/Alert.js",
						"~/Scripts/jquery.nicescroll.min.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/ClientTheme/css/bootstrap.css",
					  "~/Content/ClientTheme/css/icon.css",
					   "~/Content/AdminTheme/vendor/font-awesome/css/font-awesome.min.css"));

			//admin
			bundles.Add(new StyleBundle("~/Content/Admin/css").Include(
					  "~/Content/AdminTheme/vendor/bootstrap/css/bootstrap.min.css",
					  "~/Content/AdminTheme/vendor/metisMenu/metisMenu.min.css",
					  "~/Content/AdminTheme/vendor/datatables-plugins/dataTables.bootstrap.css",
					  "~/Content/AdminTheme/vendor/datatables-responsive/dataTables.responsive.css",
					  "~/Content/AdminTheme/vendor/font-awesome/css/font-awesome.min.css",
					  "~/Content/AdminTheme/dist/css/sb-admin-2.css",
					   "~/Content/AdminTheme/dist/css/vinhstyle.css"
					  ));

			bundles.Add(new ScriptBundle("~/bundles/Admin/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/Admin/jquery").Include(
						"~/Scripts/jquery-{version}.js",
						"~/Content/AdminTheme/vendor/jquery/jquery.min.js",
						"~/Content/AdminTheme/vendor/bootstrap/js/bootstrap.min.js",
					  "~/Content/AdminTheme/vendor/metisMenu/metisMenu.min.js",
					  "~/Content/AdminTheme/vendor/datatables/js/jquery.dataTables.min.js",
					  "~/Content/AdminTheme/vendor/datatables-plugins/dataTables.bootstrap.min.js",
					  "~/Content/AdminTheme/vendor/datatables-responsive/dataTables.responsive.js",
					  "~/Content/AdminTheme/dist/js/sb-admin-2.js"));

			bundles.Add(new ScriptBundle("~/bundles/Admin/bootstrap").Include(
						"~/Scripts/Alert.js",
						"~/Content/AdminTheme/js/Mayin.js",
						"~/Content/AdminTheme/js/create-modal.js",
						"~/Content/AdminTheme/js/detail-modal.js",
						"~/Content/AdminTheme/js/change-modal.js",
						"~/Content/AdminTheme/js/edit-modal.js",
						"~/Content/AdminTheme/js/delete-modal.js",
						"~/Content/AdminTheme/js/ChangeImages.js",
						"~/Content/AdminTheme/js/Messenger.js",
						"~/Content/AdminTheme/js/Controller/FeedbackMessenger.js",
							  "~/Scripts/jquery.nicescroll.min.js"
						));

			//BundleTable.EnableOptimizations = true;
		}
	}
}
