CREATE PROCEDURE [dbo].[sp_LichSuKhauHao_Delete] @ma_xe varchar(32), @ngay_hieu_luc smalldatetime
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_lich_su_khau_hao] WHERE [ma_xe] = @ma_xe AND ngay_hieu_luc = @ngay_hieu_luc
END