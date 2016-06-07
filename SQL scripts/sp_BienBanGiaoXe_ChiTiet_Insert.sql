ALTER PROCEDURE [dbo].[sp_BienBanGiaoXe_ChiTiet_Insert]
	@so_bien_ban nchar(32)
   ,@ma_ccdc nchar(32)
   ,@so_luong tinyint
   ,@so_km_da_su_dung numeric(18,0)
   ,@trang_thai tinyint
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO [dbo].[x_bien_ban_giao_xe_ct]
           ([so_bien_ban]
           ,[ma_ccdc]
           ,[so_luong]
           ,[so_km_da_su_dung]
           ,[trang_thai])
     VALUES
           (@so_bien_ban
           ,@ma_ccdc
           ,@so_luong
           ,@so_km_da_su_dung
           ,@trang_thai)
END