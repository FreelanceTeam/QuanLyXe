CREATE PROCEDURE [dbo].[sp_BienBanGiaoXe_Delete]
	@so_bien_ban nchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_bien_ban_giao_xe_ct] WHERE so_bien_ban = @so_bien_ban
	DELETE FROM [dbo].[x_bien_ban_giao_xe] WHERE so_bien_ban = @so_bien_ban
END