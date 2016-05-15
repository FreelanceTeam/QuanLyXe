CREATE PROCEDURE [dbo].[sp_TaiSanXe_Delete] @ma_xe varchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[tai_san_xe] WHERE [ma_xe] = @ma_xe
END