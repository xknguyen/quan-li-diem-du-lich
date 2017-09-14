using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TLTY.Areas.Admin.Models
{
	public class HasCredentialAttribute : AuthorizeAttribute
	{
		public string PathID { set; get; }

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			var session = (UserLogin)HttpContext.Current.Session[Constants.USER_SESSION];
			if (session == null)
			{
				return false;
			}

			List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.UserName);

			if (privilegeLevels.Contains(this.PathID) || session.AccountGroupID == Constants.ADMIN_GROUP)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			filterContext.Result = new RedirectResult("~/Admin/Home/NotificationAuthorize");
			//filterContext.Redirect("~/Admin/Login");
		}

		private List<string> GetCredentialByLoggedInUser(string userName)
		{
			var credentials = (List<string>)HttpContext.Current.Session[Constants.SESSION_CREDENTIALS];
			return credentials;
		}
	}
}