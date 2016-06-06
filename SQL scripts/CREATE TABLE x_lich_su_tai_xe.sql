CREATE TABLE [dbo].[x_lich_su_tai_xe](
	[ma_xe] [varchar](32) NOT NULL,
	[ma_tai_xe] [char](16) NOT NULL,
	[so_km_bat_dau] [numeric](18, 0) NULL,
	[so_km_ket_thuc] [numeric](18, 0) NULL,
	[ngay_bat_dau] [smalldatetime] NULL,
	[ngay_ket_thuc] [smalldatetime] NULL,
	[trang_thai] [char](1) NULL,
	[ngay_cap_nhat] [datetime] NULL,
	[nguoi_cap_nhat] [nvarchar](50) NULL,
	[ngay_tao] [datetime] NULL,
	[nguoi_tao] [nvarchar](50) NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_x_lich_su_tai_xe_2] PRIMARY KEY CLUSTERED 
(
	[ma_xe] ASC,
	[ma_tai_xe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO