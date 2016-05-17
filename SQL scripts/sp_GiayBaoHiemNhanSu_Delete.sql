CREATE PROCEDURE [dbo].[sp_GiayBaoHiemNhanSu_Delete]
	@ma_giay varchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_giay_bao_hiem_nhan_su_ct] WHERE ma_giay = @ma_giay
	DELETE FROM [dbo].[x_giay_bao_hiem_nhan_su] WHERE ma_giay = @ma_giay
END