ALTER PROCEDURE [dbo].[sp_BienBanGiaoXe_ChiTiet_Delete]
	@so_bien_ban nchar(32)
   ,@ma_ccdc nchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_bien_ban_giao_xe_ct] WHERE so_bien_ban = @so_bien_ban AND ma_ccdc = @ma_ccdc
END


