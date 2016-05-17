CREATE PROCEDURE [dbo].[sp_BienBanThuHoi_Delete]
	@so_bien_ban nchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_bien_ban_thu_hoi] WHERE so_bien_ban = @so_bien_ban
END