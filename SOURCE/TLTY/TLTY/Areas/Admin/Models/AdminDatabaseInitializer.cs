using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EntityModel.EF;

namespace TLTY.Areas.Admin.Models
{
	public class AdminDatabaseInitializer : DropCreateDatabaseIfModelChanges<TLTYDBContext>
	{
		protected override void Seed(TLTYDBContext context)
		{
			//Thêm đường dẫn
			var ADD_ACCOUNT = new Path()
			{
				ID = "ADD_ACCOUNT",
				Name = "Thêm tài khoản"
			};
			context.Paths.Add(ADD_ACCOUNT);

			var DELETE_ACCOUNT = new Path()
			{
				ID = "DELETE_ACCOUNT",
				Name = "Xóa tài khoản"
			};
			context.Paths.Add(DELETE_ACCOUNT);

			var EDIT_ACCOUNT = new Path()
			{
				ID = "EDIT_ACCOUNT",
				Name = "Sửa tài khoản"
			};
			context.Paths.Add(EDIT_ACCOUNT);

			var VIEW_ACCOUNT = new Path()
			{
				ID = "VIEW_ACCOUNT",
				Name = "Xem tài khoản"
			};
			context.Paths.Add(VIEW_ACCOUNT);

			var DETAILS_ACCOUNT = new Path()
			{
				ID = "DETAILS_ACCOUNT",
				Name = "Xem chi tiết tài khoản"
			};
			context.Paths.Add(DETAILS_ACCOUNT);

			var CHANGE_ACCOUNT = new Path()
			{
				ID = "CHANGE_ACCOUNT",
				Name = "Thay đổi mật khẩu"
			};
			context.Paths.Add(CHANGE_ACCOUNT);

			

			//Thêm nhóm

			var ADMIN = new AccountGroup()
			{
				ID = "ADMIN",
				Name = "Quản trị"
			};

			context.AccountGroups.Add(ADMIN);

			var MEMBER = new AccountGroup()
			{
				ID = "MEMBER",
				Name = "Thành viên"
			};

			context.AccountGroups.Add(MEMBER);

			var MOD = new AccountGroup()
			{
				ID = "MOD",
				Name = "Điều hành"
			};

			context.AccountGroups.Add(MOD);

			//Thêm nối nhóm với đường dẫn

			var ad_1 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "ADD_ACCOUNT"
			};

			context.GroupPaths.Add(ad_1);

			var ad_2 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "DELETE_ACCOUNT"
			};

			context.GroupPaths.Add(ad_2);

			var ad_3 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "EDIT_ACCOUNT"
			};

			context.GroupPaths.Add(ad_3);

			var ad_4 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "VIEW_ACCOUNT"
			};

			context.GroupPaths.Add(ad_4);

			var ad_5 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "DETAILS_ACCOUNT"
			};

			context.GroupPaths.Add(ad_5);

			var ad_6 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "CHANGE_ACCOUNT"
			};

			context.GroupPaths.Add(ad_6);

			//Thêm tài khoản
			var admin = new Account()
			{
				UserName = "admin",
				Password = "e00cf25ad42683b3df678c61f42c6bda",
				FirstName = "Vinh",
				LastName = "Sang Khánh",
				Avatar = "/DATA/images/Avatar/10l.jpg",
				Email = "khanhvinhit@gmail.com",
				Birthday = DateTime.Parse("1/1/1995"),
				CreateDate = DateTime.Now.Date,
				AccountGroupID = "ADMIN",
				Address = "Đà Lạt",
				Phone = "01634141300",
				Status = true

			};
			context.Accounts.Add(admin);

			context.SaveChanges();
		}
	}
}