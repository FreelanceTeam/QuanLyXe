CREATE PROCEDURE [dbo].[sp_GiayBaoHiemThanXe_Delete]
	@ma_giay varchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_giay_bao_hiem_than_xe_ct] WHERE ma_giay = @ma_giay
	DELETE FROM [dbo].[x_giay_bao_hiem_than_xe] WHERE ma_giay = @ma_giay
END