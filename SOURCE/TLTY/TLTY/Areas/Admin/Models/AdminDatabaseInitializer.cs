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
			//Thêm đường dẫn tài khoản
			var CREATE_ACCOUNT = new Path()
			{
				ID = "CREATE_ACCOUNT",
				Name = "Thêm tài khoản"
			};
			context.Paths.Add(CREATE_ACCOUNT);

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

            //Thêm đường dẫn liên hệ
            var CREATE_CONTACT = new Path()
            {
                ID = "CREATE_CONTACT",
                Name = "Thêm liên hệ"
            };
            context.Paths.Add(CREATE_CONTACT);

            var DELETE_CONTACT = new Path()
            {
                ID = "DELETE_CONTACT",
                Name = "Xóa liên hệ"
            };
            context.Paths.Add(DELETE_CONTACT);

            var EDIT_CONTACT = new Path()
            {
                ID = "EDIT_CONTACT",
                Name = "Sửa liên hệ"
            };
            context.Paths.Add(EDIT_CONTACT);

            var VIEW_CONTACT = new Path()
            {
                ID = "VIEW_CONTACT",
                Name = "Xem liên hệ"
            };
            context.Paths.Add(VIEW_CONTACT);

            var DETAILS_CONTACT = new Path()
            {
                ID = "DETAILS_ACCOUNT",
                Name = "Xem chi tiết liên hệ"
            };
            context.Paths.Add(DETAILS_CONTACT);

            //Thêm đường dẫn bảng giá
            var CREATE_TICKER = new Path()
            {
                ID = "CREATE_TICKER",
                Name = "Thêm bảng giá"
            };
            context.Paths.Add(CREATE_TICKER);

            var DELETE_TICKER = new Path()
            {
                ID = "DELETE_TICKER",
                Name = "Xóa bảng giá"
            };
            context.Paths.Add(DELETE_TICKER);

            var EDIT_TICKER = new Path()
            {
                ID = "EDIT_TICKER",
                Name = "Sửa bảng giá"
            };
            context.Paths.Add(EDIT_TICKER);

            var VIEW_TICKER = new Path()
            {
                ID = "VIEW_TICKER",
                Name = "Xem bảng giá"
            };
            context.Paths.Add(VIEW_TICKER);

            var DETAILS_TICKER = new Path()
            {
                ID = "DETAILS_TICKER",
                Name = "Xem chi tiết bảng giá"
            };
            context.Paths.Add(DETAILS_TICKER);

            //Thêm đường dẫn trình ảnh
            var CREATE_SLIDER = new Path()
            {
                ID = "CREATE_SLIDER",
                Name = "Thêm trình ảnh"
            };
            context.Paths.Add(CREATE_SLIDER);

            var DELETE_SLIDER = new Path()
            {
                ID = "DELETE_SLIDER",
                Name = "Xóa trình ảnh"
            };
            context.Paths.Add(DELETE_SLIDER);

            var EDIT_SLIDER = new Path()
            {
                ID = "EDIT_SLIDER",
                Name = "Sửa trình ảnh"
            };
            context.Paths.Add(EDIT_SLIDER);

            var VIEW_SLIDER = new Path()
            {
                ID = "VIEW_SLIDER",
                Name = "Xem trình ảnh"
            };
            context.Paths.Add(VIEW_SLIDER);

            var DETAILS_SLIDER = new Path()
            {
                ID = "DETAILS_SLIDER",
                Name = "Xem chi tiết trình ảnh"
            };
            context.Paths.Add(DETAILS_SLIDER);

            //Thêm đường dẫn phản hồi

            var DELETE_REQUEST = new Path()
            {
                ID = "DELETE_REQUEST",
                Name = "Xóa phản hồi"
            };
            context.Paths.Add(DELETE_SLIDER);


            var DETAILS_REQUEST = new Path()
            {
                ID = "DETAILS_REQUEST",
                Name = "Xem chi tiết phản hồi"
            };
            context.Paths.Add(DETAILS_REQUEST);

            //Thêm đường dẫn giới thiệu
            var CREATE_INTRUCTION = new Path()
            {
                ID = "CREATE_INTRUCTION",
                Name = "Thêm giới thiệu"
            };
            context.Paths.Add(CREATE_INTRUCTION);

            var DELETE_INTRUCTION = new Path()
            {
                ID = "DELETE_INTRUCTION",
                Name = "Xóa giới thiệu"
            };
            context.Paths.Add(DELETE_INTRUCTION);

            var EDIT_INTRUCTION = new Path()
            {
                ID = "EDIT_INTRUCTION",
                Name = "Sửa giới thiệu"
            };
            context.Paths.Add(EDIT_INTRUCTION);

            var VIEW_INTRUCTION = new Path()
            {
                ID = "VIEW_INTRUCTION",
                Name = "Xem giới thiệu"
            };
            context.Paths.Add(VIEW_INTRUCTION);

            var DETAILS_INTRUCTION = new Path()
            {
                ID = "DETAILS_INTRUCTION",
                Name = "Xem chi tiết giới thiệu"
            };
            context.Paths.Add(DETAILS_INTRUCTION);

            //Thêm đường dẫn yêu cầu

            var DELETE_FEEDBACK = new Path()
            {
                ID = "DELETE_FEEDBACK",
                Name = "Xóa yêu cầu"
            };
            context.Paths.Add(DELETE_FEEDBACK);

            var DETAILS_FEEDBACK = new Path()
            {
                ID = "DELETE_FEEDBACK",
                Name = "Xem chi tiết yêu cầu"
            };
            context.Paths.Add(DELETE_FEEDBACK);

            //Thêm đường dẫn nội dung
            var CREATE_CONTENT = new Path()
            {
                ID = "CREATE_CONTENT",
                Name = "Thêm nội dung"
            };
            context.Paths.Add(CREATE_CONTENT);

            var DELETE_CONTENT = new Path()
            {
                ID = "DELETE_CONTENT",
                Name = "Xóa nội dung"
            };
            context.Paths.Add(DELETE_CONTENT);

            var EDIT_CONTENT = new Path()
            {
                ID = "EDIT_CONTENT",
                Name = "Sửa nội dung"
            };
            context.Paths.Add(EDIT_CONTENT);

            var VIEW_CONTENT = new Path()
            {
                ID = "VIEW_CONTENT",
                Name = "Xem nội dung"
            };
            context.Paths.Add(VIEW_CONTENT);

            var DETAILS_CONTENT = new Path()
            {
                ID = "DETAILS_CONTENT",
                Name = "Xem chi tiết nội dung"
            };
            context.Paths.Add(DETAILS_CONTENT);


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
				PathID = "CREATE_ACCOUNT"
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