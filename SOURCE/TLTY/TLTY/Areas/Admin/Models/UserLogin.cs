using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLTY.Areas.Admin.Models
{
	[Serializable]
	public class UserLogin
	{
		public long AccountID { set; get; }
		public string UserName { set; get; }
		public string FristName { set; get; }
		public string LastName { set; get; }
		public string Phone { set; get; }
		public string Email { set; get; }
		public string Address { set; get; }
		public string Avatar { set; get; }
		public string AccountGroupID { set; get; }
	}
}