USE [master]
GO
/****** Object:  Database [TLTY]    Script Date: 9/18/2017 10:16:08 AM ******/
CREATE DATABASE [TLTY]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TLTY', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TLTY.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TLTY_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\TLTY_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [TLTY] SET AUTO_CLOSE ON 
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
ALTER DATABASE [TLTY] SET  ENABLE_BROKER 
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
ALTER DATABASE [TLTY] SET READ_COMMITTED_SNAPSHOT ON 
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
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 9/18/2017 10:16:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Account]    Script Date: 9/18/2017 10:16:08 AM ******/
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
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountGroup]    Script Date: 9/18/2017 10:16:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountGroup](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.AccountGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 9/18/2017 10:16:08 AM ******/
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
 CONSTRAINT [PK_dbo.Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Content]    Script Date: 9/18/2017 10:16:08 AM ******/
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
 CONSTRAINT [PK_dbo.Content] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 9/18/2017 10:16:08 AM ******/
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
 CONSTRAINT [PK_dbo.Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupPath]    Script Date: 9/18/2017 10:16:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPath](
	[AccountGroupID] [nvarchar](50) NOT NULL,
	[PathID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.GroupPath] PRIMARY KEY CLUSTERED 
(
	[AccountGroupID] ASC,
	[PathID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Instruction]    Script Date: 9/18/2017 10:16:08 AM ******/
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
 CONSTRAINT [PK_dbo.Instruction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Path]    Script Date: 9/18/2017 10:16:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Path](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Path] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Request]    Script Date: 9/18/2017 10:16:08 AM ******/
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
	[ContentID] [bigint] NULL,
	[Detail] [ntext] NULL,
	[MoreImages] [xml] NULL,
 CONSTRAINT [PK_dbo.Request] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slider]    Script Date: 9/18/2017 10:16:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[DisplayOrder] [int] NOT NULL,
	[Link] [nvarchar](500) NULL,
	[ContentID] [bigint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Status] [bit] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Slider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticker]    Script Date: 9/18/2017 10:16:08 AM ******/
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
	[Type] [bit] NOT NULL,
	[Quantity] [bigint] NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Ticker] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201709150801138_InitialCreate', N'EntityModel.EF.TLTYDBContext', 0x1F8B0800000000000400ED5CDD6EE3B815BE2FD077107459CC5A49A65B6C037B17192759049D4CD2383B68AF06B4C438C4E8C72B51D918459F6C2FF691FA0AA5244A22254A2225DAB233C6008398D2F948F1FC923C3CFFFBFD8FE94FAF9E6BBCC03042813F334F2727A6017D3B7090BF9A99317EFAEE07F3A71FFFFCA7E995E3BD1A9FF3F7DE27EF114A3F9A99CF18AFCF2D2BB29FA107A28987EC308882273CB103CF024E609D9D9CFCDD3A3DB52081300996614C1F621F230FA63FC8CF79E0DB708D63E0DE060E7423DA4E9E2C5254E313F060B406369C995784126FD2F72657D7A671E1224046B180EE936900DF0F30C0648CE7BF447081C3C05F2DD6A401B88F9B3524EF3D01378274ECE7E5EBB29F7172967C865512E650761CE1C053043C7D4FE7C5AA92F79A5DB398373273D93C255F9DCEDECCBCB0ED804CFBCF6110AF4DA3DAE1F9DC0D9397AB133C61C9DE19CCC377853810A949FEBD33E6B18BE310CE7C18E3109037EEE3A58BEC7FC0CD63F015FA333F765D76906498E419D7409AEEC3600D43BC79804F74E83797A661F1745695B0206368B20F226240A4D9346EC1EB47E8AFF0F3CCFC9E88EF357A854EDE40C5E2171F11D92734388CC9CF4F64BC60E9C2E2B9D5DA65F27F4BA76792BD563AF9045ED02AE551A53BCA99C8341EA09BBE103DA375A60A39DBBEF05CBF0E03EF21704B62EEF9974710AE20269F10B4BCB408E2D0AE0C736A95E2262384EAF27798A277E3E3BFFD552047CC772F7010C29FA10F4380A1730F308621B11E370E4CBFB74BE688990B35C99DA2B4DF8328FA2D089DDDF7CC8AA30E356FEFED1A85111E678A3F026D3DB777F40185F8D9019BBCA34B228B8FC8531FF19507903B822C3E077EDB2C9D7EAF61922E5E0006E1D67971E138218CA256B1D6D1CF3C8484CB09A7EB5C6FA75C10D3151703FC10105F01FC6E9E753932EAA37439B3DC4FB53AB3DCE3F57266246CC5C056716694E2609DD9FBB3AD3AB3369154B408E3F9C59EDAA16C05F4589B2ECBA9A5135D5EA1B79642A59093521CAC966E39E41C47AD6E21068F08BBDB0F868E56A840F98CE06FF36CC1C6F98076AA4BC2AA567D277F6EE39B2F616487689DED9F0C8E9E143BBFF1C00A6EDF5EDF12D5EDEC4A767E3BF48048FD2A08376A42246D97AF217496C0FEAA60987392A36516F7358EA979CB6B3E8DBE408F4596B3715A0CACB426A74B2922ACCF0AAA5CD08CA5CBD54D24AB9B24196E1F13A07BBF4A79A32E1BF656BB9516961B3F22707626C0D2E2C2501D8DBFB8AF718CFF31581E3DEC3DF4C853DA7428BA9831BDCBB77B6229CDCD07F86B0C23957D194A71983CDDFEEEE948C78087B481389E73D3E362E8CE642DACD89163DA7707B170910343058B92111CAC411937A2D4730C7989A2B50B367761CAB9765BD9715A8EFCAFDB3F356DD0C063D8BCDD1D8D3EDC93B61B8FC8FEAA64373282A3DDE865378EA7349A3528A11E8AF1CF1850DE2A0416F721B2CBE98736F2000933EE43F217CD27FEC1341636484671720086E1228A021BA53AC06FDDF19927FCA8AF7CC7904943C93E804967219F410C045A139340C63233FF529B900EE8225DB3064D336478FC93C9E4B4D605B12A304CD41AB8C4B545C44E211FD74D10F26DB406AEC4682AB492062CE149D14BF5C9255C433FB13D12F32CD37DE7D6AF55F458B1B25DB335B51811AABB9C34FD0711B39A2BEEC7C77F5F7E48438A57D142981826EA81222AC655F9485017100B3E8C589552C885D251133621580B4E27044D77124114B9531210503C8A22B1A303223F3514619487901D20C5798508853900E98061F6B14540DCE6780754D360A4C641B75244F4C5BE4C0744B6761221E4CBB00E802C881201E4F1580580D1AD9A985672039957DB7208AB8A2F69CB8B2F61B5A4664524AD771D2CD7DF6A8CC77FBFC09F15F6A57836B5B21B34B4616A355CB599DE82F59AB856E6EA0D6D3116D9BD9BF9770BF54B295E8661D991E06E4A31DAA22712768215AC3C4D6C8003D32C6C12E18125489CFBDCF16AAFF1D6B441F6F2BE4406B3CEC05C2E73AAE46FBA23D57C4B46E08328FD35F93C2FF1636980DDC0F83AB991DC83022E080531FD3C7063CF6F76ABCDD459C4CBD2672D7584A955197FCD5FD666AA22B9D5E957618E0EBEF467C9AEB851AE41588CB2551EA9BC97C12295ADF248D53889C5EB8AA19A5199FB142C20D32C8F555E9060A1CA5679A4F206048B54B6CA23D1BD6A16863629F030DB54E718983529708F5E57E0B846DB1450F23C640E266F94C76197EB2C14DB2E8F96AF9B59A4BC6D6FEC5711FD0EB05F7998AC6EBF1A29B763BFF4F2579F355493946D6B810EBD56B12F234A3E1CE8B9F3D55D3FC917528E1D47352130A9ED2C0CD37CD4C38C82C9476781986679ACFC549405CADB5450984D4A1E8A79208F971FA072F248DB14248A398AE5448A695790A922119C93A8A2756FEC4EB9D333C0F0145B42EA96A799745F4DCFBE04AB638687BA557B24E167762807487FB995A92EFE2DB4BB5D62E619CFFC025894BC3D22BFB8ADE0011C63F78CD579D64ABDAF56EB6D07397A029331038991346AB0F1EB69F7D44CDE1BDFB52D4E9606F0213F8252674523E5D8DCD8971D81430AC0985C3B6E4865F3AE8DEA4199C3FC80768022D2935C753D6C22DC5735E4B3503921E19E281C4DA4D9A8DCB144DA328EF8BFF588E9A0566A79E2C300C5A41912EA8AD944B8AF8AF9B60537CBDC6431B2167984326F9345295B1522912C99938B44B2A60357C45A764CF595A277DA52FC2EB26368664A7775DA5AAA4AF64A92141BBC242E9148C926C2D09B242F4C16BFBA7317A5496CF90BB7C0474F2484CD52C4CDB393D3B34A91DBFD29386B4591C365B077549DE579B6835C77FF0584F67372E25DB99136E09EA410F38C071D7017419877B28BB95AA2154A04B133F97F6076BDCCFCF52A40AA0D585CAFA184AFE5E9DEF80E7C9D99FF49E9CF8D9B7F7DE121DE1969F8786E9C18FF6D11C55ED548B57D75B5D8683F39AFE3566B8B3AA9CF1E5263469F04B1775785A8491119B5CFE5AB84EA9AC44A39C006BBA60C5BBF44937007572ED1C820F137599608EBAA1722CC63D9853DDC8A31949BF071EDAA2A2BFB496B0F25E85657754C65C3A2A112E59B71ED5B11BF5AA1475DE2F36DE85EAD6463CA79B599E20B06D0DB49C36FEFC978AD1E156F74C947BD7E015912290B59A568A2464F28CE2E39DA8F830D15351AA4E17643A4AF128ADFA348600FF11DBD589FAE8D04BE165F3FD45EA5F68E36E3181AE870EB7BE37AD5AAC61D771EE50BB2BD8D95F676B61CF76105BA6B8B36DCF0D48A26E5CE41EBB2646C4323CA7978D39EB6C786A3A8DA574512946B7D69DB0CED96D2633031747D3FBC4AD7B7A35FC73DAE06842C49A23F7DB5D8553F77C455BF727650FD4AAF7EE9297645EBAD6403EC5782AA86D9AF58D6904A564D753B644C89D1A374D56195A9AAD75FA932902FECC34B40297D4201C9126488022D03C2F74C88FBD4A96A2B53D5D247277C51A8AA065F3C11C12BD6B76A2B6FD5040F156A5FB596BE1275A05E18ABBD2E96A88F5E65B3BAAA66893A522DABD558554B04AE526FABADDC96085BAD16574B292E11B85299AE962A5D22ECFDA9E0C559A17AB1A5BA5515B8A33A713D9ED4519CAB9E66486C39E98D846FD92F1214A055093125983EB4392B5EBC73E33F05B953A98C287F4570F24AC245701162F4448C17796CC3284A2B6E7E066E9C6E562CA173E3DFC5781D63F2C9D05BBA5C9669E294DAFA4F2B90F1639EDEA5514EA4E313C8305112F1DEF91F62E43AC5B8AF05DBE80D1089B7A3517EC24B9C44FBAB4D81F4A97639A709884E5FE1A41FA147D6BE184677FE02BCC03E632331F947B802F626CF166D06E966043FEDD34B045621F0228A51D2939F44861DEFF5C7FF0379BA65E931820000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [UserName], [Password], [AccountGroupID], [FirstName], [LastName], [Birthday], [Email], [Phone], [Avatar], [Address], [CreateDate], [Status]) VALUES (1, N'admin', N'e00cf25ad42683b3df678c61f42c6bda', N'ADMIN', N'Vinh', N'Sang Khánh', CAST(N'1995-01-01' AS Date), N'khanhvinhit@gmail.com', N'01634141300', N'/DATA/images/Avatar/10l.jpg', N'Đà Lạt', CAST(N'2017-09-15 00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
INSERT [dbo].[AccountGroup] ([ID], [Name]) VALUES (N'ADMIN', N'Quản trị')
INSERT [dbo].[AccountGroup] ([ID], [Name]) VALUES (N'MEMBER', N'Thành viên')
INSERT [dbo].[AccountGroup] ([ID], [Name]) VALUES (N'MOD', N'Điều hành')
INSERT [dbo].[AccountGroup] ([ID], [Name]) VALUES (N'SERVICES', N'Chăm sóc khách hàng')
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ID], [CreateDate], [UserName], [Status], [Address], [Phone], [Email]) VALUES (1, CAST(N'2017-09-15 00:00:00.000' AS DateTime), N'admin', 1, N'Thung Lũng Tình Yêu', N'123456', N'khanhvinhit@gmail.com')
SET IDENTITY_INSERT [dbo].[Contact] OFF
SET IDENTITY_INSERT [dbo].[Content] ON 

INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [CreateDate], [UserName], [Status], [ViewCount], [Detail], [Description], [Images], [MoreImages], [Category]) VALUES (1, N'VẬN CHUYỂN TRONG KHU DU LỊCH', N'VAN-CHUYEN-TRONG-KHU-DU-LICH', CAST(N'2017-09-15 00:00:00.000' AS DateTime), N'admin', 1, 18, N'<p>Tr&ecirc;n Cao nguy&ecirc;n với độ cao hơn 1500m so với mặt nước biển, du kh&aacute;ch vẫn c&oacute; thể du ngoạn bằng xe Lửa cổ, xe Jeep, xe Điện<strong>.&nbsp;</strong>H&agrave;nh tr&igrave;nh tham quan bắt đầu từ Khu Trung t&acirc;m, đi qua những con đường quanh co rợp b&oacute;ng m&aacute;t sẽ đưa du kh&aacute;ch đến Cầu kh&oacute;a T&igrave;nh y&ecirc;u, V&ograve;i nước tr&ecirc;n kh&ocirc;ng, Phố hoa, tham quan Vườn Ươm, Thung lũng hoa Cẩm T&uacute; Cầu. Đặc biệt l&agrave; tham quan &ldquo;Đồi Vọng Cảnh&rdquo; &ndash;&nbsp;nơi c&oacute; vườn bon sai với nhiều c&acirc;y kiểng qu&yacute; hiếm, Vườn T&igrave;nh nh&acirc;n, Tiểu cảnh Adam &amp; Eva&hellip; c&ugrave;ng với Linh vật Rồng &ndash; C&ocirc;ng (được chế t&aacute;c bằng đ&aacute; qu&yacute;, mạ v&agrave;ng) với ước muốn người đến tham quan sẽ gặp được nhiều điều may mắn trong cuộc sống v&agrave; th&agrave;nh đạt trong kinh doanh. Từ đ&acirc;y, du kh&aacute;ch c&oacute; thể ph&oacute;ng tầm mắt bao qu&aacute;t, ngắm to&agrave;n cảnh TTC World &ndash; Thung lũng T&igrave;nh Y&ecirc;u ngập&nbsp;tr&agrave;n&nbsp;hoa. Du kh&aacute;ch sẽ được tham quan trong khoảng thời gian k&eacute;o d&agrave;i 30 ph&uacute;t, sau đ&oacute; xe sẽ đ&oacute;n du kh&aacute;ch về lại Khu Trung t&acirc;m &ndash; kết th&uacute;c cuộc h&agrave;nh tr&igrave;nh.</p>
', N'Trên Cao nguyên với độ cao hơn 1500m so với mặt nước biển, du khách vẫn có thể du ngoạn bằng xe Lửa cổ, xe Jeep, xe Điện.', N'/DATA/images/Instruction/2.jpg', N'<Images><Image>/DATA/images/Slider/XE-DIEN.jpg</Image><Image>/DATA/images/Slider/XE-LUA.jpg</Image></Images>', 0)
INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [CreateDate], [UserName], [Status], [ViewCount], [Detail], [Description], [Images], [MoreImages], [Category]) VALUES (2, N'TRÒ CHƠI VẬN ĐỘNG', N'TRO-CHOI-VAN-DONG', CAST(N'2017-09-18 00:00:00.000' AS DateTime), N'admin', 1, 0, N'<p><em><strong>Highwire&nbsp;</strong>&ndash;</em>&nbsp;tr&ograve; chơi thể thao cảm gi&aacute;c mạnh đ&atilde; xuất hiện l&acirc;u ở c&aacute;c nước ch&acirc;u &Acirc;u nhưng vẫn c&ograve;n lạ lẫm tại Việt Nam đ&atilde; c&oacute; mặt tại TTC World &ndash;&nbsp;Thung lũng T&igrave;nh y&ecirc;u.&nbsp;<em><strong>Highwire&nbsp;</strong></em>l&agrave; tr&ograve; chơi ngo&agrave;i trời được cấu tạo bởi nhiều tấm gỗ gắn tr&ecirc;n sợi c&aacute;p v&agrave; buộc v&agrave;o c&acirc;y to. Điểm th&uacute; vị nhất của tr&ograve; chơi n&agrave;y l&agrave; qu&yacute; kh&aacute;ch sẽ phải vượt l&ecirc;n ch&iacute;nh sự sợ h&atilde;i của m&igrave;nh để chinh phục c&aacute;c thử th&aacute;ch ở độ cao 9m so với mặt đất.</p>

<p><em><strong>Highwire</strong></em>&nbsp;c&oacute; 2 chặng với mức độ từ dễ tới kh&oacute;. Tổng chiều d&agrave;i tr&ecirc;n 250m, được l&agrave;m từ 850 cấu kiện gỗ, gồm 21 thử th&aacute;ch. Gồm 02 chặng:</p>

<p><em>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&ndash; Chặng thứ nhất:</em>&nbsp;được thiết kế để trẻ em cao tr&ecirc;n 1,1m c&oacute; thể trải nghiệm v&agrave; ho&agrave;n thiện kỹ năng bản th&acirc;n</p>

<p><em>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</em><em>&ndash; Chặng thứ hai:</em>&nbsp;đ&ograve;i hỏi độ tập trung cao với nhiều thử th&aacute;ch kh&oacute; d&agrave;nh cho người lớn như: vượt qua &ldquo;Cầu d&acirc;y văng&rdquo;; &ldquo; Cầu d&acirc;y v&otilde;ng&rdquo;; chinh phục &ldquo;Ống tử thần&rdquo;; &ldquo;V&aacute;ch ngăn khổng lồ&rdquo;&hellip;</p>

<p>Thử th&aacute;ch lớn nhất đối với người chơi ch&iacute;nh l&agrave; tr&ograve; chơi&nbsp;<em><strong>&ldquo;Đu d&acirc;y mạo hiểm tự do &ndash; Zipline&rdquo;</strong></em>&nbsp;với hệ thống c&aacute;p bắt đầu từ độ cao 9m, băng qua một qu&atilde;ng đường rừng th&ocirc;ng d&agrave;i. Qu&yacute; kh&aacute;ch sẽ phải chinh phục cảm gi&aacute;c sợ h&atilde;i độ cao của những chướng ngại vật l&agrave;m mất thăng bằng, tạo cảm gi&aacute;c th&uacute; vị cho Qu&yacute; kh&aacute;ch khi tham gia.</p>
', N'Highwire – trò chơi thể thao cảm giác mạnh đã xuất hiện lâu ở các nước châu Âu nhưng vẫn còn lạ lẫm tại Việt Nam đã có mặt tại TTC World – Thung lũng Tình yêu.', N'/DATA/images/Instruction/4.jpg', N'<Images><Image>/DATA/images/Express/IMG_1546.jpg</Image><Image>/DATA/images/Express/IMG_1651.jpg</Image></Images>', 0)
INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [CreateDate], [UserName], [Status], [ViewCount], [Detail], [Description], [Images], [MoreImages], [Category]) VALUES (3, N'CANO – PEDALO', N'CANO-–-PEDALO', CAST(N'2017-09-18 00:00:00.000' AS DateTime), N'admin', 1, 0, N'<p>Đ&acirc;y l&agrave; dịch vụ vui chơi giải tr&iacute; hấp dẫn kh&ocirc;ng thể bỏ qua tại Thung lũng T&igrave;nh y&ecirc;u. Với mặt hồ rộng tho&aacute;ng, kh&ocirc;ng kh&iacute; m&aacute;t mẻ, cảnh sắc tuyệt mỹ, Qu&yacute; kh&aacute;ch sẽ trải qua những gi&acirc;y ph&uacute;t bồng bềnh tr&ecirc;n Cano, Pedalo tham quan một v&ograve;ng hồ Đa Thiện với khung cảnh thi&ecirc;n nhi&ecirc;n trữ t&igrave;nh, thơ mộng tạo cho du kh&aacute;ch một cảm gi&aacute;c m&aacute;t mẻ sảng kho&aacute;i. Những ph&uacute;t tự t&igrave;nh b&ecirc;n cạnh người y&ecirc;u thương tr&ecirc;n mặt hồ Thung lũng T&igrave;nh y&ecirc;u sẽ đọng lại trong l&ograve;ng du kh&aacute;ch&nbsp;những kỷ niệm kh&oacute; phai.</p>

<p>&nbsp;</p>
', N'Đây là dịch vụ vui chơi giải trí hấp dẫn không thể bỏ qua tại Thung lũng Tình yêu.', N'/DATA/images/Instruction/1.png', N'<Images><Image>/DATA/images/Express/CANO-PEDALO-1.jpg</Image><Image>/DATA/images/Express/CANO-PEDALO.jpg</Image></Images>', 0)
INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [CreateDate], [UserName], [Status], [ViewCount], [Detail], [Description], [Images], [MoreImages], [Category]) VALUES (4, N'GIẢI KHÁT VALLEY D’AMOUR – FASTFOOD', N'GIAI-KHAT-VALLEY-D’AMOUR-–-FASTFOOD', CAST(N'2017-09-18 00:00:00.000' AS DateTime), N'admin', 1, 1, N'<p>Để đ&aacute;p ứng nhu cầu của Du kh&aacute;ch, KDL Thung lũng T&igrave;nh y&ecirc;u đ&atilde; x&acirc;y dựng cửa h&agrave;ng thức ăn nhanh ngay tại khu&ocirc;n vi&ecirc;n trung t&acirc;m, với c&aacute;c m&oacute;n ăn nhanh hấp dẫn như x&uacute;c x&iacute;ch, c&aacute; vi&ecirc;n chi&ecirc;n, b&ograve; vi&ecirc;n chi&ecirc;n, g&agrave; r&aacute;n&hellip; v&agrave; c&aacute;c loại nước uống như c&agrave; ph&ecirc;, tr&agrave;, c&aacute;c loại nước giải kh&aacute;t phục vụ nhu cầu ăn uống của Du kh&aacute;ch khi tham quan tại đ&acirc;y.</p>

<p>&nbsp;</p>
', N'Để đáp ứng nhu cầu của Du khách, KDL Thung lũng Tình yêu đã xây dựng cửa hàng thức ăn nhanh ngay tại khuôn viên trung tâm.', N'/DATA/images/Instruction/1.png', N'<Images><Image>/DATA/images/Express/FASTFOOD.jpg</Image></Images>', 0)
SET IDENTITY_INSERT [dbo].[Content] OFF
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([ID], [Name], [Email], [Phone], [CreateDate], [Status], [Description]) VALUES (1, N'Vinh', N'khanhvinhit', N'123456', CAST(N'2017-09-15 00:00:00.000' AS DateTime), 1, N'Sống tốt')
INSERT [dbo].[Feedback] ([ID], [Name], [Email], [Phone], [CreateDate], [Status], [Description]) VALUES (2, N'aesfrafase', N'zczvczdvdzxv@gmail.com', N'123456789', CAST(N'2017-09-15 00:00:00.000' AS DateTime), 1, N'zsczsvcfszacfv')
SET IDENTITY_INSERT [dbo].[Feedback] OFF
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'CHANGE_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'CREATE_CONTENT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'CREATE_INSTRUCTION')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'CREATE_SLIDER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'CREATE_TICKER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'DELETE_CONTENT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'DELETE_INSTRUCTION')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'DELETE_SLIDER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'DELETE_TICKER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'DETAILS_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'DETAILS_CONTENT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'DETAILS_INSTRUCTION')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'DETAILS_SLIDER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'DETAILS_TICKER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'EDIT_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'EDIT_CONTENT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'EDIT_INSTRUCTION')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'EDIT_SLIDER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'EDIT_TICKER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'VIEW_CONTENT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'VIEW_INSTRUCTION')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'VIEW_SLIDER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MEMBER', N'VIEW_TICKER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'CHANGE_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'CREATE_CONTACT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'CREATE_CONTENT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'CREATE_INSTRUCTION')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'CREATE_SLIDER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'CREATE_TICKER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DELETE_CONTACT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DELETE_CONTENT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DELETE_FEEDBACK')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DELETE_INSTRUCTION')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DELETE_REQUEST')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DELETE_SLIDER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DELETE_TICKER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DETAILS_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DETAILS_CONTACT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DETAILS_CONTENT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DETAILS_FEEDBACK')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DETAILS_INSTRUCTION')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DETAILS_REQUEST')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DETAILS_SLIDER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'DETAILS_TICKER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'EDIT_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'EDIT_CONTACT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'EDIT_CONTENT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'EDIT_FEEDBACK')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'EDIT_INSTRUCTION')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'EDIT_REQUEST')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'EDIT_SLIDER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'EDIT_TICKER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'VIEW_CONTACT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'VIEW_CONTENT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'VIEW_FEEDBACK')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'VIEW_INSTRUCTION')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'VIEW_REQUEST')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'VIEW_SLIDER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'MOD', N'VIEW_TICKER')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'CHANGE_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'CREATE_CONTACT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'DELETE_CONTACT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'DELETE_FEEDBACK')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'DELETE_REQUEST')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'DETAILS_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'DETAILS_CONTACT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'DETAILS_FEEDBACK')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'DETAILS_REQUEST')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'EDIT_ACCOUNT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'EDIT_CONTACT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'EDIT_FEEDBACK')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'EDIT_REQUEST')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'VIEW_CONTACT')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'VIEW_FEEDBACK')
INSERT [dbo].[GroupPath] ([AccountGroupID], [PathID]) VALUES (N'SERVICES', N'VIEW_REQUEST')
SET IDENTITY_INSERT [dbo].[Instruction] ON 

INSERT [dbo].[Instruction] ([ID], [Name], [CreateDate], [UserName], [Status], [Detail], [Images], [MoreImages]) VALUES (1, N'Đi Đà Lạt', CAST(N'2017-09-18 00:00:00.000' AS DateTime), N'admin', 1, N'<p>Đ&agrave; Lạt được nhiều người y&ecirc;u th&iacute;ch bởi kh&iacute; hậu m&aacute;t mẻ, danh lam thắng cảnh thơ mộng v&agrave; ngh&igrave;n hoa đua sắc quanh năm. Du kh&aacute;ch vẫn thường n&oacute;i Đ&agrave; Lạt l&agrave; nơi chưa đi th&igrave; mong chờ, đến rồi th&igrave; lưu luyến v&agrave; d&ugrave; chưa rời khỏi đ&atilde; muốn quay lại.</p>

<p>Du lịch Đ&agrave; Lạt lu&ocirc;n l&agrave; điểm đến thu h&uacute;t nhiều du kh&aacute;ch kh&ocirc;ng chỉ bởi kh&iacute; hậu m&agrave; c&ograve;n l&agrave; quang cảnh thi&ecirc;n nhi&ecirc;n tuyệt vời.Trong số c&aacute;c cảnh đẹp của Đ&agrave; Lạt,&nbsp;<strong>Thung lũng T&igrave;nh y&ecirc;u&nbsp;</strong>l&agrave; một trong những thắng cảnh Du lịch nổi tiếng đ&atilde; đi v&agrave;o tiềm thức của mỗi người d&acirc;n cũng như c&aacute;c du kh&aacute;ch từ mọi miền đất nước.&nbsp;<strong>Thung lũng t&igrave;nh y&ecirc;u</strong>&nbsp;c&aacute;ch Trung t&acirc;m th&agrave;nh phố Đ&agrave; Lạt khoảng 6 km về hướng Đ&ocirc;ng Bắc với tổng diện t&iacute;ch gần 140 ha.</p>

<hr/>
', N'/DATA/images/Instruction/1.png', NULL)
INSERT [dbo].[Instruction] ([ID], [Name], [CreateDate], [UserName], [Status], [Detail], [Images], [MoreImages]) VALUES (2, N'Đến Thung Lũng Tình Yêu', CAST(N'2017-09-18 00:00:00.000' AS DateTime), N'admin', 1, N'<p>Từ trung t&acirc;m th&agrave;nh phố Đ&agrave; Lạt, Qu&yacute; kh&aacute;ch c&oacute; thể đi xe hơi, xe m&aacute;y khoảng 15 ph&uacute;t theo hướng đường Nguyễn Văn Trỗi &ndash; B&ugrave;i Thị Xu&acirc;n ( hoặc Phan Bội Ch&acirc;u &ndash; B&ugrave;i Thị Xu&acirc;n, hoặc Phan Bội Ch&acirc;u &ndash; B&ugrave;i Thị Xu&acirc;n &ndash; Đinh Ti&ecirc;n Ho&agrave;ng ) đến Ng&atilde; 5 Đại học rồi đi hết đường Ph&ugrave; Đổng Thi&ecirc;n Vương v&agrave; rẽ phải theo đường Mai Anh Đ&agrave;o 500 m&eacute;t sẽ tới Khu Du lịch.</p>

<hr/>
', N'/DATA/images/Instruction/2.jpg', NULL)
INSERT [dbo].[Instruction] ([ID], [Name], [CreateDate], [UserName], [Status], [Detail], [Images], [MoreImages]) VALUES (3, N'Vallée D’ Amour', CAST(N'2017-09-18 00:00:00.000' AS DateTime), N'admin', 1, N'<p>Xưa kia, nơi đ&acirc;y l&agrave; một thắng cảnh hoang sơ nhưng đầy thơ mộng, với những d&ograve;ng suối nhỏ, những thảm cỏ xanh mướt v&agrave; những đồi th&ocirc;ng chập ch&ugrave;ng .., đ&acirc;y ch&iacute;nh l&agrave; nơi hẹn h&ograve; l&yacute; tưởng cho những đ&ocirc;i t&igrave;nh nh&acirc;n. V&igrave; vậy người Ph&aacute;p khi ngự trị tại Đ&agrave; Lạt đ&atilde; đặt t&ecirc;n bằng tiếng Ph&aacute;p cho thắng cảnh n&agrave;y l&agrave; Vall&eacute;e D&rsquo; Amour. Năm 1953, Thị trưởng của Đ&agrave; Lạt l&uacute;c bấy giờ đ&atilde; quyết định lấy t&ecirc;n thắng cảnh n&agrave;y bằng tiếng Việt gọi l&agrave;&nbsp;<strong>Thung lũng T&igrave;nh y&ecirc;u,&nbsp;</strong>t&ecirc;n gọi n&agrave;y tồn tại cho đến b&acirc;y giờ.</p>
<hr/>
', N'/DATA/images/Instruction/1.png', NULL)
INSERT [dbo].[Instruction] ([ID], [Name], [CreateDate], [UserName], [Status], [Detail], [Images], [MoreImages]) VALUES (4, N'Hiện nay', CAST(N'2017-09-18 00:00:00.000' AS DateTime), N'admin', 1, N'<p>Ng&agrave;y nay,&nbsp;<strong>Thung lũng T&igrave;nh y&ecirc;u</strong>&nbsp;đ&atilde; trở th&agrave;nh một trong những địa điểm Du lịch hấp dẫn v&agrave; l&yacute; tưởng nhờ được bao quanh bởi hồ nước v&agrave; đồi th&ocirc;ng lộng gi&oacute; tạo th&agrave;nh những mảng kh&ocirc;ng gian thực thực hư hư. Sự hấp dẫn của v&ugrave;ng Thung lũng n&agrave;y vốn l&agrave; n&eacute;t l&atilde;ng mạn tự nhi&ecirc;n của một kh&ocirc;ng gian xanh, non nước hữu t&igrave;nh.</p>

<p>Tại đ&acirc;y, c&oacute; h&igrave;nh ảnh đ&ocirc;i b&agrave;n tay c&ugrave;ng trao nhẫn, Đ&ocirc;i bướm hoa t&igrave;nh nh&acirc;n, Vườn c&ocirc;ng khoe sắc thắm, Phố hoa, tiểu cảnh Adam &amp; Eva độc đ&aacute;o, ấn tượng. Thung lũng T&igrave;nh Y&ecirc;u c&ograve;n l&agrave; nơi tổ chức sự kiện ng&agrave;y T&igrave;nh Nh&acirc;n (14/02) h&agrave;ng năm. Ng&agrave;y T&igrave;nh Nh&acirc;n được diễn ra tại c&acirc;y cầu t&igrave;nh y&ecirc;u nằm tr&ecirc;n Hồ Đa thiện. C&acirc;y cầu c&ograve;n l&agrave; nơi d&agrave;nh cho những đ&ocirc;i t&igrave;nh nh&acirc;n thề non, hẹn ước, gắn những chiếc ổ kh&oacute;a t&igrave;nh y&ecirc;u thể hiện sự gắn kết, bền chặt của c&aacute;c cặp đ&ocirc;i y&ecirc;u nhau. Đặc biệt Qu&yacute; kh&aacute;ch c&oacute; cơ hội chinh phục M&ecirc; Cung T&igrave;nh Y&ecirc;u với h&igrave;nh tr&aacute;i tim được xem l&agrave; M&ecirc; Cung Sinh Th&aacute;i lớn nhất Việt Nam.</p>
<hr/>
', N'/DATA/images/Instruction/3.png', NULL)
INSERT [dbo].[Instruction] ([ID], [Name], [CreateDate], [UserName], [Status], [Detail], [Images], [MoreImages]) VALUES (5, N'Điểm nhấn', CAST(N'2017-09-18 00:00:00.000' AS DateTime), N'admin', 1, N'<p>Đến với&nbsp;<strong>Thung lũng t&igrave;nh y&ecirc;u</strong>, ngo&agrave;i việc thưởng ngoạn c&aacute;c thắng cảnh thi&ecirc;n nhi&ecirc;n thơ mộng hữu t&igrave;nh với mu&ocirc;n ng&agrave;n hoa khoe sắc. Qu&yacute; kh&aacute;ch c&ograve;n được tham gia vui chơi, giải tr&iacute; với nhiều loại h&igrave;nh đa dạng v&agrave; hấp dẫn như: Đi Cano, Pedalo tr&ecirc;n hồ, Cưỡi ngựa, hoạt động cắm trại, bắn s&uacute;ng sơn, tr&ograve; chơi &ldquo;Giữ thăng bằng tr&ecirc;n d&acirc;y c&aacute;p &ndash; Highwire&rdquo;. Hiện tại,&nbsp;<strong>Thung lũng T&igrave;nh Y&ecirc;u</strong>&nbsp;c&oacute;&nbsp;<strong>xe lửa, xe s&acirc;n golf,&nbsp;</strong>xe sẽ đưa du kh&aacute;ch tham quan ho&agrave;n to&agrave;n miễn ph&iacute; tất cả những cảnh đẹp của Thung Lũng t&igrave;nh y&ecirc;u, v&agrave; l&ecirc;n ngọn đồi cao nhất l&agrave;&nbsp;<strong>&ldquo;Đồi Vọng cảnh</strong>&nbsp;&ndash; Từ đ&acirc;y du kh&aacute;ch c&oacute; thể ph&oacute;ng tầm mắt bao qu&aacute;t, ngắm to&agrave;n cảnh&nbsp;<strong>Thung lũng T&igrave;nh Y&ecirc;u</strong>&nbsp;tr&agrave;n ngập hoa&rdquo;.</p>
<hr/>
', N'/DATA/images/Instruction/4.jpg', NULL)
INSERT [dbo].[Instruction] ([ID], [Name], [CreateDate], [UserName], [Status], [Detail], [Images], [MoreImages]) VALUES (6, N'TTC World – Thung Lũng Tình Yêu', CAST(N'2017-09-18 00:00:00.000' AS DateTime), N'admin', 1, N'<p>Với sự quản l&yacute; của<em>&nbsp;</em><strong>C&ocirc;ng ty CPDL&nbsp;Th&agrave;nh Th&agrave;nh C&ocirc;ng L&acirc;m Đồng</strong><em>,&nbsp;</em>bộ mặt của Khu Du lịch đ&atilde; từng bước thay đổi theo hướng xanh &ndash; sạch &ndash; đẹp,&nbsp;<strong>Thung Lũng T&igrave;nh Y&ecirc;u</strong>&nbsp;giờ đ&acirc;y đ&atilde; trở th&agrave;nh một trong những địa điểm tham quan, d&atilde; ngoại, vui chơi giải tr&iacute; kh&ocirc;ng thể thiếu trong chương tr&igrave;nh&nbsp;Tour&nbsp; Du lịch Đ&agrave; Lạt&nbsp;của du kh&aacute;ch từ mọi miền đất nước đến với Th&agrave;nh phố Đ&agrave; Lạt Mộng Mơ.</p>
<hr/>', N'/DATA/images/Instruction/21.png', NULL)
SET IDENTITY_INSERT [dbo].[Instruction] OFF
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'CHANGE_ACCOUNT', N'Thay đổi mật khẩu')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'CREATE_ACCOUNT', N'Thêm tài khoản')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'CREATE_CONTACT', N'Thêm liên hệ')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'CREATE_CONTENT', N'Thêm nội dung')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'CREATE_INSTRUCTION', N'Thêm giới thiệu')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'CREATE_SLIDER', N'Thêm trình ảnh')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'CREATE_TICKER', N'Thêm bảng giá')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DELETE_ACCOUNT', N'Xóa tài khoản')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DELETE_CONTACT', N'Xóa liên hệ')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DELETE_CONTENT', N'Xóa nội dung')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DELETE_FEEDBACK', N'Xóa yêu cầu')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DELETE_INSTRUCTION', N'Xóa giới thiệu')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DELETE_REQUEST', N'Xóa phản hồi')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DELETE_SLIDER', N'Xóa trình ảnh')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DELETE_TICKER', N'Xóa bảng giá')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DETAILS_ACCOUNT', N'Xem chi tiết tài khoản')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DETAILS_CONTACT', N'Xem chi tiết liên hệ')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DETAILS_CONTENT', N'Xem chi tiết nội dung')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DETAILS_FEEDBACK', N'Xem chi tiết yêu cầu')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DETAILS_INSTRUCTION', N'Xem chi tiết giới thiệu')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DETAILS_REQUEST', N'Xem chi tiết phản hồi')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DETAILS_SLIDER', N'Xem chi tiết trình ảnh')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'DETAILS_TICKER', N'Xem chi tiết bảng giá')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'EDIT_ACCOUNT', N'Sửa tài khoản')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'EDIT_CONTACT', N'Sửa liên hệ')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'EDIT_CONTENT', N'Sửa nội dung')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'EDIT_FEEDBACK', N'Xem chi tiết yêu cầu')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'EDIT_INSTRUCTION', N'Sửa giới thiệu')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'EDIT_REQUEST', N'Xóa phản hồi')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'EDIT_SLIDER', N'Sửa trình ảnh')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'EDIT_TICKER', N'Sửa bảng giá')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'VIEW_ACCOUNT', N'Xem tài khoản')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'VIEW_CONTACT', N'Xem liên hệ')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'VIEW_CONTENT', N'Xem nội dung')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'VIEW_FEEDBACK', N'Xem chi tiết yêu cầu')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'VIEW_INSTRUCTION', N'Xem giới thiệu')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'VIEW_REQUEST', N'Xem chi tiết phản hồi')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'VIEW_SLIDER', N'Xem trình ảnh')
INSERT [dbo].[Path] ([ID], [Name]) VALUES (N'VIEW_TICKER', N'Xem bảng giá')
SET IDENTITY_INSERT [dbo].[Request] ON 

INSERT [dbo].[Request] ([ID], [Name], [Phone], [Email], [CreateDate], [Status], [ContentID], [Detail], [MoreImages]) VALUES (1, N'Vinh', N'123456', N'khanhvinhit@gmail.com', CAST(N'2017-09-15 00:00:00.000' AS DateTime), 1, 1, N'Trên Cao nguyên với độ cao hơn 1500m so với mặt nước biển, du khách vẫn có thể du ngoạn bằng xe Lửa cổ, xe Jeep, xe Điện.', N'<Images><Image>/DATA/Upload/1-k-du-lich-nuoc-ngoai-den-vn-370x250.jpg</Image><Image>/DATA/Upload/1-XE-LUA.jpg</Image></Images>')
INSERT [dbo].[Request] ([ID], [Name], [Phone], [Email], [CreateDate], [Status], [ContentID], [Detail], [MoreImages]) VALUES (2, N'Vinh ka', N'123456789', N'khanhvinhit@gmail.com', CAST(N'2017-09-15 00:00:00.000' AS DateTime), 1, 1, N'Ahihi Đẹp lắm', N'<Images><Image>/DATA/Upload/2-anh-quan-oi-dung-so-v-1504763467-400.jpg</Image><Image>/DATA/Upload/2-chuyen-do-hoi-kho-1504880395-400.jpg</Image></Images>')
SET IDENTITY_INSERT [dbo].[Request] OFF
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([ID], [Name], [DisplayOrder], [Link], [ContentID], [CreateDate], [UserName], [Status], [Description]) VALUES (1, N'VẬN CHUYỂN TRONG KHU DU LỊCH BẰNG XE LỬA', 1, N'/DATA/images/Slider/XE-LUA.jpg', 1, CAST(N'2017-09-15 00:00:00.000' AS DateTime), N'admin', 1, N'Trên Cao nguyên với độ cao hơn 1500m so với mặt nước biển, du khách vẫn có thể du ngoạn bằng xe Lửa cổ, xe Jeep, xe Điện.')
INSERT [dbo].[Slider] ([ID], [Name], [DisplayOrder], [Link], [ContentID], [CreateDate], [UserName], [Status], [Description]) VALUES (2, N'VẬN CHUYỂN TRONG KHU DU LỊCH BẰNG XE JEEP', 2, N'/DATA/images/Slider/XE-DIEN.jpg', 1, CAST(N'2017-09-15 00:00:00.000' AS DateTime), N'admin', 1, N'Trên Cao nguyên với độ cao hơn 1500m so với mặt nước biển, du khách vẫn có thể du ngoạn bằng xe Lửa cổ, xe Jeep, xe Điện.')
SET IDENTITY_INSERT [dbo].[Slider] OFF
SET IDENTITY_INSERT [dbo].[Ticker] ON 

INSERT [dbo].[Ticker] ([ID], [Name], [CreateDate], [UserName], [Status], [Type], [Quantity], [Price], [Description]) VALUES (1, N'Du lịch bằng xe Jeep.', CAST(N'2017-09-15 00:00:00.000' AS DateTime), N'admin', 1, 1, 5, CAST(1500000 AS Decimal(18, 0)), N'5 người trên một xe, quý khách có thể được chở vòng quanh hồ!')
SET IDENTITY_INSERT [dbo].[Ticker] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AccountGroupID]    Script Date: 9/18/2017 10:16:08 AM ******/
CREATE NONCLUSTERED INDEX [IX_AccountGroupID] ON [dbo].[Account]
(
	[AccountGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Account_dbo.AccountGroup_AccountGroupID] FOREIGN KEY([AccountGroupID])
REFERENCES [dbo].[AccountGroup] ([ID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_dbo.Account_dbo.AccountGroup_AccountGroupID]
GO
USE [master]
GO
ALTER DATABASE [TLTY] SET  READ_WRITE 
GO
