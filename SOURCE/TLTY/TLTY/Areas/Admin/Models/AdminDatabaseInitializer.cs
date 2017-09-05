using System;
using System.Data.Entity;
using EntityModel.EF;

namespace TLTY.Areas.Admin.Models
{
	public class AdminDatabaseInitializer : DropCreateDatabaseIfModelChanges<TLTYDBContext>
	{
		protected override void Seed(TLTYDBContext context)
		{
			//Thêm đường dẫn tài khoản
			var createAccount = new Path()
			{
				ID = "CREATE_ACCOUNT",
				Name = "Thêm tài khoản"
			};
			context.Paths.Add(createAccount);

			var deleteAccount = new Path()
			{
				ID = "DELETE_ACCOUNT",
				Name = "Xóa tài khoản"
			};
			context.Paths.Add(deleteAccount);

			var editAccount = new Path()
			{
				ID = "EDIT_ACCOUNT",
				Name = "Sửa tài khoản"
			};
			context.Paths.Add(editAccount);

			var viewAccount = new Path()
			{
				ID = "VIEW_ACCOUNT",
				Name = "Xem tài khoản"
			};
			context.Paths.Add(viewAccount);

			var detailsAccount = new Path()
			{
				ID = "DETAILS_ACCOUNT",
				Name = "Xem chi tiết tài khoản"
			};
			context.Paths.Add(detailsAccount);

			var changeAccount = new Path()
			{
				ID = "CHANGE_ACCOUNT",
				Name = "Thay đổi mật khẩu"
			};
			context.Paths.Add(changeAccount);

            //Thêm đường dẫn liên hệ
            var createContact = new Path()
            {
                ID = "CREATE_CONTACT",
                Name = "Thêm liên hệ"
            };
            context.Paths.Add(createContact);

            var deleteContact = new Path()
            {
                ID = "DELETE_CONTACT",
                Name = "Xóa liên hệ"
            };
            context.Paths.Add(deleteContact);

            var editContact = new Path()
            {
                ID = "EDIT_CONTACT",
                Name = "Sửa liên hệ"
            };
            context.Paths.Add(editContact);

            var viewContact = new Path()
            {
                ID = "VIEW_CONTACT",
                Name = "Xem liên hệ"
            };
            context.Paths.Add(viewContact);

            var detailsContact = new Path()
            {
                ID = "DETAILS_ACCOUNT",
                Name = "Xem chi tiết liên hệ"
            };
            context.Paths.Add(detailsContact);

            //Thêm đường dẫn bảng giá
            var createTicker = new Path()
            {
                ID = "CREATE_TICKER",
                Name = "Thêm bảng giá"
            };
            context.Paths.Add(createTicker);

            var deleteTicker = new Path()
            {
                ID = "DELETE_TICKER",
                Name = "Xóa bảng giá"
            };
            context.Paths.Add(deleteTicker);

            var editTicker = new Path()
            {
                ID = "EDIT_TICKER",
                Name = "Sửa bảng giá"
            };
            context.Paths.Add(editTicker);

            var viewTicker = new Path()
            {
                ID = "VIEW_TICKER",
                Name = "Xem bảng giá"
            };
            context.Paths.Add(viewTicker);

            var detailsTicker = new Path()
            {
                ID = "DETAILS_TICKER",
                Name = "Xem chi tiết bảng giá"
            };
            context.Paths.Add(detailsTicker);

            //Thêm đường dẫn trình ảnh
            var createSlider = new Path()
            {
                ID = "CREATE_SLIDER",
                Name = "Thêm trình ảnh"
            };
            context.Paths.Add(createSlider);

            var deleteSlider = new Path()
            {
                ID = "DELETE_SLIDER",
                Name = "Xóa trình ảnh"
            };
            context.Paths.Add(deleteSlider);

            var editSlider = new Path()
            {
                ID = "EDIT_SLIDER",
                Name = "Sửa trình ảnh"
            };
            context.Paths.Add(editSlider);

            var viewSlider = new Path()
            {
                ID = "VIEW_SLIDER",
                Name = "Xem trình ảnh"
            };
            context.Paths.Add(viewSlider);

            var detailsSlider = new Path()
            {
                ID = "DETAILS_SLIDER",
                Name = "Xem chi tiết trình ảnh"
            };
            context.Paths.Add(detailsSlider);

            //Thêm đường dẫn phản hồi

            var deleteRequest = new Path()
            {
                ID = "DELETE_REQUEST",
                Name = "Xóa phản hồi"
            };
			context.Paths.Add(deleteRequest);


            var detailsRequest = new Path()
            {
                ID = "DETAILS_REQUEST",
                Name = "Xem chi tiết phản hồi"
            };
            context.Paths.Add(detailsRequest);

            //Thêm đường dẫn giới thiệu
            var createIntruction = new Path()
            {
                ID = "CREATE_INTRUCTION",
                Name = "Thêm giới thiệu"
            };
            context.Paths.Add(createIntruction);

            var deleteIntruction = new Path()
            {
                ID = "DELETE_INTRUCTION",
                Name = "Xóa giới thiệu"
            };
            context.Paths.Add(deleteIntruction);

            var editIntruction = new Path()
            {
                ID = "EDIT_INTRUCTION",
                Name = "Sửa giới thiệu"
            };
            context.Paths.Add(editIntruction);

            var viewIntruction = new Path()
            {
                ID = "VIEW_INTRUCTION",
                Name = "Xem giới thiệu"
            };
            context.Paths.Add(viewIntruction);

            var detailsIntruction = new Path()
            {
                ID = "DETAILS_INTRUCTION",
                Name = "Xem chi tiết giới thiệu"
            };
            context.Paths.Add(detailsIntruction);

            //Thêm đường dẫn yêu cầu

            var deleteFeedback = new Path()
            {
                ID = "DELETE_FEEDBACK",
                Name = "Xóa yêu cầu"
            };
            context.Paths.Add(deleteFeedback);

            var detailsFeedback = new Path()
            {
                ID = "DELETE_FEEDBACK",
                Name = "Xem chi tiết yêu cầu"
            };
			context.Paths.Add(detailsFeedback);

            //Thêm đường dẫn nội dung
            var createContent = new Path()
            {
                ID = "CREATE_CONTENT",
                Name = "Thêm nội dung"
            };
            context.Paths.Add(createContent);

            var deleteContent = new Path()
            {
                ID = "DELETE_CONTENT",
                Name = "Xóa nội dung"
            };
            context.Paths.Add(deleteContent);

            var editContent = new Path()
            {
                ID = "EDIT_CONTENT",
                Name = "Sửa nội dung"
            };
            context.Paths.Add(editContent);

            var viewContent = new Path()
            {
                ID = "VIEW_CONTENT",
                Name = "Xem nội dung"
            };
            context.Paths.Add(viewContent);

            var detailsContent = new Path()
            {
                ID = "DETAILS_CONTENT",
                Name = "Xem chi tiết nội dung"
            };
            context.Paths.Add(detailsContent);


			//Thêm nhóm

			var adminGroup = new AccountGroup()
			{
				ID = "ADMIN",
				Name = "Quản trị"
			};

			context.AccountGroups.Add(adminGroup);

			var memberGroup = new AccountGroup()
			{
				ID = "MEMBER",
				Name = "Thành viên"
			};

			context.AccountGroups.Add(memberGroup);

			var modGroup = new AccountGroup()
			{
				ID = "MOD",
				Name = "Điều hành"
			};

			context.AccountGroups.Add(modGroup);

			//Thêm nối nhóm với đường dẫn

			var ad1 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "CREATE_ACCOUNT"
			};

			context.GroupPaths.Add(ad1);

			var ad2 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "DELETE_ACCOUNT"
			};

			context.GroupPaths.Add(ad2);

			var ad3 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "EDIT_ACCOUNT"
			};

			context.GroupPaths.Add(ad3);

			var ad4 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "VIEW_ACCOUNT"
			};

			context.GroupPaths.Add(ad4);

			var ad5 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "DETAILS_ACCOUNT"
			};

			context.GroupPaths.Add(ad5);

			var ad6 = new GroupPath()
			{
				AccountGroupID = "ADMIN",
				PathID = "CHANGE_ACCOUNT"
			};

			context.GroupPaths.Add(ad6);

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