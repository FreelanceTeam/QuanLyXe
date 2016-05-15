CREATE PROCEDURE [dbo].[sp_PhuTung_Delete] 
	@ma_xe varchar(32)
	,@ma_tai_san nchar(32)
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM [dbo].[x_phu_tung_kem_theo] WHERE [ma_xe] = @ma_xe AND ma_tai_san = @ma_tai_san
END


