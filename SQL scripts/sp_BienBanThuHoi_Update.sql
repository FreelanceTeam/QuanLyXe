CREATE PROCEDURE [dbo].[sp_BienBanThuHoi_Update]
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
	,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_bien_ban_thu_hoi]
   SET [ngay_bien_ban] = @ngay_bien_ban
      ,[ma_xe] = @ma_xe
      ,[ma_tai_xe] = @ma_tai_xe
      ,[ngay_ket_thuc] = @ngay_ket_thuc
      ,[so_km_ket_thuc] = @so_km_ket_thuc
      ,[ly_do_thu_hoi] = @ly_do_thu_hoi
      ,[ghi_chu] = @ghi_chu
      ,[ngay_cap_nhat] = @ngay_cap_nhat
      ,[nguoi_cap_nhat] = @nguoi_cap_nhat
      ,[status] = @status
 WHERE so_bien_ban = @so_bien_ban
END


