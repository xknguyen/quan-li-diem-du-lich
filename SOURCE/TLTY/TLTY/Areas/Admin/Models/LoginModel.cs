using System.ComponentModel.DataAnnotations;

namespace TLTY.Areas.Admin.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Mời nhập tài khoản!")]
		public string UserName { set; get; }

		[Required(ErrorMessage = "Mời nhập mật khẩu!")]
		public string Password { set; get; }

		public bool RememberMe { set; get; }
	}
}