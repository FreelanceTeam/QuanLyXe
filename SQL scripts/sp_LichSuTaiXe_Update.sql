CREATE PROCEDURE [dbo].[sp_LichSuTaiXe_Update]
	@ma_xe varchar(32)
   ,@ma_tai_xe char(16)
   ,@so_km_bat_dau numeric(18,0)
   ,@so_km_ket_thuc numeric(18,0)
   ,@ngay_bat_dau smalldatetime
   ,@ngay_ket_thuc smalldatetime
   ,@trang_thai char(1)
   ,@ngay_cap_nhat datetime
   ,@nguoi_cap_nhat nvarchar(50)
   ,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_lich_su_tai_xe]
	SET [so_km_bat_dau] = @so_km_bat_dau
	  ,[so_km_ket_thuc] = @so_km_ket_thuc
	  ,[ngay_bat_dau] = @ngay_bat_dau
	  ,[ngay_ket_thuc] = @ngay_ket_thuc
	  ,[trang_thai] = @trang_thai
	  ,[ngay_cap_nhat] = @ngay_cap_nhat
	  ,[nguoi_cap_nhat] = @nguoi_cap_nhat
	  ,[status] = @status
	WHERE [ma_xe] = @ma_xe AND [ma_tai_xe] = @ma_tai_xe
END


