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
				ID = "DETAILS_CONTACT",
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

			var editRequest = new Path()
			{
				ID = "EDIT_REQUEST",
				Name = "Xóa phản hồi"
			};
			context.Paths.Add(editRequest);

			var viewRequest = new Path()
			{
				ID = "VIEW_REQUEST",
				Name = "Xem chi tiết phản hồi"
			};
			context.Paths.Add(viewRequest);

			var detailsRequest = new Path()
			{
				ID = "DETAILS_REQUEST",
				Name = "Xem chi tiết phản hồi"
			};
			context.Paths.Add(detailsRequest);

			//Thêm đường dẫn giới thiệu
			var createinstruction = new Path()
			{
				ID = "CREATE_INSTRUCTION",
				Name = "Thêm giới thiệu"
			};
			context.Paths.Add(createinstruction);

			var deleteinstruction = new Path()
			{
				ID = "DELETE_INSTRUCTION",
				Name = "Xóa giới thiệu"
			};
			context.Paths.Add(deleteinstruction);

			var editinstruction = new Path()
			{
				ID = "EDIT_INSTRUCTION",
				Name = "Sửa giới thiệu"
			};
			context.Paths.Add(editinstruction);

			var viewinstruction = new Path()
			{
				ID = "VIEW_INSTRUCTION",
				Name = "Xem giới thiệu"
			};
			context.Paths.Add(viewinstruction);

			var detailsinstruction = new Path()
			{
				ID = "DETAILS_INSTRUCTION",
				Name = "Xem chi tiết giới thiệu"
			};
			context.Paths.Add(detailsinstruction);

			//Thêm đường dẫn yêu cầu
			var deleteFeedback = new Path()
			{
				ID = "DELETE_FEEDBACK",
				Name = "Xóa yêu cầu"
			};
			context.Paths.Add(deleteFeedback);

			var editFeedback = new Path()
			{
				ID = "EDIT_FEEDBACK",
				Name = "Xem chi tiết yêu cầu"
			};
			context.Paths.Add(editFeedback);

			var viewFeedback = new Path()
			{
				ID = "VIEW_FEEDBACK",
				Name = "Xem chi tiết yêu cầu"
			};
			context.Paths.Add(viewFeedback);

			var detailsFeedback = new Path()
			{
				ID = "DETAILS_FEEDBACK",
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

			var servicesGroup = new AccountGroup()
			{
				ID = "SERVICES",
				Name = "Chăm sóc khách hàng"
			};
			context.AccountGroups.Add(servicesGroup);

			var modGroup = new AccountGroup()
			{
				ID = "MOD",
				Name = "Điều hành"
			};
			context.AccountGroups.Add(modGroup);

			//Thêm nối nhóm với đường dẫn cho tài khoản
			var mo3 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "EDIT_ACCOUNT"
			};
			context.GroupPaths.Add(mo3);

			var mo5 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DETAILS_ACCOUNT"
			};
			context.GroupPaths.Add(mo5);

			var mo6 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "CHANGE_ACCOUNT"
			};
			context.GroupPaths.Add(mo6);

			//Thêm nối nhóm với đường dẫn cho lien hệ
			var mo7 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "CREATE_CONTACT"
			};
			context.GroupPaths.Add(mo7);

			var mo8 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DELETE_CONTACT"
			};
			context.GroupPaths.Add(mo8);

			var mo9 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "EDIT_CONTACT"
			};
			context.GroupPaths.Add(mo9);

			var mo10 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "VIEW_CONTACT"
			};
			context.GroupPaths.Add(mo10);

			var mo11 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DETAILS_CONTACT"
			};

			//Thêm nối nhóm với đường dẫn cho bảng giá
			context.GroupPaths.Add(mo11);

			var mo12 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "CREATE_TICKER"
			};
			context.GroupPaths.Add(mo12);

			var mo13 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DELETE_TICKER"
			};
			context.GroupPaths.Add(mo13);

			var mo14 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "EDIT_TICKER"
			};
			context.GroupPaths.Add(mo14);

			var mo15 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "VIEW_TICKER"
			};
			context.GroupPaths.Add(mo15);

			var mo16 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DETAILS_TICKER"
			};
			context.GroupPaths.Add(mo16);

			var mo17 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "CREATE_SLIDER"
			};
			context.GroupPaths.Add(mo17);

			var mo18 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DELETE_SLIDER"
			};
			context.GroupPaths.Add(mo18);

			var mo19 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "EDIT_SLIDER"
			};
			context.GroupPaths.Add(mo19);

			var mo20 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "VIEW_SLIDER"
			};
			context.GroupPaths.Add(mo20);

			var mo21 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DETAILS_SLIDER"
			};
			context.GroupPaths.Add(mo21);

			var mo22 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DELETE_REQUEST"
			};
			context.GroupPaths.Add(mo22);

			var mo23 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "EDIT_REQUEST"
			};
			context.GroupPaths.Add(mo23);

			var mo24 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "VIEW_REQUEST"
			};
			context.GroupPaths.Add(mo24);

			var mo25 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DETAILS_REQUEST"
			};
			context.GroupPaths.Add(mo25);

			var mo26 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "CREATE_INSTRUCTION"
			};
			context.GroupPaths.Add(mo26);

			var mo27 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DELETE_INSTRUCTION"
			};
			context.GroupPaths.Add(mo27);

			var mo28 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "EDIT_INSTRUCTION"
			};
			context.GroupPaths.Add(mo28);

			var mo29 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "VIEW_INSTRUCTION"
			};
			context.GroupPaths.Add(mo29);

			var mo30 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DETAILS_INSTRUCTION"
			};
			context.GroupPaths.Add(mo30);

			var mo31 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DELETE_FEEDBACK"
			};
			context.GroupPaths.Add(mo31);

			var mo32 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "EDIT_FEEDBACK"
			};
			context.GroupPaths.Add(mo32);

			var mo33 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "VIEW_FEEDBACK"
			};
			context.GroupPaths.Add(mo33);

			var mo34 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DETAILS_FEEDBACK"
			};
			context.GroupPaths.Add(mo34);

			var mo35 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "CREATE_CONTENT"
			};
			context.GroupPaths.Add(mo35);

			var mo36 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DELETE_CONTENT"
			};
			context.GroupPaths.Add(mo36);

			var mo37 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "EDIT_CONTENT"
			};
			context.GroupPaths.Add(mo37);

			var mo38 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "VIEW_CONTENT"
			};
			context.GroupPaths.Add(mo38);

			var mo39 = new GroupPath()
			{
				AccountGroupID = "MOD",
				PathID = "DETAILS_CONTENT"
			};
			context.GroupPaths.Add(mo39);

			//Quyên cho nhóm SER
			//Thêm nối nhóm với đường dẫn cho liên hệ
			var se1 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "CREATE_CONTACT"
			};
			context.GroupPaths.Add(se1);

			var se2 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "DELETE_CONTACT"
			};
			context.GroupPaths.Add(se2);

			var se3 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "EDIT_CONTACT"
			};
			context.GroupPaths.Add(se3);

			var se4 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "VIEW_CONTACT"
			};
			context.GroupPaths.Add(se4);

			var se5 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "DETAILS_CONTACT"
			};
			context.GroupPaths.Add(se5);

			//Phản hồi
			var se6 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "DELETE_REQUEST"
			};
			context.GroupPaths.Add(se6);

			var se7 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "EDIT_REQUEST"
			};
			context.GroupPaths.Add(se7);

			var se8 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "VIEW_REQUEST"
			};
			context.GroupPaths.Add(se8);

			var se9 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "DETAILS_REQUEST"
			};
			context.GroupPaths.Add(se9);

			//Yêu cầu
			var se10 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "DELETE_FEEDBACK"
			};
			context.GroupPaths.Add(se10);

			var se11 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "EDIT_FEEDBACK"
			};
			context.GroupPaths.Add(se11);

			var se12 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "VIEW_FEEDBACK"
			};
			context.GroupPaths.Add(se12);

			var se13 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "DETAILS_FEEDBACK"
			};
			context.GroupPaths.Add(se13);

			var se14 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "EDIT_ACCOUNT"
			};
			context.GroupPaths.Add(se14);

			var se15 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "DETAILS_ACCOUNT"
			};
			context.GroupPaths.Add(se15);

			var se16 = new GroupPath()
			{
				AccountGroupID = "SERVICES",
				PathID = "CHANGE_ACCOUNT"
			};
			context.GroupPaths.Add(se16);

			//Quyền cho nhân viên
			var me1 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "CREATE_INSTRUCTION"
			};
			context.GroupPaths.Add(me1);

			var me2 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "DELETE_INSTRUCTION"
			};
			context.GroupPaths.Add(me2);

			var me3 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "EDIT_INSTRUCTION"
			};
			context.GroupPaths.Add(me3);

			var me4 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "VIEW_INSTRUCTION"
			};
			context.GroupPaths.Add(me4);

			var me5 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "DETAILS_INSTRUCTION"
			};
			context.GroupPaths.Add(me5);

			var me6 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "CREATE_CONTENT"
			};
			context.GroupPaths.Add(me6);

			var me7 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "DELETE_CONTENT"
			};
			context.GroupPaths.Add(me7);

			var me8 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "EDIT_CONTENT"
			};
			context.GroupPaths.Add(me8);

			var me9 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "VIEW_CONTENT"
			};
			context.GroupPaths.Add(me9);

			var me10 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "DETAILS_CONTENT"
			};
			context.GroupPaths.Add(me10);

			//Thêm nối nhóm với đường dẫn cho bảng giá
			var me11 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "CREATE_TICKER"
			};
			context.GroupPaths.Add(me11);

			var me12 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "DELETE_TICKER"
			};
			context.GroupPaths.Add(me12);

			var me13 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "EDIT_TICKER"
			};
			context.GroupPaths.Add(me13);

			var me14 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "VIEW_TICKER"
			};
			context.GroupPaths.Add(me14);

			var me15 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "DETAILS_TICKER"
			};
			context.GroupPaths.Add(me15);

			var me16 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "CREATE_SLIDER"
			};
			context.GroupPaths.Add(me16);

			var me17 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "DELETE_SLIDER"
			};
			context.GroupPaths.Add(me17);

			var me18 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "EDIT_SLIDER"
			};
			context.GroupPaths.Add(me18);

			var me19 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "VIEW_SLIDER"
			};
			context.GroupPaths.Add(me19);

			var me20 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "DETAILS_SLIDER"
			};
			context.GroupPaths.Add(me20);

			var me21 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "EDIT_ACCOUNT"
			};
			context.GroupPaths.Add(me21);

            var me22 = new GroupPath()
            {
                AccountGroupID = "MEMBER",
                PathID = "DETAILS_ACCOUNT"
            };
			context.GroupPaths.Add(me22);

			var me23 = new GroupPath()
			{
				AccountGroupID = "MEMBER",
				PathID = "CHANGE_ACCOUNT"
			};
			context.GroupPaths.Add(me23);

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