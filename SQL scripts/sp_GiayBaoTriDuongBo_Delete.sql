CREATE PROCEDURE [dbo].[sp_GiayBaoTriDuongBo_Delete]
	@ma_giay varchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_giay_bao_tri_duong_bo_ct] WHERE ma_giay = @ma_giay
	DELETE FROM [dbo].[x_giay_bao_tri_duong_bo] WHERE ma_giay = @ma_giay
END