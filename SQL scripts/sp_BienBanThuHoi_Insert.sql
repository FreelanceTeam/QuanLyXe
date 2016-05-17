CREATE PROCEDURE [dbo].[sp_BienBanThuHoi_Insert]
	@so_bien_ban nchar(32)
	,@ngay_bien_ban smalldatetime
	,@ma_xe nchar(32)
	,@ma_tai_xe nchar(32)
	,@ngay_ket_thuc smalldatetime
	,@so_km_ket_thuc numeric(4,0)
	,@ly_do_thu_hoi nvarchar(100)
	,@ghi_chu nvarchar(100)
	,@ngay_cap_nhat datetime
	,@nguoi_cap_nhat nvarchar(50)
	,@ngay_tao datetime
	,@nguoi_tao nvarchar(50)
	,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO [dbo].[x_bien_ban_thu_hoi]
           ([so_bien_ban]
           ,[ngay_bien_ban]
           ,[ma_xe]
           ,[ma_tai_xe]
           ,[ngay_ket_thuc]
           ,[so_km_ket_thuc]
           ,[ly_do_thu_hoi]
           ,[ghi_chu]
           ,[ngay_cap_nhat]
           ,[nguoi_cap_nhat]
           ,[ngay_tao]
           ,[nguoi_tao]
           ,[status])
     VALUES
           (@so_bien_ban
           ,@ngay_bien_ban
           ,@ma_xe
           ,@ma_tai_xe
           ,@ngay_ket_thuc
           ,@so_km_ket_thuc
           ,@ly_do_thu_hoi
           ,@ghi_chu
           ,@ngay_cap_nhat
           ,@nguoi_cap_nhat
           ,@ngay_tao
           ,@nguoi_tao
           ,@status)
END


