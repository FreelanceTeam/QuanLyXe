CREATE PROCEDURE [dbo].[sp_GiayBaoHiemThanXe_ChiTiet_Delete]
	@ma_giay varchar(32)
	,@ngay_cap smalldatetime
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_giay_bao_hiem_than_xe_ct] WHERE ma_giay = @ma_giay AND ngay_cap = @ngay_cap

	IF(NOT EXISTS(SELECT ma_giay FROM [dbo].[x_giay_bao_hiem_than_xe_ct] WHERE ma_giay = @ma_giay))
		UPDATE [dbo].[x_giay_bao_hiem_than_xe] SET [ngay_cap_lan_dau] = NULL WHERE ma_giay = @ma_giay
END


