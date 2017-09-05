USE [master]
GO
/****** Object:  Database [TLTY]    Script Date: 9/5/2017 10:40:30 AM ******/
CREATE DATABASE [TLTY]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TLTY', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TLTY.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TLTY_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TLTY_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TLTY] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TLTY].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TLTY] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TLTY] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TLTY] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TLTY] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TLTY] SET ARITHABORT OFF 
GO
ALTER DATABASE [TLTY] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TLTY] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TLTY] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TLTY] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TLTY] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TLTY] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TLTY] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TLTY] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TLTY] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TLTY] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TLTY] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TLTY] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TLTY] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TLTY] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TLTY] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TLTY] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TLTY] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TLTY] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TLTY] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TLTY] SET  MULTI_USER 
GO
ALTER DATABASE [TLTY] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TLTY] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TLTY] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TLTY] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TLTY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[AccountGroupID] [nvarchar](50) NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](250) NULL,
	[Birthday] [date] NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[Avatar] [nvarchar](250) NULL,
	[Address] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountGroup]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountGroup](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_AccountGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Status] [bit] NOT NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Content]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[CreateDate] [datetime] NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Status] [bit] NOT NULL,
	[ViewCount] [int] NULL,
	[Detail] [ntext] NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Images] [nvarchar](250) NULL,
	[MoreImages] [xml] NULL,
	[Category] [bit] NOT NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[Description] [ntext] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupPath]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPath](
	[AccountGroupID] [nvarchar](50) NOT NULL,
	[PathID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GroupPath] PRIMARY KEY CLUSTERED 
(
	[AccountGroupID] ASC,
	[PathID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Instruction]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instruction](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Status] [bit] NOT NULL,
	[Detail] [ntext] NOT NULL,
	[Images] [nvarchar](250) NULL,
	[MoreImages] [xml] NULL,
 CONSTRAINT [PK_Instruction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Path]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Path](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_Path] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Request]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[MoreImage] [xml] NULL,
	[ContentID] [bigint] NULL,
	[Detail] [ntext] NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slider]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[DisplayOrder] [int] NOT NULL,
	[Link] [nvarchar](250) NULL,
	[ContentID] [bigint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Status] [bit] NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticker]    Script Date: 9/5/2017 10:40:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticker](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[CreateDate] [datetime] NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Status] [bit] NOT NULL,
	[Type] [bit] NULL,
	[Quantity] [bigint] NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Ticker] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (1, N'admin', N'e00cf25ad42683b3df678c61f42c6bda', N'ADMIN', N'Vinh', N'Sang Khánh', CAST(0xE51C0B00 AS Date), N'khanhvinhit@gmail.com', N'01634141300', N'/DATA/images/Avatar/10l.jpg', N'Đà Lạt - Lâm Đồng', CAST(0x0000A7D801736F1C AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (2, N'khanhvinhit', N'1', N'MEMBER', N'Vinh', N'Sanh Khánh', CAST(0xE51C0B00 AS Date), N'khanhvinhit@gmail.com', N'016341333', N'/DATA/images/Avatar/anime_naruto_uchiha_itachi_sharingan_akatsuki_look_28354_1920x1080.jpg', N'Đà Lạt - Lâm Đồng sdfa', CAST(0x0000A7D801744464 AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (4, N'Giang', N'b4b750e636aa02522415ab831f94b6b9', N'MEMBER', N'gp', N'hp', CAST(0xE51C0B00 AS Date), N'gfff@gmail.com', N'135132333', N'/DATA/images/Avatar/3sKVHO28.png', N'LĐdfdfsdfs', CAST(0x0000A7DF00000000 AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (5, N'kb', N'e6b44d01d80833b117fc61d09457b689', N'MEMBER', N'jhb', N'jhb', CAST(0xE51C0B00 AS Date), N'kshdsh@gmail.com', N'1321233232', N'/DATA/images/Avatar/3sKVHO28.png', N'dffdfdfddf', CAST(0x0000A7DF00000000 AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (6, N'546456', N'398527883a57aa4e1b105f87b0187ecb', N'MEMBER', N'2313s', N'5645641', CAST(0xE51C0B00 AS Date), N'kssshdsh@gmail.com', N'12312', N'/DATA/images/Avatar/10l.jpg', N'LĐssádfdfdf', CAST(0x0000A7DF00000000 AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (7, N'ád', N'8a3e54714364609e70bccc6c8996afd6', N'MEMBER', N'ầ', N'ádasd', CAST(0xE51C0B00 AS Date), N'fhf@gmail.com', N'12323233', N'/DATA/images/Avatar/10l.jpg', N'ấdfsấdd', CAST(0x0000A7DF00000000 AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (8, N'adasd', N'f1efe20fa3646bae2ac604bb393bbf67', N'MEMBER', N'sâf', N'áeatfgs', CAST(0xE51C0B00 AS Date), N'khanhvinhitaaa@gmail.com', N'13123132', N'/DATA/images/Avatar/10l.jpg', N'lđádfaaaa', CAST(0x0000A7DF00000000 AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (9, N'ahihi', N'3cdcdfe1e5fb4d80f2d30f07ba3e59a9', N'MEMBER', N'khanh', N'ádasd', CAST(0xE51C0B00 AS Date), N'khanhvinhitaaa@gmail.com.vn', N'1233343', N'/DATA/images/Avatar/10l.jpg', N'adaâdd', CAST(0x0000A7DF00000000 AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (10, N'12313', N'0a39ad12beb32ce0de5114321e830dcd', N'MEMBER', N'123123123', N'13212313', CAST(0xE51C0B00 AS Date), N'sdfss@gmail.com', N'13513', N'/DATA/images/Avatar/10l.jpg', N'LĐrẻer', CAST(0x0000A7DF00000000 AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (13, N'ahaha', N'ad33e8cd08ba4d889368d0802fd969a0', N'MEMBER', N'1513', N'123123', CAST(0xE51C0B00 AS Date), N'kssshdsh@gmail.com', N'135132', N'/DATA/images/Avatar/10l.jpg', N'132123', CAST(0x0000A7DF00000000 AS DateTime), 0)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (14, N'321356', N'c99804470ca1a8ce0810c713c76cf901', N'MEMBER', N'23131856', N'132165', CAST(0xE51C0B00 AS Date), N'56161@GMAIL.COM', N'132132', N'/DATA/images/Avatar/10l.jpg', N'8465163', CAST(0x0000A7E100000000 AS DateTime), 0)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (15, N'abc', N'0659c7992e268962384eb17fafe88364', N'MEMBER', N'1223', N'124134', CAST(0xE51C0B00 AS Date), N'khanh@gmail.com', N'123', N'/DATA/images/Avatar/10l.jpg', N'123s', CAST(0x0000A7E200000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
INSERT [dbo].[AccountGroup] ([ID], [Name]) VALUES (N'ADMIN', N'Quản trị')
INSERT [dbo].[AccountGroup] ([ID], [Name]) VALUES (N'MEMBER', N'Thành viên')
INSERT [dbo].[AccountGroup] ([ID], [Name]) VALUES (N'MOD', N'Điều hành')
SET IDENTITY_INSERT [dbo].[Content] ON 

INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [CreateDate], [UserName], [Status], [ViewCount], [Detail], [Description], [Images], [MoreImages], [Category]) VALUES (1, N'ahihi', N'ahihi', CAST(0x0000A7E000000000 AS DateTime), N'admin', 0, NULL, N'<p>&aacute;dasdfasfasf</p>
', N'6562323', N'/DATA/images/Avatar/3sKVHO28.png', N'<Images><Image>/DATA/images/Avatar/10l.jpg</Image></Images>', 0)
SET IDENTITY_INSERT [dbo].[Content] OFF
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'ADMIN', N'ADD_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'ADMIN', N'DELETE_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'ADMIN', N'EDIT_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'ADMIN', N'VIEW_ACCOUNT')
SET IDENTITY_INSERT [dbo].[Instruction] ON 

INSERT [dbo].[Instruction] ([ID], [Name], [CreateDate], [UserName], [Status], [Detail], [Images], [MoreImages]) VALUES (1, N'ahihi', CAST(0x0000A7E000000000 AS DateTime), N'admin', 0, N'<p>ahihii ng&agrave;y ấy em đi nh&eacute;</p>
', N'/DATA/images/Avatar/3sKVHO28.png', N'<Images><Image>/DATA/images/Avatar/anime_naruto_uchiha_itachi_sharingan_akatsuki_look_28354_1920x1080.jpg</Image><Image>/DATA/images/Avatar/3sKVHO28.png</Image></Images>')
INSERT [dbo].[Instruction] ([ID], [Name], [CreateDate], [UserName], [Status], [Detail], [Images], [MoreImages]) VALUES (2, N'Anh sẽ về', CAST(0x0000A7E100000000 AS DateTime), N'admin', 0, N'<p>ahihi</p>
', N'/DATA/images/Avatar/10l.jpg', N'<Images><Image>/DATA/images/Avatar/3sKVHO28.png</Image></Images>')
SET IDENTITY_INSERT [dbo].[Instruction] OFF
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'ADD_ACCOUNT', N'Thêm tài khoản')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DELETE_ACCOUNT', N'Xóa tài khoản')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'EDIT_ACCOUNT', N'Sửa tài khoản')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'VIEW_ACCOUNT', N'Xem danh sách tài khoảng')
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_CreateDate_1]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Status_1]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_CreateDate_1]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_Status_1]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_CreateDate_1]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_Status_1]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_CreateDate_1]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_Status_1]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Instruction] ADD  CONSTRAINT [DF_Instruction_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Instruction] ADD  CONSTRAINT [DF_Instruction_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Request] ADD  CONSTRAINT [DF_Request_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Request] ADD  CONSTRAINT [DF_Request_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Slider] ADD  CONSTRAINT [DF_Slider_CreateDate_1]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Slider] ADD  CONSTRAINT [DF_Slider_Status_1]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Ticker] ADD  CONSTRAINT [DF_Ticker_CreateDate_1]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Ticker] ADD  CONSTRAINT [DF_Ticker_Status_1]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountGroup] FOREIGN KEY([AccountGroupID])
REFERENCES [dbo].[AccountGroup] ([ID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountGroup]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Content] FOREIGN KEY([ContentID])
REFERENCES [dbo].[Content] ([ID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Content]
GO
ALTER TABLE [dbo].[Slider]  WITH CHECK ADD  CONSTRAINT [FK_Slider_Content] FOREIGN KEY([ContentID])
REFERENCES [dbo].[Content] ([ID])
GO
ALTER TABLE [dbo].[Slider] CHECK CONSTRAINT [FK_Slider_Content]
GO
USE [master]
GO
ALTER DATABASE [TLTY] SET  READ_WRITE 
GO
