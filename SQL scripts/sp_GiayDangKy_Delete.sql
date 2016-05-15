CREATE PROCEDURE [dbo].[sp_GiayDangKy_Delete]
	@ma_giay varchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_giay_dang_ky_ct] WHERE ma_giay = @ma_giay
	DELETE FROM [dbo].[x_giay_dang_ky] WHERE ma_giay = @ma_giay
END