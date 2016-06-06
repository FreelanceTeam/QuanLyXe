CREATE PROCEDURE [dbo].[sp_LichSuTaiXe_Delete]
	@ma_xe varchar(32)
	,@ma_tai_xe char(16)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_lich_su_tai_xe] WHERE ma_xe = @ma_xe AND ma_tai_xe = @ma_tai_xe
END