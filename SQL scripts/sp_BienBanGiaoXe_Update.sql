CREATE PROCEDURE [dbo].[sp_BienBanGiaoXe_Update]
	@so_bien_ban nchar(32) 
   ,@ngay_bien_ban smalldatetime 
   ,@ma_xe varchar(32) 
   ,@ma_tai_xe nvarchar(50) 
   ,@ngay_nhan_xe smalldatetime 
   ,@so_km_bat_dau numeric(4,0) 
   ,@ghi_chu text 
   ,@ngay_cap_nhat datetime 
   ,@nguoi_cap_nhat nvarchar(50) 
   ,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_bien_ban_giao_xe]
	SET [ngay_bien_ban] = @ngay_bien_ban
	  ,[ma_xe] = @ma_xe
	  ,[ma_tai_xe] = @ma_tai_xe
	  ,[ngay_nhan_xe] = @ngay_nhan_xe
	  ,[so_km_bat_dau] = @so_km_bat_dau
	  ,[ghi_chu] = @ghi_chu
	  ,[ngay_cap_nhat] = @ngay_cap_nhat
	  ,[nguoi_cap_nhat] = @nguoi_cap_nhat
	  ,[status] = @status
	WHERE so_bien_ban = @so_bien_ban
END


