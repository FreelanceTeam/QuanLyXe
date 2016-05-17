CREATE PROCEDURE [dbo].[sp_BienBanGiaoXe_ChiTiet_Update]
	@so_bien_ban nchar(32)
   ,@ma_ccdc nchar(32)
   ,@so_luong tinyint
   ,@so_km_da_su_dung numeric(18,0)
   ,@tinh_trang tinyint
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_bien_ban_giao_xe_ct]
	SET [so_luong] = @so_luong
      ,[so_km_da_su_dung] = @so_km_da_su_dung
      ,[tinh_trang] = @tinh_trang
	WHERE  so_bien_ban = @so_bien_ban AND ma_ccdc = @ma_ccdc
END


