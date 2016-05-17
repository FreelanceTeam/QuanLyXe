CREATE PROCEDURE [dbo].[sp_GiayBaoTriDuongBo_ChiTiet_Delete]
	@ma_giay varchar(32)
	,@ngay_cap smalldatetime
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_giay_bao_tri_duong_bo_ct] WHERE ma_giay = @ma_giay AND ngay_cap = @ngay_cap

	IF(NOT EXISTS(SELECT ma_giay FROM [dbo].[x_giay_bao_tri_duong_bo_ct] WHERE ma_giay = @ma_giay))
		UPDATE [dbo].[x_giay_bao_tri_duong_bo] SET [ngay_cap_lan_dau] = NULL WHERE ma_giay = @ma_giay
END


