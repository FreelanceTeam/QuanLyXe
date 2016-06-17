USE [thanhan]
GO

/****** Object:  Table [dbo].[ts_lich_su_khau_hao]    Script Date: 06/03/2016 15:45:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ts_lich_su_khau_hao]') AND type in (N'U'))
DROP TABLE [dbo].[ts_lich_su_khau_hao]
GO

USE [thanhan]
GO

/****** Object:  Table [dbo].[ts_lich_su_khau_hao]    Script Date: 06/03/2016 15:45:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ts_lich_su_khau_hao]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ts_lich_su_khau_hao](
	[ma_tai_san] [nchar](32) NOT NULL,
	[ngay_hieu_luc] [smalldatetime] NOT NULL,
	[gia_tri_khau_hao] [numeric](18, 0) NULL,
	[ti_le_khau_hao] [numeric](16, 2) NULL,
	[gia_tri_con_lai] [numeric](18, 0) NULL,
	[gia_tri_trich_kh_nam] [numeric](18, 0) NULL,
	[gia_tri_trich_kh_thang] [numeric](18, 0) NULL,
	[ghi_chu] [nvarchar](100) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_ts_lich_su_khau_hao] PRIMARY KEY CLUSTERED 
(
	[ma_tai_san] ASC,
	[ngay_hieu_luc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_PADDING OFF
GO

