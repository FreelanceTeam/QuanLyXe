USE [master]
GO
/****** Object:  Database [thanhan]    Script Date: 5/15/2016 12:28:45 PM ******/
CREATE DATABASE [thanhan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mq_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\thanhan_Data.MDF' , SIZE = 7040KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'mq_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\thanhan_Log.LDF' , SIZE = 2560KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
GO
ALTER DATABASE [thanhan] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [thanhan].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [thanhan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [thanhan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [thanhan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [thanhan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [thanhan] SET ARITHABORT OFF 
GO
ALTER DATABASE [thanhan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [thanhan] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [thanhan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [thanhan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [thanhan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [thanhan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [thanhan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [thanhan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [thanhan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [thanhan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [thanhan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [thanhan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [thanhan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [thanhan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [thanhan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [thanhan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [thanhan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [thanhan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [thanhan] SET  MULTI_USER 
GO
ALTER DATABASE [thanhan] SET PAGE_VERIFY TORN_PAGE_DETECTION  
GO
ALTER DATABASE [thanhan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [thanhan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [thanhan] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [thanhan] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'thanhan', N'ON'
GO
USE [thanhan]
GO
/****** Object:  UserDefinedFunction [dbo].[ff_ExactInlist]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE FUNCTION [dbo].[ff_ExactInlist](@cItem VARCHAR(33), @strList NVARCHAR(4000))  
RETURNS INT
BEGIN 
	DECLARE @nStart INT, @nReturn INT
	SET  @nStart = 1
	SET  @nReturn = 0
	SET @cItem = RTRIM(LTRIM(@cItem))
	SET @strList = RTRIM(LTRIM(@strList)) + ','
	WHILE CHARINDEX(',', @strList,  @nStart) > 0
		BEGIN
			IF RTRIM(LTRIM(@cItem)) = RTRIM(LTRIM(SUBSTRING(@strList, @nStart, CHARINDEX(',', @strList,  @nStart) - @nStart))) 
				BEGIN
					SET @nReturn = 1
					BREAK
				END
			SET @nStart = CHARINDEX(',', @strList,  @nStart) + 1
		END
	RETURN @nReturn
END




GO
/****** Object:  UserDefinedFunction [dbo].[ff_Inlist]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE FUNCTION [dbo].[ff_Inlist](@cItem NVARCHAR(511), @strList NVARCHAR(4000))  
RETURNS INT
BEGIN 
	DECLARE @nStart INT, @nReturn INT
	SET @nStart = 1
	SET @nReturn = 0
	SET @cItem = RTRIM(LTRIM(@cItem))
	SET @strList = RTRIM(LTRIM(@strList)) + ','
	WHILE CHARINDEX(',', @strList,  @nStart) > 0
		BEGIN
			IF @cItem LIKE (RTRIM(LTRIM(SUBSTRING(@strList, @nStart, CHARINDEX(',', @strList,  @nStart) - @nStart))) + '%')
				BEGIN
					SET @nReturn = 1
					BREAK
				END
			SET @nStart = CHARINDEX(',', @strList,  @nStart) + 1
		END
	RETURN @nReturn
END



GO
/****** Object:  UserDefinedFunction [dbo].[tf_GetStartDate]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE FUNCTION [dbo].[tf_GetStartDate](@dS SMALLDATETIME)
RETURNS CHAR(8) AS  
BEGIN 	
	DECLARE @cReturn VARCHAR(8)
	SET  @cReturn = STR(YEAR(@dS), 4) + '0101'	
	RETURN @cReturn
END






GO
/****** Object:  Table [dbo].[dm_bo_phan]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dm_bo_phan](
	[ma_bp] [nchar](32) NOT NULL,
	[ten_bp] [nvarchar](50) NOT NULL,
	[ghi_chu] [nvarchar](50) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_dm_bp] PRIMARY KEY CLUSTERED 
(
	[ma_bp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dm_cong_cu_dung_cu]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dm_cong_cu_dung_cu](
	[ma_ccdc] [nchar](32) NOT NULL,
	[ten_ccdc] [nvarchar](50) NOT NULL,
	[ma_lts] [nchar](32) NOT NULL,
	[ghi_chu] [nvarchar](50) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NULL,
 CONSTRAINT [PK_dm_cong_cu_dung_cu] PRIMARY KEY CLUSTERED 
(
	[ma_ccdc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dm_don_vi_tinh]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dm_don_vi_tinh](
	[ma_dvt] [nchar](32) NOT NULL,
	[ten_dvt] [nvarchar](50) NOT NULL,
	[ghi_chu] [nvarchar](50) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_dm_don_vi_tinh] PRIMARY KEY CLUSTERED 
(
	[ma_dvt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dm_ke_hoach_bao_duong]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dm_ke_hoach_bao_duong](
	[ma_khbd] [nchar](32) NOT NULL,
	[noi_dung] [nvarchar](50) NOT NULL,
	[dinh_ky] [tinyint] NULL,
	[dinh_ky_theo] [char](1) NULL,
	[dinh_ky_km] [numeric](16, 0) NULL,
	[nhac_nho] [tinyint] NULL,
	[nhac_nho_theo] [char](1) NULL,
	[nhac_nho_km] [numeric](16, 0) NULL CONSTRAINT [DF_dm_ke_hoach_bao_duong_nhac_nho_km]  DEFAULT (0),
	[noi_dung_dinh_ky] [nvarchar](50) NULL,
	[noi_dung_nhac_nho] [nvarchar](50) NULL,
	[ghi_chu] [nvarchar](50) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_dm_ke_hoach_bao_duong] PRIMARY KEY CLUSTERED 
(
	[ma_khbd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dm_loai_nhan_vien]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dm_loai_nhan_vien](
	[ma_lnv] [nchar](32) NOT NULL,
	[ten_lnv] [nvarchar](50) NOT NULL,
	[ghi_chu] [nvarchar](50) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_dm_lnv] PRIMARY KEY CLUSTERED 
(
	[ma_lnv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dm_loai_tai_san]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dm_loai_tai_san](
	[ma_lts] [nchar](32) NOT NULL,
	[ten_lts] [nvarchar](50) NOT NULL,
	[ma_nts] [nchar](32) NOT NULL,
	[ma_dvt] [nchar](32) NULL,
	[ghi_chu] [nvarchar](40) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_dm_mat_hang] PRIMARY KEY CLUSTERED 
(
	[ma_lts] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dm_nha_cung_cap]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dm_nha_cung_cap](
	[ma_ncc] [nchar](50) NOT NULL,
	[ten_ncc] [nvarchar](50) NOT NULL,
	[ma_so_thue] [nvarchar](50) NULL,
	[dia_chi] [nvarchar](50) NOT NULL,
	[dien_thoai] [nvarchar](50) NULL,
	[fax] [nvarchar](50) NULL,
	[loai_ncc] [char](1) NULL CONSTRAINT [DF_dm_nha_cung_cap_loai_ncc]  DEFAULT (0),
	[ghi_chu] [nvarchar](50) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_dm_nha_cung_cap] PRIMARY KEY CLUSTERED 
(
	[ma_ncc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dm_nhan_vien]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dm_nhan_vien](
	[ma_nv] [char](16) NOT NULL,
	[ten_nv] [nvarchar](50) NOT NULL,
	[dia_chi] [nvarchar](50) NULL,
	[dien_thoai] [nvarchar](50) NULL,
	[chuc_vu] [nvarchar](50) NULL,
	[ma_bp] [nchar](32) NULL,
	[ma_lnv] [nchar](32) NULL,
	[so_cmnd] [char](15) NULL,
	[ngay_cap] [smalldatetime] NULL,
	[noi_cap] [nvarchar](50) NULL,
	[so_gplx] [char](15) NULL,
	[ngay_cap_gplx] [smalldatetime] NULL,
	[luong_co_ban] [numeric](16, 0) NULL,
	[luong_thu_viec] [numeric](18, 0) NULL,
	[luong_chuyen_can] [numeric](16, 0) NULL,
	[luong_bao_hiem] [numeric](16, 0) NULL,
	[phan_tram_bao_hiem] [numeric](16, 2) NULL,
	[phan_tram_dn] [numeric](16, 2) NULL,
	[hinh_anh] [image] NULL,
	[tinh_trang_work] [smallint] NULL,
	[ngay_lam_viec] [smalldatetime] NULL,
	[ngay_nghi_viec] [smalldatetime] NULL,
	[ngay_cap_nhat] [datetime] NOT NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NOT NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_dm_nv] PRIMARY KEY CLUSTERED 
(
	[ma_nv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dm_nhom_tai_san]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dm_nhom_tai_san](
	[ma_nts] [nchar](32) NOT NULL,
	[ten_nts] [nvarchar](50) NOT NULL,
	[ghi_chu] [nvarchar](50) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_dm_loai_hang] PRIMARY KEY CLUSTERED 
(
	[ma_nts] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dmstt]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dmstt](
	[stt_rec] [numeric](10, 0) NOT NULL,
	[ngay_ks] [smalldatetime] NULL,
 CONSTRAINT [PK_dmstt] PRIMARY KEY CLUSTERED 
(
	[stt_rec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[kho_cong_cu_dung_cu]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kho_cong_cu_dung_cu](
	[stt_rec] [char](13) NOT NULL,
	[ma_ccdc] [nchar](50) NOT NULL,
	[ngay_ct] [smalldatetime] NULL,
	[ma_kho] [nchar](16) NULL,
	[sl_nhap] [numeric](16, 2) NULL,
	[sl_xuat] [numeric](16, 2) NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_cap_nhat] [datetime] NOT NULL,
 CONSTRAINT [PK_kho_cong_cu_dung_cu] PRIMARY KEY CLUSTERED 
(
	[stt_rec] ASC,
	[ma_ccdc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[lookup]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[lookup](
	[code] [char](32) NOT NULL,
	[cfield] [char](32) NULL,
	[ctable] [char](32) NOT NULL,
	[corder] [char](32) NULL,
	[ckey] [char](32) NOT NULL,
	[fields] [varchar](256) NOT NULL,
	[fields2] [varchar](256) NOT NULL,
	[headers] [nvarchar](512) NOT NULL,
	[headers2] [nvarchar](512) NOT NULL,
	[formats] [nvarchar](512) NOT NULL,
	[widths] [varchar](256) NOT NULL,
	[sysfields] [varchar](256) NULL,
	[sysfields2] [varchar](256) NULL,
	[sysheaders] [nvarchar](512) NULL,
	[sysheaders2] [nvarchar](512) NULL,
	[sysformats] [nvarchar](512) NULL,
	[syswidths] [varchar](256) NULL,
	[title] [nvarchar](128) NOT NULL,
	[title2] [nvarchar](128) NOT NULL,
	[nfielddf] [tinyint] NULL,
	[noprdf] [tinyint] NULL,
	[df] [nchar](256) NULL,
	[df2] [nchar](256) NULL,
	[datetime2] [datetime] NULL,
	[xtype] [char](1) NULL,
	[xkeyfield] [char](16) NULL,
	[xkey] [char](16) NULL,
	[xkeyref] [char](16) NULL,
	[xpage] [bit] NULL,
	[x_define] [bit] NULL,
 CONSTRAINT [PK_lookup] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[menu]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[menu](
	[menu_id] [char](8) NOT NULL,
	[menu_id0] [char](8) NOT NULL,
	[bar] [nchar](128) NOT NULL,
	[bar2] [nchar](128) NOT NULL,
	[type] [char](1) NULL,
	[exe] [char](128) NULL,
	[rep_file] [char](27) NULL,
	[title] [nchar](64) NULL,
	[title2] [nchar](64) NULL,
	[web_menu] [tinyint] NULL,
	[web_doc] [char](10) NULL,
	[icon] [char](10) NULL,
	[expl_icon] [tinyint] NULL,
	[sysid] [char](32) NULL,
	[rep_form] [char](32) NULL,
	[syscode] [char](3) NULL,
	[hide_yn] [tinyint] NULL,
	[password] [tinyint] NULL,
	[expl_id] [char](8) NULL,
	[expl_id0] [char](8) NULL,
	[msys] [numeric](1, 0) NULL,
	[xtop] [numeric](5, 2) NULL,
	[xleft] [numeric](5, 2) NULL,
	[sbar] [nvarchar](128) NULL,
	[sbar2] [nvarchar](128) NULL,
	[vc_active] [varchar](256) NULL,
	[mbar] [nchar](66) NULL,
	[mbar2] [nchar](66) NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reports]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reports](
	[form] [char](32) NOT NULL,
	[rep_id] [char](32) NOT NULL,
	[bilingual_fr] [char](5) NOT NULL,
	[rep_text] [nvarchar](128) NULL,
	[rep_text2] [nvarchar](128) NULL,
	[rep_title] [nvarchar](128) NULL,
	[rep_title2] [nvarchar](128) NULL,
	[rep_file] [char](16) NULL,
	[fields] [char](512) NULL,
	[fields2] [char](512) NULL,
	[headers] [nchar](512) NULL,
	[headers2] [nchar](512) NULL,
	[formats] [char](512) NULL,
	[widths] [char](256) NULL,
	[title] [nvarchar](128) NULL,
	[title2] [nvarchar](128) NULL,
	[xtitle] [nvarchar](128) NULL,
	[nfielddf] [tinyint] NULL,
	[noprdf] [tinyint] NULL,
	[cadvtables] [char](24) NULL,
	[cadvjoin1] [char](24) NULL,
	[cadvjoin2] [char](24) NULL,
	[df] [nchar](512) NULL,
	[df2] [nchar](512) NULL,
	[datetime2] [datetime] NULL,
 CONSTRAINT [PK_reports] PRIMARY KEY CLUSTERED 
(
	[form] ASC,
	[rep_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tai_san_may_moc_thiet_bi]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tai_san_may_moc_thiet_bi](
	[ma_tai_san] [nchar](32) NOT NULL,
	[ten_tai_san] [nvarchar](50) NOT NULL,
	[ngay_ct_mua] [smalldatetime] NULL,
	[so_ct_mua] [nchar](32) NULL,
	[hang_san_xuat] [nvarchar](50) NOT NULL,
	[ma_ncc] [nchar](50) NOT NULL,
	[ma_lts] [nchar](32) NULL,
	[ma_dvt] [nchar](32) NULL,
	[nam_san_xuat] [tinyint] NOT NULL,
	[so_nam_su_dung] [tinyint] NULL,
	[so_thang_bao_hanh] [tinyint] NULL,
	[nguyen_gia] [numeric](18, 0) NULL,
	[gia_tri_khau_hao] [numeric](18, 0) NULL,
	[ti_le_khau_hao] [numeric](16, 2) NULL,
	[gia_tri_con_lai] [numeric](18, 0) NULL,
	[tinh_trang] [char](1) NULL,
	[ma_bp] [nchar](32) NULL,
	[ma_nv] [nchar](32) NULL,
	[ma_kho] [nchar](32) NULL,
	[ghi_chu] [nvarchar](200) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_tai_san_may_moc_thiet_bi] PRIMARY KEY CLUSTERED 
(
	[ma_tai_san] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tai_san_xe]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tai_san_xe](
	[ma_xe] [varchar](32) NOT NULL,
	[bien_so] [varchar](32) NOT NULL,
	[hang_san_xuat] [nvarchar](50) NOT NULL,
	[loai_xe] [varchar](32) NOT NULL,
	[ma_lts] [nchar](32) NULL,
	[nam_san_xuat] [smallint] NULL,
	[so_nam_su_dung] [tinyint] NULL,
	[so_may] [char](32) NULL,
	[so_khung] [char](32) NULL,
	[mau] [nvarchar](32) NULL,
	[binh_nhien_lieu] [nchar](15) NULL,
	[loai_nhien_lieu] [nvarchar](32) NULL,
	[trong_tai_the_tich] [numeric](18, 0) NULL,
	[trong_tai_khoi_luong] [numeric](18, 0) NULL,
	[tong_trong_luong] [numeric](18, 0) NULL,
	[nguyen_gia] [numeric](18, 0) NULL,
	[gia_tri_khau_hao] [numeric](18, 0) NULL,
	[ti_le_khau_hao] [numeric](16, 2) NULL,
	[gia_tri_con_lai] [numeric](18, 0) NULL,
	[hinh_anh] [image] NULL,
	[ghi_chu] [nvarchar](200) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_dm_xe] PRIMARY KEY CLUSTERED 
(
	[ma_xe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[userinfo]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userinfo](
	[id] [numeric](3, 0) NOT NULL,
	[name] [char](30) NOT NULL,
	[comment] [nchar](30) NOT NULL,
	[ma_dvcs] [char](16) NOT NULL,
	[comment2] [nchar](30) NULL,
	[password] [nchar](128) NOT NULL,
	[admin] [tinyint] NOT NULL,
	[r_access] [text] NULL,
	[r_new] [text] NULL,
	[r_del] [text] NULL,
	[r_edit] [text] NULL,
	[r_read] [text] NULL,
	[r_print] [text] NULL,
	[r_post] [text] NULL,
	[group_id] [numeric](3, 0) NULL,
	[lastaccess] [datetime] NULL,
	[menu_hide] [text] NULL,
	[status] [char](1) NULL,
	[datetime0] [datetime] NULL,
	[datetime2] [datetime] NULL,
	[user_id0] [numeric](3, 0) NULL,
	[user_id2] [numeric](3, 0) NULL,
	[ma_td1] [char](16) NULL,
	[ma_td2] [char](16) NULL,
	[ma_td3] [char](16) NULL,
	[sl_td1] [numeric](16, 4) NULL,
	[sl_td2] [numeric](16, 4) NULL,
	[sl_td3] [numeric](16, 4) NULL,
	[ngay_td1] [smalldatetime] NULL,
	[ngay_td2] [smalldatetime] NULL,
	[ngay_td3] [smalldatetime] NULL,
	[gc_td1] [nchar](64) NULL,
	[gc_td2] [nchar](64) NULL,
	[gc_td3] [nchar](64) NULL,
	[s1] [char](16) NULL,
	[s2] [char](16) NULL,
	[s3] [char](16) NULL,
	[s4] [numeric](16, 4) NULL,
	[s5] [numeric](16, 4) NULL,
	[s6] [numeric](16, 4) NULL,
	[s7] [smalldatetime] NULL,
	[s8] [smalldatetime] NULL,
	[s9] [smalldatetime] NULL,
	[ngay_cap_nhat] [datetime] NOT NULL,
 CONSTRAINT [PK_userinfo] PRIMARY KEY CLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_bien_ban_giao_xe]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_bien_ban_giao_xe](
	[so_bien_ban] [nchar](32) NOT NULL,
	[ngay_bien_ban] [smalldatetime] NULL,
	[ma_xe] [varchar](32) NOT NULL,
	[ma_tai_xe] [nvarchar](50) NOT NULL,
	[ngay_nhan_xe] [smalldatetime] NULL,
	[so_km_bat_dau] [numeric](4, 0) NULL,
	[ghi_chu] [text] NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_x_lich_su_tai_xe] PRIMARY KEY CLUSTERED 
(
	[so_bien_ban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_bien_ban_giao_xe_ct]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[x_bien_ban_giao_xe_ct](
	[so_bien_ban] [nchar](32) NOT NULL,
	[ma_ccdc] [nchar](32) NOT NULL,
	[so_luong] [tinyint] NOT NULL,
	[so_km_da_su_dung] [numeric](18, 0) NULL,
	[tinh_trang] [tinyint] NULL,
 CONSTRAINT [PK_x_bien_ban_giao_xe_ct] PRIMARY KEY CLUSTERED 
(
	[so_bien_ban] ASC,
	[ma_ccdc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[x_bien_ban_thu_hoi]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_bien_ban_thu_hoi](
	[so_bien_ban] [nchar](32) NOT NULL,
	[ngay_bien_ban] [smalldatetime] NOT NULL,
	[ma_xe] [nchar](32) NOT NULL,
	[ma_tai_xe] [nchar](32) NOT NULL,
	[ngay_ket_thuc] [smalldatetime] NOT NULL,
	[so_km_ket_thuc] [numeric](4, 0) NULL,
	[ly_do_thu_hoi] [nvarchar](100) NULL,
	[ghi_chu] [nvarchar](100) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_x_lich_su_tai_xe_1] PRIMARY KEY CLUSTERED 
(
	[so_bien_ban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_giay_bao_hiem_nhan_su]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_giay_bao_hiem_nhan_su](
	[ma_giay] [varchar](32) NOT NULL,
	[ma_xe] [varchar](32) NOT NULL,
	[don_vi] [nvarchar](50) NULL,
	[ngay_cap_lan_dau] [smalldatetime] NULL,
	[nhac_nho_truoc_ngay] [numeric](4, 0) NULL,
	[hinh_anh] [image] NULL,
	[ghi_chu] [ntext] NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_x_giay_bao_hiem_nhan_su] PRIMARY KEY CLUSTERED 
(
	[ma_giay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_giay_bao_hiem_nhan_su_ct]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_giay_bao_hiem_nhan_su_ct](
	[ma_giay] [varchar](32) NOT NULL,
	[ngay_cap] [smalldatetime] NOT NULL,
	[ngay_het_han] [smalldatetime] NOT NULL,
	[chi_phi] [numeric](18, 0) NULL,
	[ghi_chu] [ntext] NULL,
	[ngay_cap_nhat] [smalldatetime] NULL,
	[nguoi_cap_nhat] [nchar](32) NULL,
	[trang_thai] [char](1) NOT NULL,
 CONSTRAINT [PK_x_giay_bao_hiem_nhan_su_ct] PRIMARY KEY CLUSTERED 
(
	[ma_giay] ASC,
	[ngay_cap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_giay_bao_hiem_than_xe]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_giay_bao_hiem_than_xe](
	[ma_giay] [varchar](32) NOT NULL,
	[ma_xe] [varchar](32) NOT NULL,
	[don_vi] [nvarchar](50) NULL,
	[ngay_cap_lan_dau] [smalldatetime] NULL,
	[nhac_nho_truoc_ngay] [numeric](4, 0) NULL,
	[hinh_anh] [image] NULL,
	[ghi_chu] [ntext] NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_x_giay_bao_hiem_than_xe] PRIMARY KEY CLUSTERED 
(
	[ma_giay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_giay_bao_hiem_than_xe_ct]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_giay_bao_hiem_than_xe_ct](
	[ma_giay] [varchar](32) NOT NULL,
	[ngay_cap] [smalldatetime] NOT NULL,
	[ngay_het_han] [smalldatetime] NOT NULL,
	[chi_phi] [numeric](18, 0) NULL,
	[ghi_chu] [ntext] NULL,
	[ngay_cap_nhat] [smalldatetime] NULL,
	[nguoi_cap_nhat] [nchar](32) NULL,
	[trang_thai] [char](1) NOT NULL,
 CONSTRAINT [PK_x_giay_bao_hiem_than_xe_ct] PRIMARY KEY CLUSTERED 
(
	[ma_giay] ASC,
	[ngay_cap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_giay_bao_tri_duong_bo]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_giay_bao_tri_duong_bo](
	[ma_giay] [varchar](32) NOT NULL,
	[ma_xe] [varchar](32) NOT NULL,
	[don_vi] [nvarchar](50) NULL,
	[ngay_cap_lan_dau] [smalldatetime] NULL,
	[nhac_nho_truoc_ngay] [numeric](4, 0) NULL,
	[hinh_anh] [image] NULL,
	[ghi_chu] [ntext] NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_x_giay_bao_tri_duong_bo] PRIMARY KEY CLUSTERED 
(
	[ma_giay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_giay_bao_tri_duong_bo_ct]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_giay_bao_tri_duong_bo_ct](
	[ma_giay] [varchar](32) NOT NULL,
	[ngay_cap] [smalldatetime] NOT NULL,
	[ngay_het_han] [smalldatetime] NOT NULL,
	[chi_phi] [numeric](18, 0) NULL,
	[ghi_chu] [ntext] NULL,
	[ngay_cap_nhat] [smalldatetime] NULL,
	[nguoi_cap_nhat] [nchar](32) NULL,
	[trang_thai] [char](1) NOT NULL,
 CONSTRAINT [PK_x_giay_bao_tri_duong_bo_ct] PRIMARY KEY CLUSTERED 
(
	[ma_giay] ASC,
	[ngay_cap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_giay_dang_kiem]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_giay_dang_kiem](
	[ma_giay] [varchar](32) NOT NULL,
	[ma_xe] [varchar](32) NOT NULL,
	[don_vi] [nvarchar](50) NULL,
	[ngay_cap_lan_dau] [smalldatetime] NULL,
	[nhac_nho_truoc_ngay] [numeric](4, 0) NULL,
	[hinh_anh] [image] NULL,
	[ghi_chu] [ntext] NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_x_giay_dang_kiem] PRIMARY KEY CLUSTERED 
(
	[ma_giay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_giay_dang_kiem_ct]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_giay_dang_kiem_ct](
	[ma_giay] [varchar](32) NOT NULL,
	[ngay_cap] [smalldatetime] NOT NULL,
	[ngay_het_han] [smalldatetime] NOT NULL,
	[ghi_chu] [ntext] NULL,
	[ngay_cap_nhat] [smalldatetime] NULL,
	[nguoi_cap_nhat] [nchar](32) NULL,
	[trang_thai] [char](1) NOT NULL,
 CONSTRAINT [PK_x_giay_dang_kiem_ct] PRIMARY KEY CLUSTERED 
(
	[ma_giay] ASC,
	[ngay_cap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_giay_dang_ky]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_giay_dang_ky](
	[ma_giay] [varchar](32) NOT NULL,
	[ma_xe] [varchar](32) NOT NULL,
	[don_vi] [nvarchar](50) NULL,
	[ngay_cap_lan_dau] [smalldatetime] NULL,
	[nhac_nho_truoc_ngay] [numeric](4, 0) NULL,
	[hinh_anh] [image] NULL,
	[ghi_chu] [ntext] NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_x_giay_dang_ky] PRIMARY KEY CLUSTERED 
(
	[ma_giay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_giay_dang_ky_ct]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[x_giay_dang_ky_ct](
	[ma_giay] [varchar](32) NOT NULL,
	[ngay_cap] [smalldatetime] NOT NULL,
	[ngay_het_han] [smalldatetime] NOT NULL,
	[ghi_chu] [ntext] NULL,
	[ngay_cap_nhat] [smalldatetime] NULL,
	[nguoi_cap_nhat] [nchar](32) NULL,
	[trang_thai] [char](1) NOT NULL,
 CONSTRAINT [PK_x_giay_dang_ky_ct] PRIMARY KEY CLUSTERED 
(
	[ma_giay] ASC,
	[ngay_cap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[x_phu_tung_kem_theo]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[x_phu_tung_kem_theo](
	[ma_xe] [nchar](32) NOT NULL,
	[ma_tai_san] [nchar](32) NOT NULL,
	[so_luong] [tinyint] NOT NULL,
	[so_km_da_su_dung] [numeric](18, 0) NULL,
	[tinh_trang] [tinyint] NULL,
 CONSTRAINT [PK_x_phu_tung_kem_theo] PRIMARY KEY CLUSTERED 
(
	[ma_xe] ASC,
	[ma_tai_san] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[x_bien_ban_giao_xe_ct] ADD  CONSTRAINT [DF_x_bien_ban_giao_xe_ct_so_luong]  DEFAULT (0) FOR [so_luong]
GO
/****** Object:  StoredProcedure [dbo].[fs_GenerateInserts]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE proc [dbo].[fs_GenerateInserts] @cTableName VARCHAR(32), @sKey VARCHAR(128), @sOrder VARCHAR(128)
AS
BEGIN
/*
	SET NOCOUNT ON
	DECLARE @nColID int, @sColList VARCHAR(8000), @cColName VARCHAR(128), @cStartIns VARCHAR(786), @cDataType VARCHAR(128), @cActValues VARCHAR(8000)
	SELECT @nColID = 0, @cColName = '', @sColList = '', @cActValues = '', @cStartIns = 'INSERT INTO ' + @cTableName
	SELECT @nColID = MIN(ordinal_position) FROM information_schema.COLUMNS (NOLOCK)  WHERE table_name = @cTableName AND data_type NOT IN ('image')
	WHILE @nColID IS NOT NULL
		BEGIN
			SELECT @cColName =column_name, @cDataType = data_type FROM information_schema.COLUMNS (NOLOCK) WHERE ordinal_position = @nColID AND table_name = @cTableName AND data_type NOT IN ('image')
			SET @cActValues = @cActValues + CASE 
				WHEN @cDataType IN ('char','VARCHAR','nchar','NVARCHAR') THEN 'COALESCE(CHAR(78) + '''''''' + REPLACE(RTRIM(' + @cColName + '),'''''''','''''''''''')+'''''''',''NULL'')'
				WHEN @cDataType IN ('datetime','smalldatetime') THEN 'COALESCE('''''''' + RTRIM(CONVERT(char,' + @cColName + ',109))+'''''''',''NULL'')'
				WHEN @cDataType IN ('uniqueidentifier') THEN  	'COALESCE('''''''' + REPLACE(CONVERT(char(255),RTRIM(' + @cColName + ')),'''''''','''''''''''')+'''''''',''NULL'')'
				WHEN @cDataType IN ('text','ntext') THEN  'COALESCE('''''''' + REPLACE(CONVERT(char(8000),' + @cColName + '),'''''''','''''''''''')+'''''''',''NULL'')'					
				WHEN @cDataType IN ('binary','varbinary') THEN  'COALESCE(RTRIM(CONVERT(char,' + 'CONVERT(int,' + @cColName + '))),''NULL'')'  
				WHEN @cDataType IN ('float','real','money','smallmoney')THEN 'COALESCE(LTRIM(RTRIM(' + 'CONVERT(char, ' +  @cColName  + ',2)' + ')),''NULL'')' 
				ELSE 'COALESCE(LTRIM(RTRIM(' + 'CONVERT(char, ' +  @cColName  + ')' + ')),''NULL'')' 
			END   + '+' +  ''',''' + ' + '
			SET @sColList = @sColList +  @cColName + ','	
			SELECT @nColID = MIN(ordinal_position)  FROM information_schema.COLUMNS (NOLOCK) WHERE table_name = @cTableName AND ordinal_position > @nColID AND data_type NOT IN ('image')
		END
	SELECT @sColList = LEFT(@sColList,LEN(@sColList) - 1), @cActValues = LEFT(@cActValues,LEN(@cActValues) - 6)
	SET @cActValues = 'SELECT ' +  '''' + RTRIM(@cStartIns) + ' ''+' + '''(' + RTRIM(@sColList) +  '''+' + ''')''' + ' +''VALUES(''+ ' +  @cActValues  + '+'')''' + ' FROM ' + RTRIM(@cTableName) + ' WHERE ' + @sKey + ' ORDER BY ' + @sOrder
	EXEC (@cActValues)
	SET NOCOUNT OFF
*/
	SET NOCOUNT ON
	DECLARE @nColID int, @sColList VARCHAR(8000), @cColName VARCHAR(128), @cStartIns VARCHAR(786), @cDataType VARCHAR(128), @cActValues VARCHAR(8000), @cActValues1 VARCHAR(8000), @cActValues2 VARCHAR(8000)
	SELECT @nColID = 0, @cColName = '', @sColList = '', @cActValues = '', @cActValues1 = '', @cActValues2 = '', @cStartIns = 'INSERT INTO ' + @cTableName
	SELECT @nColID = MIN(ordinal_position) FROM information_schema.COLUMNS (NOLOCK)  WHERE table_name = @cTableName AND data_type NOT IN ('image')
	WHILE @nColID IS NOT NULL
		BEGIN
			SELECT @cColName = column_name, @cDataType = data_type FROM information_schema.COLUMNS (NOLOCK) WHERE ordinal_position = @nColID AND table_name = @cTableName AND data_type NOT IN ('image')
			IF LEN(@cActValues) < 7500
					SET @cActValues = @cActValues + CASE 
					WHEN @cDataType IN ('char','VARCHAR','nchar','NVARCHAR') THEN 'ISNULL(''N'' + '''''''' + REPLACE(RTRIM(' + @cColName + '),'''''''','''''''''''')+'''''''',''NULL'')'
					WHEN @cDataType IN ('datetime','smalldatetime') THEN 'ISNULL('''''''' + RTRIM(CONVERT(char,' + @cColName + ',109))+'''''''',''NULL'')'
					WHEN @cDataType IN ('uniqueidentifier') THEN  	'ISNULL('''''''' + CONVERT(char(255),RTRIM(' + @cColName + '))+'''''''',''NULL'')'
					WHEN @cDataType IN ('text') THEN  'ISNULL('''''''' + REPLACE(RTRIM(CONVERT(char(8000),' + @cColName + ')),'''''''','''''''''''')+'''''''',''NULL'')'					
					WHEN @cDataType IN ('ntext') THEN  'ISNULL(''N'''''' + REPLACE(RTRIM(CONVERT(nchar(4000),' + @cColName + ')),'''''''','''''''''''')+'''''''',''NULL'')'					
					WHEN @cDataType IN ('binary','varbinary') THEN  'ISNULL(RTRIM(CONVERT(char,' + 'CONVERT(int,' + @cColName + '))),''NULL'')'  
					WHEN @cDataType IN ('float','real','money','smallmoney')THEN 'ISNULL(LTRIM(RTRIM(' + 'CONVERT(char, ' +  @cColName  + ',2)' + ')),''NULL'')' 
					ELSE 'ISNULL(LTRIM(RTRIM(' + 'CONVERT(char, ' +  @cColName  + ')' + ')),''NULL'')' 
				END   + '+' +  ''',''' + ' + '
				ELSE  IF LEN(@cActValues1) < 7500
						SET @cActValues1 = @cActValues1 + CASE 
						WHEN @cDataType IN ('char','VARCHAR','nchar','NVARCHAR') THEN 'ISNULL(''N'' + '''''''' + REPLACE(RTRIM(' + @cColName + '),'''''''','''''''''''')+'''''''',''NULL'')'
						WHEN @cDataType IN ('datetime','smalldatetime') THEN 'ISNULL('''''''' + RTRIM(CONVERT(char,' + @cColName + ',109))+'''''''',''NULL'')'
						WHEN @cDataType IN ('uniqueidentifier') THEN  	'ISNULL('''''''' + CONVERT(char(255),RTRIM(' + @cColName + '))+'''''''',''NULL'')'
						WHEN @cDataType IN ('text') THEN  'ISNULL('''''''' + REPLACE(RTRIM(CONVERT(char(8000),' + @cColName + ')),'''''''','''''''''''')+'''''''',''NULL'')'					
						WHEN @cDataType IN ('ntext') THEN  'ISNULL(''N'''''' + REPLACE(RTRIM(CONVERT(nchar(4000),' + @cColName + ')),'''''''','''''''''''')+'''''''',''NULL'')'					
						WHEN @cDataType IN ('binary','varbinary') THEN  'ISNULL(RTRIM(CONVERT(char,' + 'CONVERT(int,' + @cColName + '))),''NULL'')'  
						WHEN @cDataType IN ('float','real','money','smallmoney')THEN 'ISNULL(LTRIM(RTRIM(' + 'CONVERT(char, ' +  @cColName  + ',2)' + ')),''NULL'')' 
						ELSE 'ISNULL(LTRIM(RTRIM(' + 'CONVERT(char, ' +  @cColName  + ')' + ')),''NULL'')' 
						END   + '+' +  ''',''' + ' + '
					ELSE
							SET @cActValues2 = @cActValues2 + CASE 
							WHEN @cDataType IN ('char','VARCHAR','nchar','NVARCHAR') THEN 'ISNULL(''N'' + '''''''' + REPLACE(RTRIM(' + @cColName + '),'''''''','''''''''''')+'''''''',''NULL'')'
							WHEN @cDataType IN ('datetime','smalldatetime') THEN 'ISNULL('''''''' + RTRIM(CONVERT(char,' + @cColName + ',109))+'''''''',''NULL'')'
							WHEN @cDataType IN ('uniqueidentifier') THEN  	'ISNULL('''''''' + CONVERT(char(255),RTRIM(' + @cColName + '))+'''''''',''NULL'')'
							WHEN @cDataType IN ('text') THEN  'ISNULL('''''''' + REPLACE(RTRIM(CONVERT(char(8000),' + @cColName + ')),'''''''','''''''''''')+'''''''',''NULL'')'					
							WHEN @cDataType IN ('ntext') THEN  'ISNULL(''N'''''' + REPLACE(RTRIM(CONVERT(nchar(4000),' + @cColName + ')),'''''''','''''''''''')+'''''''',''NULL'')'					
							WHEN @cDataType IN ('binary','varbinary') THEN  'ISNULL(RTRIM(CONVERT(char,' + 'CONVERT(int,' + @cColName + '))),''NULL'')'  
							WHEN @cDataType IN ('float','real','money','smallmoney')THEN 'ISNULL(LTRIM(RTRIM(' + 'CONVERT(char, ' +  @cColName  + ',2)' + ')),''NULL'')' 
							ELSE 'ISNULL(LTRIM(RTRIM(' + 'CONVERT(char, ' +  @cColName  + ')' + ')),''NULL'')' 
							END   + '+' +  ''',''' + ' + '
			SET @sColList = @sColList +  @cColName + ','	
			SELECT @nColID = MIN(ordinal_position)  FROM information_schema.COLUMNS (NOLOCK) WHERE table_name = @cTableName AND ordinal_position > @nColID AND data_type NOT IN ('image')
		END

	SELECT @sColList = LEFT(@sColList,LEN(@sColList) - 1)
	IF @cActValues2 <> '' SELECT @cActValues2 = LEFT(@cActValues2,LEN(@cActValues2) - 6) 
		ELSE  IF @cActValues1 <> '' SELECT @cActValues1 = LEFT(@cActValues1,LEN(@cActValues1) - 6)
				ELSE IF @cActValues <> '' SELECT @cActValues = LEFT(@cActValues,LEN(@cActValues) - 6)

	--SET @cActValues = 'SELECT ' +  '''' + RTRIM(@cStartIns) + ' ''+' + '''(' + RTRIM(@sColList) +  '''+' + ''')''' + ' +''VALUES(''+ ' +  @cActValues + @cActValues1+ @cActValues2  + '+'')''' + ' FROM ' + RTRIM(@cTableName) + ' WHERE ' + @sKey + ' ORDER BY ' + @sOrder
	--EXEC (@cActValues)

	DECLARE @cSelect VARCHAR(8000), @cFrom VARCHAR(8000)
	SELECT @cSelect = 'SELECT ' + '''' + RTRIM(@cStartIns) + ' ''+' + '''(' + RTRIM(@sColList) + '''+' + ''')'''+ ' +''VALUES(''+ '
	SELECT @cFrom = '+'')''' + ' FROM ' + RTRIM(@cTableName) + ' WHERE ' + @sKey + ' ORDER BY ' + @sOrder
	EXEC (@cSelect + @cActValues + @cActValues1 + @cActValues2 + @cFrom)

	SET NOCOUNT OFF
END

GO
/****** Object:  StoredProcedure [dbo].[fs_UpdateUFromU2]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[fs_UpdateUFromU2] 
	@cUser VARCHAR(30)
	, @cFromUser VARCHAR(30) 	
AS
BEGIN
	DECLARE @cr_Access VARCHAR(4000)
	SELECT @cr_Access = r_access FROM userinfo WHERE name = @cFromUser
	UPDATE userinfo SET r_access = @cr_Access WHERE name = @cUser	 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetIdentityNumber]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetIdentityNumber] @wsID AS CHAR(1), @cCode CHAR(3), @cTable VARCHAR(33)
AS 
BEGIN
	SET NOCOUNT ON
	DECLARE @strSQL NVARCHAR(4000)
	SET @strSQL = 'DECLARE @MaxIdentityNumber NUMERIC(9)' + CHAR(13)
	SET @strSQL = @strSQL + 'SELECT @MaxIdentityNumber = stt_rec + 1 FROM dmstt' + CHAR(13)
	SET @strSQL = @strSQL + ' WHILE EXISTS (SELECT * FROM ' + RTRIM(@cTable) + ' WHERE stt_rec = ' + CHAR(39) + @wsID + CHAR(39) + ' + REPLACE(STR(@MaxIdentityNumber, 9), % %, %0%) + %' + @cCode + '%)' + CHAR(13)
	SET @strSQL = @strSQL +  'SET @MaxIdentityNumber = @MaxIdentityNumber +1' + CHAR(13)
	SET @strSQL = @strSQL + 'UPDATE dmstt SET stt_rec = @MaxIdentityNumber' + CHAR(13)
	SET @strSQL = @strSQL + 'SELECT (%' + @wsID +'% + REPLACE(STR(@MaxIdentityNumber, 9), % %, %0%) + %' + @cCode + '%) AS IdNumber' + CHAR(13)

	SELECT @strSQL = REPLACE(@strSQL, '%', CHAR(39))

	EXEC sp_executesql @strSQL
	SET NOCOUNT OFF
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKiem_ChiTiet_Delete]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKiem_ChiTiet_Delete]
	@ma_giay varchar(32)
	,@ngay_cap smalldatetime
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_giay_dang_kiem_ct] WHERE ma_giay = @ma_giay AND ngay_cap = @ngay_cap

	IF(NOT EXISTS(SELECT ma_giay FROM [dbo].[x_giay_dang_kiem_ct] WHERE ma_giay = @ma_giay))
		UPDATE [dbo].[x_giay_dang_kiem] SET [ngay_cap_lan_dau] = NULL WHERE ma_giay = @ma_giay
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKiem_ChiTiet_Insert]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKiem_ChiTiet_Insert]
	@ma_giay varchar(32)
	,@ngay_cap smalldatetime
	,@ngay_het_han smalldatetime
	,@ghi_chu ntext
	,@ngay_cap_nhat smalldatetime
	,@nguoi_cap_nhat nchar(32)
	,@trang_thai char(1)
AS
BEGIN
	SET NOCOUNT OFF;

	IF(NOT EXISTS(SELECT ma_giay FROM [dbo].[x_giay_dang_kiem_ct] WHERE ma_giay = @ma_giay))
		UPDATE [dbo].[x_giay_dang_kiem] SET [ngay_cap_lan_dau] = @ngay_cap WHERE ma_giay = @ma_giay
	
	IF(EXISTS(SELECT ma_giay FROM [dbo].[x_giay_dang_kiem_ct] WHERE ma_giay = @ma_giay AND ngay_het_han < getdate()))
		UPDATE [dbo].[x_giay_dang_kiem_ct] SET @trang_thai = '0' WHERE ma_giay = @ma_giay AND ngay_het_han < getdate()

	INSERT INTO [dbo].[x_giay_dang_kiem_ct]
		([ma_giay]
		,[ngay_cap]
		,[ngay_het_han]
		,[ghi_chu]
		,[ngay_cap_nhat]
		,[nguoi_cap_nhat]
		,[trang_thai])
	VALUES
		(@ma_giay
		,@ngay_cap
		,@ngay_het_han
		,@ghi_chu
		,@ngay_cap_nhat
		,@nguoi_cap_nhat
		,@trang_thai)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKiem_ChiTiet_Update]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKiem_ChiTiet_Update]
	@ma_giay varchar(32)
	,@ngay_cap smalldatetime
	,@ngay_het_han smalldatetime
	,@ghi_chu ntext
	,@ngay_cap_nhat smalldatetime
	,@nguoi_cap_nhat nchar(32)
	,@trang_thai char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_giay_dang_kiem_ct]
	SET [ngay_het_han] = @ngay_het_han
		,[ghi_chu] = @ghi_chu
		,[ngay_cap_nhat] = @ngay_cap_nhat
		,[nguoi_cap_nhat] = @nguoi_cap_nhat
		,[trang_thai] = @trang_thai
	WHERE  ma_giay = @ma_giay AND ngay_cap = @ngay_cap
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKiem_Delete]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKiem_Delete]
	@ma_giay varchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_giay_dang_kiem_ct] WHERE ma_giay = @ma_giay
	DELETE FROM [dbo].[x_giay_dang_kiem] WHERE ma_giay = @ma_giay
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKiem_Insert]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKiem_Insert]
	@ma_giay varchar(32)
	,@ma_xe varchar(32)
	,@don_vi nvarchar(50)
	,@ngay_cap_lan_dau smalldatetime
	,@nhac_nho_truoc_ngay numeric(4,0)
	,@hinh_anh image
	,@ghi_chu ntext
	,@ngay_cap_nhat datetime
	,@nguoi_cap_nhat nvarchar(50)
	,@ngay_tao datetime
	,@nguoi_tao nvarchar(50)
	,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO [dbo].[x_giay_dang_kiem]
           ([ma_giay]
           ,[ma_xe]
           ,[don_vi]
           ,[ngay_cap_lan_dau]
           ,[nhac_nho_truoc_ngay]
           ,[hinh_anh]
           ,[ghi_chu]
           ,[ngay_cap_nhat]
           ,[nguoi_cap_nhat]
           ,[ngay_tao]
           ,[nguoi_tao]
           ,[status])
     VALUES
           (@ma_giay
           ,@ma_xe
           ,@don_vi
           ,@ngay_cap_lan_dau
           ,@nhac_nho_truoc_ngay
           ,@hinh_anh
           ,@ghi_chu
           ,@ngay_cap_nhat
           ,@nguoi_cap_nhat
           ,@ngay_tao
           ,@nguoi_tao
           ,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKiem_Update]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKiem_Update]
	@ma_giay varchar(32)
	,@ma_xe varchar(32)
	,@don_vi nvarchar(50)
	,@ngay_cap_lan_dau smalldatetime
	,@nhac_nho_truoc_ngay numeric(4,0)
	,@hinh_anh image
	,@ghi_chu ntext
	,@ngay_cap_nhat datetime
	,@nguoi_cap_nhat nvarchar(50)
	,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_giay_dang_kiem]
	   SET [don_vi] = @don_vi		  
		  ,[nhac_nho_truoc_ngay] = @nhac_nho_truoc_ngay
		  ,[hinh_anh] = @hinh_anh
		  ,[ghi_chu] = @ghi_chu
		  ,[ngay_cap_nhat] = @ngay_cap_nhat
		  ,[nguoi_cap_nhat] = @nguoi_cap_nhat
		  ,[status] = @status
	 WHERE ma_giay = @ma_giay
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKy_ChiTiet_Delete]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKy_ChiTiet_Delete]
	@ma_giay varchar(32)
	,@ngay_cap smalldatetime
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_giay_dang_ky_ct] WHERE ma_giay = @ma_giay AND ngay_cap = @ngay_cap

	IF(NOT EXISTS(SELECT ma_giay FROM [dbo].[x_giay_dang_ky_ct] WHERE ma_giay = @ma_giay))
		UPDATE [dbo].[x_giay_dang_ky] SET [ngay_cap_lan_dau] = NULL WHERE ma_giay = @ma_giay
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKy_ChiTiet_Insert]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKy_ChiTiet_Insert]
	@ma_giay varchar(32)
	,@ngay_cap smalldatetime
	,@ngay_het_han smalldatetime
	,@ghi_chu ntext
	,@ngay_cap_nhat smalldatetime
	,@nguoi_cap_nhat nchar(32)
	,@trang_thai char(1)
AS
BEGIN
	SET NOCOUNT OFF;

	IF(NOT EXISTS(SELECT ma_giay FROM [dbo].[x_giay_dang_ky_ct] WHERE ma_giay = @ma_giay))
		UPDATE [dbo].[x_giay_dang_ky] SET [ngay_cap_lan_dau] = @ngay_cap WHERE ma_giay = @ma_giay
	
	IF(EXISTS(SELECT ma_giay FROM [dbo].[x_giay_dang_ky_ct] WHERE ma_giay = @ma_giay AND ngay_het_han < getdate()))
		UPDATE [dbo].[x_giay_dang_ky_ct] SET @trang_thai = '0' WHERE ma_giay = @ma_giay AND ngay_het_han < getdate()

	INSERT INTO [dbo].[x_giay_dang_ky_ct]
		([ma_giay]
		,[ngay_cap]
		,[ngay_het_han]
		,[ghi_chu]
		,[ngay_cap_nhat]
		,[nguoi_cap_nhat]
		,[trang_thai])
	VALUES
		(@ma_giay
		,@ngay_cap
		,@ngay_het_han
		,@ghi_chu
		,@ngay_cap_nhat
		,@nguoi_cap_nhat
		,@trang_thai)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKy_ChiTiet_Update]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKy_ChiTiet_Update]
	@ma_giay varchar(32)
	,@ngay_cap smalldatetime
	,@ngay_het_han smalldatetime
	,@ghi_chu ntext
	,@ngay_cap_nhat smalldatetime
	,@nguoi_cap_nhat nchar(32)
	,@trang_thai char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_giay_dang_ky_ct]
	SET [ngay_het_han] = @ngay_het_han
		,[ghi_chu] = @ghi_chu
		,[ngay_cap_nhat] = @ngay_cap_nhat
		,[nguoi_cap_nhat] = @nguoi_cap_nhat
		,[trang_thai] = @trang_thai
	WHERE  ma_giay = @ma_giay AND ngay_cap = @ngay_cap
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKy_Delete]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKy_Delete]
	@ma_giay varchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_giay_dang_ky_ct] WHERE ma_giay = @ma_giay
	DELETE FROM [dbo].[x_giay_dang_ky] WHERE ma_giay = @ma_giay
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKy_Insert]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKy_Insert]
	@ma_giay varchar(32)
	,@ma_xe varchar(32)
	,@don_vi nvarchar(50)
	,@ngay_cap_lan_dau smalldatetime
	,@nhac_nho_truoc_ngay numeric(4,0)
	,@hinh_anh image
	,@ghi_chu ntext
	,@ngay_cap_nhat datetime
	,@nguoi_cap_nhat nvarchar(50)
	,@ngay_tao datetime
	,@nguoi_tao nvarchar(50)
	,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO [dbo].[x_giay_dang_ky]
           ([ma_giay]
           ,[ma_xe]
           ,[don_vi]
           ,[ngay_cap_lan_dau]
           ,[nhac_nho_truoc_ngay]
           ,[hinh_anh]
           ,[ghi_chu]
           ,[ngay_cap_nhat]
           ,[nguoi_cap_nhat]
           ,[ngay_tao]
           ,[nguoi_tao]
           ,[status])
     VALUES
           (@ma_giay
           ,@ma_xe
           ,@don_vi
           ,@ngay_cap_lan_dau
           ,@nhac_nho_truoc_ngay
           ,@hinh_anh
           ,@ghi_chu
           ,@ngay_cap_nhat
           ,@nguoi_cap_nhat
           ,@ngay_tao
           ,@nguoi_tao
           ,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GiayDangKy_Update]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiayDangKy_Update]
	@ma_giay varchar(32)
	,@ma_xe varchar(32)
	,@don_vi nvarchar(50)
	,@ngay_cap_lan_dau smalldatetime
	,@nhac_nho_truoc_ngay numeric(4,0)
	,@hinh_anh image
	,@ghi_chu ntext
	,@ngay_cap_nhat datetime
	,@nguoi_cap_nhat nvarchar(50)
	,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_giay_dang_ky]
	   SET [don_vi] = @don_vi		  
		  ,[nhac_nho_truoc_ngay] = @nhac_nho_truoc_ngay
		  ,[hinh_anh] = @hinh_anh
		  ,[ghi_chu] = @ghi_chu
		  ,[ngay_cap_nhat] = @ngay_cap_nhat
		  ,[nguoi_cap_nhat] = @nguoi_cap_nhat
		  ,[status] = @status
	 WHERE ma_giay = @ma_giay
END


GO
/****** Object:  StoredProcedure [dbo].[sp_PhuTung_Delete]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhuTung_Delete] 
	@ma_xe varchar(32)
	,@ma_tai_san nchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_phu_tung_kem_theo] WHERE [ma_xe] = @ma_xe AND ma_tai_san = @ma_tai_san
END



GO
/****** Object:  StoredProcedure [dbo].[sp_PhuTung_Insert]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhuTung_Insert]
	@ma_xe nchar(32)
	,@ma_tai_san nchar(32)
	,@so_luong tinyint
	,@so_km_da_su_dung numeric(18,0)
	,@tinh_trang tinyint
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO [dbo].[x_phu_tung_kem_theo]
           ([ma_xe]
           ,[ma_tai_san]
           ,[so_luong]
           ,[so_km_da_su_dung]
           ,[tinh_trang])
     VALUES
           (@ma_xe
           ,@ma_tai_san
           ,@so_luong
           ,@so_km_da_su_dung
           ,@tinh_trang)
END



GO
/****** Object:  StoredProcedure [dbo].[sp_PhuTung_Update]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhuTung_Update]
	@ma_xe nchar(32)
	,@ma_tai_san nchar(32)
	,@so_luong tinyint
	,@so_km_da_su_dung numeric(18,0)
	,@tinh_trang tinyint
AS
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_phu_tung_kem_theo]
	   SET [so_luong] = @so_luong
		  ,[so_km_da_su_dung] = @so_km_da_su_dung
		  ,[tinh_trang] = @tinh_trang
	 WHERE [ma_xe] = @ma_xe AND ma_tai_san = @ma_tai_san

GO
/****** Object:  StoredProcedure [dbo].[sp_TaiSanXe_Delete]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TaiSanXe_Delete] @ma_xe varchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[tai_san_xe] WHERE [ma_xe] = @ma_xe
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TaiSanXe_Insert]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TaiSanXe_Insert]
	@ma_xe varchar(32)
	,@bien_so varchar(32)
	,@hang_san_xuat nvarchar(50)
	,@loai_xe varchar(32)
	,@ma_lts nchar(32)
	,@nam_san_xuat smallint
	,@so_nam_su_dung tinyint
	,@so_may char(32)
	,@so_khung char(32)
	,@mau nvarchar(32)
	,@binh_nhien_lieu nchar(15)
	,@loai_nhien_lieu nvarchar(32)
	,@trong_tai_the_tich numeric(18,0)
	,@trong_tai_khoi_luong numeric(18,0)
	,@tong_trong_luong numeric(18,0)
	,@nguyen_gia numeric(18,0)
	,@gia_tri_khau_hao numeric(18,0)
	,@ti_le_khau_hao numeric(16,2)
	,@gia_tri_con_lai numeric(18,0)
	,@hinh_anh image
	,@ghi_chu nvarchar(200)
	,@ngay_cap_nhat datetime
	,@nguoi_cap_nhat nvarchar(50)
	,@ngay_tao datetime
	,@nguoi_tao nvarchar(50)
	,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO [dbo].[tai_san_xe]
           ([ma_xe]
           ,[bien_so]
           ,[hang_san_xuat]
           ,[loai_xe]
           ,[ma_lts]
           ,[nam_san_xuat]
           ,[so_nam_su_dung]
           ,[so_may]
           ,[so_khung]
           ,[mau]
           ,[binh_nhien_lieu]
           ,[loai_nhien_lieu]
           ,[trong_tai_the_tich]
           ,[trong_tai_khoi_luong]
           ,[tong_trong_luong]
           ,[nguyen_gia]
           ,[gia_tri_khau_hao]
           ,[ti_le_khau_hao]
           ,[gia_tri_con_lai]
           ,[hinh_anh]
           ,[ghi_chu]
           ,[ngay_cap_nhat]
           ,[nguoi_cap_nhat]
           ,[ngay_tao]
           ,[nguoi_tao]
           ,[status])
     VALUES
           (@ma_xe
			,@bien_so
			,@hang_san_xuat
			,@loai_xe
			,@ma_lts
			,@nam_san_xuat
			,@so_nam_su_dung
			,@so_may
			,@so_khung
			,@mau
			,@binh_nhien_lieu
			,@loai_nhien_lieu
			,@trong_tai_the_tich
			,@trong_tai_khoi_luong
			,@tong_trong_luong
			,@nguyen_gia
			,@gia_tri_khau_hao
			,@ti_le_khau_hao
			,@gia_tri_con_lai
			,@hinh_anh
			,@ghi_chu
			,@ngay_cap_nhat
			,@nguoi_cap_nhat
			,@ngay_tao
			,@nguoi_tao
			,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[sp_TaiSanXe_Update]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TaiSanXe_Update]
	@ma_xe varchar(32)
	,@bien_so varchar(32)
	,@hang_san_xuat nvarchar(50)
	,@loai_xe varchar(32)
	,@ma_lts nchar(32)
	,@nam_san_xuat smallint
	,@so_nam_su_dung tinyint
	,@so_may char(32)
	,@so_khung char(32)
	,@mau nvarchar(32)
	,@binh_nhien_lieu nchar(15)
	,@loai_nhien_lieu nvarchar(32)
	,@trong_tai_the_tich numeric(18,0)
	,@trong_tai_khoi_luong numeric(18,0)
	,@tong_trong_luong numeric(18,0)
	,@nguyen_gia numeric(18,0)
	,@gia_tri_khau_hao numeric(18,0)
	,@ti_le_khau_hao numeric(16,2)
	,@gia_tri_con_lai numeric(18,0)
	,@hinh_anh image
	,@ghi_chu nvarchar(200)
	,@ngay_cap_nhat datetime
	,@nguoi_cap_nhat nvarchar(50)
	,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[tai_san_xe]
		SET [bien_so] = @bien_so
		,[hang_san_xuat] = @hang_san_xuat
		,[loai_xe] = @loai_xe
		,[ma_lts] = @ma_lts
		,[nam_san_xuat] = @nam_san_xuat
		,[so_nam_su_dung] = @so_nam_su_dung
		,[so_may] = @so_may
		,[so_khung] = @so_khung
		,[mau] = @mau
		,[binh_nhien_lieu] = @binh_nhien_lieu
		,[loai_nhien_lieu] = @loai_nhien_lieu
		,[trong_tai_the_tich] = @trong_tai_the_tich
		,[trong_tai_khoi_luong] = @trong_tai_khoi_luong
		,[tong_trong_luong] = @tong_trong_luong
		,[nguyen_gia] = @nguyen_gia
		,[gia_tri_khau_hao] = @gia_tri_khau_hao
		,[ti_le_khau_hao] = @ti_le_khau_hao
		,[gia_tri_con_lai] = @gia_tri_con_lai
		,[hinh_anh] = @hinh_anh
		,[ghi_chu] = @ghi_chu
		,[ngay_cap_nhat] = @ngay_cap_nhat
		,[nguoi_cap_nhat] = @nguoi_cap_nhat
		,[status] = @status
		WHERE [ma_xe] = @ma_xe
END
GO
/****** Object:  StoredProcedure [dbo].[ts_GetMenuRight]    Script Date: 5/15/2016 12:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ts_GetMenuRight]
AS
BEGIN
	DECLARE @strsql NVARCHAR(4000), @strsql_tmp NVARCHAR(4000)
	SELECT * INTO #cmd FROM menu ORDER BY Menu_id

	INSERT INTO #cmd(menu_id, menu_id0, bar, bar2) 
		SELECT LEFT((menu_id), 5) + '.01', menu_id, N'Mới', N'New' FROM #cmd WHERE type IN ('D', 'V')
		UNION ALL SELECT LEFT((menu_id), 5) + '.02', menu_id, N'Sửa', N'Edit' FROM #cmd WHERE type IN ('D', 'V')
		UNION ALL SELECT LEFT((menu_id), 5) + '.03', menu_id, N'Xóa', N'Delete' FROM #cmd WHERE type IN ('D', 'V')
		UNION ALL SELECT LEFT((menu_id), 5) + '.04', menu_id, N'In', N'Print' FROM #cmd WHERE type IN ('D', 'V')
		
	SELECT * FROM #cmd ORDER BY menu_id
END


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'M-Thang, D-Ngay, W-Tuan, Y-Nam' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dm_ke_hoach_bao_duong', @level2type=N'COLUMN',@level2name=N'dinh_ky_theo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'M-Thang, D-Ngay, W-Tuan, Y-Nam' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dm_ke_hoach_bao_duong', @level2type=N'COLUMN',@level2name=N'nhac_nho_theo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0-NCC, 1- NCC Noi Bo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dm_nha_cung_cap', @level2type=N'COLUMN',@level2name=N'loai_ncc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 - Chinh thuc, 1- Thu viec' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dm_nhan_vien', @level2type=N'COLUMN',@level2name=N'tinh_trang_work'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Y-Da su dung, N-Chua su dung, H-Da bi hu hong' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tai_san_may_moc_thiet_bi', @level2type=N'COLUMN',@level2name=N'tinh_trang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tai_san_may_moc_thiet_bi', @level2type=N'COLUMN',@level2name=N'ma_kho'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lay tu danh muc loai tai san voi nhom la XE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tai_san_xe', @level2type=N'COLUMN',@level2name=N'ma_lts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1- Gan tren xe dang su dung, 2- Gan du phong, 3 - Phu kien kem theo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'x_bien_ban_giao_xe_ct', @level2type=N'COLUMN',@level2name=N'tinh_trang'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tu dong gen: GDK+MAXE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'x_giay_dang_ky', @level2type=N'COLUMN',@level2name=N'ma_giay'
GO
USE [master]
GO
ALTER DATABASE [thanhan] SET  READ_WRITE 
GO
