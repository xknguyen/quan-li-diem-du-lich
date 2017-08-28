USE [master]
GO
/****** Object:  Database [TLTY]    Script Date: 8/28/2017 9:32:36 AM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 8/28/2017 9:32:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
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
/****** Object:  Table [dbo].[AccountGroup]    Script Date: 8/28/2017 9:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountGroup](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupPathID] [bigint] NULL,
	[AccountID] [bigint] NULL,
	[Description] [ntext] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_AccountGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 8/28/2017 9:32:37 AM ******/
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
/****** Object:  Table [dbo].[Content]    Script Date: 8/28/2017 9:32:37 AM ******/
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
/****** Object:  Table [dbo].[Feedback]    Script Date: 8/28/2017 9:32:37 AM ******/
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
/****** Object:  Table [dbo].[GroupPath]    Script Date: 8/28/2017 9:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPath](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupID] [bigint] NULL,
	[PathID] [bigint] NULL,
 CONSTRAINT [PK_GroupPath] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Instruction]    Script Date: 8/28/2017 9:32:37 AM ******/
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
/****** Object:  Table [dbo].[Path]    Script Date: 8/28/2017 9:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Path](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PathName] [nvarchar](250) NULL,
	[Description] [ntext] NULL,
	[Link] [nvarchar](150) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_Path] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Request]    Script Date: 8/28/2017 9:32:37 AM ******/
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
/****** Object:  Table [dbo].[Slider]    Script Date: 8/28/2017 9:32:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[DisplayOrder] [int] NOT NULL,
	[Link] [nchar](10) NULL,
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
/****** Object:  Table [dbo].[Ticker]    Script Date: 8/28/2017 9:32:37 AM ******/
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

INSERT [dbo].[Account] ([ID], [UserName], [Password], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (1, N'admin', N'1', N'Vinh', N'Sang Khánh', CAST(0xE51C0B00 AS Date), N'khanhvinhit@gmail.com', N'01634141300', N'/DATA/images/Avatar/10l.jpg', N'Đà Lạt - Lâm Đồng', CAST(0x0000A7D801736FCD AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [UserName], [Password], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (2, N'khanhvinhit', N'1', N'Vinh', N'Sanh Khánh', CAST(0xE51C0B00 AS Date), N'khanhvinhit@gmail.com', N'01634141300', N'/DATA/images/Avatar/3sKVHO28.png', N'Đà Lạt - Lâm Đồng', CAST(0x0000A7D8017444F7 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
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
ALTER TABLE [dbo].[AccountGroup]  WITH CHECK ADD  CONSTRAINT [FK_AccountGroup_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[AccountGroup] CHECK CONSTRAINT [FK_AccountGroup_Account]
GO
ALTER TABLE [dbo].[GroupPath]  WITH CHECK ADD  CONSTRAINT [FK_GroupPath_AccountGroup] FOREIGN KEY([GroupID])
REFERENCES [dbo].[AccountGroup] ([ID])
GO
ALTER TABLE [dbo].[GroupPath] CHECK CONSTRAINT [FK_GroupPath_AccountGroup]
GO
ALTER TABLE [dbo].[GroupPath]  WITH CHECK ADD  CONSTRAINT [FK_GroupPath_Path] FOREIGN KEY([PathID])
REFERENCES [dbo].[Path] ([ID])
GO
ALTER TABLE [dbo].[GroupPath] CHECK CONSTRAINT [FK_GroupPath_Path]
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
